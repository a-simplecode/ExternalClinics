
namespace ExternalClinics
{
    partial class DoctorsAdd
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
            this.Code_Label = new System.Windows.Forms.Label();
            this.Name_Label = new System.Windows.Forms.Label();
            this.Specialty_Label = new System.Windows.Forms.Label();
            this.Photo_label = new System.Windows.Forms.Label();
            this.Status_Label = new System.Windows.Forms.Label();
            this.Password_Label = new System.Windows.Forms.Label();
            this.Doc_Code = new System.Windows.Forms.TextBox();
            this.Doc_Name = new System.Windows.Forms.TextBox();
            this.Doc_Photo = new System.Windows.Forms.PictureBox();
            this.Doc_Status_Active = new System.Windows.Forms.RadioButton();
            this.Doc_Status_Inactive = new System.Windows.Forms.RadioButton();
            this.Doc_Password = new System.Windows.Forms.TextBox();
            this.Clear = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Doc_Specialty = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Doc_Photo)).BeginInit();
            this.SuspendLayout();
            // 
            // Code_Label
            // 
            this.Code_Label.AutoSize = true;
            this.Code_Label.Location = new System.Drawing.Point(86, 22);
            this.Code_Label.Name = "Code_Label";
            this.Code_Label.Size = new System.Drawing.Size(49, 15);
            this.Code_Label.TabIndex = 0;
            this.Code_Label.Text = "Code * :";
            // 
            // Name_Label
            // 
            this.Name_Label.AutoSize = true;
            this.Name_Label.Location = new System.Drawing.Point(86, 51);
            this.Name_Label.Name = "Name_Label";
            this.Name_Label.Size = new System.Drawing.Size(75, 15);
            this.Name_Label.TabIndex = 1;
            this.Name_Label.Text = "Full Name * :";
            // 
            // Specialty_Label
            // 
            this.Specialty_Label.AutoSize = true;
            this.Specialty_Label.Location = new System.Drawing.Point(86, 80);
            this.Specialty_Label.Name = "Specialty_Label";
            this.Specialty_Label.Size = new System.Drawing.Size(68, 15);
            this.Specialty_Label.TabIndex = 2;
            this.Specialty_Label.Text = "Specialty * :";
            // 
            // Photo_label
            // 
            this.Photo_label.AutoSize = true;
            this.Photo_label.Location = new System.Drawing.Point(86, 112);
            this.Photo_label.Name = "Photo_label";
            this.Photo_label.Size = new System.Drawing.Size(45, 15);
            this.Photo_label.TabIndex = 3;
            this.Photo_label.Text = "Photo :";
            // 
            // Status_Label
            // 
            this.Status_Label.AutoSize = true;
            this.Status_Label.Location = new System.Drawing.Point(86, 211);
            this.Status_Label.Name = "Status_Label";
            this.Status_Label.Size = new System.Drawing.Size(45, 15);
            this.Status_Label.TabIndex = 4;
            this.Status_Label.Text = "Status :";
            // 
            // Password_Label
            // 
            this.Password_Label.AutoSize = true;
            this.Password_Label.Location = new System.Drawing.Point(86, 236);
            this.Password_Label.Name = "Password_Label";
            this.Password_Label.Size = new System.Drawing.Size(71, 15);
            this.Password_Label.TabIndex = 5;
            this.Password_Label.Text = "Password * :";
            // 
            // Doc_Code
            // 
            this.Doc_Code.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Doc_Code.Location = new System.Drawing.Point(190, 22);
            this.Doc_Code.MaxLength = 4;
            this.Doc_Code.Name = "Doc_Code";
            this.Doc_Code.Size = new System.Drawing.Size(69, 23);
            this.Doc_Code.TabIndex = 7;
            this.Doc_Code.Leave += new System.EventHandler(this.Doc_Code_Leave);
            // 
            // Doc_Name
            // 
            this.Doc_Name.Location = new System.Drawing.Point(190, 51);
            this.Doc_Name.MaxLength = 600;
            this.Doc_Name.Name = "Doc_Name";
            this.Doc_Name.Size = new System.Drawing.Size(142, 23);
            this.Doc_Name.TabIndex = 8;
            // 
            // Doc_Photo
            // 
            this.Doc_Photo.Location = new System.Drawing.Point(190, 112);
            this.Doc_Photo.Name = "Doc_Photo";
            this.Doc_Photo.Size = new System.Drawing.Size(110, 93);
            this.Doc_Photo.TabIndex = 10;
            this.Doc_Photo.TabStop = false;
            // 
            // Doc_Status_Active
            // 
            this.Doc_Status_Active.AutoSize = true;
            this.Doc_Status_Active.Checked = true;
            this.Doc_Status_Active.Location = new System.Drawing.Point(190, 211);
            this.Doc_Status_Active.Name = "Doc_Status_Active";
            this.Doc_Status_Active.Size = new System.Drawing.Size(58, 19);
            this.Doc_Status_Active.TabIndex = 11;
            this.Doc_Status_Active.TabStop = true;
            this.Doc_Status_Active.Text = "Active";
            this.Doc_Status_Active.UseVisualStyleBackColor = true;
            // 
            // Doc_Status_Inactive
            // 
            this.Doc_Status_Inactive.AutoSize = true;
            this.Doc_Status_Inactive.Location = new System.Drawing.Point(266, 209);
            this.Doc_Status_Inactive.Name = "Doc_Status_Inactive";
            this.Doc_Status_Inactive.Size = new System.Drawing.Size(66, 19);
            this.Doc_Status_Inactive.TabIndex = 12;
            this.Doc_Status_Inactive.Text = "Inactive";
            this.Doc_Status_Inactive.UseVisualStyleBackColor = true;
            // 
            // Doc_Password
            // 
            this.Doc_Password.Location = new System.Drawing.Point(190, 236);
            this.Doc_Password.MaxLength = 100;
            this.Doc_Password.Name = "Doc_Password";
            this.Doc_Password.PasswordChar = '*';
            this.Doc_Password.Size = new System.Drawing.Size(142, 23);
            this.Doc_Password.TabIndex = 13;
            // 
            // Clear
            // 
            this.Clear.BackColor = System.Drawing.Color.NavajoWhite;
            this.Clear.Location = new System.Drawing.Point(86, 291);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(114, 32);
            this.Clear.TabIndex = 14;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.YellowGreen;
            this.Save.Location = new System.Drawing.Point(225, 291);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(107, 32);
            this.Save.TabIndex = 15;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Doc_Specialty
            // 
            this.Doc_Specialty.FormattingEnabled = true;
            this.Doc_Specialty.Location = new System.Drawing.Point(190, 80);
            this.Doc_Specialty.MaxDropDownItems = 100;
            this.Doc_Specialty.Name = "Doc_Specialty";
            this.Doc_Specialty.Size = new System.Drawing.Size(142, 23);
            this.Doc_Specialty.TabIndex = 9;
            // 
            // DoctorsAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 335);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Doc_Password);
            this.Controls.Add(this.Doc_Status_Inactive);
            this.Controls.Add(this.Doc_Status_Active);
            this.Controls.Add(this.Doc_Photo);
            this.Controls.Add(this.Doc_Specialty);
            this.Controls.Add(this.Doc_Name);
            this.Controls.Add(this.Doc_Code);
            this.Controls.Add(this.Password_Label);
            this.Controls.Add(this.Status_Label);
            this.Controls.Add(this.Photo_label);
            this.Controls.Add(this.Specialty_Label);
            this.Controls.Add(this.Name_Label);
            this.Controls.Add(this.Code_Label);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DoctorsAdd";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add";
            ((System.ComponentModel.ISupportInitialize)(this.Doc_Photo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Code_Label;
        private System.Windows.Forms.Label Name_Label;
        private System.Windows.Forms.Label Specialty_Label;
        private System.Windows.Forms.Label Photo_label;
        private System.Windows.Forms.Label Status_Label;
        private System.Windows.Forms.Label Password_Label;
        private System.Windows.Forms.TextBox Doc_Code;
        private System.Windows.Forms.TextBox Doc_Name;
        private System.Windows.Forms.PictureBox Doc_Photo;
        private System.Windows.Forms.RadioButton Doc_Status_Active;
        private System.Windows.Forms.RadioButton Doc_Status_Inactive;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TextBox Doc_Password;
        public System.Windows.Forms.ComboBox Doc_Specialty;
    }
}