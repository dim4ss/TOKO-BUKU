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
        string konfigurasi = "server=localhost;username=root;password=;database=toko_buku;port=3306;";
        public Form1()
        {
            InitializeComponent();
            txtpw.UseSystemPasswordChar = true;
            cmd.Items.Add("admin");
            cmd.Items.Add("user");
            cmd.SelectedIndex = 1;



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtuser.Text.Trim();
            string password = txtpw.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Username dan password harus diisi!");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(konfigurasi))
                {
                    conn.Open();

                    string query = @"
                        SELECT username, nama, role
                        FROM users
                        WHERE username = @username
                        AND password = @password
                        LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string nama = reader["nama"].ToString();
                                string role = reader["role"].ToString();

                                // Jika ADMIN
                                if (role.ToLower() == "admin")
                                {
                                    Dashboar admin=
                                        new Dashboar (username, nama);

                                    admin.Show();
                                    this.Hide();
                                }

                                // Jika USER
                                else if (role.ToLower() == "user")
                                {
                                    DashboardKasir user =
                                        new DashboardKasir (username, nama);

                                    user.Show();
                                    this.Hide();
                                }

                                else
                                {
                                    MessageBox.Show("Role tidak dikenali!");
                                }
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Username atau password salah!",
                                    "Login Gagal",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Terjadi kesalahan:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

