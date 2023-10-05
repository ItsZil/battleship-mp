﻿namespace ClientApp.Forms
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
            gameBoardLeft = new TableLayoutPanel();
            gameBoardRight = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            readyButton = new Button();
            label3 = new Label();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label4 = new Label();
            placeShipButton = new Button();
            turnIndicatorLabel = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // gameBoardLeft
            // 
            gameBoardLeft.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            gameBoardLeft.ColumnCount = 6;
            gameBoardLeft.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666718F));
            gameBoardLeft.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            gameBoardLeft.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            gameBoardLeft.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            gameBoardLeft.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            gameBoardLeft.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            gameBoardLeft.Location = new Point(93, 85);
            gameBoardLeft.Margin = new Padding(3, 2, 3, 2);
            gameBoardLeft.Name = "gameBoardLeft";
            gameBoardLeft.RowCount = 6;
            gameBoardLeft.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoardLeft.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoardLeft.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoardLeft.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoardLeft.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoardLeft.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoardLeft.Size = new Size(242, 202);
            gameBoardLeft.TabIndex = 0;
            // 
            // gameBoardRight
            // 
            gameBoardRight.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            gameBoardRight.ColumnCount = 6;
            gameBoardRight.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666718F));
            gameBoardRight.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            gameBoardRight.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            gameBoardRight.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            gameBoardRight.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            gameBoardRight.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6666679F));
            gameBoardRight.Location = new Point(487, 85);
            gameBoardRight.Margin = new Padding(3, 2, 3, 2);
            gameBoardRight.Name = "gameBoardRight";
            gameBoardRight.RowCount = 6;
            gameBoardRight.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoardRight.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoardRight.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoardRight.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoardRight.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoardRight.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoardRight.Size = new Size(247, 202);
            gameBoardRight.TabIndex = 36;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(182, 52);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 37;
            label1.Text = "Your Board";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(582, 52);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 38;
            label2.Text = "Enemy's Board";
            // 
            // readyButton
            // 
            readyButton.Location = new Point(320, 308);
            readyButton.Margin = new Padding(3, 2, 3, 2);
            readyButton.Name = "readyButton";
            readyButton.Size = new Size(168, 22);
            readyButton.TabIndex = 39;
            readyButton.Text = "Ready!";
            readyButton.UseVisualStyleBackColor = true;
            readyButton.Click += readyButton_Click;
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
            textBox1.PlaceholderText = "X";
            textBox1.Size = new Size(24, 23);
            textBox1.TabIndex = 42;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(72, 381);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Y";
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
            // placeShipButton
            // 
            placeShipButton.Location = new Point(122, 380);
            placeShipButton.Margin = new Padding(3, 2, 3, 2);
            placeShipButton.Name = "placeShipButton";
            placeShipButton.Size = new Size(82, 22);
            placeShipButton.TabIndex = 45;
            placeShipButton.Text = "Place!";
            placeShipButton.UseVisualStyleBackColor = true;
            placeShipButton.Click += placeShipButton_Click;
            // 
            // turnIndicatorLabel
            // 
            turnIndicatorLabel.Dock = DockStyle.Bottom;
            turnIndicatorLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            turnIndicatorLabel.Location = new Point(3, 0);
            turnIndicatorLabel.Name = "turnIndicatorLabel";
            turnIndicatorLabel.Size = new Size(100, 50);
            turnIndicatorLabel.TabIndex = 46;
            turnIndicatorLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(turnIndicatorLabel);
            flowLayoutPanel1.Location = new Point(364, 102);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(117, 50);
            flowLayoutPanel1.TabIndex = 47;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(853, 410);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(placeShipButton);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(readyButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(gameBoardRight);
            Controls.Add(gameBoardLeft);
            Margin = new Padding(3, 2, 3, 2);
            Name = "GameForm";
            Tag = "1_1";
            Text = "GameForm";
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel gameBoardLeft;
        private TableLayoutPanel gameBoardRight;
        private Label label1;
        private Label label2;
        private Button readyButton;
        private Label label3;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label4;
        private Button placeShipButton;
        private Label turnIndicatorLabel;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}