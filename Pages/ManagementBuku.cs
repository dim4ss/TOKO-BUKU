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
    
    public partial class ManagementBuku : Form
    {
        string konfigurasi =
         "server=localhost;" +
         "username=root;" +
         "password=;" +
         "database=kasir_buku;" +
         "port=3306;";
        public ManagementBuku()
        {
            InitializeComponent();
            AturDataGridView();
            LoadDataBuku();

            // Event untuk menyimpan perubahan DataGridView
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
        }
        

        private void AturDataGridView()
        {
            dataGridView1.AutoGenerateColumns = true;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.MultiSelect = false;

            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.EditMode =
                DataGridViewEditMode.EditOnKeystrokeOrF2;
        }



        private void LoadDataBuku(string pencarian = "")
        {
            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(konfigurasi))
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
                            stok
                        FROM books
                        WHERE kode_buku LIKE @cari
                           OR judul LIKE @cari
                           OR pengarang LIKE @cari
                        ORDER BY id_buku DESC;";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@cari",
                            "%" + pencarian + "%"
                        );

                        MySqlDataAdapter adapter =
                            new MySqlDataAdapter(cmd);

                        DataTable table = new DataTable();

                        adapter.Fill(table);

                        dataGridView1.DataSource = table;
                    }
                }

                AturKolomGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal mengambil data buku:\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void AturKolomGrid()
        {
            if (dataGridView1.Columns.Count == 0)
                return;

            // ID disembunyikan
            dataGridView1.Columns["id_buku"].Visible = false;

            dataGridView1.Columns["kode_buku"].HeaderText =
                "Kode Buku";

            dataGridView1.Columns["judul"].HeaderText =
                "Judul";

            dataGridView1.Columns["pengarang"].HeaderText =
                "Pengarang";

            dataGridView1.Columns["penerbit"].HeaderText =
                "Penerbit";

            dataGridView1.Columns["harga"].HeaderText =
                "Harga";

            dataGridView1.Columns["stok"].HeaderText =
                "Stok";

            // Kode buku tidak boleh diubah
            dataGridView1.Columns["kode_buku"].ReadOnly = true;

            // ID juga tidak boleh diubah
            dataGridView1.Columns["id_buku"].ReadOnly = true;
        }


        private void ManagementBuku_Load(object sender, EventArgs e)
        {

        }

        private void btntambah_Click(object sender, EventArgs e)
        {
            string kode = txtcoda.Text.Trim();
            string judul = txtjdl.Text.Trim();
            string pengarang = txtpngrng.Text.Trim();
            string penerbit = txtpnrbt.Text.Trim();

            if (kode == "" ||
                judul == "" ||
                pengarang == "" ||
                penerbit == "" ||
                txtharga.Text.Trim() == "" ||
                txtstok.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Semua data buku harus diisi!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            decimal harga;

            if (!decimal.TryParse(
                txtharga.Text,
                out harga))
            {
                MessageBox.Show(
                    "Harga harus berupa angka!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtharga.Focus();
                return;
            }

            int stok;

            if (!int.TryParse(
                txtstok.Text,
                out stok))
            {
                MessageBox.Show(
                    "Stok harus berupa angka!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtstok.Focus();
                return;
            }

            if (stok < 0)
            {
                MessageBox.Show(
                    "Stok tidak boleh negatif!"
                );

                return;
            }

            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(konfigurasi))
                {
                    conn.Open();

                    // Cek kode buku
                    string cek = @"
                        SELECT COUNT(*)
                        FROM books
                        WHERE kode_buku = @kode";

                    using (MySqlCommand cmdCek =
                        new MySqlCommand(cek, conn))
                    {
                        cmdCek.Parameters.AddWithValue(
                            "@kode",
                            kode
                        );

                        int jumlah =
                            Convert.ToInt32(
                                cmdCek.ExecuteScalar()
                            );

                        if (jumlah > 0)
                        {
                            MessageBox.Show(
                                "Kode buku sudah digunakan!",
                                "Peringatan",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );

                            txtcoda.Focus();

                            return;
                        }
                    }

                    // INSERT
                    string query = @"
                        INSERT INTO books
                        (
                            kode_buku,
                            judul,
                            pengarang,
                            penerbit,
                            harga,
                            stok
                        )
                        VALUES
                        (
                            @kode,
                            @judul,
                            @pengarang,
                            @penerbit,
                            @harga,
                            @stok
                        );";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@kode",
                            kode
                        );

                        cmd.Parameters.AddWithValue(
                            "@judul",
                            judul
                        );

                        cmd.Parameters.AddWithValue(
                            "@pengarang",
                            pengarang
                        );

                        cmd.Parameters.AddWithValue(
                            "@penerbit",
                            penerbit
                        );

                        cmd.Parameters.AddWithValue(
                            "@harga",
                            harga
                        );

                        cmd.Parameters.AddWithValue(
                            "@stok",
                            stok
                        );

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Buku berhasil ditambahkan!",
                    "Berhasil",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                BersihkanInput();

                LoadDataBuku();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menambahkan buku:\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void BersihkanInput()
        {
            txtcoda.Clear();
            txtharga.Clear();
            txtjdl.Clear();
            txtpngrng.Clear();
            txtpnrbt.Clear();
            txtstok.Clear();

            txtcoda.Focus();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtcari_TextChanged(object sender, EventArgs e)
        {
            LoadDataBuku(txtcari.Text.Trim());
        }

        private void btnref_Click(object sender, EventArgs e)
        {
            txtcari.Clear();

            LoadDataBuku();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
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
            TransaksiPenjualan pindah2 = new TransaksiPenjualan();
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
            ManagementStock pindah1 = new ManagementStock();
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
            LaporanPenjualan pindah3 = new LaporanPenjualan();
            pindah3.FormClosed += Pindah3_FormClosed;
            pindah3.Show();
            this.Hide();
        }

        private void Pindah3_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                // Ambil ID buku dari baris yang diedit
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                int idBuku = Convert.ToInt32(row.Cells["id_buku"].Value);
                string judul = Convert.ToString(row.Cells["judul"].Value);
                string pengarang = Convert.ToString(row.Cells["pengarang"].Value);
                string penerbit = Convert.ToString(row.Cells["penerbit"].Value);

                decimal harga;
                int stok;

                if (!decimal.TryParse(
                    Convert.ToString(row.Cells["harga"].Value), out harga))
                {
                    MessageBox.Show("Harga harus berupa angka!");
                    LoadDataBuku();
                    return;
                }

                if (!int.TryParse(
                    Convert.ToString(row.Cells["stok"].Value), out stok) || stok < 0)
                {
                    MessageBox.Show("Stok harus berupa angka dan tidak boleh negatif!");
                    LoadDataBuku();
                    return;
                }

                string query = @"
            UPDATE books
            SET judul = @judul,
                pengarang = @pengarang,
                penerbit = @penerbit,
                harga = @harga,
                stok = @stok
            WHERE id_buku = @id";

                using (MySqlConnection conn = new MySqlConnection(konfigurasi))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@judul", judul);
                        cmd.Parameters.AddWithValue("@pengarang", pengarang);
                        cmd.Parameters.AddWithValue("@penerbit", penerbit);
                        cmd.Parameters.AddWithValue("@harga", harga);
                        cmd.Parameters.AddWithValue("@stok", stok);
                        cmd.Parameters.AddWithValue("@id", idBuku);

                        int hasil = cmd.ExecuteNonQuery();

                        if (hasil > 0)
                        {
                            MessageBox.Show(
                                "Data buku berhasil diperbarui!",
                                "Berhasil",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                }

                LoadDataBuku(txtcari.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memperbarui data buku:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                LoadDataBuku(txtcari.Text.Trim());
            }
        }

        private void btnhps_Click(object sender, EventArgs e)
        {
            // Pastikan ada baris yang dipilih
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Pilih buku yang ingin dihapus!");
                return;
            }

            // Ambil ID buku dari baris terpilih
            object nilaiID = dataGridView1.CurrentRow.Cells["id_buku"].Value;

            if (nilaiID == null || nilaiID == DBNull.Value)
            {
                MessageBox.Show("ID buku tidak ditemukan!");
                return;
            }

            int idBuku = Convert.ToInt32(nilaiID);

            // Konfirmasi penghapusan
            DialogResult konfirmasi = MessageBox.Show(
                "Apakah kamu yakin ingin menghapus buku ini?",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (konfirmasi != DialogResult.Yes)
                return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(konfigurasi))
                {
                    conn.Open();

                    string query = "DELETE FROM books WHERE id_buku = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idBuku);

                        int hasil = cmd.ExecuteNonQuery();

                        if (hasil > 0)
                        {
                            MessageBox.Show(
                                "Buku berhasil dihapus dari database!",
                                "Berhasil",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                        else
                        {
                            MessageBox.Show("Data buku tidak ditemukan.");
                        }
                    }
                }

                // Muat ulang data dari database
                LoadDataBuku(txtcari.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menghapus buku:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}

