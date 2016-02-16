namespace WindowsFormsApplication1
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
            this.submitButton = new System.Windows.Forms.Button();
            this.inputCurrencyTypeLabel = new System.Windows.Forms.Label();
            this.inputCurrencyAmountLabel = new System.Windows.Forms.Label();
            this.outputCurrencyTypeLabel = new System.Windows.Forms.Label();
            this.outputCurrencyAmountLabel = new System.Windows.Forms.Label();
            this.outputCurrencyAmountTextBox = new System.Windows.Forms.TextBox();
            this.inputCurrencyAmountTextBox = new System.Windows.Forms.TextBox();
            this.inputCurrencyTypeSelect = new System.Windows.Forms.ComboBox();
            this.outputCurrencyTypeSelect = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(15, 134);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(116, 42);
            this.submitButton.TabIndex = 1;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // inputCurrencyTypeLabel
            // 
            this.inputCurrencyTypeLabel.AutoSize = true;
            this.inputCurrencyTypeLabel.Location = new System.Drawing.Point(12, 37);
            this.inputCurrencyTypeLabel.Name = "inputCurrencyTypeLabel";
            this.inputCurrencyTypeLabel.Size = new System.Drawing.Size(136, 17);
            this.inputCurrencyTypeLabel.TabIndex = 2;
            this.inputCurrencyTypeLabel.Text = "Input Currency Type";
            // 
            // inputCurrencyAmountLabel
            // 
            this.inputCurrencyAmountLabel.AutoSize = true;
            this.inputCurrencyAmountLabel.Location = new System.Drawing.Point(382, 37);
            this.inputCurrencyAmountLabel.Name = "inputCurrencyAmountLabel";
            this.inputCurrencyAmountLabel.Size = new System.Drawing.Size(152, 17);
            this.inputCurrencyAmountLabel.TabIndex = 3;
            this.inputCurrencyAmountLabel.Text = "Input Currency Amount";
            // 
            // outputCurrencyTypeLabel
            // 
            this.outputCurrencyTypeLabel.AutoSize = true;
            this.outputCurrencyTypeLabel.Location = new System.Drawing.Point(12, 80);
            this.outputCurrencyTypeLabel.Name = "outputCurrencyTypeLabel";
            this.outputCurrencyTypeLabel.Size = new System.Drawing.Size(148, 17);
            this.outputCurrencyTypeLabel.TabIndex = 4;
            this.outputCurrencyTypeLabel.Text = "Output Currency Type";
            // 
            // outputCurrencyAmountLabel
            // 
            this.outputCurrencyAmountLabel.AutoSize = true;
            this.outputCurrencyAmountLabel.Location = new System.Drawing.Point(380, 80);
            this.outputCurrencyAmountLabel.Name = "outputCurrencyAmountLabel";
            this.outputCurrencyAmountLabel.Size = new System.Drawing.Size(164, 17);
            this.outputCurrencyAmountLabel.TabIndex = 5;
            this.outputCurrencyAmountLabel.Text = "Output Currency Amount";
            // 
            // outputCurrencyAmountTextBox
            // 
            this.outputCurrencyAmountTextBox.Location = new System.Drawing.Point(550, 80);
            this.outputCurrencyAmountTextBox.Name = "outputCurrencyAmountTextBox";
            this.outputCurrencyAmountTextBox.ReadOnly = true;
            this.outputCurrencyAmountTextBox.Size = new System.Drawing.Size(117, 22);
            this.outputCurrencyAmountTextBox.TabIndex = 6;
            // 
            // inputCurrencyAmountTextBox
            // 
            this.inputCurrencyAmountTextBox.Location = new System.Drawing.Point(550, 34);
            this.inputCurrencyAmountTextBox.Name = "inputCurrencyAmountTextBox";
            this.inputCurrencyAmountTextBox.Size = new System.Drawing.Size(117, 22);
            this.inputCurrencyAmountTextBox.TabIndex = 7;
            // 
            // inputCurrencyTypeSelect
            // 
            this.inputCurrencyTypeSelect.FormattingEnabled = true;
            this.inputCurrencyTypeSelect.Location = new System.Drawing.Point(163, 34);
            this.inputCurrencyTypeSelect.Name = "inputCurrencyTypeSelect";
            this.inputCurrencyTypeSelect.Size = new System.Drawing.Size(190, 24);
            this.inputCurrencyTypeSelect.TabIndex = 10;
            // 
            // outputCurrencyTypeSelect
            // 
            this.outputCurrencyTypeSelect.FormattingEnabled = true;
            this.outputCurrencyTypeSelect.Location = new System.Drawing.Point(163, 80);
            this.outputCurrencyTypeSelect.Name = "outputCurrencyTypeSelect";
            this.outputCurrencyTypeSelect.Size = new System.Drawing.Size(190, 24);
            this.outputCurrencyTypeSelect.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 198);
            this.Controls.Add(this.outputCurrencyTypeSelect);
            this.Controls.Add(this.inputCurrencyTypeSelect);
            this.Controls.Add(this.inputCurrencyAmountTextBox);
            this.Controls.Add(this.outputCurrencyAmountTextBox);
            this.Controls.Add(this.outputCurrencyAmountLabel);
            this.Controls.Add(this.outputCurrencyTypeLabel);
            this.Controls.Add(this.inputCurrencyAmountLabel);
            this.Controls.Add(this.inputCurrencyTypeLabel);
            this.Controls.Add(this.submitButton);
            this.Name = "Form1";
            this.Text = "Currency Converter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label inputCurrencyTypeLabel;
        private System.Windows.Forms.Label inputCurrencyAmountLabel;
        private System.Windows.Forms.Label outputCurrencyTypeLabel;
        private System.Windows.Forms.Label outputCurrencyAmountLabel;
        private System.Windows.Forms.TextBox outputCurrencyAmountTextBox;
        private System.Windows.Forms.TextBox inputCurrencyAmountTextBox;
        private System.Windows.Forms.ComboBox inputCurrencyTypeSelect;
        private System.Windows.Forms.ComboBox outputCurrencyTypeSelect;
    }
}

