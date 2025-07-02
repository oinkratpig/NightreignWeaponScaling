namespace NightreignWeaponScaling
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxOutput = new TextBox();
            comboBoxNightfarers = new ComboBox();
            buttonBrowse = new Button();
            textBoxFilePath = new TextBox();
            SuspendLayout();
            // 
            // textBoxOutput
            // 
            textBoxOutput.Location = new Point(12, 12);
            textBoxOutput.Multiline = true;
            textBoxOutput.Name = "textBoxOutput";
            textBoxOutput.ReadOnly = true;
            textBoxOutput.ScrollBars = ScrollBars.Vertical;
            textBoxOutput.Size = new Size(311, 257);
            textBoxOutput.TabIndex = 0;
            // 
            // comboBoxNightfarers
            // 
            comboBoxNightfarers.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxNightfarers.FormattingEnabled = true;
            comboBoxNightfarers.Location = new Point(93, 275);
            comboBoxNightfarers.Name = "comboBoxNightfarers";
            comboBoxNightfarers.Size = new Size(150, 23);
            comboBoxNightfarers.TabIndex = 1;
            comboBoxNightfarers.SelectedIndexChanged += comboBoxNightfarers_SelectedIndexChanged;
            // 
            // buttonBrowse
            // 
            buttonBrowse.Location = new Point(12, 306);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(75, 23);
            buttonBrowse.TabIndex = 2;
            buttonBrowse.Text = "Browse";
            buttonBrowse.UseVisualStyleBackColor = true;
            buttonBrowse.Click += buttonBrowse_Click;
            // 
            // textBoxFilePath
            // 
            textBoxFilePath.Location = new Point(93, 305);
            textBoxFilePath.Name = "textBoxFilePath";
            textBoxFilePath.PlaceholderText = " No info file selected yet";
            textBoxFilePath.ReadOnly = true;
            textBoxFilePath.Size = new Size(230, 23);
            textBoxFilePath.TabIndex = 3;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 340);
            Controls.Add(textBoxFilePath);
            Controls.Add(buttonBrowse);
            Controls.Add(comboBoxNightfarers);
            Controls.Add(textBoxOutput);
            Name = "FormMain";
            Text = "Nightreign Weapon Scaling";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxOutput;
        private ComboBox comboBoxNightfarers;
        private Button buttonBrowse;
        private TextBox textBoxFilePath;
    }
}
