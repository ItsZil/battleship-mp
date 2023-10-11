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
            gameBoardLeft = new TableLayoutPanel();
            gameBoardRight = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            readyButton = new Button();
            label3 = new Label();
            shipPlacementTypeComboBox = new ComboBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label4 = new Label();
            placeShipButton = new Button();
            turnIndicatorLabel = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            interactionModeTableLayoutPanel = new TableLayoutPanel();
            shootModeRadioButton = new RadioButton();
            radioButton3 = new RadioButton();
            placeRadarModeButton = new RadioButton();
            activeModeLabel = new Label();
            remainingItemTableLayoutPanel = new TableLayoutPanel();
            remainingRadarTextLabel = new Label();
            remainingRadarCountLabel = new Label();
            remainingMoveShipsTextLabel = new Label();
            remainingMoveShipsCountLabel = new Label();
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(182, 37);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 37;
            label1.Text = "Your Board";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(582, 37);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 38;
            label2.Text = "Enemy's Board";
            // 
            // readyButton
            // 
            readyButton.Location = new Point(316, 298);
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
            label3.Location = new Point(32, 298);
            label3.Name = "label3";
            label3.Size = new Size(89, 15);
            label3.TabIndex = 40;
            label3.Text = "Available Ships:";
            // 
            // shipPlacementTypeComboBox
            // 
            shipPlacementTypeComboBox.FormattingEnabled = true;
            shipPlacementTypeComboBox.Items.AddRange(new object[] { "One piece", "Two piece (horizontal)", "Two piece (vertical)", "Three piece (vertical)" });
            shipPlacementTypeComboBox.Location = new Point(32, 316);
            shipPlacementTypeComboBox.Margin = new Padding(3, 2, 3, 2);
            shipPlacementTypeComboBox.Name = "shipPlacementTypeComboBox";
            shipPlacementTypeComboBox.Size = new Size(133, 23);
            shipPlacementTypeComboBox.TabIndex = 41;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(32, 369);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "X";
            textBox1.Size = new Size(24, 23);
            textBox1.TabIndex = 42;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(72, 369);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Y";
            textBox2.Size = new Size(22, 23);
            textBox2.TabIndex = 43;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 345);
            label4.Name = "label4";
            label4.Size = new Size(147, 15);
            label4.TabIndex = 44;
            label4.Text = "Enter starting Coordinates:";
            // 
            // placeShipButton
            // 
            placeShipButton.Location = new Point(122, 368);
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
            flowLayoutPanel1.Location = new Point(364, 87);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(117, 50);
            flowLayoutPanel1.TabIndex = 47;
            // 
            // interactionModeTableLayoutPanel
            // 
            interactionModeTableLayoutPanel.ColumnCount = 1;
            interactionModeTableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            interactionModeTableLayoutPanel.Controls.Add(shootModeRadioButton, 0, 1);
            interactionModeTableLayoutPanel.Controls.Add(radioButton3, 0, 2);
            interactionModeTableLayoutPanel.Controls.Add(placeRadarModeButton, 0, 3);
            interactionModeTableLayoutPanel.Controls.Add(activeModeLabel, 0, 0);
            interactionModeTableLayoutPanel.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            interactionModeTableLayoutPanel.Location = new Point(367, 169);
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
            // shootModeRadioButton
            // 
            shootModeRadioButton.AutoSize = true;
            shootModeRadioButton.Checked = true;
            shootModeRadioButton.Location = new Point(3, 18);
            shootModeRadioButton.Name = "shootModeRadioButton";
            shootModeRadioButton.Size = new Size(56, 19);
            shootModeRadioButton.TabIndex = 0;
            shootModeRadioButton.TabStop = true;
            shootModeRadioButton.Text = "Shoot";
            shootModeRadioButton.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(3, 43);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(81, 19);
            radioButton3.TabIndex = 5;
            radioButton3.Text = "Move Ship";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // placeRadarModeButton
            // 
            placeRadarModeButton.AutoSize = true;
            placeRadarModeButton.Location = new Point(3, 68);
            placeRadarModeButton.Name = "placeRadarModeButton";
            placeRadarModeButton.Size = new Size(86, 19);
            placeRadarModeButton.TabIndex = 1;
            placeRadarModeButton.Text = "Place Radar";
            placeRadarModeButton.UseVisualStyleBackColor = true;
            // 
            // activeModeLabel
            // 
            activeModeLabel.AutoSize = true;
            activeModeLabel.Location = new Point(3, 0);
            activeModeLabel.Name = "activeModeLabel";
            activeModeLabel.Size = new Size(77, 15);
            activeModeLabel.TabIndex = 4;
            activeModeLabel.Text = "Active mode:";
            // 
            // remainingItemTableLayoutPanel
            // 
            remainingItemTableLayoutPanel.ColumnCount = 2;
            remainingItemTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80.1282043F));
            remainingItemTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.8717957F));
            remainingItemTableLayoutPanel.Controls.Add(remainingRadarTextLabel, 0, 1);
            remainingItemTableLayoutPanel.Controls.Add(remainingRadarCountLabel, 1, 1);
            remainingItemTableLayoutPanel.Controls.Add(remainingMoveShipsTextLabel, 0, 0);
            remainingItemTableLayoutPanel.Controls.Add(remainingMoveShipsCountLabel, 1, 0);
            remainingItemTableLayoutPanel.Location = new Point(527, 298);
            remainingItemTableLayoutPanel.Name = "remainingItemTableLayoutPanel";
            remainingItemTableLayoutPanel.RowCount = 2;
            remainingItemTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            remainingItemTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            remainingItemTableLayoutPanel.Size = new Size(140, 100);
            remainingItemTableLayoutPanel.TabIndex = 49;
            remainingItemTableLayoutPanel.Visible = false;
            // 
            // remainingRadarTextLabel
            // 
            remainingRadarTextLabel.Anchor = AnchorStyles.Left;
            remainingRadarTextLabel.AutoSize = true;
            remainingRadarTextLabel.Location = new Point(3, 67);
            remainingRadarTextLabel.Name = "remainingRadarTextLabel";
            remainingRadarTextLabel.Size = new Size(102, 15);
            remainingRadarTextLabel.TabIndex = 2;
            remainingRadarTextLabel.Text = "Remaining radars:";
            // 
            // remainingRadarCountLabel
            // 
            remainingRadarCountLabel.Anchor = AnchorStyles.Left;
            remainingRadarCountLabel.AutoSize = true;
            remainingRadarCountLabel.Location = new Point(115, 67);
            remainingRadarCountLabel.Name = "remainingRadarCountLabel";
            remainingRadarCountLabel.Size = new Size(13, 15);
            remainingRadarCountLabel.TabIndex = 3;
            remainingRadarCountLabel.Text = "0";
            // 
            // remainingMoveShipsTextLabel
            // 
            remainingMoveShipsTextLabel.Anchor = AnchorStyles.Left;
            remainingMoveShipsTextLabel.AutoSize = true;
            remainingMoveShipsTextLabel.Location = new Point(3, 10);
            remainingMoveShipsTextLabel.Name = "remainingMoveShipsTextLabel";
            remainingMoveShipsTextLabel.Size = new Size(92, 30);
            remainingMoveShipsTextLabel.TabIndex = 0;
            remainingMoveShipsTextLabel.Text = "Remaining ship movements:";
            // 
            // remainingMoveShipsCountLabel
            // 
            remainingMoveShipsCountLabel.Anchor = AnchorStyles.Left;
            remainingMoveShipsCountLabel.AutoSize = true;
            remainingMoveShipsCountLabel.Location = new Point(115, 17);
            remainingMoveShipsCountLabel.Name = "remainingMoveShipsCountLabel";
            remainingMoveShipsCountLabel.Size = new Size(13, 15);
            remainingMoveShipsCountLabel.TabIndex = 1;
            remainingMoveShipsCountLabel.Text = "0";
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(853, 410);
            Controls.Add(remainingItemTableLayoutPanel);
            Controls.Add(interactionModeTableLayoutPanel);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(placeShipButton);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(shipPlacementTypeComboBox);
            Controls.Add(label3);
            Controls.Add(readyButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(gameBoardRight);
            Controls.Add(gameBoardLeft);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "GameForm";
            Tag = "1_1";
            Text = "Battleship";
            flowLayoutPanel1.ResumeLayout(false);
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
        private Label label1;
        private Label label2;
        private Button readyButton;
        private Label label3;
        private ComboBox shipPlacementTypeComboBox;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label4;
        private Button placeShipButton;
        private Label turnIndicatorLabel;
        private FlowLayoutPanel flowLayoutPanel1;
        private TableLayoutPanel interactionModeTableLayoutPanel;
        private RadioButton shootModeRadioButton;
        private RadioButton placeRadarModeButton;
        private Label activeModeLabel;
        private RadioButton radioButton3;
        private TableLayoutPanel remainingItemTableLayoutPanel;
        private Label remainingMoveShipsTextLabel;
        private Label remainingMoveShipsCountLabel;
        private Label remainingRadarTextLabel;
        private Label remainingRadarCountLabel;
    }
}