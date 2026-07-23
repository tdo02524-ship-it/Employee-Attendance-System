namespace ChamCongRFID
{
    partial class FormLuong
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblThang = new System.Windows.Forms.Label();
            this.cboThang = new System.Windows.Forms.ComboBox();
            this.lblNam = new System.Windows.Forms.Label();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.btnTinhLuong = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.dgvLuong = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(208, 27);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "QUẢN LÝ LƯƠNG";
            // 
            // lblThang
            // 
            this.lblThang.AutoSize = true;
            this.lblThang.Location = new System.Drawing.Point(30, 75);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(58, 23);
            this.lblThang.TabIndex = 6;
            this.lblThang.Text = "Tháng";
            // 
            // cboThang
            // 
            this.cboThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThang.Location = new System.Drawing.Point(94, 68);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(80, 31);
            this.cboThang.TabIndex = 5;
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Location = new System.Drawing.Point(180, 75);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(47, 23);
            this.lblNam.TabIndex = 4;
            this.lblNam.Text = "Năm";
            // 
            // cboNam
            // 
            this.cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNam.Location = new System.Drawing.Point(230, 70);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(100, 31);
            this.cboNam.TabIndex = 3;
            // 
            // btnTinhLuong
            // 
            this.btnTinhLuong.BackColor = System.Drawing.Color.White;
            this.btnTinhLuong.FlatAppearance.BorderSize = 0;
            this.btnTinhLuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTinhLuong.ForeColor = System.Drawing.Color.Black;
            this.btnTinhLuong.Location = new System.Drawing.Point(350, 68);
            this.btnTinhLuong.Name = "btnTinhLuong";
            this.btnTinhLuong.Size = new System.Drawing.Size(120, 32);
            this.btnTinhLuong.TabIndex = 2;
            this.btnTinhLuong.Text = "Tính lương";
            this.btnTinhLuong.UseVisualStyleBackColor = false;
            this.btnTinhLuong.Click += new System.EventHandler(this.btnTinhLuong_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnXuatExcel.FlatAppearance.BorderSize = 0;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
            this.btnXuatExcel.Location = new System.Drawing.Point(810, 68);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(120, 32);
            this.btnXuatExcel.TabIndex = 1;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // dgvLuong
            // 
            this.dgvLuong.AllowUserToAddRows = false;
            this.dgvLuong.AllowUserToDeleteRows = false;
            this.dgvLuong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLuong.BackgroundColor = System.Drawing.Color.White;
            this.dgvLuong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvLuong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLuong.ColumnHeadersHeight = 35;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLuong.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLuong.EnableHeadersVisualStyles = false;
            this.dgvLuong.Location = new System.Drawing.Point(34, 168);
            this.dgvLuong.Name = "dgvLuong";
            this.dgvLuong.ReadOnly = true;
            this.dgvLuong.RowHeadersVisible = false;
            this.dgvLuong.RowHeadersWidth = 51;
            this.dgvLuong.RowTemplate.Height = 40;
            this.dgvLuong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLuong.Size = new System.Drawing.Size(900, 343);
            this.dgvLuong.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Bảng lương chi tiết của nhân viên";
            // 
            // FormLuong
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(960, 560);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvLuong);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.btnTinhLuong);
            this.Controls.Add(this.cboNam);
            this.Controls.Add(this.lblNam);
            this.Controls.Add(this.cboThang);
            this.Controls.Add(this.lblThang);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLuong";
            this.Text = "Quản Lý Lương";
            this.Load += new System.EventHandler(this.FormLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle, lblThang, lblNam;
        private System.Windows.Forms.ComboBox cboThang, cboNam;
        private System.Windows.Forms.Button btnTinhLuong, btnXuatExcel;
        private System.Windows.Forms.DataGridView dgvLuong;
        private System.Windows.Forms.Label label1;
    }
}