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
            BattleshipTitleLabel.Font = new Font("Stencil", 36F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            BattleshipTitleLabel.ForeColor = Color.FromArgb(64, 64, 64);
            BattleshipTitleLabel.Location = new Point(234, 20);
            BattleshipTitleLabel.Name = "BattleshipTitleLabel";
            BattleshipTitleLabel.Size = new Size(322, 57);
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
            tableLayoutPanel1.Location = new Point(12, 116);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 62.8205147F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 37.1794853F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(798, 318);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // JoinServerNameLabel
            // 
            JoinServerNameLabel.Anchor = AnchorStyles.Left;
            JoinServerNameLabel.AutoSize = true;
            JoinServerNameLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            JoinServerNameLabel.Location = new Point(402, 114);
            JoinServerNameLabel.Name = "JoinServerNameLabel";
            JoinServerNameLabel.Size = new Size(103, 20);
            JoinServerNameLabel.TabIndex = 7;
            JoinServerNameLabel.Text = "Server Name:";
            // 
            // JoinGameTitleLabel
            // 
            JoinGameTitleLabel.Anchor = AnchorStyles.None;
            JoinGameTitleLabel.AutoSize = true;
            JoinGameTitleLabel.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            JoinGameTitleLabel.Location = new Point(542, 33);
            JoinGameTitleLabel.Name = "JoinGameTitleLabel";
            JoinGameTitleLabel.Size = new Size(113, 30);
            JoinGameTitleLabel.TabIndex = 1;
            JoinGameTitleLabel.Text = "Join Game";
            // 
            // CreateGameTitleLabel
            // 
            CreateGameTitleLabel.Anchor = AnchorStyles.None;
            CreateGameTitleLabel.AutoSize = true;
            CreateGameTitleLabel.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            CreateGameTitleLabel.Location = new Point(131, 33);
            CreateGameTitleLabel.Name = "CreateGameTitleLabel";
            CreateGameTitleLabel.Size = new Size(137, 30);
            CreateGameTitleLabel.TabIndex = 0;
            CreateGameTitleLabel.Text = "Create Game";
            // 
            // CreateGameNameTextbox
            // 
            CreateGameNameTextbox.Anchor = AnchorStyles.Left;
            CreateGameNameTextbox.BackColor = Color.WhiteSmoke;
            CreateGameNameTextbox.Location = new Point(3, 166);
            CreateGameNameTextbox.Name = "CreateGameNameTextbox";
            CreateGameNameTextbox.Size = new Size(161, 23);
            CreateGameNameTextbox.TabIndex = 3;
            // 
            // CreateServerNameLabel
            // 
            CreateServerNameLabel.Anchor = AnchorStyles.Left;
            CreateServerNameLabel.AutoSize = true;
            CreateServerNameLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            CreateServerNameLabel.Location = new Point(3, 114);
            CreateServerNameLabel.Name = "CreateServerNameLabel";
            CreateServerNameLabel.Size = new Size(103, 20);
            CreateServerNameLabel.TabIndex = 4;
            CreateServerNameLabel.Text = "Server Name:";
            // 
            // CreateServerPasswordLabel
            // 
            CreateServerPasswordLabel.Anchor = AnchorStyles.Left;
            CreateServerPasswordLabel.AutoSize = true;
            CreateServerPasswordLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            CreateServerPasswordLabel.Location = new Point(3, 213);
            CreateServerPasswordLabel.Name = "CreateServerPasswordLabel";
            CreateServerPasswordLabel.Size = new Size(77, 20);
            CreateServerPasswordLabel.TabIndex = 5;
            CreateServerPasswordLabel.Text = "Password:";
            // 
            // CreateGamePasswordTextbox
            // 
            CreateGamePasswordTextbox.Anchor = AnchorStyles.Left;
            CreateGamePasswordTextbox.BackColor = Color.WhiteSmoke;
            CreateGamePasswordTextbox.Location = new Point(3, 247);
            CreateGamePasswordTextbox.Name = "CreateGamePasswordTextbox";
            CreateGamePasswordTextbox.Size = new Size(161, 23);
            CreateGamePasswordTextbox.TabIndex = 6;
            CreateGamePasswordTextbox.UseSystemPasswordChar = true;
            // 
            // JoinGameNameTextbox
            // 
            JoinGameNameTextbox.Anchor = AnchorStyles.Left;
            JoinGameNameTextbox.BackColor = Color.WhiteSmoke;
            JoinGameNameTextbox.Location = new Point(402, 166);
            JoinGameNameTextbox.Name = "JoinGameNameTextbox";
            JoinGameNameTextbox.Size = new Size(161, 23);
            JoinGameNameTextbox.TabIndex = 8;
            // 
            // JoinGamePasswordLabel
            // 
            JoinGamePasswordLabel.Anchor = AnchorStyles.Left;
            JoinGamePasswordLabel.AutoSize = true;
            JoinGamePasswordLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            JoinGamePasswordLabel.Location = new Point(402, 213);
            JoinGamePasswordLabel.Name = "JoinGamePasswordLabel";
            JoinGamePasswordLabel.Size = new Size(77, 20);
            JoinGamePasswordLabel.TabIndex = 9;
            JoinGamePasswordLabel.Text = "Password:";
            // 
            // JoinGamePasswordTextbox
            // 
            JoinGamePasswordTextbox.Anchor = AnchorStyles.Left;
            JoinGamePasswordTextbox.BackColor = Color.WhiteSmoke;
            JoinGamePasswordTextbox.Location = new Point(402, 247);
            JoinGamePasswordTextbox.Name = "JoinGamePasswordTextbox";
            JoinGamePasswordTextbox.Size = new Size(161, 23);
            JoinGamePasswordTextbox.TabIndex = 10;
            JoinGamePasswordTextbox.UseSystemPasswordChar = true;
            // 
            // JoinGameButton
            // 
            JoinGameButton.Anchor = AnchorStyles.None;
            JoinGameButton.Location = new Point(528, 284);
            JoinGameButton.Name = "JoinGameButton";
            JoinGameButton.Size = new Size(141, 23);
            JoinGameButton.TabIndex = 11;
            JoinGameButton.Text = "Join";
            JoinGameButton.UseVisualStyleBackColor = true;
            // 
            // CreateGameButton
            // 
            CreateGameButton.Anchor = AnchorStyles.None;
            CreateGameButton.Location = new Point(129, 284);
            CreateGameButton.Name = "CreateGameButton";
            CreateGameButton.Size = new Size(141, 23);
            CreateGameButton.TabIndex = 2;
            CreateGameButton.Text = "Create";
            CreateGameButton.UseVisualStyleBackColor = true;
            // 
            // StartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(822, 471);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(BattleshipTitleLabel);
            Name = "StartForm";
            Text = "Battleship";
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