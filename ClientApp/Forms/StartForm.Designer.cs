﻿namespace ClientApp
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
            startEmptyGameButton = new Button();
            startPlacedShipsGameButton = new Button();
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
            tableLayoutPanel1.Location = new Point(12, 116);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 62.8205147F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 37.1794853F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(798, 343);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // CreateGamePasswordTextbox
            // 
            CreateGamePasswordTextbox.Anchor = AnchorStyles.None;
            CreateGamePasswordTextbox.BackColor = Color.WhiteSmoke;
            CreateGamePasswordTextbox.Location = new Point(119, 252);
            CreateGamePasswordTextbox.Name = "CreateGamePasswordTextbox";
            CreateGamePasswordTextbox.Size = new Size(161, 23);
            CreateGamePasswordTextbox.TabIndex = 6;
            CreateGamePasswordTextbox.UseSystemPasswordChar = true;
            // 
            // JoinGamePasswordTextbox
            // 
            JoinGamePasswordTextbox.Anchor = AnchorStyles.None;
            JoinGamePasswordTextbox.BackColor = Color.White;
            JoinGamePasswordTextbox.Location = new Point(518, 252);
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
            JoinGameButton.Click += JoinGameButton_Click;
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
            CreateGameButton.Click += CreateGameButton_Click;
            // 
            // CreateGameNameTextbox
            // 
            CreateGameNameTextbox.Anchor = AnchorStyles.None;
            CreateGameNameTextbox.BackColor = Color.WhiteSmoke;
            CreateGameNameTextbox.Location = new Point(119, 171);
            CreateGameNameTextbox.Name = "CreateGameNameTextbox";
            CreateGameNameTextbox.Size = new Size(161, 23);
            CreateGameNameTextbox.TabIndex = 3;
            // 
            // JoinGameNameTextbox
            // 
            JoinGameNameTextbox.Anchor = AnchorStyles.None;
            JoinGameNameTextbox.BackColor = Color.WhiteSmoke;
            JoinGameNameTextbox.Location = new Point(518, 171);
            JoinGameNameTextbox.Name = "JoinGameNameTextbox";
            JoinGameNameTextbox.Size = new Size(161, 23);
            JoinGameNameTextbox.TabIndex = 8;
            // 
            // CreateGameTitleLabel
            // 
            CreateGameTitleLabel.Anchor = AnchorStyles.None;
            CreateGameTitleLabel.AutoSize = true;
            CreateGameTitleLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            CreateGameTitleLabel.ForeColor = Color.Coral;
            CreateGameTitleLabel.Location = new Point(115, 31);
            CreateGameTitleLabel.Name = "CreateGameTitleLabel";
            CreateGameTitleLabel.Size = new Size(168, 37);
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
            JoinGameTitleLabel.Location = new Point(529, 31);
            JoinGameTitleLabel.Name = "JoinGameTitleLabel";
            JoinGameTitleLabel.Size = new Size(139, 37);
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
            JoinServerNameLabel.Location = new Point(547, 118);
            JoinServerNameLabel.Name = "JoinServerNameLabel";
            JoinServerNameLabel.Size = new Size(103, 20);
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
            CreateServerNameLabel.Location = new Point(148, 118);
            CreateServerNameLabel.Name = "CreateServerNameLabel";
            CreateServerNameLabel.Size = new Size(103, 20);
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
            CreateServerPasswordLabel.Location = new Point(161, 218);
            CreateServerPasswordLabel.Name = "CreateServerPasswordLabel";
            CreateServerPasswordLabel.Size = new Size(77, 20);
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
            JoinGamePasswordLabel.Location = new Point(560, 218);
            JoinGamePasswordLabel.Name = "JoinGamePasswordLabel";
            JoinGamePasswordLabel.Size = new Size(77, 20);
            JoinGamePasswordLabel.TabIndex = 17;
            JoinGamePasswordLabel.Text = "Password:";
            JoinGamePasswordLabel.TextOutlineColor = Color.Black;
            // 
            // createGameLevelComboBox
            // 
            createGameLevelComboBox.Anchor = AnchorStyles.None;
            createGameLevelComboBox.FormattingEnabled = true;
            createGameLevelComboBox.Items.AddRange(new object[] { "Basic Level", "Enhanced Level", "Advanced Level", "Expert Level" });
            createGameLevelComboBox.Location = new Point(129, 316);
            createGameLevelComboBox.Name = "createGameLevelComboBox";
            createGameLevelComboBox.Size = new Size(141, 23);
            createGameLevelComboBox.TabIndex = 18;
            // 
            // BattleshipTitleLabel
            // 
            BattleshipTitleLabel.AutoSize = true;
            BattleshipTitleLabel.BackColor = Color.Transparent;
            BattleshipTitleLabel.Font = new Font("Verdana", 48F, FontStyle.Underline, GraphicsUnit.Point);
            BattleshipTitleLabel.ForeColor = Color.Coral;
            BattleshipTitleLabel.Location = new Point(274, 27);
            BattleshipTitleLabel.Name = "BattleshipTitleLabel";
            BattleshipTitleLabel.Size = new Size(353, 78);
            BattleshipTitleLabel.TabIndex = 4;
            BattleshipTitleLabel.Text = "Battleship";
            BattleshipTitleLabel.TextOutlineColor = Color.Black;
            // 
            // startEmptyGameButton
            // 
            startEmptyGameButton.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            startEmptyGameButton.Location = new Point(687, 12);
            startEmptyGameButton.Name = "startEmptyGameButton";
            startEmptyGameButton.Size = new Size(123, 23);
            startEmptyGameButton.TabIndex = 5;
            startEmptyGameButton.Text = "Empty Expert Prot.";
            startEmptyGameButton.UseVisualStyleBackColor = true;
            startEmptyGameButton.Click += startEmptyGameButton_Click;
            // 
            // startPlacedShipsGameButton
            // 
            startPlacedShipsGameButton.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            startPlacedShipsGameButton.Location = new Point(687, 41);
            startPlacedShipsGameButton.Name = "startPlacedShipsGameButton";
            startPlacedShipsGameButton.Size = new Size(123, 23);
            startPlacedShipsGameButton.TabIndex = 6;
            startPlacedShipsGameButton.Text = "Ships Expert Prot.";
            startPlacedShipsGameButton.UseVisualStyleBackColor = true;
            startPlacedShipsGameButton.Click += startPlacedShipsGameButton_Click;
            // 
            // StartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(822, 471);
            Controls.Add(startPlacedShipsGameButton);
            Controls.Add(startEmptyGameButton);
            Controls.Add(BattleshipTitleLabel);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
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
        private Button startEmptyGameButton;
        private Button startPlacedShipsGameButton;
    }
}