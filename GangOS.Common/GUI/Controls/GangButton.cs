using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace GangOS.Common.GUI.Controls
{
    public partial class GangButton : UserControl
    {
        public event EventHandler onClick;

        public bool Clickable { get; set; }

        private bool m_hovered;
        private bool m_pressed;
        private int m_preferredWidth = 1;
        private int m_preferredHeight = 1;

        public GangButton()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (DesignMode)
                return;

            DoubleBuffered = true;

            this.Click += ControlClick;

            lblGangName.Font = FontFactory.GetFont("Tahoma", 11.25F, FontStyle.Bold);

            lblGangName.MouseEnter += ControlMouseEnter;
            lblGangName.MouseLeave += ControlMouseLeave;
            lblGangName.MouseDown += ControlMouseDown;
            lblGangName.MouseUp += ControlMouseUp;
            lblGangName.Click += ControlClick;
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

        protected void ControlClick(object sender, EventArgs e)
        {
            if (onClick != null)
                onClick(this, e);
        }

        private void UpdateContent()
        {
            if (Tag != null)
                lblGangName.Text = ((Gang)Tag).Name;
            else
                lblGangName.Text = "Gang Name";

            // Adjusts all the controls layout
            PerformCustomLayout(false);
        }

        private void PerformCustomLayout(bool tooltip)
        {
            if (!Visible)
                return;

            int margin = 8;

            int labelWidth = 0;
            if (!tooltip)
                labelWidth = (int)(250 * (Graphics.FromHwnd(Handle).DpiX / GangOSClient.DefaultDpi));

            float bigFontSize = 9.25f;

            int top = margin + 4;
            int left = margin * 2;
            int rightPad = tooltip ? 10 : 0;

            lblGangName.Font = FontFactory.GetFont(lblGangName.Font.FontFamily, bigFontSize, lblGangName.Font.Style);
            lblGangName.Location = new Point(left, top);
            lblGangName.AutoSize = true;
            top += lblGangName.Height + top;

            Width = left + labelWidth + margin;
            m_preferredHeight = Height;
            m_preferredWidth = Width;
        }
    }
}
