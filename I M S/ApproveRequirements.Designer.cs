
namespace I_M_S
{
    partial class ApproveRequirements
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
            System.Windows.Forms.PictureBox logout2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApproveRequirements));
            System.Windows.Forms.PictureBox pictureBox6;
            this.panel2 = new System.Windows.Forms.Panel();
            this.logout = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.societyID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.itemID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.editusers = new System.Windows.Forms.Button();
            this.dasboard = new System.Windows.Forms.Button();
            this.logingdetails = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.addusers = new System.Windows.Forms.Button();
            this.loging = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.approve = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            logout2 = new System.Windows.Forms.PictureBox();
            pictureBox6 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(logout2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox6)).BeginInit();
            this.loging.SuspendLayout();
            this.SuspendLayout();
            // 
            // logout2
            // 
            logout2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            logout2.Image = ((System.Drawing.Image)(resources.GetObject("logout2.Image")));
            logout2.Location = new System.Drawing.Point(9, 391);
            logout2.Name = "logout2";
            logout2.Size = new System.Drawing.Size(36, 34);
            logout2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            logout2.TabIndex = 19;
            logout2.TabStop = false;
            logout2.Click += new System.EventHandler(this.logout2_Click);
            // 
            // pictureBox6
            // 
            pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            pictureBox6.Location = new System.Drawing.Point(21, 14);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new System.Drawing.Size(122, 112);
            pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 9;
            pictureBox6.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(192, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(694, 456);
            this.panel2.TabIndex = 1;
            // 
            // logout
            // 
            this.logout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(46)))), ((int)(((byte)(85)))));
            this.logout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(46)))), ((int)(((byte)(85)))));
            this.logout.FlatAppearance.BorderSize = 0;
            this.logout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(46)))), ((int)(((byte)(85)))));
            this.logout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(46)))), ((int)(((byte)(85)))));
            this.logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout.ForeColor = System.Drawing.Color.Silver;
            this.logout.Location = new System.Drawing.Point(12, 391);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(142, 34);
            this.logout.TabIndex = 20;
            this.logout.Text = "Logout";
            this.logout.UseVisualStyleBackColor = false;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(46)))), ((int)(((byte)(85)))));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.societyID,
            this.itemID,
            this.quantity,
            this.status});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(326, 155);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(371, 160);
            this.listView1.TabIndex = 174;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged_1);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 50;
            // 
            // societyID
            // 
            this.societyID.Text = "Society";
            this.societyID.Width = 70;
            // 
            // itemID
            // 
            this.itemID.Text = "Item";
            this.itemID.Width = 50;
            // 
            // quantity
            // 
            this.quantity.Text = "Quantity";
            this.quantity.Width = 90;
            // 
            // status
            // 
            this.status.Text = "Status";
            this.status.Width = 100;
            // 
            // editusers
            // 
            this.editusers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(60)))));
            this.editusers.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.editusers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(87)))), ((int)(((byte)(157)))));
            this.editusers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(87)))), ((int)(((byte)(157)))));
            this.editusers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editusers.ForeColor = System.Drawing.Color.Silver;
            this.editusers.Location = new System.Drawing.Point(9, 264);
            this.editusers.Name = "editusers";
            this.editusers.Size = new System.Drawing.Size(145, 30);
            this.editusers.TabIndex = 154;
            this.editusers.Text = "Edit User";
            this.editusers.UseVisualStyleBackColor = false;
            this.editusers.Click += new System.EventHandler(this.editusers_Click);
            // 
            // dasboard
            // 
            this.dasboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(60)))));
            this.dasboard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.dasboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(87)))), ((int)(((byte)(157)))));
            this.dasboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(87)))), ((int)(((byte)(157)))));
            this.dasboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dasboard.ForeColor = System.Drawing.Color.Silver;
            this.dasboard.Location = new System.Drawing.Point(9, 192);
            this.dasboard.Name = "dasboard";
            this.dasboard.Size = new System.Drawing.Size(145, 30);
            this.dasboard.TabIndex = 7;
            this.dasboard.Text = "Dashboard";
            this.dasboard.UseVisualStyleBackColor = false;
            this.dasboard.Click += new System.EventHandler(this.dasboard_Click_1);
            // 
            // logingdetails
            // 
            this.logingdetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(60)))));
            this.logingdetails.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.logingdetails.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(87)))), ((int)(((byte)(157)))));
            this.logingdetails.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(87)))), ((int)(((byte)(157)))));
            this.logingdetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logingdetails.ForeColor = System.Drawing.Color.Silver;
            this.logingdetails.Location = new System.Drawing.Point(9, 300);
            this.logingdetails.Name = "logingdetails";
            this.logingdetails.Size = new System.Drawing.Size(145, 31);
            this.logingdetails.TabIndex = 6;
            this.logingdetails.Text = "Loging Details";
            this.logingdetails.UseVisualStyleBackColor = false;
            this.logingdetails.Click += new System.EventHandler(this.logingdetails_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(87)))), ((int)(((byte)(157)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(87)))), ((int)(((byte)(157)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(87)))), ((int)(((byte)(157)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Silver;
            this.button1.Location = new System.Drawing.Point(9, 337);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "Approve Requirements";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // addusers
            // 
            this.addusers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(60)))));
            this.addusers.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.addusers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(87)))), ((int)(((byte)(157)))));
            this.addusers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(87)))), ((int)(((byte)(157)))));
            this.addusers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addusers.ForeColor = System.Drawing.Color.Silver;
            this.addusers.Location = new System.Drawing.Point(9, 228);
            this.addusers.Name = "addusers";
            this.addusers.Size = new System.Drawing.Size(145, 30);
            this.addusers.TabIndex = 2;
            this.addusers.Text = "Add Users";
            this.addusers.UseVisualStyleBackColor = false;
            this.addusers.Click += new System.EventHandler(this.addusers_Click);
            // 
            // loging
            // 
            this.loging.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(46)))), ((int)(((byte)(85)))));
            this.loging.Controls.Add(this.editusers);
            this.loging.Controls.Add(logout2);
            this.loging.Controls.Add(pictureBox6);
            this.loging.Controls.Add(this.dasboard);
            this.loging.Controls.Add(this.logingdetails);
            this.loging.Controls.Add(this.button1);
            this.loging.Controls.Add(this.addusers);
            this.loging.Controls.Add(this.panel2);
            this.loging.Controls.Add(this.button3);
            this.loging.Controls.Add(this.logout);
            this.loging.Cursor = System.Windows.Forms.Cursors.PanSouth;
            this.loging.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loging.Location = new System.Drawing.Point(12, 12);
            this.loging.Name = "loging";
            this.loging.Size = new System.Drawing.Size(166, 437);
            this.loging.TabIndex = 175;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(46)))), ((int)(((byte)(85)))));
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(46)))), ((int)(((byte)(85)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(46)))), ((int)(((byte)(85)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(46)))), ((int)(((byte)(85)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Silver;
            this.button3.Location = new System.Drawing.Point(0, 117);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(164, 55);
            this.button3.TabIndex = 12;
            this.button3.Text = "Super Admin";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // approve
            // 
            this.approve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(46)))), ((int)(((byte)(85)))));
            this.approve.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.approve.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(87)))), ((int)(((byte)(157)))));
            this.approve.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(87)))), ((int)(((byte)(157)))));
            this.approve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.approve.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.approve.ForeColor = System.Drawing.Color.Silver;
            this.approve.Location = new System.Drawing.Point(556, 346);
            this.approve.Name = "approve";
            this.approve.Size = new System.Drawing.Size(125, 32);
            this.approve.TabIndex = 173;
            this.approve.Text = "Approve";
            this.approve.UseVisualStyleBackColor = false;
            this.approve.Click += new System.EventHandler(this.approve_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(342, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 43);
            this.label1.TabIndex = 172;
            this.label1.Text = "Select to Approve";
            // 
            // ApproveRequirements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(934, 461);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.loging);
            this.Controls.Add(this.approve);
            this.Controls.Add(this.label1);
            this.Name = "ApproveRequirements";
            this.Text = "ApproveRequirements";
            this.Load += new System.EventHandler(this.ApproveRequirements_Load);
            ((System.ComponentModel.ISupportInitialize)(logout2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox6)).EndInit();
            this.loging.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader societyID;
        private System.Windows.Forms.ColumnHeader itemID;
        private System.Windows.Forms.ColumnHeader quantity;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.Button editusers;
        private System.Windows.Forms.Button dasboard;
        private System.Windows.Forms.Button logingdetails;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button addusers;
        private System.Windows.Forms.Panel loging;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button approve;
        private System.Windows.Forms.Label label1;
    }
}