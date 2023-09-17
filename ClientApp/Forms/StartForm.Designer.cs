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
            TestMessageLabel = new Label();
            GetTestMessageButton = new Button();
            SuspendLayout();
            // 
            // TestMessageLabel
            // 
            TestMessageLabel.AutoSize = true;
            TestMessageLabel.Location = new Point(305, 197);
            TestMessageLabel.Name = "TestMessageLabel";
            TestMessageLabel.Size = new Size(194, 15);
            TestMessageLabel.TabIndex = 0;
            TestMessageLabel.Text = "Click button to test the connection.";
            // 
            // GetTestMessageButton
            // 
            GetTestMessageButton.Location = new Point(337, 226);
            GetTestMessageButton.Name = "GetTestMessageButton";
            GetTestMessageButton.Size = new Size(116, 22);
            GetTestMessageButton.TabIndex = 1;
            GetTestMessageButton.Text = "GetTestMessage";
            GetTestMessageButton.UseVisualStyleBackColor = true;
            GetTestMessageButton.Click += GetTestMessageButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(GetTestMessageButton);
            Controls.Add(TestMessageLabel);
            Name = "Form1";
            Text = "Battleship";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TestMessageLabel;
        private Button GetTestMessageButton;
    }
}