namespace Views.Views
{
    partial class MainView
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
            this.ExpressionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.BeginIntervalTextBox = new System.Windows.Forms.TextBox();
            this.EndIntervalTextBox = new System.Windows.Forms.TextBox();
            this.ErrorTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.ExpressionGroupBox = new System.Windows.Forms.GroupBox();
            this.AnswerGridView = new System.Windows.Forms.DataGridView();
            this.XColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnswerGroupBox = new System.Windows.Forms.GroupBox();
            this.AnswerLabel = new System.Windows.Forms.Label();
            this.ExpressionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerGridView)).BeginInit();
            this.AnswerGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExpressionTextBox
            // 
            this.ExpressionTextBox.Location = new System.Drawing.Point(32, 62);
            this.ExpressionTextBox.Name = "ExpressionTextBox";
            this.ExpressionTextBox.Size = new System.Drawing.Size(248, 20);
            this.ExpressionTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Введите уравнение";
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(32, 222);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(75, 23);
            this.CalculateButton.TabIndex = 5;
            this.CalculateButton.Text = "Посчитать";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // BeginIntervalTextBox
            // 
            this.BeginIntervalTextBox.Location = new System.Drawing.Point(32, 128);
            this.BeginIntervalTextBox.Name = "BeginIntervalTextBox";
            this.BeginIntervalTextBox.Size = new System.Drawing.Size(75, 20);
            this.BeginIntervalTextBox.TabIndex = 6;
            // 
            // EndIntervalTextBox
            // 
            this.EndIntervalTextBox.Location = new System.Drawing.Point(175, 121);
            this.EndIntervalTextBox.Name = "EndIntervalTextBox";
            this.EndIntervalTextBox.Size = new System.Drawing.Size(86, 20);
            this.EndIntervalTextBox.TabIndex = 7;
            // 
            // ErrorTextBox
            // 
            this.ErrorTextBox.Location = new System.Drawing.Point(32, 187);
            this.ErrorTextBox.Name = "ErrorTextBox";
            this.ErrorTextBox.Size = new System.Drawing.Size(115, 20);
            this.ErrorTextBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Интервал";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(137, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "-";
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Location = new System.Drawing.Point(29, 160);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(54, 13);
            this.ErrorLabel.TabIndex = 11;
            this.ErrorLabel.Text = "Точность";
            // 
            // ExpressionGroupBox
            // 
            this.ExpressionGroupBox.Controls.Add(this.ExpressionTextBox);
            this.ExpressionGroupBox.Controls.Add(this.EndIntervalTextBox);
            this.ExpressionGroupBox.Controls.Add(this.ErrorLabel);
            this.ExpressionGroupBox.Controls.Add(this.label1);
            this.ExpressionGroupBox.Controls.Add(this.label3);
            this.ExpressionGroupBox.Controls.Add(this.CalculateButton);
            this.ExpressionGroupBox.Controls.Add(this.label2);
            this.ExpressionGroupBox.Controls.Add(this.BeginIntervalTextBox);
            this.ExpressionGroupBox.Controls.Add(this.ErrorTextBox);
            this.ExpressionGroupBox.Location = new System.Drawing.Point(12, 12);
            this.ExpressionGroupBox.Name = "ExpressionGroupBox";
            this.ExpressionGroupBox.Size = new System.Drawing.Size(388, 291);
            this.ExpressionGroupBox.TabIndex = 12;
            this.ExpressionGroupBox.TabStop = false;
            // 
            // AnswerGridView
            // 
            this.AnswerGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AnswerGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.XColumn,
            this.AColumn,
            this.bColumn,
            this.FxColumn});
            this.AnswerGridView.Location = new System.Drawing.Point(6, 44);
            this.AnswerGridView.Name = "AnswerGridView";
            this.AnswerGridView.Size = new System.Drawing.Size(277, 241);
            this.AnswerGridView.TabIndex = 13;
            this.AnswerGridView.Visible = false;
            // 
            // XColumn
            // 
            this.XColumn.HeaderText = "x";
            this.XColumn.Name = "XColumn";
            // 
            // AColumn
            // 
            this.AColumn.HeaderText = "a";
            this.AColumn.Name = "AColumn";
            // 
            // bColumn
            // 
            this.bColumn.HeaderText = "b";
            this.bColumn.Name = "bColumn";
            // 
            // FxColumn
            // 
            this.FxColumn.HeaderText = "f(x)";
            this.FxColumn.Name = "FxColumn";
            // 
            // AnswerGroupBox
            // 
            this.AnswerGroupBox.Controls.Add(this.AnswerGridView);
            this.AnswerGroupBox.Location = new System.Drawing.Point(441, 12);
            this.AnswerGroupBox.Name = "AnswerGroupBox";
            this.AnswerGroupBox.Size = new System.Drawing.Size(291, 291);
            this.AnswerGroupBox.TabIndex = 15;
            this.AnswerGroupBox.TabStop = false;
            this.AnswerGroupBox.Text = "Ответ";
            // 
            // AnswerLabel
            // 
            this.AnswerLabel.AutoSize = true;
            this.AnswerLabel.Location = new System.Drawing.Point(447, 310);
            this.AnswerLabel.Name = "AnswerLabel";
            this.AnswerLabel.Size = new System.Drawing.Size(0, 13);
            this.AnswerLabel.TabIndex = 16;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 340);
            this.Controls.Add(this.AnswerLabel);
            this.Controls.Add(this.ExpressionGroupBox);
            this.Controls.Add(this.AnswerGroupBox);
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Метод дихотомии";
            this.ExpressionGroupBox.ResumeLayout(false);
            this.ExpressionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerGridView)).EndInit();
            this.AnswerGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ExpressionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.TextBox BeginIntervalTextBox;
        private System.Windows.Forms.TextBox EndIntervalTextBox;
        private System.Windows.Forms.TextBox ErrorTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.GroupBox ExpressionGroupBox;
        private System.Windows.Forms.DataGridView AnswerGridView;
        private System.Windows.Forms.GroupBox AnswerGroupBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn XColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FxColumn;
        private System.Windows.Forms.Label AnswerLabel;
    }
}