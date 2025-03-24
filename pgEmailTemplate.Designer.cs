namespace SwiftSend.C_
{
    partial class pgEmailTemplate
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
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            txtMessage = new TextBox();
            btnSave = new Button();
            label4 = new Label();
            txtTemplateTitle = new TextBox();
            comboBoxTemplates = new ComboBox();
            txtTemplateName = new TextBox();
            btnBack = new Button();
            btnDelete = new Button();
            btnInsert = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(51, 51, 51);
            label2.Location = new Point(48, 61);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(275, 48);
            label2.TabIndex = 1;
            label2.Text = "Email Template";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(51, 51, 51);
            label1.Location = new Point(34, 158);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(196, 28);
            label1.TabIndex = 7;
            label1.Text = "Email Template name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(51, 51, 51);
            label3.Location = new Point(99, 262);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(224, 28);
            label3.TabIndex = 8;
            label3.Text = "Email Template Message";
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(97, 310);
            txtMessage.Margin = new Padding(4, 5, 4, 5);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(708, 322);
            txtMessage.TabIndex = 10;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Purple;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(870, 407);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(129, 67);
            btnSave.TabIndex = 13;
            btnSave.Text = "Save Template";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(51, 51, 51);
            label4.Location = new Point(48, 215);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(133, 28);
            label4.TabIndex = 14;
            label4.Text = "Template Title";
            // 
            // txtTemplateTitle
            // 
            txtTemplateTitle.Location = new Point(209, 215);
            txtTemplateTitle.Margin = new Padding(4, 5, 4, 5);
            txtTemplateTitle.Name = "txtTemplateTitle";
            txtTemplateTitle.Size = new Size(341, 31);
            txtTemplateTitle.TabIndex = 15;
            // 
            // comboBoxTemplates
            // 
            comboBoxTemplates.FormattingEnabled = true;
            comboBoxTemplates.Location = new Point(854, 158);
            comboBoxTemplates.Name = "comboBoxTemplates";
            comboBoxTemplates.Size = new Size(170, 33);
            comboBoxTemplates.TabIndex = 19;
            comboBoxTemplates.SelectedIndexChanged += comboBoxTemplates_SelectedIndexChanged;
            // 
            // txtTemplateName
            // 
            txtTemplateName.Location = new Point(256, 159);
            txtTemplateName.Name = "txtTemplateName";
            txtTemplateName.Size = new Size(150, 31);
            txtTemplateName.TabIndex = 20;
            txtTemplateName.TextChanged += txtTemplateName_TextChanged;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(112, 34);
            btnBack.TabIndex = 21;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click_1;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Purple;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(870, 507);
            btnDelete.Margin = new Padding(4, 5, 4, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(129, 67);
            btnDelete.TabIndex = 22;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click_1;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.Purple;
            btnInsert.ForeColor = Color.White;
            btnInsert.Location = new Point(870, 310);
            btnInsert.Margin = new Padding(4, 5, 4, 5);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(129, 67);
            btnInsert.TabIndex = 23;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            btnInsert.Click += btnInsert_Click;
            // 
            // pgEmailTemplate
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkViolet;
            ClientSize = new Size(1149, 750);
            Controls.Add(btnInsert);
            Controls.Add(btnDelete);
            Controls.Add(btnBack);
            Controls.Add(txtTemplateName);
            Controls.Add(comboBoxTemplates);
            Controls.Add(txtTemplateTitle);
            Controls.Add(label4);
            Controls.Add(btnSave);
            Controls.Add(txtMessage);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Margin = new Padding(4, 5, 4, 5);
            Name = "pgEmailTemplate";
            Text = "pgEmailTemplate";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private Label label3;
        private TextBox txtMessage;
        private Button btnSave;
        private Label label4;
        private TextBox txtTemplateTitle;
        private ComboBox comboBoxTemplates;
        private TextBox txtTemplateName;
        private Button btnBack;
        private Button btnDelete;
        private Button btnInsert;
    }
}