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

namespace Kasir_TokoBuku
{
    public partial class Form1 : Form
    {
        string konfigurasi = "server=localhost;username=root;password=;database=kasir_buku;port=3306;";
        public Form1()
        {
            InitializeComponent();
            txtpw.UseSystemPasswordChar = true;

            // ComboBox role hanya untuk tampilan/pilihan pengguna.
            // Role yang menentukan akses tetap dibaca dari database.
            cmd.Items.Clear();
            cmd.Items.Add("admin");
            cmd.Items.Add("kasir");
            cmd.SelectedIndex = 1;

            txtuser.Text = placeholderUsername;
            txtuser.ForeColor = Color.Gray;

            txtuser.Enter += Txtuser_Enter;
            txtuser.Leave += Txtuser_Leave;

            // Login dengan menekan Enter pada password
            txtpw.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    button1.PerformClick();
                }
            };

            Shown += (s, e) => txtuser.Focus();

        }

        private void Txtuser_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtuser.Text))
            {
                txtuser.Text = placeholderUsername;
                txtuser.ForeColor = Color.Gray;
            }
        }

        private void Txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == placeholderUsername)
            {
                txtuser.Clear();
                txtuser.ForeColor = Color.Black;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtuser.Text.Trim();
            string password = txtpw.Text;

            if (username == placeholderUsername)
                username = "";

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Username dan password harus diisi.",
                    "Login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(konfigurasi))
                {
                    conn.Open();

                    string query = @"
                        SELECT username, nama, role
                        FROM users
                        WHERE username = @username
                          AND password = @password
                        LIMIT 1;";

                    string nama;
                    string role;
                    string usernameDatabase;

                    using (MySqlCommand cmdLogin =
                        new MySqlCommand(query, conn))
                    {
                        cmdLogin.Parameters.AddWithValue(
                            "@username", username);

                        cmdLogin.Parameters.AddWithValue(
                            "@password", password);

                        using (MySqlDataReader reader =
                            cmdLogin.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show(
                                    "Username atau password salah.",
                                    "Login Gagal",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                return;
                            }

                            usernameDatabase =
                                reader["username"].ToString();

                            nama = reader["nama"].ToString();
                            role = reader["role"].ToString()
                                .Trim().ToLowerInvariant();
                        }
                    }

                    // Role dari database menjadi penentu dashboard.
                    Form dashboard;

                    if (role == "admin")
                    {
                        dashboard = new Dashboar(
                            usernameDatabase, nama);
                    }
                    else if (role == "kasir")
                    {
                        dashboard = new DashboardKasir(
                            usernameDatabase, nama);
                    }
                    else
                    {
                        MessageBox.Show(
                            "Role akun tidak dikenali: " + role,
                            "Login Gagal",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    dashboard.StartPosition =
                        FormStartPosition.CenterScreen;

                    // Login ditutup ketika dashboard ditutup.
                    dashboard.FormClosed += (s, args) => this.Close();

                    dashboard.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal melakukan login:\n" + ex.Message,
                    "Kesalahan Database",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private string placeholderUsername = "Username";
        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == placeholderUsername)
            {
                txtuser.Clear();
                txtuser.ForeColor = Color.Black;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtuser.Text))
            {
                txtuser.Text = placeholderUsername;
                txtuser.ForeColor = Color.Gray;
            }
        }
    }
}

