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
        private DataTable dataStock;
        public ManagementStock()
        {
            InitializeComponent();
            string koneksi ="server=localhost;database=kasir_buku;uid=root;pwd=;";

            txtcodebuku.Clear();
            txtjudulbuku.Clear();
            txtjumlahbukunew.Clear();
            txtstoksaatini.Clear();
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
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Dashboar pindah1 = new Dashboar();
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
            ManagementBuku pindah4 = new ManagementBuku();
            pindah4.FormClosed += Pindah4_FormClosed;
            pindah4.Show();
            this.Hide();
        }

        private void Pindah4_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void ManagementStock_Load_1(object sender, EventArgs e)
        {

        }

        private void btncari_Click(object sender, EventArgs e)
        {
            string keyword = txtCari.Text.Trim();

            // Sesuaikan nama database dengan database XAMPP kamu
            string koneksi = "server=localhost;database=kasir_buku;uid=root;pwd=;";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(koneksi))
                {
                    conn.Open();

                    string query = @"
                SELECT *
                FROM buku
                WHERE kode_buku LIKE @cari
                   OR judul_buku LIKE @cari";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@cari", "%" + keyword + "%");

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dataGridView1.DataSource = dt;

                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("Buku tidak ditemukan!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pencarian gagal: " + ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string koneksi =
       "server=localhost;database=kasir_buku;uid=root;pwd=;";

            string kode = txtcodebuku.Text.Trim();
            string judul = txtjudulbuku.Text.Trim();

            int jumlahBaru;

            if (kode == "" || judul == "")
            {
                MessageBox.Show("Kode dan judul buku wajib diisi!");
                return;
            }

            if (!int.TryParse(txtjumlahbukunew.Text, out jumlahBaru)
                || jumlahBaru <= 0)
            {
                MessageBox.Show("Jumlah buku harus berupa angka positif!");
                return;
            }

            try
            {
                using (MySqlConnection conn =
                       new MySqlConnection(koneksi))
                {
                    conn.Open();

                    string query = @"
                UPDATE buku
                SET stok = stok + @jumlah
                WHERE kode_buku = @kode";

                    using (MySqlCommand cmd =
                           new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@jumlah", jumlahBaru);
                        cmd.Parameters.AddWithValue("@kode", kode);

                        int hasil = cmd.ExecuteNonQuery();

                        if (hasil > 0)
                        {
                            MessageBox.Show(
                                "Stock buku berhasil ditambahkan!"
                            );

                            txtcodebuku.Clear();
                            txtjudulbuku.Clear();
                            txtstoksaatini.Clear();
                            txtjumlahbukunew.Clear();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Kode buku tidak ditemukan di database!"
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menambah stock: " + ex.Message
                );
            }
        }
    }
}

