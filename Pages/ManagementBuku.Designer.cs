namespace Kasir_TokoBuku.Pages
{
    partial class ManagementBuku
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.directorySearcher2 = new System.DirectoryServices.DirectorySearcher();
            this.btntambah = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtcoda = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtjdl = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtpngrng = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtpnrbt = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtharga = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtstok = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnhps = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.txtcari = new Guna.UI2.WinForms.Guna2TextBox();
            this.btncari = new System.Windows.Forms.Button();
            this.btnref = new System.Windows.Forms.Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.butlp = new Guna.UI2.WinForms.Guna2Button();
            this.butms = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(246, 12);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(244, 33);
            this.guna2HtmlLabel2.TabIndex = 9;
            this.guna2HtmlLabel2.Text = "Management Buku";
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // directorySearcher2
            // 
            this.directorySearcher2.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher2.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher2.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // btntambah
            // 
            this.btntambah.BackColor = System.Drawing.Color.Blue;
            this.btntambah.ForeColor = System.Drawing.Color.White;
            this.btntambah.Location = new System.Drawing.Point(570, 147);
            this.btntambah.Name = "btntambah";
            this.btntambah.Size = new System.Drawing.Size(198, 38);
            this.btntambah.TabIndex = 29;
            this.btntambah.Text = "Tambah Buku";
            this.btntambah.UseVisualStyleBackColor = false;
            this.btntambah.Click += new System.EventHandler(this.btntambah_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(213, 193);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(555, 254);
            this.dataGridView1.TabIndex = 30;
            // 
            // txtcoda
            // 
            this.txtcoda.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtcoda.DefaultText = "Kode Buku";
            this.txtcoda.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtcoda.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtcoda.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtcoda.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtcoda.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtcoda.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtcoda.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtcoda.Location = new System.Drawing.Point(211, 66);
            this.txtcoda.Name = "txtcoda";
            this.txtcoda.PlaceholderText = "";
            this.txtcoda.SelectedText = "";
            this.txtcoda.Size = new System.Drawing.Size(161, 36);
            this.txtcoda.TabIndex = 32;
            // 
            // txtjdl
            // 
            this.txtjdl.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtjdl.DefaultText = "Judul Buku";
            this.txtjdl.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtjdl.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtjdl.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtjdl.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtjdl.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtjdl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtjdl.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtjdl.Location = new System.Drawing.Point(211, 108);
            this.txtjdl.Name = "txtjdl";
            this.txtjdl.PlaceholderText = "";
            this.txtjdl.SelectedText = "";
            this.txtjdl.Size = new System.Drawing.Size(161, 36);
            this.txtjdl.TabIndex = 33;
            // 
            // txtpngrng
            // 
            this.txtpngrng.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtpngrng.DefaultText = "Pengarang";
            this.txtpngrng.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtpngrng.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtpngrng.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtpngrng.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtpngrng.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtpngrng.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtpngrng.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtpngrng.Location = new System.Drawing.Point(211, 150);
            this.txtpngrng.Name = "txtpngrng";
            this.txtpngrng.PlaceholderText = "";
            this.txtpngrng.SelectedText = "";
            this.txtpngrng.Size = new System.Drawing.Size(161, 36);
            this.txtpngrng.TabIndex = 34;
            // 
            // txtpnrbt
            // 
            this.txtpnrbt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtpnrbt.DefaultText = "Penerbit";
            this.txtpnrbt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtpnrbt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtpnrbt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtpnrbt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtpnrbt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtpnrbt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtpnrbt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtpnrbt.Location = new System.Drawing.Point(394, 66);
            this.txtpnrbt.Name = "txtpnrbt";
            this.txtpnrbt.PlaceholderText = "";
            this.txtpnrbt.SelectedText = "";
            this.txtpnrbt.Size = new System.Drawing.Size(161, 36);
            this.txtpnrbt.TabIndex = 35;
            // 
            // txtharga
            // 
            this.txtharga.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtharga.DefaultText = "Harga";
            this.txtharga.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtharga.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtharga.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtharga.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtharga.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtharga.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtharga.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtharga.Location = new System.Drawing.Point(394, 107);
            this.txtharga.Name = "txtharga";
            this.txtharga.PlaceholderText = "";
            this.txtharga.SelectedText = "";
            this.txtharga.Size = new System.Drawing.Size(161, 36);
            this.txtharga.TabIndex = 36;
            // 
            // txtstok
            // 
            this.txtstok.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtstok.DefaultText = "Stok";
            this.txtstok.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtstok.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtstok.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtstok.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtstok.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtstok.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtstok.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtstok.Location = new System.Drawing.Point(394, 149);
            this.txtstok.Name = "txtstok";
            this.txtstok.PlaceholderText = "";
            this.txtstok.SelectedText = "";
            this.txtstok.Size = new System.Drawing.Size(161, 36);
            this.txtstok.TabIndex = 37;
            // 
            // btnhps
            // 
            this.btnhps.BackColor = System.Drawing.Color.Maroon;
            this.btnhps.ForeColor = System.Drawing.Color.White;
            this.btnhps.Location = new System.Drawing.Point(570, 103);
            this.btnhps.Name = "btnhps";
            this.btnhps.Size = new System.Drawing.Size(96, 38);
            this.btnhps.TabIndex = 38;
            this.btnhps.Text = "Hapus Buku";
            this.btnhps.UseVisualStyleBackColor = false;
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnupdate.ForeColor = System.Drawing.Color.White;
            this.btnupdate.Location = new System.Drawing.Point(672, 103);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(96, 38);
            this.btnupdate.TabIndex = 39;
            this.btnupdate.Text = "Update Buku";
            this.btnupdate.UseVisualStyleBackColor = false;
            // 
            // txtcari
            // 
            this.txtcari.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtcari.DefaultText = "Cari Buku";
            this.txtcari.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtcari.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtcari.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtcari.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtcari.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtcari.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtcari.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtcari.Location = new System.Drawing.Point(570, 12);
            this.txtcari.Name = "txtcari";
            this.txtcari.PlaceholderText = "";
            this.txtcari.SelectedText = "";
            this.txtcari.Size = new System.Drawing.Size(198, 36);
            this.txtcari.TabIndex = 40;
            this.txtcari.TextChanged += new System.EventHandler(this.txtcari_TextChanged);
            // 
            // btncari
            // 
            this.btncari.BackColor = System.Drawing.Color.SlateGray;
            this.btncari.ForeColor = System.Drawing.Color.White;
            this.btncari.Location = new System.Drawing.Point(570, 54);
            this.btncari.Name = "btncari";
            this.btncari.Size = new System.Drawing.Size(96, 38);
            this.btncari.TabIndex = 42;
            this.btncari.Text = "Cari Buku";
            this.btncari.UseVisualStyleBackColor = false;
            // 
            // btnref
            // 
            this.btnref.BackColor = System.Drawing.Color.SlateGray;
            this.btnref.ForeColor = System.Drawing.Color.White;
            this.btnref.Location = new System.Drawing.Point(672, 54);
            this.btnref.Name = "btnref";
            this.btnref.Size = new System.Drawing.Size(96, 38);
            this.btnref.TabIndex = 43;
            this.btnref.Text = "Refresh";
            this.btnref.UseVisualStyleBackColor = false;
            this.btnref.Click += new System.EventHandler(this.btnref_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.DimGray;
            this.guna2Panel1.Controls.Add(this.butlp);
            this.guna2Panel1.Controls.Add(this.butms);
            this.guna2Panel1.Controls.Add(this.guna2Button2);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2Panel1.Controls.Add(this.pictureBox1);
            this.guna2Panel1.Controls.Add(this.guna2Button1);
            this.guna2Panel1.Location = new System.Drawing.Point(-2, -6);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(207, 465);
            this.guna2Panel1.TabIndex = 44;
            // 
            // butlp
            // 
            this.butlp.BorderRadius = 10;
            this.butlp.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.butlp.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.butlp.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.butlp.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.butlp.FillColor = System.Drawing.SystemColors.MenuBar;
            this.butlp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butlp.ForeColor = System.Drawing.Color.Black;
            this.butlp.Location = new System.Drawing.Point(20, 238);
            this.butlp.Name = "butlp";
            this.butlp.Size = new System.Drawing.Size(167, 26);
            this.butlp.TabIndex = 10;
            this.butlp.Text = "Laporan Penjualan";
            this.butlp.Click += new System.EventHandler(this.butlp_Click);
            // 
            // butms
            // 
            this.butms.BorderRadius = 10;
            this.butms.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.butms.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.butms.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.butms.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.butms.FillColor = System.Drawing.SystemColors.MenuBar;
            this.butms.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butms.ForeColor = System.Drawing.Color.Black;
            this.butms.Location = new System.Drawing.Point(20, 193);
            this.butms.Name = "butms";
            this.butms.Size = new System.Drawing.Size(167, 26);
            this.butms.TabIndex = 9;
            this.butms.Text = "Management Stock";
            this.butms.Click += new System.EventHandler(this.butms_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.BorderRadius = 10;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.SystemColors.MenuBar;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button2.ForeColor = System.Drawing.Color.Black;
            this.guna2Button2.Location = new System.Drawing.Point(20, 149);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(167, 26);
            this.guna2Button2.TabIndex = 8;
            this.guna2Button2.Text = "Transaksi Penjualan";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(54, 38);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(115, 27);
            this.guna2HtmlLabel1.TabIndex = 7;
            this.guna2HtmlLabel1.Text = "Toko Buku";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Kasir_TokoBuku.Properties.Resources.download__16__removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(11, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.SystemColors.MenuBar;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.Location = new System.Drawing.Point(20, 106);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(118, 26);
            this.guna2Button1.TabIndex = 0;
            this.guna2Button1.Text = "Dashboard";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click_1);
            // 
            // ManagementBuku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.btnref);
            this.Controls.Add(this.btncari);
            this.Controls.Add(this.txtcari);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.btnhps);
            this.Controls.Add(this.txtstok);
            this.Controls.Add(this.txtharga);
            this.Controls.Add(this.txtpnrbt);
            this.Controls.Add(this.txtpngrng);
            this.Controls.Add(this.txtjdl);
            this.Controls.Add(this.txtcoda);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btntambah);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Name = "ManagementBuku";
            this.Text = "Tambah Buku";
            this.Load += new System.EventHandler(this.ManagementBuku_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.DirectoryServices.DirectorySearcher directorySearcher2;
        private System.Windows.Forms.Button btntambah;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Guna.UI2.WinForms.Guna2TextBox txtcoda;
        private Guna.UI2.WinForms.Guna2TextBox txtjdl;
        private Guna.UI2.WinForms.Guna2TextBox txtpngrng;
        private Guna.UI2.WinForms.Guna2TextBox txtpnrbt;
        private Guna.UI2.WinForms.Guna2TextBox txtharga;
        private Guna.UI2.WinForms.Guna2TextBox txtstok;
        private System.Windows.Forms.Button btnhps;
        private System.Windows.Forms.Button btnupdate;
        private Guna.UI2.WinForms.Guna2TextBox txtcari;
        private System.Windows.Forms.Button btncari;
        private System.Windows.Forms.Button btnref;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button butlp;
        private Guna.UI2.WinForms.Guna2Button butms;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}