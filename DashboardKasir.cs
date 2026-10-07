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
    public partial class DashboardKasir : Form
    {
        string connectionString = "server=localhost;username=root;password=;database=toko_buku;port=3306;";
        public DashboardKasir()
        {
            InitializeComponent();

            //tampilandasboar();
            TampilkanBukuTerlaris();    
        }
        public DashboardKasir(string username, string nama)
        {
            InitializeComponent();
           
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //LoadDashboard();
            TampilkanBukuTerlaris();
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
                    judul_buku,
                    SUM(dt.jumlah) AS total_terjual
                FROM transaction_details dt
                INNER JOIN books 
                    ON id_buku = id_buku
                GROUP BY id_buku, judul_buku
                ORDER BY total_terjual DESC
                LIMIT 10";

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

                                series.Points.AddXY(judul,jumlah);
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
    }
}
