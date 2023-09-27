namespace ClientApp.Forms
{
    partial class GameForm
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
            gameBoard1 = new TableLayoutPanel();
            gameBoard2 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            label3 = new Label();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label4 = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // gameBoard1
            // 
            gameBoard1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            gameBoard1.ColumnCount = 6;
            gameBoard1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666718F));
            gameBoard1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            gameBoard1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            gameBoard1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            gameBoard1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            gameBoard1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            gameBoard1.Location = new Point(93, 85);
            gameBoard1.Margin = new Padding(3, 2, 3, 2);
            gameBoard1.Name = "gameBoard1";
            gameBoard1.RowCount = 6;
            gameBoard1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoard1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoard1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoard1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoard1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoard1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoard1.Size = new Size(242, 202);
            gameBoard1.TabIndex = 0;
            // 
            // gameBoard2
            // 
            gameBoard2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            gameBoard2.ColumnCount = 6;
            gameBoard2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666718F));
            gameBoard2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            gameBoard2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            gameBoard2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            gameBoard2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            gameBoard2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            gameBoard2.Location = new Point(487, 85);
            gameBoard2.Margin = new Padding(3, 2, 3, 2);
            gameBoard2.Name = "gameBoard2";
            gameBoard2.RowCount = 6;
            gameBoard2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoard2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoard2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoard2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoard2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoard2.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoard2.Size = new Size(247, 202);
            gameBoard2.TabIndex = 36;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(159, 52);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 37;
            label1.Text = "Your Board";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(563, 52);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 38;
            label2.Text = "Enemy's Board";
            // 
            // button1
            // 
            button1.Location = new Point(320, 308);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(168, 22);
            button1.TabIndex = 39;
            button1.Text = "Ready!";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 310);
            label3.Name = "label3";
            label3.Size = new Size(89, 15);
            label3.TabIndex = 40;
            label3.Text = "Available Ships:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "One piece", "Two piece (horizontal)", "Two piece (vertical)", "Three piece (vertical)" });
            comboBox1.Location = new Point(32, 328);
            comboBox1.Margin = new Padding(3, 2, 3, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(133, 23);
            comboBox1.TabIndex = 41;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(32, 381);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(24, 23);
            textBox1.TabIndex = 42;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(72, 381);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(22, 23);
            textBox2.TabIndex = 43;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 357);
            label4.Name = "label4";
            label4.Size = new Size(147, 15);
            label4.TabIndex = 44;
            label4.Text = "Enter starting Coordinates:";
            // 
            // button2
            // 
            button2.Location = new Point(122, 380);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(82, 22);
            button2.TabIndex = 45;
            button2.Text = "Place!";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(853, 410);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(gameBoard2);
            Controls.Add(gameBoard1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "GameForm";
            Tag = "1_1";
            Text = "GameForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel gameBoard1;
        private TableLayoutPanel gameBoard2;
        private Label label1;
        private Label label2;
        private Button button1;
        private Label label3;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label4;
        private Button button2;
    }
}