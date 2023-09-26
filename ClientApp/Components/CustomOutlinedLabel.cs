using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClientApp.Components
{
    public class CustomOutlinedLabel : Label
    {
        public Color TextOutlineColor { get; set; } = Color.Black;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Color textColor = ForeColor;
            string text = Text;
            Font font = Font;

            using (SolidBrush outlineBrush = new SolidBrush(TextOutlineColor))
            {
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {

                        RectangleF outlineRect = new RectangleF(ClientRectangle.Left + dx, ClientRectangle.Top + dy, ClientRectangle.Width, ClientRectangle.Height);
                        e.Graphics.DrawString(text, font, outlineBrush, outlineRect);
                    }
                }
            }

            using (SolidBrush textBrush = new SolidBrush(textColor))
            {
                e.Graphics.DrawString(text, font, textBrush, ClientRectangle);
            }
        }
    }
}