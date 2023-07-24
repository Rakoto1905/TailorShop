namespace TailorShopV1._0._0
{
    partial class DeleteCustomer
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
            this.BtnHyr = new System.Windows.Forms.Button();
            this.BtnEvet = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnHyr
            // 
            this.BtnHyr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnHyr.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnHyr.Location = new System.Drawing.Point(398, 229);
            this.BtnHyr.Name = "BtnHyr";
            this.BtnHyr.Size = new System.Drawing.Size(84, 38);
            this.BtnHyr.TabIndex = 4;
            this.BtnHyr.Text = "Hayır";
            this.BtnHyr.UseVisualStyleBackColor = false;
            // 
            // BtnEvet
            // 
            this.BtnEvet.BackColor = System.Drawing.Color.Green;
            this.BtnEvet.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnEvet.Location = new System.Drawing.Point(277, 229);
            this.BtnEvet.Name = "BtnEvet";
            this.BtnEvet.Size = new System.Drawing.Size(84, 38);
            this.BtnEvet.TabIndex = 5;
            this.BtnEvet.Text = "Evet";
            this.BtnEvet.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nolu Öğrenciyi Silmek istediğinize emin misiniz?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 3;
            // 
            // DeleteCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnHyr);
            this.Controls.Add(this.BtnEvet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DeleteCustomer";
            this.Text = "DeleteCustomer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnHyr;
        private System.Windows.Forms.Button BtnEvet;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
    }
}