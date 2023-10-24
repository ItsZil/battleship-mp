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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            tableLayoutPanel1 = new TableLayoutPanel();
            CreateGamePasswordTextbox = new TextBox();
            JoinGamePasswordTextbox = new TextBox();
            JoinGameButton = new Button();
            CreateGameButton = new Button();
            CreateGameNameTextbox = new TextBox();
            JoinGameNameTextbox = new TextBox();
            CreateGameTitleLabel = new Components.CustomOutlinedLabel();
            JoinGameTitleLabel = new Components.CustomOutlinedLabel();
            JoinServerNameLabel = new Components.CustomOutlinedLabel();
            CreateServerNameLabel = new Components.CustomOutlinedLabel();
            CreateServerPasswordLabel = new Components.CustomOutlinedLabel();
            JoinGamePasswordLabel = new Components.CustomOutlinedLabel();
            createGameLevelComboBox = new ComboBox();
            BattleshipTitleLabel = new Components.CustomOutlinedLabel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(CreateGamePasswordTextbox, 0, 4);
            tableLayoutPanel1.Controls.Add(JoinGamePasswordTextbox, 1, 4);
            tableLayoutPanel1.Controls.Add(JoinGameButton, 1, 5);
            tableLayoutPanel1.Controls.Add(CreateGameButton, 0, 5);
            tableLayoutPanel1.Controls.Add(CreateGameNameTextbox, 0, 2);
            tableLayoutPanel1.Controls.Add(JoinGameNameTextbox, 1, 2);
            tableLayoutPanel1.Controls.Add(CreateGameTitleLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(JoinGameTitleLabel, 1, 0);
            tableLayoutPanel1.Controls.Add(JoinServerNameLabel, 1, 1);
            tableLayoutPanel1.Controls.Add(CreateServerNameLabel, 0, 1);
            tableLayoutPanel1.Controls.Add(CreateServerPasswordLabel, 0, 3);
            tableLayoutPanel1.Controls.Add(JoinGamePasswordLabel, 1, 3);
            tableLayoutPanel1.Controls.Add(createGameLevelComboBox, 0, 6);
            tableLayoutPanel1.Location = new Point(14, 155);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 62.8205147F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 37.1794853F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 67F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel1.Size = new Size(912, 457);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // CreateGamePasswordTextbox
            // 
            CreateGamePasswordTextbox.Anchor = AnchorStyles.None;
            CreateGamePasswordTextbox.BackColor = Color.WhiteSmoke;
            CreateGamePasswordTextbox.Location = new Point(136, 339);
            CreateGamePasswordTextbox.Margin = new Padding(3, 4, 3, 4);
            CreateGamePasswordTextbox.Name = "CreateGamePasswordTextbox";
            CreateGamePasswordTextbox.Size = new Size(183, 27);
            CreateGamePasswordTextbox.TabIndex = 6;
            CreateGamePasswordTextbox.UseSystemPasswordChar = true;
            // 
            // JoinGamePasswordTextbox
            // 
            JoinGamePasswordTextbox.Anchor = AnchorStyles.None;
            JoinGamePasswordTextbox.BackColor = Color.White;
            JoinGamePasswordTextbox.Location = new Point(592, 339);
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
            // CreateGameNameTextbox
            // 
            CreateGameNameTextbox.Anchor = AnchorStyles.None;
            CreateGameNameTextbox.BackColor = Color.WhiteSmoke;
            CreateGameNameTextbox.Location = new Point(136, 233);
            CreateGameNameTextbox.Margin = new Padding(3, 4, 3, 4);
            CreateGameNameTextbox.Name = "CreateGameNameTextbox";
            CreateGameNameTextbox.Size = new Size(183, 27);
            CreateGameNameTextbox.TabIndex = 3;
            // 
            // JoinGameNameTextbox
            // 
            JoinGameNameTextbox.Anchor = AnchorStyles.None;
            JoinGameNameTextbox.BackColor = Color.WhiteSmoke;
            JoinGameNameTextbox.Location = new Point(592, 233);
            JoinGameNameTextbox.Margin = new Padding(3, 4, 3, 4);
            JoinGameNameTextbox.Name = "JoinGameNameTextbox";
            JoinGameNameTextbox.Size = new Size(183, 27);
            JoinGameNameTextbox.TabIndex = 8;
            // 
            // CreateGameTitleLabel
            // 
            CreateGameTitleLabel.Anchor = AnchorStyles.None;
            CreateGameTitleLabel.AutoSize = true;
            CreateGameTitleLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            CreateGameTitleLabel.ForeColor = Color.Coral;
            CreateGameTitleLabel.Location = new Point(122, 44);
            CreateGameTitleLabel.Name = "CreateGameTitleLabel";
            CreateGameTitleLabel.Size = new Size(211, 46);
            CreateGameTitleLabel.TabIndex = 12;
            CreateGameTitleLabel.Text = "Create game";
            CreateGameTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            CreateGameTitleLabel.TextOutlineColor = Color.Black;
            // 
            // JoinGameTitleLabel
            // 
            JoinGameTitleLabel.Anchor = AnchorStyles.None;
            JoinGameTitleLabel.AutoSize = true;
            JoinGameTitleLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            JoinGameTitleLabel.ForeColor = Color.Coral;
            JoinGameTitleLabel.Location = new Point(598, 44);
            JoinGameTitleLabel.Name = "JoinGameTitleLabel";
            JoinGameTitleLabel.Size = new Size(172, 46);
            JoinGameTitleLabel.TabIndex = 13;
            JoinGameTitleLabel.Text = "Join game";
            JoinGameTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            JoinGameTitleLabel.TextOutlineColor = Color.Black;
            // 
            // JoinServerNameLabel
            // 
            JoinServerNameLabel.Anchor = AnchorStyles.None;
            JoinServerNameLabel.AutoSize = true;
            JoinServerNameLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            JoinServerNameLabel.ForeColor = Color.Coral;
            JoinServerNameLabel.Location = new Point(619, 161);
            JoinServerNameLabel.Name = "JoinServerNameLabel";
            JoinServerNameLabel.Size = new Size(129, 25);
            JoinServerNameLabel.TabIndex = 14;
            JoinServerNameLabel.Text = "Server Name:";
            JoinServerNameLabel.TextOutlineColor = Color.Black;
            // 
            // CreateServerNameLabel
            // 
            CreateServerNameLabel.Anchor = AnchorStyles.None;
            CreateServerNameLabel.AutoSize = true;
            CreateServerNameLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            CreateServerNameLabel.ForeColor = Color.Coral;
            CreateServerNameLabel.Location = new Point(163, 161);
            CreateServerNameLabel.Name = "CreateServerNameLabel";
            CreateServerNameLabel.Size = new Size(129, 25);
            CreateServerNameLabel.TabIndex = 15;
            CreateServerNameLabel.Text = "Server Name:";
            CreateServerNameLabel.TextOutlineColor = Color.Black;
            // 
            // CreateServerPasswordLabel
            // 
            CreateServerPasswordLabel.Anchor = AnchorStyles.None;
            CreateServerPasswordLabel.AutoSize = true;
            CreateServerPasswordLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            CreateServerPasswordLabel.ForeColor = Color.Coral;
            CreateServerPasswordLabel.Location = new Point(180, 295);
            CreateServerPasswordLabel.Name = "CreateServerPasswordLabel";
            CreateServerPasswordLabel.Size = new Size(96, 25);
            CreateServerPasswordLabel.TabIndex = 16;
            CreateServerPasswordLabel.Text = "Password:";
            CreateServerPasswordLabel.TextOutlineColor = Color.Black;
            // 
            // JoinGamePasswordLabel
            // 
            JoinGamePasswordLabel.Anchor = AnchorStyles.None;
            JoinGamePasswordLabel.AutoSize = true;
            JoinGamePasswordLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            JoinGamePasswordLabel.ForeColor = Color.Coral;
            JoinGamePasswordLabel.Location = new Point(636, 295);
            JoinGamePasswordLabel.Name = "JoinGamePasswordLabel";
            JoinGamePasswordLabel.Size = new Size(96, 25);
            JoinGamePasswordLabel.TabIndex = 17;
            JoinGamePasswordLabel.Text = "Password:";
            JoinGamePasswordLabel.TextOutlineColor = Color.Black;
            // 
            // createGameLevelComboBox
            // 
            createGameLevelComboBox.Anchor = AnchorStyles.None;
            createGameLevelComboBox.FormattingEnabled = true;
            createGameLevelComboBox.Items.AddRange(new object[] { "Basic Level", "Enhanced Level", "Advanced Level", "Expert Level" });
            createGameLevelComboBox.Location = new Point(147, 423);
            createGameLevelComboBox.Margin = new Padding(3, 4, 3, 4);
            createGameLevelComboBox.Name = "createGameLevelComboBox";
            createGameLevelComboBox.Size = new Size(161, 28);
            createGameLevelComboBox.TabIndex = 18;
            // 
            // BattleshipTitleLabel
            // 
            BattleshipTitleLabel.AutoSize = true;
            BattleshipTitleLabel.BackColor = Color.Transparent;
            BattleshipTitleLabel.Font = new Font("Verdana", 48F, FontStyle.Underline, GraphicsUnit.Point);
            BattleshipTitleLabel.ForeColor = Color.Coral;
            BattleshipTitleLabel.Location = new Point(313, 36);
            BattleshipTitleLabel.Name = "BattleshipTitleLabel";
            BattleshipTitleLabel.Size = new Size(442, 97);
            BattleshipTitleLabel.TabIndex = 4;
            BattleshipTitleLabel.Text = "Battleship";
            BattleshipTitleLabel.TextOutlineColor = Color.Black;
            // 
            // StartForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(939, 628);
            Controls.Add(BattleshipTitleLabel);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "StartForm";
            Text = "Battleship";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox CreateGameNameTextbox;
        private Button CreateGameButton;
        private TextBox CreateGamePasswordTextbox;
        private TextBox JoinGameNameTextbox;
        private TextBox JoinGamePasswordTextbox;
        private Button JoinGameButton;
        private Components.CustomOutlinedLabel BattleshipTitleLabel;
        private Components.CustomOutlinedLabel CreateGameTitleLabel;
        private Components.CustomOutlinedLabel JoinGameTitleLabel;
        private Components.CustomOutlinedLabel JoinServerNameLabel;
        private Components.CustomOutlinedLabel CreateServerNameLabel;
        private Components.CustomOutlinedLabel CreateServerPasswordLabel;
        private Components.CustomOutlinedLabel JoinGamePasswordLabel;
        private ComboBox createGameLevelComboBox;
    }
}