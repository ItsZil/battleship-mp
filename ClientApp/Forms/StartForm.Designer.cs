namespace ClientApp
{
    partial class StartForm
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
            BattleshipTitleLabel = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            JoinServerNameLabel = new Label();
            JoinGameTitleLabel = new Label();
            CreateGameTitleLabel = new Label();
            CreateGameNameTextbox = new TextBox();
            CreateServerNameLabel = new Label();
            CreateServerPasswordLabel = new Label();
            CreateGamePasswordTextbox = new TextBox();
            JoinGameNameTextbox = new TextBox();
            JoinGamePasswordLabel = new Label();
            JoinGamePasswordTextbox = new TextBox();
            JoinGameButton = new Button();
            CreateGameButton = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // BattleshipTitleLabel
            // 
            BattleshipTitleLabel.AutoSize = true;
            BattleshipTitleLabel.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            BattleshipTitleLabel.ForeColor = Color.FromArgb(64, 64, 64);
            BattleshipTitleLabel.Location = new Point(267, 27);
            BattleshipTitleLabel.Name = "BattleshipTitleLabel";
            BattleshipTitleLabel.Size = new Size(302, 69);
            BattleshipTitleLabel.TabIndex = 2;
            BattleshipTitleLabel.Text = "Battleship";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.None;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(JoinServerNameLabel, 1, 1);
            tableLayoutPanel1.Controls.Add(JoinGameTitleLabel, 1, 0);
            tableLayoutPanel1.Controls.Add(CreateGameTitleLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(CreateGameNameTextbox, 0, 2);
            tableLayoutPanel1.Controls.Add(CreateServerNameLabel, 0, 1);
            tableLayoutPanel1.Controls.Add(CreateServerPasswordLabel, 0, 3);
            tableLayoutPanel1.Controls.Add(CreateGamePasswordTextbox, 0, 4);
            tableLayoutPanel1.Controls.Add(JoinGameNameTextbox, 1, 2);
            tableLayoutPanel1.Controls.Add(JoinGamePasswordLabel, 1, 3);
            tableLayoutPanel1.Controls.Add(JoinGamePasswordTextbox, 1, 4);
            tableLayoutPanel1.Controls.Add(JoinGameButton, 1, 5);
            tableLayoutPanel1.Controls.Add(CreateGameButton, 0, 5);
            tableLayoutPanel1.Location = new Point(14, 155);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 62.8205147F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 37.1794853F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 67F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 59F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel1.Size = new Size(912, 424);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // JoinServerNameLabel
            // 
            JoinServerNameLabel.Anchor = AnchorStyles.Left;
            JoinServerNameLabel.AutoSize = true;
            JoinServerNameLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            JoinServerNameLabel.Location = new Point(459, 156);
            JoinServerNameLabel.Name = "JoinServerNameLabel";
            JoinServerNameLabel.Size = new Size(129, 25);
            JoinServerNameLabel.TabIndex = 7;
            JoinServerNameLabel.Text = "Server Name:";
            // 
            // JoinGameTitleLabel
            // 
            JoinGameTitleLabel.Anchor = AnchorStyles.None;
            JoinGameTitleLabel.AutoSize = true;
            JoinGameTitleLabel.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            JoinGameTitleLabel.Location = new Point(611, 46);
            JoinGameTitleLabel.Name = "JoinGameTitleLabel";
            JoinGameTitleLabel.Size = new Size(145, 37);
            JoinGameTitleLabel.TabIndex = 1;
            JoinGameTitleLabel.Text = "Join Game";
            // 
            // CreateGameTitleLabel
            // 
            CreateGameTitleLabel.Anchor = AnchorStyles.None;
            CreateGameTitleLabel.AutoSize = true;
            CreateGameTitleLabel.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            CreateGameTitleLabel.Location = new Point(141, 46);
            CreateGameTitleLabel.Name = "CreateGameTitleLabel";
            CreateGameTitleLabel.Size = new Size(174, 37);
            CreateGameTitleLabel.TabIndex = 0;
            CreateGameTitleLabel.Text = "Create Game";
            // 
            // CreateGameNameTextbox
            // 
            CreateGameNameTextbox.Anchor = AnchorStyles.Left;
            CreateGameNameTextbox.BackColor = Color.WhiteSmoke;
            CreateGameNameTextbox.Location = new Point(3, 227);
            CreateGameNameTextbox.Margin = new Padding(3, 4, 3, 4);
            CreateGameNameTextbox.Name = "CreateGameNameTextbox";
            CreateGameNameTextbox.Size = new Size(183, 27);
            CreateGameNameTextbox.TabIndex = 3;
            // 
            // CreateServerNameLabel
            // 
            CreateServerNameLabel.Anchor = AnchorStyles.Left;
            CreateServerNameLabel.AutoSize = true;
            CreateServerNameLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            CreateServerNameLabel.Location = new Point(3, 156);
            CreateServerNameLabel.Name = "CreateServerNameLabel";
            CreateServerNameLabel.Size = new Size(129, 25);
            CreateServerNameLabel.TabIndex = 4;
            CreateServerNameLabel.Text = "Server Name:";
            // 
            // CreateServerPasswordLabel
            // 
            CreateServerPasswordLabel.Anchor = AnchorStyles.Left;
            CreateServerPasswordLabel.AutoSize = true;
            CreateServerPasswordLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            CreateServerPasswordLabel.Location = new Point(3, 289);
            CreateServerPasswordLabel.Name = "CreateServerPasswordLabel";
            CreateServerPasswordLabel.Size = new Size(96, 25);
            CreateServerPasswordLabel.TabIndex = 5;
            CreateServerPasswordLabel.Text = "Password:";
            // 
            // CreateGamePasswordTextbox
            // 
            CreateGamePasswordTextbox.Anchor = AnchorStyles.Left;
            CreateGamePasswordTextbox.BackColor = Color.WhiteSmoke;
            CreateGamePasswordTextbox.Location = new Point(3, 333);
            CreateGamePasswordTextbox.Margin = new Padding(3, 4, 3, 4);
            CreateGamePasswordTextbox.Name = "CreateGamePasswordTextbox";
            CreateGamePasswordTextbox.Size = new Size(183, 27);
            CreateGamePasswordTextbox.TabIndex = 6;
            CreateGamePasswordTextbox.UseSystemPasswordChar = true;
            // 
            // JoinGameNameTextbox
            // 
            JoinGameNameTextbox.Anchor = AnchorStyles.Left;
            JoinGameNameTextbox.BackColor = Color.WhiteSmoke;
            JoinGameNameTextbox.Location = new Point(459, 227);
            JoinGameNameTextbox.Margin = new Padding(3, 4, 3, 4);
            JoinGameNameTextbox.Name = "JoinGameNameTextbox";
            JoinGameNameTextbox.Size = new Size(183, 27);
            JoinGameNameTextbox.TabIndex = 8;
            // 
            // JoinGamePasswordLabel
            // 
            JoinGamePasswordLabel.Anchor = AnchorStyles.Left;
            JoinGamePasswordLabel.AutoSize = true;
            JoinGamePasswordLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            JoinGamePasswordLabel.Location = new Point(459, 289);
            JoinGamePasswordLabel.Name = "JoinGamePasswordLabel";
            JoinGamePasswordLabel.Size = new Size(96, 25);
            JoinGamePasswordLabel.TabIndex = 9;
            JoinGamePasswordLabel.Text = "Password:";
            // 
            // JoinGamePasswordTextbox
            // 
            JoinGamePasswordTextbox.Anchor = AnchorStyles.Left;
            JoinGamePasswordTextbox.BackColor = Color.WhiteSmoke;
            JoinGamePasswordTextbox.Location = new Point(459, 333);
            JoinGamePasswordTextbox.Margin = new Padding(3, 4, 3, 4);
            JoinGamePasswordTextbox.Name = "JoinGamePasswordTextbox";
            JoinGamePasswordTextbox.Size = new Size(183, 27);
            JoinGamePasswordTextbox.TabIndex = 10;
            JoinGamePasswordTextbox.UseSystemPasswordChar = true;
            // 
            // JoinGameButton
            // 
            JoinGameButton.Anchor = AnchorStyles.None;
            JoinGameButton.Location = new Point(603, 378);
            JoinGameButton.Margin = new Padding(3, 4, 3, 4);
            JoinGameButton.Name = "JoinGameButton";
            JoinGameButton.Size = new Size(161, 31);
            JoinGameButton.TabIndex = 11;
            JoinGameButton.Text = "Join";
            JoinGameButton.UseVisualStyleBackColor = true;
            JoinGameButton.Click += JoinGameButton_Click;
            // 
            // CreateGameButton
            // 
            CreateGameButton.Anchor = AnchorStyles.None;
            CreateGameButton.Location = new Point(147, 378);
            CreateGameButton.Margin = new Padding(3, 4, 3, 4);
            CreateGameButton.Name = "CreateGameButton";
            CreateGameButton.Size = new Size(161, 31);
            CreateGameButton.TabIndex = 2;
            CreateGameButton.Text = "Create";
            CreateGameButton.UseVisualStyleBackColor = true;
            CreateGameButton.Click += CreateGameButton_Click;
            // 
            // StartForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(939, 628);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(BattleshipTitleLabel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "StartForm";
            Text = "Battleship";
            Load += StartForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label BattleshipTitleLabel;
        private TableLayoutPanel tableLayoutPanel1;
        private Label JoinGameTitleLabel;
        private Label CreateGameTitleLabel;
        private TextBox CreateGameNameTextbox;
        private Label CreateServerNameLabel;
        private Button CreateGameButton;
        private Label CreateServerPasswordLabel;
        private TextBox CreateGamePasswordTextbox;
        private Label JoinServerNameLabel;
        private TextBox JoinGameNameTextbox;
        private Label JoinGamePasswordLabel;
        private TextBox JoinGamePasswordTextbox;
        private Button JoinGameButton;
    }
}