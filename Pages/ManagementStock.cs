using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kasir_TokoBuku.Pages
{
    public partial class ManagementStock : Form
    {
        public class Koneksi
        {
            public static MySqlConnection GetConnection()
            {
                string connectionString =
                    "server=localhost;" +
                    "database=toko_buku;" +
                    "uid=root;" +
                    "pwd=;";

                return new MySqlConnection(connectionString);
            }
        }
        public ManagementStock()
        {
            InitializeComponent();
        }
        private void ManagementStock_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("KodeBuku", "Kode Buku");
            dataGridView1.Columns.Add("JudulBuku", "Judul Buku");
            dataGridView1.Columns.Add("StockSaatIni", "Stock Saat Ini");
            dataGridView1.Columns.Add("JumlahBukuBaru", "Jumlah Buku Baru");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(
                guna2TextBox1.Text,
                guna2TextBox2.Text,
                guna2TextBox4.Text,
                guna2TextBox5.Text
            );
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DashboardKasir pindah1 = new DashboardKasir();
            pindah1.FormClosed += Pindah1_FormClosed;
            pindah1.Show();
            this.Hide();
            
        }

        private void Pindah1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void butlp_Click(object sender, EventArgs e)
        {
            LaporanPenjualan pindah2 = new LaporanPenjualan();
            pindah2.FormClosed += Pindah2_FormClosed;
            pindah2.Show();
            this.Hide();
        }

        private void Pindah2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void buttp_Click(object sender, EventArgs e)
        {
            TransaksiPenjualan pindah3 = new TransaksiPenjualan();
            pindah3.FormClosed += Pindah3_FormClosed;
            pindah3.Show();
            this.Hide();
        }

        private void Pindah3_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void butms_Click(object sender, EventArgs e)
        {
            ManagementStock pindah4 = new ManagementStock();
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
