namespace SwiftSend.C_
{
    partial class pgClasses
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
            Menu = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtClid = new TextBox();
            txtClassName = new TextBox();
            txtYearGroup = new TextBox();
            txtNumber = new TextBox();
            btnFirst = new Button();
            btnLast = new Button();
            btnPrevious = new Button();
            button1 = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // Menu
            // 
            Menu.AutoSize = true;
            Menu.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            Menu.ForeColor = Color.FromArgb(51, 51, 51);
            Menu.Location = new Point(77, 44);
            Menu.Margin = new Padding(4, 0, 4, 0);
            Menu.Name = "Menu";
            Menu.Size = new Size(138, 48);
            Menu.TabIndex = 14;
            Menu.Text = "Classes";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(51, 51, 51);
            label1.Location = new Point(76, 95);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(324, 40);
            label1.TabIndex = 15;
            label1.Text = "Enter a new class below.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(76, 182);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(30, 25);
            label2.TabIndex = 16;
            label2.Text = "ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(76, 268);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(104, 25);
            label3.TabIndex = 17;
            label3.Text = "Class Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(76, 350);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(99, 25);
            label4.TabIndex = 18;
            label4.Text = "Year Group";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(76, 437);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(138, 25);
            label5.TabIndex = 19;
            label5.Text = "Number in class";
            // 
            // txtClid
            // 
            txtClid.Location = new Point(76, 212);
            txtClid.Margin = new Padding(4, 5, 4, 5);
            txtClid.Name = "txtClid";
            txtClid.Size = new Size(600, 31);
            txtClid.TabIndex = 20;
            // 
            // txtClassName
            // 
            txtClassName.Location = new Point(76, 298);
            txtClassName.Margin = new Padding(4, 5, 4, 5);
            txtClassName.Name = "txtClassName";
            txtClassName.Size = new Size(600, 31);
            txtClassName.TabIndex = 21;
            txtClassName.TextChanged += txtClassName_TextChanged;
            // 
            // txtYearGroup
            // 
            txtYearGroup.Location = new Point(76, 388);
            txtYearGroup.Margin = new Padding(4, 5, 4, 5);
            txtYearGroup.Name = "txtYearGroup";
            txtYearGroup.Size = new Size(600, 31);
            txtYearGroup.TabIndex = 22;
            // 
            // txtNumber
            // 
            txtNumber.Location = new Point(76, 467);
            txtNumber.Margin = new Padding(4, 5, 4, 5);
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new Size(600, 31);
            txtNumber.TabIndex = 23;
            // 
            // btnFirst
            // 
            btnFirst.Location = new Point(863, 204);
            btnFirst.Margin = new Padding(4, 5, 4, 5);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(93, 53);
            btnFirst.TabIndex = 24;
            btnFirst.Text = "First";
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += btnFirst_Click;
            // 
            // btnLast
            // 
            btnLast.Location = new Point(863, 287);
            btnLast.Margin = new Padding(4, 5, 4, 5);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(93, 53);
            btnLast.TabIndex = 26;
            btnLast.Text = "Last";
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += btnLast_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(863, 445);
            btnPrevious.Margin = new Padding(4, 5, 4, 5);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(93, 53);
            btnPrevious.TabIndex = 27;
            btnPrevious.Text = "Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // button1
            // 
            button1.Location = new Point(863, 366);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(93, 53);
            button1.TabIndex = 29;
            button1.Text = "Next";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.Location = new Point(76, 573);
            btnAdd.Margin = new Padding(4, 5, 4, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.RightToLeft = RightToLeft.No;
            btnAdd.Size = new Size(263, 53);
            btnAdd.TabIndex = 30;
            btnAdd.Text = "Add Class";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(224, 224, 224);
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.ForeColor = Color.FromArgb(51, 51, 51);
            btnDelete.Location = new Point(398, 573);
            btnDelete.Margin = new Padding(4, 5, 4, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(278, 53);
            btnDelete.TabIndex = 31;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(112, 34);
            btnBack.TabIndex = 32;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // pgClasses
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkViolet;
            ClientSize = new Size(1143, 750);
            Controls.Add(btnBack);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(button1);
            Controls.Add(btnPrevious);
            Controls.Add(btnLast);
            Controls.Add(btnFirst);
            Controls.Add(txtNumber);
            Controls.Add(txtYearGroup);
            Controls.Add(txtClassName);
            Controls.Add(txtClid);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Menu);
            Margin = new Padding(4, 5, 4, 5);
            Name = "pgClasses";
            Text = "pgClasses";
            Load += pgClasses_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label Menu;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtClid;
        private TextBox txtClassName;
        private TextBox txtYearGroup;
        private TextBox txtNumber;
        private Button btnFirst;
        private Button btnLast;
        private Button btnPrevious;
        private Button btnNew;
        private Button button1;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnBack;
    }
}