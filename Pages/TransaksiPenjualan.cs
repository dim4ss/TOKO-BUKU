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
        private PrintDocument printDocument1 = new PrintDocument();
        string connectionString = "server=localhost;database=kasir_buku;uid=root;pwd=;port=3306;";
        string strukId = "";
        string strukJudul = "";
        string strukJumlah = "";
        string strukHarga = "";
        string strukSubtotal = "";
        string strukDiskon = "";
        string strukKembalian = "";
        string strukTotal = "";
        string strukBayar = "";
        private DataTable tabelKeranjang;

        MySqlConnection conn;
        public TransaksiPenjualan()
        {
            InitializeComponent();

            conn = new MySqlConnection(connectionString);

            this.Load += TransaksiPenjualan_Load;

            databuku.CellDoubleClick += dataGridView2_DoubleClick;


            txtbayar.TextChanged += txtBayar_TextChanged;
            printDocument1.PrintPage += printDocument_PrintPage;



        }

        private void TransaksiPenjualan_Load(object sender, EventArgs e)
        {
            TampilkanBuku();
            BuatKeranjang();

            HitungTotalKeranjang();
            datakeranjang.AllowUserToAddRows = false;
            datakeranjang.AllowUserToDeleteRows = false;
            datakeranjang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datakeranjang.MultiSelect = false;
            datakeranjang.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;

            datakeranjang.CellEndEdit += dataKeranjang_CellEndEdit;

            txtkembalian.ReadOnly = true;


        }


        private void BuatKeranjang()
        {
            tabelKeranjang = new DataTable();

            tabelKeranjang.Columns.Add("id_buku", typeof(int));
            tabelKeranjang.Columns.Add("kode_buku", typeof(string));
            tabelKeranjang.Columns.Add("judul", typeof(string));
            tabelKeranjang.Columns.Add("harga", typeof(decimal));
            tabelKeranjang.Columns.Add("jumlah", typeof(int));
            tabelKeranjang.Columns.Add("diskon", typeof(decimal));
            tabelKeranjang.Columns.Add("subtotal", typeof(decimal));

            datakeranjang.DataSource = tabelKeranjang;

            datakeranjang.AllowUserToAddRows = false;
            datakeranjang.AllowUserToDeleteRows = false;
            datakeranjang.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            datakeranjang.MultiSelect = false;
            datakeranjang.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            datakeranjang.Columns["id_buku"].Visible = false;

            // Semua kolom tidak bisa diedit kecuali jumlah
            datakeranjang.ReadOnly = false;

            datakeranjang.Columns["kode_buku"].ReadOnly = true;
            datakeranjang.Columns["judul"].ReadOnly = true;
            datakeranjang.Columns["harga"].ReadOnly = true;
            datakeranjang.Columns["jumlah"].ReadOnly = false;
            datakeranjang.Columns["diskon"].ReadOnly = true;
            datakeranjang.Columns["subtotal"].ReadOnly = true;

            datakeranjang.Columns["kode_buku"].HeaderText = "Kode Buku";
            datakeranjang.Columns["judul"].HeaderText = "Judul";
            datakeranjang.Columns["harga"].HeaderText = "Harga";
            datakeranjang.Columns["jumlah"].HeaderText = "Jumlah";
            datakeranjang.Columns["diskon"].HeaderText = "Diskon (%)";
            datakeranjang.Columns["subtotal"].HeaderText = "Subtotal";
        }


        private void TampilkanBuku(string kataKunci = "")
        {
            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                SELECT
                    id_buku,
                    kode_buku,
                    judul,
                    pengarang,
                    penerbit,
                    harga,
                    stok,
                    diskon
                FROM books
                WHERE judul LIKE @cari
                   OR kode_buku LIKE @cari
                ORDER BY id_buku DESC";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@cari", "%" + kataKunci + "%");

                        using (MySqlDataAdapter adapter =
                            new MySqlDataAdapter(cmd))
                        {
                            DataTable dataBuku = new DataTable();
                            adapter.Fill(dataBuku);
                            databuku.DataSource = dataBuku;
                        }
                    }
                }

                databuku.ReadOnly = true;
                databuku.AllowUserToAddRows = false;
                databuku.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                databuku.MultiSelect = false;
                databuku.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                if (databuku.Columns.Contains("id_buku"))
                    databuku.Columns["id_buku"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menampilkan buku: " + ex.Message,
                    "Kesalahan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }



        private decimal HitungTotalKeranjang()
        {
            decimal total = 0;

            foreach (DataRow item in tabelKeranjang.Rows)
            {
                total += Convert.ToDecimal(item["subtotal"]);
            }

            return total;
        }


        private void dataKeranjang_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string namaKolom = datakeranjang.Columns[e.ColumnIndex].Name;

            // Hanya kolom jumlah yang boleh diedit
            if (namaKolom != "Jumlah")
                return;

            DataGridViewRow row = datakeranjang.Rows[e.RowIndex];

            int jumlah;
            decimal harga = Convert.ToDecimal(row.Cells["Harga"].Value);

            if (!int.TryParse(
                Convert.ToString(row.Cells["Jumlah"].Value), out jumlah)
                || jumlah <= 0)
            {
                MessageBox.Show("Jumlah harus berupa angka lebih dari 0.");
                row.Cells["Jumlah"].Value = 1;
                jumlah = 1;
            }

            // Hitung subtotal berdasarkan harga satuan
            decimal subtotal = harga * jumlah;

            row.Cells["Subtotal"].Value = subtotal;

            // Perbarui total belanja
            HitungTotalBelanja();
        }

        private void HitungTotalBelanja()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in datakeranjang.Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (row.Cells["Subtotal"].Value != null &&
                    row.Cells["Subtotal"].Value != DBNull.Value)
                {
                    total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
                }
            }


            //txtTotal.Text = total.ToString("N0");
        }



        private void dataGridView2_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow baris = databuku.Rows[e.RowIndex];

            int idBuku = Convert.ToInt32(baris.Cells["id_buku"].Value);
            string kodeBuku = Convert.ToString(baris.Cells["kode_buku"].Value);
            string judul = Convert.ToString(baris.Cells["judul"].Value);
            decimal harga = Convert.ToDecimal(baris.Cells["harga"].Value);
            int stok = Convert.ToInt32(baris.Cells["stok"].Value);

            decimal diskon = 0;

            if (baris.Cells["diskon"].Value != DBNull.Value)
                diskon = Convert.ToDecimal(baris.Cells["diskon"].Value);

            if (stok <= 0)
            {
                MessageBox.Show("Stok buku habis.");
                return;
            }

            foreach (DataRow item in tabelKeranjang.Rows)
            {
                if (Convert.ToInt32(item["id_buku"]) == idBuku)
                {
                    int jumlahBaru = Convert.ToInt32(item["jumlah"]) + 1;

                    if (jumlahBaru > stok)
                    {
                        MessageBox.Show("Jumlah melebihi stok tersedia.");
                        return;
                    }

                    item["jumlah"] = jumlahBaru;
                    item["subtotal"] =
                        harga * jumlahBaru * (100 - diskon) / 100;

                    HitungKembalian();
                    return;
                }
            }

            tabelKeranjang.Rows.Add(
                idBuku,
                kodeBuku,
                judul,
                harga,
                1,
                diskon,
                harga * (100 - diskon) / 100
            );

            HitungKembalian();

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

            // Ambil total dari seluruh buku di keranjang
            decimal total = HitungTotalKeranjang();

            if (decimal.TryParse(
                txtbayar.Text.Replace(".", "").Replace(",", ""),
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
            // Pastikan keranjang tidak kosong
            if (datakeranjang.Rows.Count == 0)
            {
                MessageBox.Show("Keranjang masih kosong!");
                return;
            }

            // Validasi nominal pembayaran
            if (!decimal.TryParse(
                txtbayar.Text.Replace(".", "").Replace(",", ""),
                out decimal bayar))
            {
                MessageBox.Show("Nominal pembayaran tidak valid!");
                return;
            }

            PrintPreviewDialog preview = new PrintPreviewDialog();

            preview.Document = printDocument1;

            preview.ShowDialog();

            // Hitung total dari seluruh isi keranjang
            decimal total = 0;

            foreach (DataGridViewRow baris in datakeranjang.Rows)
            {
                if (baris.IsNewRow)
                    continue;

                if (baris.Cells["subtotal"].Value != null)
                {
                    total += Convert.ToDecimal(
                        baris.Cells["subtotal"].Value);
                }
            }

            // Validasi uang pembayaran
            if (bayar < total)
            {
                MessageBox.Show("Uang pembayaran kurang!");
                return;
            }

            // Hitung kembalian
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

        private void butms_Click(object sender, EventArgs e)
        {
            ManagementStock pindah1 = new ManagementStock();
            pindah1.FormClosed += Pindah1_FormClosed;
            pindah1.Show();
            this.Hide();
        }

        private void Pindah1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void butmb_Click(object sender, EventArgs e)
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

        private void butlp_Click(object sender, EventArgs e)
        {
            LaporanPenjualan pindah3 = new LaporanPenjualan();
            pindah3.FormClosed += Pindah3_FormClosed;
            pindah3.Show();
            this.Hide();
        }

        private void Pindah3_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void databuku_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (datakeranjang.Columns[e.ColumnIndex].Name != "jumlah")
                return;

            DataGridViewRow row = datakeranjang.Rows[e.RowIndex];

            int jumlah;
            int idBuku = Convert.ToInt32(row.Cells["id_buku"].Value);

            if (!int.TryParse(
                Convert.ToString(row.Cells["jumlah"].Value), out jumlah)
                || jumlah <= 0)
            {
                MessageBox.Show("Jumlah harus berupa angka lebih dari 0.");
                jumlah = 1;
            }

            try
            {
                using (MySqlConnection koneksi =
                    new MySqlConnection(connectionString))
                {
                    koneksi.Open();

                    string query =
                        "SELECT stok FROM books WHERE id_buku = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, koneksi))
                    {
                        cmd.Parameters.AddWithValue("@id", idBuku);

                        object hasil = cmd.ExecuteScalar();

                        if (hasil == null || hasil == DBNull.Value)
                        {
                            MessageBox.Show("Buku tidak ditemukan.");
                            return;
                        }

                        int stok = Convert.ToInt32(hasil);

                        if (jumlah > stok)
                        {
                            MessageBox.Show(
                                "Jumlah melebihi stok tersedia: " + stok);

                            jumlah = stok;
                        }

                        if (jumlah <= 0)
                        {
                            MessageBox.Show("Stok buku habis.");
                            return;
                        }
                    }
                }

                decimal harga = Convert.ToDecimal(row.Cells["harga"].Value);
                decimal diskon = Convert.ToDecimal(row.Cells["diskon"].Value);

                decimal subtotal =
                    harga * jumlah * (100 - diskon) / 100;

                row.Cells["jumlah"].Value = jumlah;
                row.Cells["subtotal"].Value = subtotal;

                tabelKeranjang.AcceptChanges();

                HitungKembalian();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memperbarui jumlah: " + ex.Message);
            }
        }
    }
}
