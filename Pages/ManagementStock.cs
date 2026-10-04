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
    }
}
