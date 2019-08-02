namespace Views.Views
{
    partial class Graphic
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
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.YCoordinateLabel = new System.Windows.Forms.Label();
            this.XCoordinateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Location = new System.Drawing.Point(44, 12);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(486, 255);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // YCoordinateLabel
            // 
            this.YCoordinateLabel.AutoSize = true;
            this.YCoordinateLabel.Location = new System.Drawing.Point(8, 118);
            this.YCoordinateLabel.Name = "YCoordinateLabel";
            this.YCoordinateLabel.Size = new System.Drawing.Size(14, 13);
            this.YCoordinateLabel.TabIndex = 1;
            this.YCoordinateLabel.Text = "X";
            // 
            // XCoordinateLabel
            // 
            this.XCoordinateLabel.AutoSize = true;
            this.XCoordinateLabel.Location = new System.Drawing.Point(175, 290);
            this.XCoordinateLabel.Name = "XCoordinateLabel";
            this.XCoordinateLabel.Size = new System.Drawing.Size(91, 13);
            this.XCoordinateLabel.TabIndex = 2;
            this.XCoordinateLabel.Text = "Номер итерации";
            // 
            // Graphic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 315);
            this.Controls.Add(this.XCoordinateLabel);
            this.Controls.Add(this.YCoordinateLabel);
            this.Controls.Add(this.chart1);
            this.Name = "Graphic";
            this.Text = "Graphic";
            this.Load += new System.EventHandler(this.Graphic_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label YCoordinateLabel;
        private System.Windows.Forms.Label XCoordinateLabel;
    }
}