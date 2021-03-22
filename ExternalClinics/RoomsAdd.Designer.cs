
namespace ExternalClinics
{
    partial class RoomsAdd
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
            this.Room_Code_Label = new System.Windows.Forms.Label();
            this.Room_Desc_Label = new System.Windows.Forms.Label();
            this.Room_Status_Label = new System.Windows.Forms.Label();
            this.Room_Status_Active = new System.Windows.Forms.RadioButton();
            this.Room_Status_Inactive = new System.Windows.Forms.RadioButton();
            this.Save = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.Room_Code = new System.Windows.Forms.TextBox();
            this.Room_Desc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Room_Code_Label
            // 
            this.Room_Code_Label.AutoSize = true;
            this.Room_Code_Label.Location = new System.Drawing.Point(56, 30);
            this.Room_Code_Label.Name = "Room_Code_Label";
            this.Room_Code_Label.Size = new System.Drawing.Size(49, 15);
            this.Room_Code_Label.TabIndex = 0;
            this.Room_Code_Label.Text = "Code * :";
            // 
            // Room_Desc_Label
            // 
            this.Room_Desc_Label.AutoSize = true;
            this.Room_Desc_Label.Location = new System.Drawing.Point(56, 62);
            this.Room_Desc_Label.Name = "Room_Desc_Label";
            this.Room_Desc_Label.Size = new System.Drawing.Size(81, 15);
            this.Room_Desc_Label.TabIndex = 1;
            this.Room_Desc_Label.Text = "Description * :";
            // 
            // Room_Status_Label
            // 
            this.Room_Status_Label.AutoSize = true;
            this.Room_Status_Label.Location = new System.Drawing.Point(56, 94);
            this.Room_Status_Label.Name = "Room_Status_Label";
            this.Room_Status_Label.Size = new System.Drawing.Size(45, 15);
            this.Room_Status_Label.TabIndex = 2;
            this.Room_Status_Label.Text = "Status :";
            // 
            // Room_Status_Active
            // 
            this.Room_Status_Active.AutoSize = true;
            this.Room_Status_Active.Checked = true;
            this.Room_Status_Active.Location = new System.Drawing.Point(154, 94);
            this.Room_Status_Active.Name = "Room_Status_Active";
            this.Room_Status_Active.Size = new System.Drawing.Size(58, 19);
            this.Room_Status_Active.TabIndex = 5;
            this.Room_Status_Active.TabStop = true;
            this.Room_Status_Active.Text = "Active";
            this.Room_Status_Active.UseVisualStyleBackColor = true;
            // 
            // Room_Status_Inactive
            // 
            this.Room_Status_Inactive.AutoSize = true;
            this.Room_Status_Inactive.Location = new System.Drawing.Point(249, 94);
            this.Room_Status_Inactive.Name = "Room_Status_Inactive";
            this.Room_Status_Inactive.Size = new System.Drawing.Size(66, 19);
            this.Room_Status_Inactive.TabIndex = 6;
            this.Room_Status_Inactive.Text = "Inactive";
            this.Room_Status_Inactive.UseVisualStyleBackColor = true;
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.YellowGreen;
            this.Save.Location = new System.Drawing.Point(208, 157);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(107, 32);
            this.Save.TabIndex = 29;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Clear
            // 
            this.Clear.BackColor = System.Drawing.Color.NavajoWhite;
            this.Clear.Location = new System.Drawing.Point(56, 157);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(114, 32);
            this.Clear.TabIndex = 28;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Room_Code
            // 
            this.Room_Code.Location = new System.Drawing.Point(154, 30);
            this.Room_Code.MaxLength = 4;
            this.Room_Code.Name = "Room_Code";
            this.Room_Code.Size = new System.Drawing.Size(161, 23);
            this.Room_Code.TabIndex = 30;
            this.Room_Code.Leave += new System.EventHandler(this.Room_Code_Leave);
            // 
            // Room_Desc
            // 
            this.Room_Desc.Location = new System.Drawing.Point(154, 62);
            this.Room_Desc.MaxLength = 100;
            this.Room_Desc.Name = "Room_Desc";
            this.Room_Desc.Size = new System.Drawing.Size(161, 23);
            this.Room_Desc.TabIndex = 31;
            // 
            // RoomsAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 216);
            this.ControlBox = false;
            this.Controls.Add(this.Room_Desc);
            this.Controls.Add(this.Room_Code);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Room_Status_Inactive);
            this.Controls.Add(this.Room_Status_Active);
            this.Controls.Add(this.Room_Status_Label);
            this.Controls.Add(this.Room_Desc_Label);
            this.Controls.Add(this.Room_Code_Label);
            this.Name = "RoomsAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Room";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Room_Code_Label;
        private System.Windows.Forms.Label Room_Desc_Label;
        private System.Windows.Forms.Label Room_Status_Label;
        private System.Windows.Forms.RadioButton Room_Status_Active;
        private System.Windows.Forms.RadioButton Room_Status_Inactive;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.TextBox Room_Code;
        private System.Windows.Forms.TextBox Room_Desc;
    }
}