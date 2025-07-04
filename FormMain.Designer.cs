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
            comboBoxOutputMode = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            checkBoxNewline = new CheckBox();
            checkBoxObsidianFormat = new CheckBox();
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
            comboBoxNightfarers.Location = new Point(173, 295);
            comboBoxNightfarers.Name = "comboBoxNightfarers";
            comboBoxNightfarers.Size = new Size(150, 23);
            comboBoxNightfarers.TabIndex = 1;
            comboBoxNightfarers.SelectedIndexChanged += comboBoxNightfarers_SelectedIndexChanged;
            // 
            // buttonBrowse
            // 
            buttonBrowse.Location = new Point(12, 399);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(75, 23);
            buttonBrowse.TabIndex = 2;
            buttonBrowse.Text = "Browse";
            buttonBrowse.UseVisualStyleBackColor = true;
            buttonBrowse.Click += buttonBrowse_Click;
            // 
            // textBoxFilePath
            // 
            textBoxFilePath.Location = new Point(93, 398);
            textBoxFilePath.Name = "textBoxFilePath";
            textBoxFilePath.PlaceholderText = " No info file selected yet";
            textBoxFilePath.ReadOnly = true;
            textBoxFilePath.Size = new Size(230, 23);
            textBoxFilePath.TabIndex = 3;
            // 
            // comboBoxOutputMode
            // 
            comboBoxOutputMode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOutputMode.FormattingEnabled = true;
            comboBoxOutputMode.Location = new Point(12, 295);
            comboBoxOutputMode.Name = "comboBoxOutputMode";
            comboBoxOutputMode.Size = new Size(150, 23);
            comboBoxOutputMode.TabIndex = 4;
            comboBoxOutputMode.SelectedIndexChanged += comboBoxOutputMode_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(265, 277);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 5;
            label1.Text = "Nightfarer";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 277);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 6;
            label2.Text = "Output Mode";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 380);
            label3.Name = "label3";
            label3.Size = new Size(96, 15);
            label3.TabIndex = 7;
            label3.Text = "Weapon Info File";
            // 
            // checkBoxNewline
            // 
            checkBoxNewline.AutoSize = true;
            checkBoxNewline.Location = new Point(12, 324);
            checkBoxNewline.Name = "checkBoxNewline";
            checkBoxNewline.Size = new Size(215, 19);
            checkBoxNewline.TabIndex = 9;
            checkBoxNewline.Text = "Move grouped scores to a new line?";
            checkBoxNewline.UseVisualStyleBackColor = true;
            checkBoxNewline.CheckedChanged += checkBoxNewline_CheckedChanged;
            // 
            // checkBoxObsidianFormat
            // 
            checkBoxObsidianFormat.AutoSize = true;
            checkBoxObsidianFormat.Location = new Point(12, 346);
            checkBoxObsidianFormat.Name = "checkBoxObsidianFormat";
            checkBoxObsidianFormat.Size = new Size(137, 19);
            checkBoxObsidianFormat.TabIndex = 10;
            checkBoxObsidianFormat.Text = "Format for Obsidian?";
            checkBoxObsidianFormat.UseVisualStyleBackColor = true;
            checkBoxObsidianFormat.CheckedChanged += checkBoxObsidianFormat_CheckedChanged;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 433);
            Controls.Add(checkBoxObsidianFormat);
            Controls.Add(checkBoxNewline);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxOutputMode);
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
        private ComboBox comboBoxOutputMode;
        private Label label1;
        private Label label2;
        private Label label3;
        private CheckBox checkBoxNewline;
        private CheckBox checkBoxObsidianFormat;
    }
}
