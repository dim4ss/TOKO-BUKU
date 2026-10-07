using Kasir_TokoBuku.Pages;
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

namespace Kasir_TokoBuku
{
   
    public partial class Dashboar : Form
    {
        string connectionString = "server=localhost;username=root;password=;database=toko_buku;port=3306;";

        public Dashboar()
        {
            InitializeComponent();
            Loaddasboard();

        }
        public Dashboar(string username, string nama)
        {
            InitializeComponent();
            TampilkanBukuTerlaris();
            InitializeComponent();

            this.Name = nama;

            lblwelcome.Text = "Selamat datang, " + nama;

        }

        private void Loaddasboard()
        {
            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // TOTAL BUKU
                    string queryBuku =
                        "SELECT COUNT(*) FROM books";

                    using (MySqlCommand cmd =
                        new MySqlCommand(queryBuku, conn))
                    {
                        int totalBuku =
                            Convert.ToInt32(cmd.ExecuteScalar());

                        lbljumlah.Text =
                            totalBuku.ToString();
                    }

                    // TOTAL TRANSAKSI
                    string queryTransaksi =
                        "SELECT COUNT(*) FROM transactions";

                    using (MySqlCommand cmd =
                        new MySqlCommand(queryTransaksi, conn))
                    {
                        int totalTransaksi =
                            Convert.ToInt32(cmd.ExecuteScalar());

                        lbltransaksi.Text =
                            totalTransaksi.ToString();
                    }

                    // TRANSAKSI HARI INI
                    string queryHariIni = @"
                SELECT COUNT(*)
                FROM transactions
                WHERE DATE(tanggal) = CURDATE()";

                    using (MySqlCommand cmd =
                        new MySqlCommand(queryHariIni, conn))
                    {
                        int transaksiHariIni =
                            Convert.ToInt32(cmd.ExecuteScalar());

                        // Kalau label khusus transaksi hari ini
                        // gunakan label berbeda, misalnya:
                        lbltransaksi.Text =
                            transaksiHariIni.ToString();
                    }

                    // PENDAPATAN HARI INI
                    string queryPendapatan = @"
                SELECT COALESCE(SUM(total_harga), 0)
                FROM transactions
                WHERE DATE(tanggal) = CURDATE()";

                    using (MySqlCommand cmd =
                        new MySqlCommand(queryPendapatan, conn))
                    {
                        decimal pendapatan =
                            Convert.ToDecimal(cmd.ExecuteScalar());

                        lbljumlah.Text =
                            "Rp " + pendapatan.ToString("N0");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal mengambil data dashboard:\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dasboard_admin_Load(object sender, EventArgs e)
        {
            Loaddasboard();
        }


        private void TampilkanBukuTerlaris()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT
                            b.judul,
                            SUM(td.jumlah) AS total_terjual
                        FROM transaction_details AS td
                        INNER JOIN books AS b
                            ON td.id_buku = b.id_buku
                        GROUP BY
                            b.id_buku,
                            b.judul
                        ORDER BY
                            total_terjual DESC
                        LIMIT 7;
                    ";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader =
                            cmd.ExecuteReader())
                        {
                            // INI ADALAH NAMA CHART KAMU
                            chart1.Series.Clear();

                            Series series =
                                new Series("Buku Terlaris");

                            series.ChartType =
                                SeriesChartType.Column;

                            series.IsValueShownAsLabel = true;

                            while (reader.Read())
                            {
                                string judul = reader["judul_buku"].ToString();

                                int jumlah =
                                    Convert.ToInt32(
                                        reader["total_terjual"]);

                                series.Points.AddXY(judul, jumlah);
                            }

                            chart1.Series.Add(series);

                            chart1.ChartAreas[0]
                                .AxisX.Title = "Buku";

                            chart1.ChartAreas[0]
                                .AxisY.Title = "Jumlah Terjual";

                            chart1.ChartAreas[0]
                                .AxisX.Interval = 1;

                            chart1.ChartAreas[0]
                                .AxisX.LabelStyle.Angle = -45;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Gagal memuat chart: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ManagementBuku pindah2 = new ManagementBuku();
            pindah2.FormClosed += Pindah2_FormClosed;
            pindah2.Show();
            this.Hide();
        }

        private void Pindah2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void butms_Click(object sender, EventArgs e)
        {
            ManagementStock pindah3 = new ManagementStock();
            pindah3.FormClosed += Pindah3_FormClosed;
            pindah3.Show();
            this.Hide();
        }

        private void Pindah3_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
