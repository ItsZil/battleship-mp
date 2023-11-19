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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            gameBoardLeft = new TableLayoutPanel();
            gameBoardRight = new TableLayoutPanel();
            readyButton = new Button();
            shipPlacementTypeComboBox = new ComboBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            placeShipButton = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            turnIndicatorLabel = new Components.CustomOutlinedLabel();
            interactionModeTableLayoutPanel = new TableLayoutPanel();
            activeModeLabel = new Components.CustomOutlinedLabel();
            shootModeRadioButton = new RadioButton();
            radioButton3 = new RadioButton();
            placeRadarModeButton = new RadioButton();
            remainingItemTableLayoutPanel = new TableLayoutPanel();
            remainingRadarCountLabel = new Components.CustomOutlinedLabel();
            remainingMoveShipsCountLabel = new Components.CustomOutlinedLabel();
            remainingRadarTextLabel = new Components.CustomOutlinedLabel();
            remainingMoveShipsTextLabel = new Components.CustomOutlinedLabel();
            YourBoardLabel = new Components.CustomOutlinedLabel();
            EnemysBoardLabel = new Components.CustomOutlinedLabel();
            AvailableShipsLabel = new Components.CustomOutlinedLabel();
            EnterStartingCoordsLabel = new Components.CustomOutlinedLabel();
            shipGroupComboBox = new ComboBox();
            groupLabel = new Components.CustomOutlinedLabel();
            shootAsGroupCheckBox = new CheckBox();
            shootAsGroupLabel = new Components.CustomOutlinedLabel();
            flowLayoutPanel1.SuspendLayout();
            interactionModeTableLayoutPanel.SuspendLayout();
            remainingItemTableLayoutPanel.SuspendLayout();
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
            gameBoardLeft.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            gameBoardLeft.Location = new Point(93, 70);
            gameBoardLeft.Margin = new Padding(3, 2, 3, 2);
            gameBoardLeft.Name = "gameBoardLeft";
            gameBoardLeft.RowCount = 6;
            gameBoardLeft.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoardLeft.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoardLeft.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoardLeft.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoardLeft.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoardLeft.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoardLeft.Size = new Size(242, 201);
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
            gameBoardRight.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            gameBoardRight.Location = new Point(487, 70);
            gameBoardRight.Margin = new Padding(3, 2, 3, 2);
            gameBoardRight.Name = "gameBoardRight";
            gameBoardRight.RowCount = 6;
            gameBoardRight.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoardRight.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoardRight.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoardRight.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoardRight.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoardRight.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            gameBoardRight.Size = new Size(247, 201);
            gameBoardRight.TabIndex = 36;
            // 
            // readyButton
            // 
            readyButton.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point);
            readyButton.Location = new Point(329, 298);
            readyButton.Margin = new Padding(3, 2, 3, 2);
            readyButton.Name = "readyButton";
            readyButton.Size = new Size(165, 22);
            readyButton.TabIndex = 39;
            readyButton.Text = "Ready!";
            readyButton.UseVisualStyleBackColor = true;
            readyButton.Click += readyButton_Click;
            // 
            // shipPlacementTypeComboBox
            // 
            shipPlacementTypeComboBox.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point);
            shipPlacementTypeComboBox.FormattingEnabled = true;
            shipPlacementTypeComboBox.Items.AddRange(new object[] { "One piece", "Two piece (horizontal)", "Two piece (vertical)", "Three piece (vertical)" });
            shipPlacementTypeComboBox.Location = new Point(32, 316);
            shipPlacementTypeComboBox.Margin = new Padding(3, 2, 3, 2);
            shipPlacementTypeComboBox.Name = "shipPlacementTypeComboBox";
            shipPlacementTypeComboBox.Size = new Size(133, 22);
            shipPlacementTypeComboBox.TabIndex = 41;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(32, 369);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "X";
            textBox1.Size = new Size(24, 22);
            textBox1.TabIndex = 42;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(72, 369);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Y";
            textBox2.Size = new Size(22, 22);
            textBox2.TabIndex = 43;
            // 
            // placeShipButton
            // 
            placeShipButton.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point);
            placeShipButton.Location = new Point(122, 368);
            placeShipButton.Margin = new Padding(3, 2, 3, 2);
            placeShipButton.Name = "placeShipButton";
            placeShipButton.Size = new Size(82, 22);
            placeShipButton.TabIndex = 45;
            placeShipButton.Text = "Place!";
            placeShipButton.UseVisualStyleBackColor = true;
            placeShipButton.Click += placeShipButton_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Controls.Add(turnIndicatorLabel);
            flowLayoutPanel1.Location = new Point(383, 87);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(85, 72);
            flowLayoutPanel1.TabIndex = 47;
            // 
            // turnIndicatorLabel
            // 
            turnIndicatorLabel.AutoSize = true;
            turnIndicatorLabel.BackColor = Color.Transparent;
            turnIndicatorLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            turnIndicatorLabel.ForeColor = Color.Coral;
            turnIndicatorLabel.Location = new Point(0, 0);
            turnIndicatorLabel.Margin = new Padding(0);
            turnIndicatorLabel.Name = "turnIndicatorLabel";
            turnIndicatorLabel.Size = new Size(0, 15);
            turnIndicatorLabel.TabIndex = 54;
            turnIndicatorLabel.TextAlign = ContentAlignment.MiddleCenter;
            turnIndicatorLabel.TextOutlineColor = Color.Black;
            // 
            // interactionModeTableLayoutPanel
            // 
            interactionModeTableLayoutPanel.BackColor = Color.Transparent;
            interactionModeTableLayoutPanel.ColumnCount = 1;
            interactionModeTableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            interactionModeTableLayoutPanel.Controls.Add(activeModeLabel, 0, 0);
            interactionModeTableLayoutPanel.Controls.Add(shootModeRadioButton, 0, 1);
            interactionModeTableLayoutPanel.Controls.Add(radioButton3, 0, 2);
            interactionModeTableLayoutPanel.Controls.Add(placeRadarModeButton, 0, 3);
            interactionModeTableLayoutPanel.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            interactionModeTableLayoutPanel.Location = new Point(367, 168);
            interactionModeTableLayoutPanel.Name = "interactionModeTableLayoutPanel";
            interactionModeTableLayoutPanel.RowCount = 4;
            interactionModeTableLayoutPanel.RowStyles.Add(new RowStyle());
            interactionModeTableLayoutPanel.RowStyles.Add(new RowStyle());
            interactionModeTableLayoutPanel.RowStyles.Add(new RowStyle());
            interactionModeTableLayoutPanel.RowStyles.Add(new RowStyle());
            interactionModeTableLayoutPanel.Size = new Size(107, 89);
            interactionModeTableLayoutPanel.TabIndex = 48;
            interactionModeTableLayoutPanel.Visible = false;
            // 
            // activeModeLabel
            // 
            activeModeLabel.Anchor = AnchorStyles.Left;
            activeModeLabel.AutoSize = true;
            activeModeLabel.BackColor = Color.Transparent;
            activeModeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            activeModeLabel.ForeColor = Color.Coral;
            activeModeLabel.Location = new Point(3, 0);
            activeModeLabel.Name = "activeModeLabel";
            activeModeLabel.Size = new Size(81, 15);
            activeModeLabel.TabIndex = 58;
            activeModeLabel.Text = "Active mode:";
            activeModeLabel.TextOutlineColor = Color.Black;
            // 
            // shootModeRadioButton
            // 
            shootModeRadioButton.AutoSize = true;
            shootModeRadioButton.Checked = true;
            shootModeRadioButton.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            shootModeRadioButton.ForeColor = Color.Coral;
            shootModeRadioButton.Location = new Point(3, 18);
            shootModeRadioButton.Name = "shootModeRadioButton";
            shootModeRadioButton.Size = new Size(63, 18);
            shootModeRadioButton.TabIndex = 0;
            shootModeRadioButton.TabStop = true;
            shootModeRadioButton.Text = "Shoot";
            shootModeRadioButton.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton3.ForeColor = Color.Coral;
            radioButton3.Location = new Point(3, 42);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(93, 18);
            radioButton3.TabIndex = 5;
            radioButton3.Text = "Move Ship";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // placeRadarModeButton
            // 
            placeRadarModeButton.AutoSize = true;
            placeRadarModeButton.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            placeRadarModeButton.ForeColor = Color.Coral;
            placeRadarModeButton.Location = new Point(3, 66);
            placeRadarModeButton.Name = "placeRadarModeButton";
            placeRadarModeButton.Size = new Size(104, 18);
            placeRadarModeButton.TabIndex = 1;
            placeRadarModeButton.Text = "Place Radar";
            placeRadarModeButton.UseVisualStyleBackColor = true;
            // 
            // remainingItemTableLayoutPanel
            // 
            remainingItemTableLayoutPanel.BackColor = Color.Transparent;
            remainingItemTableLayoutPanel.ColumnCount = 2;
            remainingItemTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80.1282043F));
            remainingItemTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.8717957F));
            remainingItemTableLayoutPanel.Controls.Add(remainingRadarCountLabel, 1, 1);
            remainingItemTableLayoutPanel.Controls.Add(remainingMoveShipsCountLabel, 1, 0);
            remainingItemTableLayoutPanel.Controls.Add(remainingRadarTextLabel, 0, 1);
            remainingItemTableLayoutPanel.Controls.Add(remainingMoveShipsTextLabel, 0, 0);
            remainingItemTableLayoutPanel.Location = new Point(527, 298);
            remainingItemTableLayoutPanel.Name = "remainingItemTableLayoutPanel";
            remainingItemTableLayoutPanel.RowCount = 3;
            remainingItemTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            remainingItemTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            remainingItemTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 15F));
            remainingItemTableLayoutPanel.Size = new Size(140, 100);
            remainingItemTableLayoutPanel.TabIndex = 49;
            remainingItemTableLayoutPanel.Visible = false;
            // 
            // remainingRadarCountLabel
            // 
            remainingRadarCountLabel.Anchor = AnchorStyles.None;
            remainingRadarCountLabel.AutoSize = true;
            remainingRadarCountLabel.BackColor = Color.Transparent;
            remainingRadarCountLabel.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            remainingRadarCountLabel.ForeColor = Color.Coral;
            remainingRadarCountLabel.Location = new Point(119, 56);
            remainingRadarCountLabel.Name = "remainingRadarCountLabel";
            remainingRadarCountLabel.Size = new Size(13, 13);
            remainingRadarCountLabel.TabIndex = 57;
            remainingRadarCountLabel.Text = "0";
            remainingRadarCountLabel.TextOutlineColor = Color.Black;
            // 
            // remainingMoveShipsCountLabel
            // 
            remainingMoveShipsCountLabel.Anchor = AnchorStyles.None;
            remainingMoveShipsCountLabel.AutoSize = true;
            remainingMoveShipsCountLabel.BackColor = Color.Transparent;
            remainingMoveShipsCountLabel.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            remainingMoveShipsCountLabel.ForeColor = Color.Coral;
            remainingMoveShipsCountLabel.Location = new Point(119, 14);
            remainingMoveShipsCountLabel.Name = "remainingMoveShipsCountLabel";
            remainingMoveShipsCountLabel.Size = new Size(13, 13);
            remainingMoveShipsCountLabel.TabIndex = 56;
            remainingMoveShipsCountLabel.Text = "0";
            remainingMoveShipsCountLabel.TextOutlineColor = Color.Black;
            // 
            // remainingRadarTextLabel
            // 
            remainingRadarTextLabel.Anchor = AnchorStyles.Left;
            remainingRadarTextLabel.AutoSize = true;
            remainingRadarTextLabel.BackColor = Color.Transparent;
            remainingRadarTextLabel.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            remainingRadarTextLabel.ForeColor = Color.Coral;
            remainingRadarTextLabel.Location = new Point(3, 56);
            remainingRadarTextLabel.Name = "remainingRadarTextLabel";
            remainingRadarTextLabel.Size = new Size(101, 13);
            remainingRadarTextLabel.TabIndex = 55;
            remainingRadarTextLabel.Text = "Remaining radars:";
            remainingRadarTextLabel.TextOutlineColor = Color.Black;
            // 
            // remainingMoveShipsTextLabel
            // 
            remainingMoveShipsTextLabel.Anchor = AnchorStyles.Left;
            remainingMoveShipsTextLabel.AutoSize = true;
            remainingMoveShipsTextLabel.BackColor = Color.Transparent;
            remainingMoveShipsTextLabel.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point);
            remainingMoveShipsTextLabel.ForeColor = Color.Coral;
            remainingMoveShipsTextLabel.Location = new Point(3, 8);
            remainingMoveShipsTextLabel.Name = "remainingMoveShipsTextLabel";
            remainingMoveShipsTextLabel.Size = new Size(91, 26);
            remainingMoveShipsTextLabel.TabIndex = 54;
            remainingMoveShipsTextLabel.Text = "Remaining ship movements:";
            remainingMoveShipsTextLabel.TextOutlineColor = Color.Black;
            // 
            // YourBoardLabel
            // 
            YourBoardLabel.AutoSize = true;
            YourBoardLabel.BackColor = Color.Transparent;
            YourBoardLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            YourBoardLabel.ForeColor = Color.Coral;
            YourBoardLabel.Location = new Point(170, 37);
            YourBoardLabel.Name = "YourBoardLabel";
            YourBoardLabel.Size = new Size(85, 19);
            YourBoardLabel.TabIndex = 50;
            YourBoardLabel.Text = "Your Board";
            YourBoardLabel.TextAlign = ContentAlignment.MiddleCenter;
            YourBoardLabel.TextOutlineColor = Color.Black;
            // 
            // EnemysBoardLabel
            // 
            EnemysBoardLabel.AutoSize = true;
            EnemysBoardLabel.BackColor = Color.Transparent;
            EnemysBoardLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            EnemysBoardLabel.ForeColor = Color.Coral;
            EnemysBoardLabel.Location = new Point(556, 37);
            EnemysBoardLabel.Name = "EnemysBoardLabel";
            EnemysBoardLabel.Size = new Size(107, 19);
            EnemysBoardLabel.TabIndex = 51;
            EnemysBoardLabel.Text = "Enemy's Board";
            EnemysBoardLabel.TextAlign = ContentAlignment.MiddleCenter;
            EnemysBoardLabel.TextOutlineColor = Color.Black;
            // 
            // AvailableShipsLabel
            // 
            AvailableShipsLabel.AutoSize = true;
            AvailableShipsLabel.BackColor = Color.Transparent;
            AvailableShipsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            AvailableShipsLabel.ForeColor = Color.Coral;
            AvailableShipsLabel.Location = new Point(32, 298);
            AvailableShipsLabel.Name = "AvailableShipsLabel";
            AvailableShipsLabel.Size = new Size(92, 15);
            AvailableShipsLabel.TabIndex = 52;
            AvailableShipsLabel.Text = "Available Ships:";
            AvailableShipsLabel.TextAlign = ContentAlignment.MiddleCenter;
            AvailableShipsLabel.TextOutlineColor = Color.Black;
            // 
            // EnterStartingCoordsLabel
            // 
            EnterStartingCoordsLabel.AutoSize = true;
            EnterStartingCoordsLabel.BackColor = Color.Transparent;
            EnterStartingCoordsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            EnterStartingCoordsLabel.ForeColor = Color.Coral;
            EnterStartingCoordsLabel.Location = new Point(32, 345);
            EnterStartingCoordsLabel.Name = "EnterStartingCoordsLabel";
            EnterStartingCoordsLabel.Size = new Size(155, 15);
            EnterStartingCoordsLabel.TabIndex = 53;
            EnterStartingCoordsLabel.Text = "Enter starting Coordinates:";
            EnterStartingCoordsLabel.TextAlign = ContentAlignment.MiddleCenter;
            EnterStartingCoordsLabel.TextOutlineColor = Color.Black;
            // 
            // shipGroupComboBox
            // 
            shipGroupComboBox.DisplayMember = "1";
            shipGroupComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            shipGroupComboBox.FormattingEnabled = true;
            shipGroupComboBox.Items.AddRange(new object[] { "1", "2", "3" });
            shipGroupComboBox.Location = new Point(171, 316);
            shipGroupComboBox.MaxDropDownItems = 3;
            shipGroupComboBox.MaxLength = 1;
            shipGroupComboBox.Name = "shipGroupComboBox";
            shipGroupComboBox.Size = new Size(44, 23);
            shipGroupComboBox.TabIndex = 54;
            shipGroupComboBox.SelectedIndexChanged += shipGroupComboBox_SelectedIndexChanged;
            // 
            // groupLabel
            // 
            groupLabel.AutoSize = true;
            groupLabel.BackColor = Color.Transparent;
            groupLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupLabel.ForeColor = Color.Coral;
            groupLabel.Location = new Point(170, 298);
            groupLabel.Name = "groupLabel";
            groupLabel.Size = new Size(45, 15);
            groupLabel.TabIndex = 55;
            groupLabel.Text = "Group:";
            groupLabel.TextAlign = ContentAlignment.MiddleCenter;
            groupLabel.TextOutlineColor = Color.Black;
            // 
            // shootAsGroupCheckBox
            // 
            shootAsGroupCheckBox.AutoSize = true;
            shootAsGroupCheckBox.Enabled = false;
            shootAsGroupCheckBox.Location = new Point(109, 320);
            shootAsGroupCheckBox.Name = "shootAsGroupCheckBox";
            shootAsGroupCheckBox.Size = new Size(15, 14);
            shootAsGroupCheckBox.TabIndex = 56;
            shootAsGroupCheckBox.UseVisualStyleBackColor = true;
            shootAsGroupCheckBox.Visible = false;
            // 
            // shootAsGroupLabel
            // 
            shootAsGroupLabel.AutoSize = true;
            shootAsGroupLabel.BackColor = Color.Transparent;
            shootAsGroupLabel.Enabled = false;
            shootAsGroupLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            shootAsGroupLabel.ForeColor = Color.Coral;
            shootAsGroupLabel.Location = new Point(72, 298);
            shootAsGroupLabel.Name = "shootAsGroupLabel";
            shootAsGroupLabel.Size = new Size(98, 15);
            shootAsGroupLabel.TabIndex = 57;
            shootAsGroupLabel.Text = "Shoot as Group::";
            shootAsGroupLabel.TextAlign = ContentAlignment.MiddleCenter;
            shootAsGroupLabel.TextOutlineColor = Color.Black;
            shootAsGroupLabel.Visible = false;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(853, 410);
            Controls.Add(shootAsGroupLabel);
            Controls.Add(shootAsGroupCheckBox);
            Controls.Add(groupLabel);
            Controls.Add(shipGroupComboBox);
            Controls.Add(EnterStartingCoordsLabel);
            Controls.Add(AvailableShipsLabel);
            Controls.Add(EnemysBoardLabel);
            Controls.Add(YourBoardLabel);
            Controls.Add(remainingItemTableLayoutPanel);
            Controls.Add(interactionModeTableLayoutPanel);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(placeShipButton);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(shipPlacementTypeComboBox);
            Controls.Add(readyButton);
            Controls.Add(gameBoardRight);
            Controls.Add(gameBoardLeft);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "GameForm";
            Tag = "1_1";
            Text = "Battleship";
            Load += GameForm_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            interactionModeTableLayoutPanel.ResumeLayout(false);
            interactionModeTableLayoutPanel.PerformLayout();
            remainingItemTableLayoutPanel.ResumeLayout(false);
            remainingItemTableLayoutPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel gameBoardLeft;
        private TableLayoutPanel gameBoardRight;
        private Button readyButton;
        private ComboBox shipPlacementTypeComboBox;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button placeShipButton;
        private FlowLayoutPanel flowLayoutPanel1;
        private TableLayoutPanel interactionModeTableLayoutPanel;
        private RadioButton shootModeRadioButton;
        private RadioButton placeRadarModeButton;
        private RadioButton radioButton3;
        private TableLayoutPanel remainingItemTableLayoutPanel;
        private Components.CustomOutlinedLabel YourBoardLabel;
        private Components.CustomOutlinedLabel EnemysBoardLabel;
        private Components.CustomOutlinedLabel activeModeLabel;
        private Components.CustomOutlinedLabel remainingRadarCountLabel;
        private Components.CustomOutlinedLabel remainingMoveShipsCountLabel;
        private Components.CustomOutlinedLabel remainingRadarTextLabel;
        private Components.CustomOutlinedLabel remainingMoveShipsTextLabel;
        private Components.CustomOutlinedLabel AvailableShipsLabel;
        private Components.CustomOutlinedLabel EnterStartingCoordsLabel;
        private Components.CustomOutlinedLabel turnIndicatorLabel;
        private ComboBox shipGroupComboBox;
        private Components.CustomOutlinedLabel groupLabel;
        private CheckBox shootAsGroupCheckBox;
        private Components.CustomOutlinedLabel shootAsGroupLabel;
    }
}