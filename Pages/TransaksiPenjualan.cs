using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kasir_TokoBuku.Pages
{
    public partial class TransaksiPenjualan : Form
    {
        string koneksi = "server=localhost;database=toko_buku;uid=root;pwd=;port=3306;";
        string strukId = "";
        string strukJudul = "";
        string strukJumlah = "";
        string strukHarga = "";
        string strukSubtotal = "";
        string strukDiskon = "";
        string strukKembalian = "";
        string strukTotal = "";
        string strukBayar = "";

        MySqlConnection conn;
        public TransaksiPenjualan()
        {
            InitializeComponent();
            
            conn = new MySqlConnection(koneksi);

            this.Load += TransaksiPenjualan_Load;

            dataGridView2.CellDoubleClick += dataGridView2_DoubleClick;

            txtjumlah.TextChanged += txtJumlah_TextChanged;
            txtbayar.TextChanged += txtBayar_TextChanged;
            
        
        }

        private void TransaksiPenjualan_Load(object sender, EventArgs e)
        {
            TampilBuku();

            txtkembalian.ReadOnly = true;
            txtsub.ReadOnly = true;

            
        }

        private void TampilBuku()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(koneksi))
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    id_buku AS 'ID Buku',
                    judul AS 'Judul',
                    penulis AS 'Penulis',
                    penerbit AS 'Penerbit',
                    harga AS 'Harga',
                    stok AS 'Stok'
                FROM books
                ORDER BY id_buku DESC
            ";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();

                    adapter.Fill(dt);

                    dataGridView2.DataSource = dt;

                    dataGridView2.AutoSizeColumnsMode =
                        DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal mengambil data buku!\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow == null)
                return;

            DataGridViewRow row = dataGridView2.CurrentRow;

            txtid.Text = row.Cells["ID Buku"].Value?.ToString();
            txtjudul.Text = row.Cells["Judul"].Value?.ToString();
            txtharga.Text = row.Cells["Harga"].Value?.ToString();

            txtjumlah.Text = "1";

            HitungSubtotal();
        }
        private void txtJumlah_TextChanged(object sender, EventArgs e)
        {
            HitungSubtotal();
        }

        private void HitungSubtotal()
        {
            decimal harga;
            int jumlah;

            if (decimal.TryParse(txtharga.Text, out harga) &&
                int.TryParse(txtjumlah.Text, out jumlah))
            {
                decimal subtotal = harga * jumlah;

                txtsub.Text = subtotal.ToString("N0");
            }
            else
            {
                txtsub.Text = "0";
            }


        }

        private void txtBayar_TextChanged(object sender, EventArgs e)
        {
            HitungKembalian();
        }

        private void txtDiskon_TextChanged(object sender, EventArgs e)
        {
            HitungKembalian();
        }

        private void HitungKembalian()
        {
            decimal bayar;
            decimal total = 0;

            decimal.TryParse(
                txtsub.Text.Replace(".", ""),
                out total);

            if (decimal.TryParse(
                txtbayar.Text.Replace(".", ""),
                out bayar))
            {
                decimal kembalian = bayar - total;

                if (kembalian < 0)
                {
                    txtkembalian.Text = "0";
                }
                else
                {
                    txtkembalian.Text = kembalian.ToString("N0");
                }
            }
            else
            {
                txtkembalian.Text = "0";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtid.Text))
            {
                MessageBox.Show(
                    "Pilih buku terlebih dahulu!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (!int.TryParse(txtjumlah.Text, out int jumlah))
            {
                MessageBox.Show("Jumlah tidak valid!");
                return;
            }

            if (!decimal.TryParse(
                txtbayar.Text.Replace(".", ""),
                out decimal bayar))
            {
                MessageBox.Show("Nominal pembayaran tidak valid!");
                return;
            }

            decimal subtotal =
                decimal.Parse(txtsub.Text.Replace(".", ""));

            decimal diskon = 0;

            decimal.TryParse(
                diskon.ToString().Replace(".", ""),
                out diskon
            );

            decimal total = subtotal - diskon;

            if (total < 0)
                total = 0;

            if (bayar < total)
            {
                MessageBox.Show(
                    "Uang pembayaran kurang!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            decimal kembalian = bayar - total;

            txtkembalian.Text = kembalian.ToString("N0");

           
        }
            private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            Font fontNormal =
                new Font("Consolas", 10);

            Font fontBold =
                new Font("Consolas", 11, FontStyle.Bold);

            Font fontTitle =
                new Font("Consolas", 14, FontStyle.Bold);

            float y = 20;

            g.DrawString(
                "TOKO BUKU",
                fontTitle,
                Brushes.Black,
                70,
                y
            );

            y += 30;

            g.DrawString(
                "NOTA PENJUALAN",
                fontBold,
                Brushes.Black,
                60,
                y
            );

            y += 30;

            g.DrawString(
                "================================",
                fontNormal,
                Brushes.Black,
                20,
                y
            );

            y += 25;

            g.DrawString(
                "Tanggal : " +
                DateTime.Now.ToString("dd-MM-yyyy HH:mm"),
                fontNormal,
                Brushes.Black,
                20,
                y
            );

            y += 25;

            g.DrawString(
                "ID Buku : " + strukId,
                fontNormal,
                Brushes.Black,
                20,
                y
            );

            y += 30;

            g.DrawString(
                strukJudul,
                fontBold,
                Brushes.Black,
                20,
                y
            );

            y += 25;

            g.DrawString(
                strukJumlah +
                " x " +
                strukHarga,
                fontNormal,
                Brushes.Black,
                20,
                y
            );

            g.DrawString(
                strukSubtotal,
                fontNormal,
                Brushes.Black,
                220,
                y
            );

            y += 30;

            g.DrawString(
                "--------------------------------",
                fontNormal,
                Brushes.Black,
                20,
                y
            );

            y += 25;

            g.DrawString(
                "Subtotal",
                fontNormal,
                Brushes.Black,
                20,
                y
            );

            g.DrawString(
                "Rp " + strukSubtotal,
                fontNormal,
                Brushes.Black,
                180,
                y
            );

            y += 25;

            g.DrawString(
                "Diskon",
                fontNormal,
                Brushes.Black,
                20,
                y
            );

            g.DrawString(
                "Rp " + strukDiskon,
                fontNormal,
                Brushes.Black,
                180,
                y
            );

            y += 25;

            g.DrawString(
                "TOTAL",
                fontBold,
                Brushes.Black,
                20,
                y
            );

            g.DrawString(
                "Rp " + strukTotal,
                fontBold,
                Brushes.Black,
                180,
                y
            );

            y += 30;

            g.DrawString(
                "Bayar",
                fontNormal,
                Brushes.Black,
                20,
                y
            );

            g.DrawString(
                "Rp " + strukBayar,
                fontNormal,
                Brushes.Black,
                180,
                y
            );

            y += 25;

            g.DrawString(
                "Kembalian",
                fontNormal,
                Brushes.Black,
                20,
                y
            );

            g.DrawString(
                "Rp " + strukKembalian,
                fontNormal,
                Brushes.Black,
                180,
                y
            );

            y += 35;

            g.DrawString(
                "================================",
                fontNormal,
                Brushes.Black,
                20,
                y
            );

            y += 30;

            g.DrawString(
                "Terima kasih telah berbelanja",
                fontNormal,
                Brushes.Black,
                35,
                y
            );
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

