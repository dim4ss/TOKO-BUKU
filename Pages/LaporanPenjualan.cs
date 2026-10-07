using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Kasir_TokoBuku.Pages
{
    public partial class LaporanPenjualan : Form
    {
      private static string connectionString =
        "Server=localhost;" +
        "Database=toko_buku;" +
        "Uid=root;" +
        "Pwd=;";

            public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public LaporanPenjualan()
        {
            InitializeComponent();
            
            // Tanggal hari ini
            dateTimePicker1.Value = DateTime.Now;

            // Tampilkan data
            TampilkanSemuaData();

            comboBox1.Items.Clear();
            comboBox1.Items.Add("Harian");
            comboBox1.Items.Add("Bulanan");

            // Default
            comboBox1.SelectedIndex = 0;

        }

        private void dtpTanggal_ValueChanged(
            object sender,
            EventArgs e)
        {
            TampilkanSemuaData();
        }

        private void TampilkanSemuaData()
        {
            TampilkanChartBukuTerlaris();
            TampilkanTotalPenjualan();
            TampilkanJumlahTransaksi();
        }

        private void TampilkanTotalPenjualan()
        {
            try
            {
                string filter =
                    comboBox1.SelectedItem.ToString();

                DateTime tanggal =
                    dateTimePicker1.Value;

                using (MySqlConnection conn =
                    database.GetConnection())
                {
                    conn.Open();

                    string query;

                    if (filter == "Harian")
                    {
                        query = @"
                            SELECT
                                COALESCE(
                                    SUM(
                                        dt.jumlah *
                                        dt.harga
                                    ), 0
                                ) AS total
                            FROM transaction_details dt

                            INNER JOIN transaction t
                                ON dt.id_transaksi =
                                   t.id_transaksi

                            WHERE DATE(t.tanggal)
                                = @tanggal";
                    }
                    else
                    {
                        query = @"
                            SELECT
                                COALESCE(
                                    SUM(
                                        dt.jumlah *
                                        dt.harga
                                    ), 0
                                ) AS total
                            FROM transaction_details dt

                            INNER JOIN transactions t
                                ON dt.id_transaksi =
                                   t.id_transaksi

                            WHERE YEAR(t.tanggal)
                                = @tahun

                            AND MONTH(t.tanggal)
                                = @bulan";
                    }

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, conn))
                    {
                        if (filter == "Harian")
                        {
                            cmd.Parameters.AddWithValue(
                                "@tanggal",
                                tanggal.ToString("yyyy-MM-dd"));
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(
                                "@tahun",
                                tanggal.Year);

                            cmd.Parameters.AddWithValue(
                                "@bulan",
                                tanggal.Month);
                        }

                        object hasil =
                            cmd.ExecuteScalar();

                        decimal total = 0;

                        if (hasil != null &&
                            hasil != DBNull.Value)
                        {
                            total =
                                Convert.ToDecimal(hasil);
                        }

                        lbltotal.Text =
                            "Rp " +
                            total.ToString("N0");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menghitung total penjualan:\n"
                    + ex.Message);
            }
        }

        private void TampilkanJumlahTransaksi()
        {
            try
            {
                string filter =
                    comboBox1.SelectedItem.ToString();

                DateTime tanggal =
                    dateTimePicker1.Value;

                using (MySqlConnection conn =
                    database.GetConnection())
                {
                    conn.Open();

                    string query;

                    if (filter == "Harian")
                    {
                        query = @"
                            SELECT COUNT(*)
                            FROM transactions
                            WHERE DATE(tanggal)
                                = @tanggal";
                    }
                    else
                    {
                        query = @"
                            SELECT COUNT(*)
                            FROM transactions
                            WHERE YEAR(tanggal)
                                = @tahun

                            AND MONTH(tanggal)
                                = @bulan";
                    }

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, conn))
                    {
                        if (filter == "Harian")
                        {
                            cmd.Parameters.AddWithValue(
                                "@tanggal",
                                tanggal.ToString("yyyy-MM-dd"));
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(
                                "@tahun",
                                tanggal.Year);

                            cmd.Parameters.AddWithValue(
                                "@bulan",
                                tanggal.Month);
                        }

                        int jumlah =
                            Convert.ToInt32(
                                cmd.ExecuteScalar());

                        lbljumlah.Text =
                            jumlah.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menghitung transaksi:\n"
                    + ex.Message);
            }
        }
    


private void TampilkanChartBukuTerlaris()
        {
            try
            {
                chart1.Series.Clear();
                chart1.ChartAreas.Clear();

                // Chart Area
                ChartArea area = new ChartArea("Area");

                area.AxisX.Title = "Buku";
                area.AxisY.Title = "Jumlah Terjual";

                area.AxisX.Interval = 1;

                area.AxisX.LabelStyle.Angle = -45;

                area.AxisY.MajorGrid.LineColor =
                    Color.LightGray;

                chart1.ChartAreas.Add(area);

                // Series
                Series series =
                    new Series("Buku Terjual");

                series.ChartType =
                    SeriesChartType.Column;

                series.Color =
                    Color.Orange;

                series.IsValueShownAsLabel = true;

                string filter =
                    comboBox1.SelectedItem.ToString();

                DateTime tanggal =
                    dateTimePicker1.Value;

                using (MySqlConnection conn =
                    database.GetConnection())
                {
                    conn.Open();

                    string query;

                    if (filter == "Harian")
                    {
                        query = @"
                            SELECT
                                b.judul,
                                SUM(dt.jumlah) AS total_terjual
                            FROM transaction_details dt

                            INNER JOIN transactions t
                                ON dt.id_transaksi =
                                   t.id_transaksi

                            INNER JOIN books b
                                ON dt.id_buku =
                                   b.id_buku

                            WHERE DATE(t.tanggal) = @tanggal

                            GROUP BY
                                b.id_buku,
                                b.judul

                            ORDER BY
                                total_terjual DESC

                            LIMIT 10";
                    }
                    else
                    {
                        query = @"
                            SELECT
                                b.judul,
                                SUM(dt.jumlah) AS total_terjual
                            FROM transaction_details dt

                            INNER JOIN transactions t
                                ON dt.id_transaksi =
                                   t.id_transaksi

                            INNER JOIN books b
                                ON dt.id_buku =
                                   b.id_buku

                            WHERE YEAR(t.tanggal) = @tahun
                            AND MONTH(t.tanggal) = @bulan

                            GROUP BY
                                b.id_buku,
                                b.judul

                            ORDER BY
                                total_terjual DESC

                            LIMIT 10";
                    }

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, conn))
                    {
                        if (filter == "Harian")
                        {
                            cmd.Parameters.AddWithValue(
                                "@tanggal",
                                tanggal.ToString("yyyy-MM-dd"));
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(
                                "@tahun",
                                tanggal.Year);

                            cmd.Parameters.AddWithValue(
                                "@bulan",
                                tanggal.Month);
                        }

                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string judul =
                                    reader["judul"]
                                    .ToString();

                                int jumlah =
                                    Convert.ToInt32(
                                        reader["total_terjual"]);

                                series.Points.AddXY(
                                    judul,
                                    jumlah);
                            }
                        }
                    }
                }

                chart1.Series.Add(series);

                chart1.Titles.Clear();

                chart1.Titles.Add(
                    "Buku Terlaris"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menampilkan chart:\n"
                    + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

       


        private void LaporanPenjualan_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Dashboar pindah = new Dashboar();
            pindah.FormClosed += Pindah_FormClosed;
            pindah.Show();
            this.Hide();
        }

        private void Pindah_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            LaporanPenjualan pindah2 = new LaporanPenjualan();
            pindah2.FormClosed += Pindah_FormClosed;
            pindah2.Show();
            this.Hide();
        }

        private void butmb_Click(object sender, EventArgs e)
        {
            ManagementBuku pindah3 = new ManagementBuku();
            pindah3.FormClosed += Pindah3_FormClosed;
            pindah3.Show();
            this.Hide();
        }

        private void Pindah3_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void butlp_Click(object sender, EventArgs e)
        {
            LaporanPenjualan pindah4 = new LaporanPenjualan();
            pindah4.FormClosed += Pindah4_FormClosed;
            pindah4.Show();
            this.Hide();
        }

        private void Pindah4_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
