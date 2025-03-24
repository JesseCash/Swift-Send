namespace SwiftSend.C_
{
    partial class pgMenu
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
            X = new Button();
            Menu = new Label();
            btnEmail = new Button();
            btnAddClass = new Button();
            btnView = new Button();
            btnTemplate = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // X
            // 
            X.BackColor = Color.Fuchsia;
            X.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            X.ForeColor = Color.FromArgb(51, 51, 51);
            X.Location = new Point(1089, 20);
            X.Margin = new Padding(4, 5, 4, 5);
            X.Name = "X";
            X.Size = new Size(37, 40);
            X.TabIndex = 0;
            X.Text = "X";
            X.UseVisualStyleBackColor = false;
            X.Click += X_Click;
            // 
            // Menu
            // 
            Menu.AutoSize = true;
            Menu.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            Menu.ForeColor = Color.FromArgb(51, 51, 51);
            Menu.Location = new Point(117, 100);
            Menu.Margin = new Padding(4, 0, 4, 0);
            Menu.Name = "Menu";
            Menu.Size = new Size(117, 48);
            Menu.TabIndex = 1;
            Menu.Text = "Menu";
            Menu.Click += Menu_Click;
            // 
            // btnEmail
            // 
            btnEmail.BackColor = Color.Purple;
            btnEmail.Location = new Point(837, 203);
            btnEmail.Margin = new Padding(4, 5, 4, 5);
            btnEmail.Name = "btnEmail";
            btnEmail.Size = new Size(40, 47);
            btnEmail.TabIndex = 2;
            btnEmail.UseVisualStyleBackColor = false;
            btnEmail.Click += btnEmail_Click;
            // 
            // btnAddClass
            // 
            btnAddClass.BackColor = Color.Purple;
            btnAddClass.Location = new Point(837, 280);
            btnAddClass.Margin = new Padding(4, 5, 4, 5);
            btnAddClass.Name = "btnAddClass";
            btnAddClass.Size = new Size(40, 47);
            btnAddClass.TabIndex = 3;
            btnAddClass.UseVisualStyleBackColor = false;
            btnAddClass.Click += btnAddClass_Click;
            // 
            // btnView
            // 
            btnView.BackColor = Color.Purple;
            btnView.Location = new Point(837, 355);
            btnView.Margin = new Padding(4, 5, 4, 5);
            btnView.Name = "btnView";
            btnView.Size = new Size(40, 47);
            btnView.TabIndex = 4;
            btnView.UseVisualStyleBackColor = false;
            btnView.Click += btnView_Click;
            // 
            // btnTemplate
            // 
            btnTemplate.BackColor = Color.Purple;
            btnTemplate.Location = new Point(837, 432);
            btnTemplate.Margin = new Padding(4, 5, 4, 5);
            btnTemplate.Name = "btnTemplate";
            btnTemplate.Size = new Size(40, 47);
            btnTemplate.TabIndex = 5;
            btnTemplate.UseVisualStyleBackColor = false;
            btnTemplate.Click += btnTemplate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(51, 51, 51);
            label1.Location = new Point(117, 202);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(291, 40);
            label1.TabIndex = 6;
            label1.Text = "Email communication";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(51, 51, 51);
            label2.Location = new Point(117, 278);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(160, 40);
            label2.TabIndex = 7;
            label2.Text = "Add a class";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(51, 51, 51);
            label3.Location = new Point(117, 353);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(194, 40);
            label3.TabIndex = 8;
            label3.Text = "View students";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(51, 51, 51);
            label4.Location = new Point(117, 430);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(269, 40);
            label4.TabIndex = 9;
            label4.Text = "Add email template";
            // 
            // pgMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumSlateBlue;
            ClientSize = new Size(1143, 750);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnTemplate);
            Controls.Add(btnView);
            Controls.Add(btnAddClass);
            Controls.Add(btnEmail);
            Controls.Add(Menu);
            Controls.Add(X);
            Margin = new Padding(4, 5, 4, 5);
            Name = "pgMenu";
            Text = "Form1";
            Load += pgMenu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button X;
        private Label Menu;
        private Button btnEmail;
        private Button btnAddClass;
        private Button btnView;
        private Button btnTemplate;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}