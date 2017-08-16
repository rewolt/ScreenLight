namespace ScreenLightService.Windows
{
    partial class LedPositionConfig
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
            this.pb_main = new System.Windows.Forms.PictureBox();
            this.bt_reset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ledMarkerControl1 = new LEDMarkerControl.LEDMarkerControl();
            ((System.ComponentModel.ISupportInitialize)(this.pb_main)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_main
            // 
            this.pb_main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_main.Location = new System.Drawing.Point(18, 18);
            this.pb_main.Margin = new System.Windows.Forms.Padding(9);
            this.pb_main.Name = "pb_main";
            this.pb_main.Size = new System.Drawing.Size(798, 396);
            this.pb_main.TabIndex = 0;
            this.pb_main.TabStop = false;
            this.pb_main.Click += new System.EventHandler(this.pb_main_Click);
            // 
            // bt_reset
            // 
            this.bt_reset.Location = new System.Drawing.Point(6, 22);
            this.bt_reset.Name = "bt_reset";
            this.bt_reset.Size = new System.Drawing.Size(75, 23);
            this.bt_reset.TabIndex = 1;
            this.bt_reset.Text = "Reset";
            this.bt_reset.UseVisualStyleBackColor = true;
            this.bt_reset.Click += new System.EventHandler(this.bt_reset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bt_reset);
            this.groupBox1.Location = new System.Drawing.Point(12, 442);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 58);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LED config";
            // 
            // ledMarkerControl1
            // 
            this.ledMarkerControl1.BackColor = System.Drawing.Color.Transparent;
            this.ledMarkerControl1.Location = new System.Drawing.Point(45, 294);
            this.ledMarkerControl1.Name = "ledMarkerControl1";
            this.ledMarkerControl1.Size = new System.Drawing.Size(12, 12);
            this.ledMarkerControl1.TabIndex = 4;
            this.ledMarkerControl1.Load += new System.EventHandler(this.ledMarkerControl1_Load);
            // 
            // LedPositionConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 512);
            this.Controls.Add(this.ledMarkerControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pb_main);
            this.Name = "LedPositionConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LED Position Config";
            this.ResizeEnd += new System.EventHandler(this.LedPositionConfig_ResizeEnd);
            this.Resize += new System.EventHandler(this.LedPositionConfig_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pb_main)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_main;
        private System.Windows.Forms.Button bt_reset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private LEDMarkerControl.LEDMarkerControl ledMarkerControl1;
    }
}