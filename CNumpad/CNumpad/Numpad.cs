using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.WindowsCE.Forms;

namespace CNumpad
{
    public class Numpad : IDisposable
    {
        Panel keyboardPanel;
        Font keyboardTextFont;
        Brush buttonLabel;
        SizeF buttonStringSize;

        PictureBox one;
        PictureBox two;
        PictureBox three;
        PictureBox four;
        PictureBox five;
        PictureBox six;
        PictureBox seven;
        PictureBox eight;
        PictureBox nine;
        PictureBox zero;
        PictureBox space;
        PictureBox backspace;
        PictureBox dot;

        const string One = "1";
        const string Two = "2";
        const string Three = "3";
        const string Four = "4";
        const string Five = "5";
        const string Six = "6";
        const string Seven = "7";
        const string Eight = "8";
        const string Nine = "9";
        const string Zero = "0";
        const string Backspace = "B/S";
        const string Dot = ".";

        Control currentActiveControl;
        Point previousLocation;

        Color buttonclickColor;
        Color buttonnormalColor;

        /// <summary>
        /// Constructor for the numpad class
        /// </summary>
        /// <param name="panelLocation">The numpad's location</param>
        /// <param name="panelColor">The numpad's background color</param>
        /// <param name="buttonColor">The buttons' color</param>
        /// <param name="buttonClickColor">The buttons' color when they are clicked</param>
        /// <param name="textColor">The text color on the buttons</param>
        public Numpad(Point panelLocation, Color panelColor, Color buttonColor, Color buttonClickColor, Color textColor)
        {
            keyboardPanel = new Panel();
            keyboardPanel.Size = new Size(272, 168);
            keyboardPanel.Location = panelLocation;
            keyboardPanel.BackColor = panelColor;

            LogFont keyboardText = new LogFont();
            keyboardText.FaceName = "Tahoma";
            keyboardText.Height = 25;
            keyboardText.Quality = LogFontQuality.AntiAliased;

            keyboardTextFont = Font.FromLogFont(keyboardText);
            buttonLabel = new SolidBrush(textColor);
            buttonclickColor = buttonClickColor;
            buttonnormalColor = buttonColor;

            initNumKeys(buttonColor);

            keyboardPanel.MouseDown += new MouseEventHandler(keyboardPanel_MouseDown);
            keyboardPanel.MouseMove += new MouseEventHandler(keyboardPanel_MouseMove);
            keyboardPanel.MouseUp += new MouseEventHandler(keyboardPanel_MouseUp);

            this.isDragEnable = true;
        }

        #region Make the numpad draggable
        void keyboardPanel_MouseUp(object sender, MouseEventArgs e)
        {
            currentActiveControl = null;
        }

        void keyboardPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentActiveControl == null || currentActiveControl != sender)
                return;

            Point location = currentActiveControl.Location;
            location.Offset(e.X - previousLocation.X, e.Y - previousLocation.Y);
            currentActiveControl.Location = location;
        }

        void keyboardPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (isDragEnable)
            {
                currentActiveControl = sender as Control;
                previousLocation = new Point(e.X, e.Y);
            }
            else
                currentActiveControl = null;
        }
        #endregion

        #region pictureBox un-click events
        void backspace_MouseUp(object sender, MouseEventArgs e)
        {
            backspace.BackColor = buttonnormalColor;
        }

        void dot_MouseUp(object sender, MouseEventArgs e)
        {
            dot.BackColor = buttonnormalColor;
        }

        void space_MouseUp(object sender, MouseEventArgs e)
        {
            space.BackColor = buttonnormalColor;
        }

        void zero_MouseUp(object sender, MouseEventArgs e)
        {
            zero.BackColor = buttonnormalColor;
        }

        void nine_MouseUp(object sender, MouseEventArgs e)
        {
            nine.BackColor = buttonnormalColor;
        }

        void eight_MouseUp(object sender, MouseEventArgs e)
        {
            eight.BackColor = buttonnormalColor;
        }

        void seven_MouseUp(object sender, MouseEventArgs e)
        {
            seven.BackColor = buttonnormalColor;
        }

        void six_MouseUp(object sender, MouseEventArgs e)
        {
            six.BackColor = buttonnormalColor;
        }

        void five_MouseUp(object sender, MouseEventArgs e)
        {
            five.BackColor = buttonnormalColor;
        }

        void four_MouseUp(object sender, MouseEventArgs e)
        {
            four.BackColor = buttonnormalColor;
        }

        void three_MouseUp(object sender, MouseEventArgs e)
        {
            three.BackColor = buttonnormalColor;
        }

        void two_MouseUp(object sender, MouseEventArgs e)
        {
            two.BackColor = buttonnormalColor;
        }

        void one_MouseUp(object sender, MouseEventArgs e)
        {
            one.BackColor = buttonnormalColor;
        }
        #endregion

        #region pictureBox paint events
        void dot_Paint(object sender, PaintEventArgs e)
        {
            buttonStringSize = e.Graphics.MeasureString(Dot, keyboardTextFont);
            float x = (dot.Width - (int)buttonStringSize.Width) / 2;
            float y = (dot.Height - (int)buttonStringSize.Height) / 2;
            e.Graphics.DrawString(Dot, keyboardTextFont, buttonLabel, x, y);

        }

        void backspace_Paint(object sender, PaintEventArgs e)
        {
            buttonStringSize = e.Graphics.MeasureString(Backspace, keyboardTextFont);
            float x = (backspace.Width - (int)buttonStringSize.Width) / 2;
            float y = (backspace.Height - (int)buttonStringSize.Height) / 2;
            e.Graphics.DrawString(Backspace, keyboardTextFont, buttonLabel, x, y);

        }

        void zero_Paint(object sender, PaintEventArgs e)
        {
            buttonStringSize = e.Graphics.MeasureString(Zero, keyboardTextFont);
            float x = (zero.Width - (int)buttonStringSize.Width) / 2;
            float y = (zero.Height - (int)buttonStringSize.Height) / 2;
            e.Graphics.DrawString(Zero, keyboardTextFont, buttonLabel, x, y);

        }

        void nine_Paint(object sender, PaintEventArgs e)
        {
            buttonStringSize = e.Graphics.MeasureString(Nine, keyboardTextFont);
            float x = (nine.Width - (int)buttonStringSize.Width) / 2;
            float y = (nine.Height - (int)buttonStringSize.Height) / 2;
            e.Graphics.DrawString(Nine, keyboardTextFont, buttonLabel, x, y);
        }

        void eight_Paint(object sender, PaintEventArgs e)
        {
            buttonStringSize = e.Graphics.MeasureString(Eight, keyboardTextFont);
            float x = (eight.Width - (int)buttonStringSize.Width) / 2;
            float y = (eight.Height - (int)buttonStringSize.Height) / 2;
            e.Graphics.DrawString(Eight, keyboardTextFont, buttonLabel, x, y);
        }

        void seven_Paint(object sender, PaintEventArgs e)
        {
            buttonStringSize = e.Graphics.MeasureString(Seven, keyboardTextFont);
            float x = (seven.Width - (int)buttonStringSize.Width) / 2;
            float y = (seven.Height - (int)buttonStringSize.Height) / 2;
            e.Graphics.DrawString(Seven, keyboardTextFont, buttonLabel, x, y);
        }

        void six_Paint(object sender, PaintEventArgs e)
        {
            buttonStringSize = e.Graphics.MeasureString(Six, keyboardTextFont);
            float x = (six.Width - (int)buttonStringSize.Width) / 2;
            float y = (six.Height - (int)buttonStringSize.Height) / 2;
            e.Graphics.DrawString(Six, keyboardTextFont, buttonLabel, x, y);
        }

        void five_Paint(object sender, PaintEventArgs e)
        {
            buttonStringSize = e.Graphics.MeasureString(Five, keyboardTextFont);
            float x = (five.Width - (int)buttonStringSize.Width) / 2;
            float y = (five.Height - (int)buttonStringSize.Height) / 2;
            e.Graphics.DrawString(Five, keyboardTextFont, buttonLabel, x, y);
        }

        void four_Paint(object sender, PaintEventArgs e)
        {
            buttonStringSize = e.Graphics.MeasureString(Four, keyboardTextFont);
            float x = (four.Width - (int)buttonStringSize.Width) / 2;
            float y = (four.Height - (int)buttonStringSize.Height) / 2;
            e.Graphics.DrawString(Four, keyboardTextFont, buttonLabel, x, y);
        }

        void three_Paint(object sender, PaintEventArgs e)
        {
            buttonStringSize = e.Graphics.MeasureString(Three, keyboardTextFont);
            float x = (three.Width - (int)buttonStringSize.Width) / 2;
            float y = (three.Height - (int)buttonStringSize.Height) / 2;
            e.Graphics.DrawString(Three, keyboardTextFont, buttonLabel, x, y);
        }

        void two_Paint(object sender, PaintEventArgs e)
        {
            buttonStringSize = e.Graphics.MeasureString(Two, keyboardTextFont);
            float x = (two.Width - (int)buttonStringSize.Width) / 2;
            float y = (two.Height - (int)buttonStringSize.Height) / 2;
            e.Graphics.DrawString(Two, keyboardTextFont, buttonLabel, x, y);
        }

        void one_Paint(object sender, PaintEventArgs e)
        {
            buttonStringSize = e.Graphics.MeasureString(One, keyboardTextFont);
            float x = (one.Width - (int)buttonStringSize.Width) / 2;
            float y = (one.Height - (int)buttonStringSize.Height) / 2;
            e.Graphics.DrawString(One, keyboardTextFont, buttonLabel, x, y);
        }
        #endregion

        #region pictureBox click events
        void dot_Click(object sender, MouseEventArgs e)
        {
            dot.BackColor = buttonclickColor;
            NumKeys.Dot();
        }

        void backspace_Click(object sender, MouseEventArgs e)
        {
            backspace.BackColor = buttonclickColor;
            NumKeys.Backspace();
        }

        void space_Click(object sender, MouseEventArgs e)
        {
            space.BackColor = buttonclickColor;
            NumKeys.Space();
        }

        void zero_Click(object sender, MouseEventArgs e)
        {
            zero.BackColor = buttonclickColor;
            NumKeys.Zero();
        }

        void nine_Click(object sender, MouseEventArgs e)
        {
            nine.BackColor = buttonclickColor;
            NumKeys.Nine();
        }

        void eight_Click(object sender, MouseEventArgs e)
        {
            eight.BackColor = buttonclickColor;
            NumKeys.Eight();
        }

        void seven_Click(object sender, MouseEventArgs e)
        {
            seven.BackColor = buttonclickColor;
            NumKeys.Seven();
        }

        void six_Click(object sender, MouseEventArgs e)
        {
            six.BackColor = buttonclickColor;
            NumKeys.Six();
        }

        void five_Click(object sender, MouseEventArgs e)
        {
            five.BackColor = buttonclickColor;
            NumKeys.Five();
        }

        void four_Click(object sender, MouseEventArgs e)
        {
            four.BackColor = buttonclickColor;
            NumKeys.Four();
        }

        void three_Click(object sender, MouseEventArgs e)
        {
            three.BackColor = buttonclickColor;
            NumKeys.Three();
        }

        void two_Click(object sender, MouseEventArgs e)
        {
            two.BackColor = buttonclickColor;
            NumKeys.Two();
        }

        void one_Click(object sender, MouseEventArgs e)
        {
            one.BackColor = buttonclickColor;
            NumKeys.One();
        }
        #endregion

        /// <summary>
        /// Initialize pictureBox and events
        /// </summary>
        /// <param name="buttonColor">The default button color</param>
        private void initNumKeys(Color buttonColor)
        {
            one = new PictureBox();
            two = new PictureBox();
            three = new PictureBox();
            four = new PictureBox();
            five = new PictureBox();
            six = new PictureBox();
            seven = new PictureBox();
            eight = new PictureBox();
            nine = new PictureBox();
            zero = new PictureBox();
            space = new PictureBox();
            backspace = new PictureBox();
            dot = new PictureBox();

            one.BackColor = buttonColor;
            two.BackColor = buttonColor;
            three.BackColor = buttonColor;
            four.BackColor = buttonColor;
            five.BackColor = buttonColor;
            six.BackColor = buttonColor;
            seven.BackColor = buttonColor;
            eight.BackColor = buttonColor;
            nine.BackColor = buttonColor;
            zero.BackColor = buttonColor;
            space.BackColor = buttonColor;
            backspace.BackColor = buttonColor;
            dot.BackColor = buttonColor;

            this.keyboardPanel.Controls.Add(one);
            this.keyboardPanel.Controls.Add(two);
            this.keyboardPanel.Controls.Add(three);
            this.keyboardPanel.Controls.Add(four);
            this.keyboardPanel.Controls.Add(five);
            this.keyboardPanel.Controls.Add(six);
            this.keyboardPanel.Controls.Add(seven);
            this.keyboardPanel.Controls.Add(eight);
            this.keyboardPanel.Controls.Add(nine);
            this.keyboardPanel.Controls.Add(zero);
            this.keyboardPanel.Controls.Add(space);
            this.keyboardPanel.Controls.Add(backspace);
            this.keyboardPanel.Controls.Add(dot);

            one.Size = new Size(47, 52);
            one.Location = new Point(6, 7);
            two.Size = new Size(47, 52);
            two.Location = new Point(59, 7);
            three.Size = new Size(47, 52);
            three.Location = new Point(113, 7);
            four.Size = new Size(47, 52);
            four.Location = new Point(166, 7);
            five.Size = new Size(47, 52);
            five.Location = new Point(219, 7);
            six.Size = new Size(47, 52);
            six.Location = new Point(6, 67);
            seven.Size = new Size(47, 52);
            seven.Location = new Point(59, 67);
            eight.Size = new Size(47, 52);
            eight.Location = new Point(113, 67);
            nine.Size = new Size(47, 52);
            nine.Location = new Point(166, 67);
            zero.Size = new Size(47, 52);
            zero.Location = new Point(219, 67);
            space.Size = new Size(123, 33);
            space.Location = new Point(77, 127);
            backspace.Size = new Size(57, 33);
            backspace.Location = new Point(209, 127);
            dot.Size = new Size(60, 33);
            dot.Location = new Point(5, 127);

            one.MouseDown += new MouseEventHandler(one_Click);
            two.MouseDown += new MouseEventHandler(two_Click);
            three.MouseDown += new MouseEventHandler(three_Click);
            four.MouseDown += new MouseEventHandler(four_Click);
            five.MouseDown += new MouseEventHandler(five_Click);
            six.MouseDown += new MouseEventHandler(six_Click);
            seven.MouseDown += new MouseEventHandler(seven_Click);
            eight.MouseDown += new MouseEventHandler(eight_Click);
            nine.MouseDown += new MouseEventHandler(nine_Click);
            zero.MouseDown += new MouseEventHandler(zero_Click);
            space.MouseDown += new MouseEventHandler(space_Click);
            backspace.MouseDown += new MouseEventHandler(backspace_Click);
            dot.MouseDown += new MouseEventHandler(dot_Click);

            one.MouseUp += new MouseEventHandler(one_MouseUp);
            two.MouseUp += new MouseEventHandler(two_MouseUp);
            three.MouseUp += new MouseEventHandler(three_MouseUp);
            four.MouseUp += new MouseEventHandler(four_MouseUp);
            five.MouseUp += new MouseEventHandler(five_MouseUp);
            six.MouseUp += new MouseEventHandler(six_MouseUp);
            seven.MouseUp += new MouseEventHandler(seven_MouseUp);
            eight.MouseUp += new MouseEventHandler(eight_MouseUp);
            nine.MouseUp += new MouseEventHandler(nine_MouseUp);
            zero.MouseUp += new MouseEventHandler(zero_MouseUp);
            space.MouseUp += new MouseEventHandler(space_MouseUp);
            backspace.MouseUp += new MouseEventHandler(backspace_MouseUp);
            dot.MouseUp += new MouseEventHandler(dot_MouseUp);

            one.Paint += new PaintEventHandler(one_Paint);
            two.Paint += new PaintEventHandler(two_Paint);
            three.Paint += new PaintEventHandler(three_Paint);
            four.Paint += new PaintEventHandler(four_Paint);
            five.Paint += new PaintEventHandler(five_Paint);
            six.Paint += new PaintEventHandler(six_Paint);
            seven.Paint += new PaintEventHandler(seven_Paint);
            eight.Paint += new PaintEventHandler(eight_Paint);
            nine.Paint += new PaintEventHandler(nine_Paint);
            zero.Paint += new PaintEventHandler(zero_Paint);
            backspace.Paint += new PaintEventHandler(backspace_Paint);
            dot.Paint += new PaintEventHandler(dot_Paint);
        }

        /// <summary>
        /// Show the numpad
        /// </summary>
        public void showNumpad()
        {
            keyboardPanel.Show();
        }

        /// <summary>
        /// Hide the numpad
        /// </summary>
        public void hideNumpad()
        {
            keyboardPanel.Hide();
        }

        /// <summary>
        /// Get the numpad object
        /// </summary>
        /// <returns>Panel control representing the numpad</returns>
        public Panel getNumpad()
        {
            return this.keyboardPanel;
        }

        /// <summary>
        /// Dispose resources
        /// </summary>
        public void Dispose()
        {
            one.MouseDown -= new MouseEventHandler(one_Click);
            two.MouseDown -= new MouseEventHandler(two_Click);
            three.MouseDown -= new MouseEventHandler(three_Click);
            four.MouseDown -= new MouseEventHandler(four_Click);
            five.MouseDown -= new MouseEventHandler(five_Click);
            six.MouseDown -= new MouseEventHandler(six_Click);
            seven.MouseDown -= new MouseEventHandler(seven_Click);
            eight.MouseDown -= new MouseEventHandler(eight_Click);
            nine.MouseDown -= new MouseEventHandler(nine_Click);
            zero.MouseDown -= new MouseEventHandler(zero_Click);
            space.MouseDown -= new MouseEventHandler(space_Click);
            backspace.MouseDown -= new MouseEventHandler(backspace_Click);
            dot.MouseDown -= new MouseEventHandler(dot_Click);

            one.Paint -= new PaintEventHandler(one_Paint);
            two.Paint -= new PaintEventHandler(two_Paint);
            three.Paint -= new PaintEventHandler(three_Paint);
            four.Paint -= new PaintEventHandler(four_Paint);
            five.Paint -= new PaintEventHandler(five_Paint);
            six.Paint -= new PaintEventHandler(six_Paint);
            seven.Paint -= new PaintEventHandler(seven_Paint);
            eight.Paint -= new PaintEventHandler(eight_Paint);
            nine.Paint -= new PaintEventHandler(nine_Paint);
            zero.Paint -= new PaintEventHandler(zero_Paint);
            backspace.Paint -= new PaintEventHandler(backspace_Paint);
            dot.Paint -= new PaintEventHandler(dot_Paint);

            one.MouseUp -= new MouseEventHandler(one_MouseUp);
            two.MouseUp -= new MouseEventHandler(two_MouseUp);
            three.MouseUp -= new MouseEventHandler(three_MouseUp);
            four.MouseUp -= new MouseEventHandler(four_MouseUp);
            five.MouseUp -= new MouseEventHandler(five_MouseUp);
            six.MouseUp -= new MouseEventHandler(six_MouseUp);
            seven.MouseUp -= new MouseEventHandler(seven_MouseUp);
            eight.MouseUp -= new MouseEventHandler(eight_MouseUp);
            nine.MouseUp -= new MouseEventHandler(nine_MouseUp);
            zero.MouseUp -= new MouseEventHandler(zero_MouseUp);
            space.MouseUp -= new MouseEventHandler(space_MouseUp);
            backspace.MouseUp -= new MouseEventHandler(backspace_MouseUp);
            dot.MouseUp -= new MouseEventHandler(dot_MouseUp);

            keyboardPanel.MouseDown -= new MouseEventHandler(keyboardPanel_MouseDown);
            keyboardPanel.MouseMove -= new MouseEventHandler(keyboardPanel_MouseMove);
            keyboardPanel.MouseUp -= new MouseEventHandler(keyboardPanel_MouseUp);

            one.Dispose();
            two.Dispose();
            three.Dispose();
            four.Dispose();
            five.Dispose();
            six.Dispose();
            seven.Dispose();
            eight.Dispose();
            nine.Dispose();
            zero.Dispose();
            space.Dispose();
            backspace.Dispose();
            dot.Dispose();

            keyboardTextFont.Dispose();
            buttonLabel.Dispose();

            keyboardPanel.Dispose();
        }

        /// <summary>
        /// Enable/disable keyboard dragging (default: true)
        /// </summary>
        public bool isDragEnable
        {
            get;
            set;
        }
    }
}
