namespace rpcj_conf
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.ch_invmouse = new System.Windows.Forms.CheckBox();
            this.nm_mousesens = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_graphics = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ch_gover = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gfx_pixel = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.gfx_texture = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gfx_aniso = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.gfx_aa = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.gfx_part = new System.Windows.Forms.CheckBox();
            this.gfx_bone = new System.Windows.Forms.ComboBox();
            this.gfx_vsync = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.bt_save = new System.Windows.Forms.Button();
            this.bt_launch = new System.Windows.Forms.Button();
            this.bt_about = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tb_vol = new System.Windows.Forms.TrackBar();
            this.label17 = new System.Windows.Forms.Label();
            this.bt_test = new System.Windows.Forms.Button();
            this.nm_scopesens = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nm_mousesens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gfx_pixel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_vol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_scopesens)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Egyszerű beállítások (billentyű kiosztást a játék indítójában)";
            // 
            // ch_invmouse
            // 
            this.ch_invmouse.AutoSize = true;
            this.ch_invmouse.Location = new System.Drawing.Point(15, 34);
            this.ch_invmouse.Name = "ch_invmouse";
            this.ch_invmouse.Size = new System.Drawing.Size(79, 17);
            this.ch_invmouse.TabIndex = 1;
            this.ch_invmouse.Text = "Inverz egér";
            this.ch_invmouse.UseVisualStyleBackColor = true;
            // 
            // nm_mousesens
            // 
            this.nm_mousesens.Location = new System.Drawing.Point(110, 57);
            this.nm_mousesens.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nm_mousesens.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nm_mousesens.Name = "nm_mousesens";
            this.nm_mousesens.Size = new System.Drawing.Size(48, 20);
            this.nm_mousesens.TabIndex = 2;
            this.nm_mousesens.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Egér érzékenység";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(12, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(297, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Grafikai beállítások (felbontást a játék indítójában)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Grafikai szint";
            // 
            // cb_graphics
            // 
            this.cb_graphics.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_graphics.FormattingEnabled = true;
            this.cb_graphics.Items.AddRange(new object[] {
            "Leggyorsabb",
            "Gyors",
            "Egyszerű",
            "Közepes",
            "Közepes feletti",
            "Magas"});
            this.cb_graphics.Location = new System.Drawing.Point(85, 134);
            this.cb_graphics.Name = "cb_graphics";
            this.cb_graphics.Size = new System.Drawing.Size(96, 21);
            this.cb_graphics.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(12, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Haladó grafikai beállítások";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Megjelenítés";
            // 
            // ch_gover
            // 
            this.ch_gover.AutoSize = true;
            this.ch_gover.Location = new System.Drawing.Point(15, 191);
            this.ch_gover.Name = "ch_gover";
            this.ch_gover.Size = new System.Drawing.Size(146, 17);
            this.ch_gover.TabIndex = 10;
            this.ch_gover.Text = "Grafikai szint felülbírálása";
            this.ch_gover.UseVisualStyleBackColor = true;
            this.ch_gover.CheckedChanged += new System.EventHandler(this.ch_gover_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Pixel fények száma";
            // 
            // gfx_pixel
            // 
            this.gfx_pixel.Location = new System.Drawing.Point(156, 239);
            this.gfx_pixel.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.gfx_pixel.Name = "gfx_pixel";
            this.gfx_pixel.Size = new System.Drawing.Size(42, 20);
            this.gfx_pixel.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 269);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Textúrák minősége";
            // 
            // gfx_texture
            // 
            this.gfx_texture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gfx_texture.FormattingEnabled = true;
            this.gfx_texture.Items.AddRange(new object[] {
            "Alacsony",
            "Közepes",
            "Magas"});
            this.gfx_texture.Location = new System.Drawing.Point(156, 266);
            this.gfx_texture.Name = "gfx_texture";
            this.gfx_texture.Size = new System.Drawing.Size(96, 21);
            this.gfx_texture.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 297);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Anizotróp textúraszűrés";
            // 
            // gfx_aniso
            // 
            this.gfx_aniso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gfx_aniso.FormattingEnabled = true;
            this.gfx_aniso.Items.AddRange(new object[] {
            "Ki",
            "Textúránként",
            "Kényszerített"});
            this.gfx_aniso.Location = new System.Drawing.Point(156, 294);
            this.gfx_aniso.Name = "gfx_aniso";
            this.gfx_aniso.Size = new System.Drawing.Size(96, 21);
            this.gfx_aniso.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 323);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Élsímítás";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 374);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Karakter animáció minősége";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 402);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Függőleges szinkron";
            // 
            // gfx_aa
            // 
            this.gfx_aa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gfx_aa.FormattingEnabled = true;
            this.gfx_aa.Items.AddRange(new object[] {
            "Ki",
            "2x",
            "4x",
            "8x"});
            this.gfx_aa.Location = new System.Drawing.Point(156, 320);
            this.gfx_aa.Name = "gfx_aa";
            this.gfx_aa.Size = new System.Drawing.Size(96, 21);
            this.gfx_aa.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 347);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Finomított részecskék";
            // 
            // gfx_part
            // 
            this.gfx_part.AutoSize = true;
            this.gfx_part.Enabled = false;
            this.gfx_part.Location = new System.Drawing.Point(156, 347);
            this.gfx_part.Name = "gfx_part";
            this.gfx_part.Size = new System.Drawing.Size(15, 14);
            this.gfx_part.TabIndex = 15;
            this.gfx_part.UseVisualStyleBackColor = true;
            // 
            // gfx_bone
            // 
            this.gfx_bone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gfx_bone.FormattingEnabled = true;
            this.gfx_bone.Items.AddRange(new object[] {
            "Alacsony",
            "Közepes",
            "Magas"});
            this.gfx_bone.Location = new System.Drawing.Point(156, 371);
            this.gfx_bone.Name = "gfx_bone";
            this.gfx_bone.Size = new System.Drawing.Size(96, 21);
            this.gfx_bone.TabIndex = 14;
            // 
            // gfx_vsync
            // 
            this.gfx_vsync.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gfx_vsync.FormattingEnabled = true;
            this.gfx_vsync.Items.AddRange(new object[] {
            "Ki",
            "Be",
            "Minden második"});
            this.gfx_vsync.Location = new System.Drawing.Point(156, 399);
            this.gfx_vsync.Name = "gfx_vsync";
            this.gfx_vsync.Size = new System.Drawing.Size(110, 21);
            this.gfx_vsync.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(196, 181);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 17;
            this.label14.Text = "Kevésbé";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(321, 181);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "Nagyon";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(218, 165);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(134, 13);
            this.label16.TabIndex = 18;
            this.label16.Text = "Teljesítmény befolyásolása";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(336, 238);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(16, 16);
            this.panel1.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Green;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(336, 266);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(16, 16);
            this.panel2.TabIndex = 19;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Orange;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Location = new System.Drawing.Point(336, 294);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(16, 16);
            this.panel3.TabIndex = 19;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(200)))), ((int)(((byte)(0)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Location = new System.Drawing.Point(336, 320);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(16, 16);
            this.panel4.TabIndex = 19;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Orange;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Location = new System.Drawing.Point(336, 345);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(16, 16);
            this.panel5.TabIndex = 19;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Yellow;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Location = new System.Drawing.Point(336, 371);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(16, 16);
            this.panel6.TabIndex = 19;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Green;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Location = new System.Drawing.Point(336, 399);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(16, 16);
            this.panel7.TabIndex = 19;
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(9, 433);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(120, 24);
            this.bt_save.TabIndex = 20;
            this.bt_save.Text = "Beállítások Mentése";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // bt_launch
            // 
            this.bt_launch.Location = new System.Drawing.Point(152, 433);
            this.bt_launch.Name = "bt_launch";
            this.bt_launch.Size = new System.Drawing.Size(96, 24);
            this.bt_launch.TabIndex = 20;
            this.bt_launch.Text = "Játék indítása";
            this.bt_launch.UseVisualStyleBackColor = true;
            this.bt_launch.Click += new System.EventHandler(this.bt_launch_Click);
            // 
            // bt_about
            // 
            this.bt_about.Location = new System.Drawing.Point(282, 433);
            this.bt_about.Name = "bt_about";
            this.bt_about.Size = new System.Drawing.Size(96, 24);
            this.bt_about.TabIndex = 20;
            this.bt_about.Text = "Programról";
            this.bt_about.UseVisualStyleBackColor = true;
            this.bt_about.Click += new System.EventHandler(this.bt_about_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::rpcj_conf.Properties.Resources.gperf;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(251, 181);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 16);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // tb_vol
            // 
            this.tb_vol.LargeChange = 10;
            this.tb_vol.Location = new System.Drawing.Point(251, 34);
            this.tb_vol.Maximum = 100;
            this.tb_vol.Name = "tb_vol";
            this.tb_vol.Size = new System.Drawing.Size(114, 45);
            this.tb_vol.SmallChange = 10;
            this.tb_vol.TabIndex = 21;
            this.tb_vol.TickFrequency = 10;
            this.tb_vol.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tb_vol.Value = 50;
            this.tb_vol.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(184, 34);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 13);
            this.label17.TabIndex = 22;
            this.label17.Text = "Hangerő";
            // 
            // bt_test
            // 
            this.bt_test.Location = new System.Drawing.Point(165, 53);
            this.bt_test.Name = "bt_test";
            this.bt_test.Size = new System.Drawing.Size(80, 24);
            this.bt_test.TabIndex = 23;
            this.bt_test.Text = "Teszt";
            this.bt_test.UseVisualStyleBackColor = true;
            this.bt_test.Click += new System.EventHandler(this.bt_test_Click);
            // 
            // nm_scopesens
            // 
            this.nm_scopesens.Location = new System.Drawing.Point(118, 83);
            this.nm_scopesens.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nm_scopesens.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nm_scopesens.Name = "nm_scopesens";
            this.nm_scopesens.Size = new System.Drawing.Size(48, 20);
            this.nm_scopesens.TabIndex = 2;
            this.nm_scopesens.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 85);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 13);
            this.label18.TabIndex = 3;
            this.label18.Text = "Szkóp érzékenység";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 468);
            this.Controls.Add(this.bt_test);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.tb_vol);
            this.Controls.Add(this.bt_about);
            this.Controls.Add(this.bt_launch);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gfx_part);
            this.Controls.Add(this.gfx_aa);
            this.Controls.Add(this.gfx_vsync);
            this.Controls.Add(this.gfx_bone);
            this.Controls.Add(this.gfx_aniso);
            this.Controls.Add(this.gfx_texture);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.gfx_pixel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ch_gover);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cb_graphics);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nm_scopesens);
            this.Controls.Add(this.nm_mousesens);
            this.Controls.Add(this.ch_invmouse);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rossz PC Játékok Sorozat Konfiguráció";
            ((System.ComponentModel.ISupportInitialize)(this.nm_mousesens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gfx_pixel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_vol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_scopesens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ch_invmouse;
        private System.Windows.Forms.NumericUpDown nm_mousesens;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_graphics;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ch_gover;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown gfx_pixel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox gfx_texture;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox gfx_aniso;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox gfx_aa;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox gfx_part;
        private System.Windows.Forms.ComboBox gfx_bone;
        private System.Windows.Forms.ComboBox gfx_vsync;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Button bt_launch;
        private System.Windows.Forms.Button bt_about;
        private System.Windows.Forms.TrackBar tb_vol;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button bt_test;
        private System.Windows.Forms.NumericUpDown nm_scopesens;
        private System.Windows.Forms.Label label18;
    }
}

