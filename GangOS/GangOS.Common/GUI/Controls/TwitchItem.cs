using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

using GangOS.Common;
using GangOS.Common.API.Twitch;

namespace GangOS.Common.GUI.Controls
{
    public partial class TwitchItem : UserControl
    {
        public bool Clickable { get; set; }

        private bool m_hovered;
        private bool m_pressed;
        private int m_preferredWidth = 1;
        private int m_preferredHeight = 1;

        public TwitchItem(Livestream stream)
        {
            InitializeComponent();

            this.Tag = stream;
        }

        #region Inherited Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (DesignMode)
                return;

            DoubleBuffered = true;

            lblTwitchUser.Font = FontFactory.GetFont("Tahoma", 11.25F, FontStyle.Bold);
            lblFollowerCount.Font = FontFactory.GetFont("Tahoma", 8.25F);
            lblViewerCount.Font = FontFactory.GetFont("Tahoma", 8.25F);

            lblTwitchUser.MouseEnter += ControlMouseEnter;
            lblTwitchUser.MouseLeave += ControlMouseLeave;
            lblTwitchUser.MouseDown += ControlMouseDown;
            lblTwitchUser.MouseUp += ControlMouseUp;
            lblFollowerCount.MouseEnter += ControlMouseEnter;
            lblFollowerCount.MouseLeave += ControlMouseLeave;
            lblFollowerCount.MouseDown += ControlMouseDown;
            lblFollowerCount.MouseUp += ControlMouseUp;
            lblViewerCount.MouseEnter += ControlMouseEnter;
            lblViewerCount.MouseLeave += ControlMouseLeave;
            lblViewerCount.MouseDown += ControlMouseDown;
            lblViewerCount.MouseUp += ControlMouseUp;

            imgTwitchAvatar.Visible = false;
            imgTwitchAvatar.Image = ((Livestream)Tag).Avatar;

            imgTwitchAvatar.MouseEnter += ControlMouseEnter;
            imgTwitchAvatar.MouseLeave += ControlMouseLeave;
            imgTwitchAvatar.MouseDown += ControlMouseDown;
            imgTwitchAvatar.MouseUp += ControlMouseUp;

            UpdateContent();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            UpdateContent();

            base.OnVisibleChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e");

            if (!m_hovered)
            {
                ButtonRenderer.DrawButton(e.Graphics, DisplayRectangle, PushButtonState.Normal);
            }
            else
            {
                ButtonRenderer.DrawButton(e.Graphics, DisplayRectangle, m_pressed
                                                                            ? PushButtonState.Pressed
                                                                            : PushButtonState.Hot);
            }

            base.OnPaint(e);
        }

        protected void ControlMouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(e);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            if (!Clickable)
                return;

            // Show back button
            m_hovered = true;
            Invalidate();

            base.OnMouseEnter(e);
        }

        protected void ControlMouseLeave(object sender, EventArgs e)
        {
            OnMouseLeave(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            m_hovered = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected void ControlMouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            m_pressed = true;
            Invalidate();
            base.OnMouseDown(e);
        }

        protected void ControlMouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            m_pressed = false;
            Invalidate();
            base.OnMouseUp(e);
        }

        #endregion

        #region Content and Layout

        private void UpdateContent()
        {
            lblTwitchUser.Text = ((Livestream)Tag).Username;
            lblFollowerCount.Text = string.Format("Followers: {0}", ((Livestream)Tag).Followers);
            lblViewerCount.Text = string.Format("Viewers: {0}", ((Livestream)Tag).Viewers);
            imgTwitchAvatar.Image = ((Livestream)Tag).Avatar;

            // Adjusts all the controls layout
            PerformCustomLayout(false);
        }

        private void PerformCustomLayout(bool tooltip)
        {
            if (!Visible)
                return;

            int margin = 8;

            // Label height
            int labelHeight = 18;
            int smallLabelHeight = 13;

            // Label width
            int labelWidth = 0;
            if (!tooltip)
                labelWidth = (int)(250 * (Graphics.FromHwnd(Handle).DpiX / GangOSClient.DefaultDpi));

            // Big font size
            float bigFontSize = 9.25f;

            // Medium font size
            float mediumFontSize = 8.25F;

            // Margin between the two labels groups
            int verticalMargin = 16;

            // Adjust portrait
            imgTwitchAvatar.Location = new Point(margin, margin);
            imgTwitchAvatar.Size = new Size(86, 86);
            imgTwitchAvatar.Visible = true;

            // Adjust the top labels
            int top = margin + 4;
            int left = 86 + margin * 2;
            int rightPad = tooltip ? 10 : 0;

            lblTwitchUser.Font = FontFactory.GetFont(lblTwitchUser.Font.FontFamily, bigFontSize, lblTwitchUser.Font.Style);
            lblTwitchUser.Location = new Point(left, top);
            lblTwitchUser.AutoSize = true;
            top += lblTwitchUser.Height + top;

            lblViewerCount.Font = FontFactory.GetFont(lblViewerCount.Font.FontFamily, mediumFontSize, lblViewerCount.Font.Style);
            lblViewerCount.Location = new Point(left, top);
            lblViewerCount.AutoSize = true;
            top += lblViewerCount.Height + 2;

            lblFollowerCount.Font = lblViewerCount.Font;
            lblFollowerCount.Location = new Point(left, top);
            lblFollowerCount.AutoSize = true;
            top += lblFollowerCount.Height + 2;

            Height = (imgTwitchAvatar.Visible ? Math.Max(imgTwitchAvatar.Height + 2 * margin, top + margin) : top + margin);

            Width = left + labelWidth + margin;
            m_preferredHeight = Height;
            m_preferredWidth = Width;
        }

        #endregion
    }
}
