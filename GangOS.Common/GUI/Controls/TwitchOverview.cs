using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GangOS.Common;
using GangOS.Common.API.Twitch;
using System.Diagnostics;

namespace GangOS.Common.GUI.Controls
{
    public partial class TwitchOverview : UserControl
    {
        private delegate void VoidCallback();

        public TwitchOverview()
        {
            InitializeComponent();
        }

        #region Inherited Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (DesignMode)
                return;

            DoubleBuffered = true;

            GangOSClient.LivestreamsUpdated += GangOSClient_LivestreamsUpdated;
            Disposed += OnDisposed;

            UpdateContent();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (DesignMode)
                return;

            if (Visible)
                UpdateContent();
        }

        private void OnDisposed(object sender, EventArgs e)
        {
            GangOSClient.LivestreamsUpdated -= GangOSClient_LivestreamsUpdated;
            Disposed -= OnDisposed;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            PerformCustomLayout();
            base.OnSizeChanged(e);
        }

        #endregion

        #region Content and Layout

        private void UpdateContent()
        {
            if (!GangOSClient.Livestreams.Any())
            {
                if (Controls.OfType<TwitchItem>().Any())
                    CleanUp(Controls.OfType<TwitchItem>().ToList());

                labelNoLivestreams.Visible = true;
                return;
            }

            Dictionary<Livestream, TwitchItem> items = Controls.OfType<TwitchItem>().ToDictionary(page => (Livestream)page.Tag);

            List<Livestream> livestreams = new List<Livestream>();

            livestreams.AddRange(GangOSClient.Livestreams);

            int index = 0;
            List<TwitchItem> twitchItems = Controls.OfType<TwitchItem>().ToList();
            foreach (var ls in livestreams)
            {
                TwitchItem currentTwitchItem = (index < twitchItems.Count ? twitchItems[index] : null);
                Livestream currentTag = currentTwitchItem != null ? (Livestream)currentTwitchItem.Tag : null;

                if (currentTag != ls)
                {
                    TwitchItem twitchItem;
                    if (items.TryGetValue(ls, out twitchItem))
                        twitchItems.Remove(twitchItem);
                    else
                        twitchItem = GetTwitchItem(ls);

                    twitchItems.Insert(index, twitchItem);
                }

                if (ls != null)
                    items.Remove(ls);

                index++;
            }

            CleanUp(items.Values.ToList());
            foreach (var item in items.Values)
            {
                twitchItems.Remove(item);
            }

            Controls.AddRange(twitchItems.ToArray<Control>());

            PerformCustomLayout();
        }

        private void CleanUp(IEnumerable<TwitchItem> items)
        {
            foreach (var item in items)
            {
                item.Click -= item_Click;
                item.Dispose();
            }

            Controls.Clear();
            Controls.Add(labelNoLivestreams);
        }

        private TwitchItem GetTwitchItem(Livestream livestream)
        {
            TwitchItem twitchItem;
            TwitchItem tempTwitchItem = null;
            try
            {
                tempTwitchItem = new TwitchItem(livestream);
                tempTwitchItem.Click += item_Click;
                tempTwitchItem.Clickable = true;

                tempTwitchItem.CreateControl();

                twitchItem = tempTwitchItem;
                tempTwitchItem = null;
            }
            finally
            {
                if (tempTwitchItem != null)
                    tempTwitchItem.Dispose();
            }

            return twitchItem;
        }

        private void PerformCustomLayout()
        {
            if (!Visible)
                return;

            IEnumerable<TwitchItem> twitchItems = Controls.OfType<TwitchItem>();

            int numControls = twitchItems.Count();
            if (numControls == 0)
                return;

            const int Pad = 12;

            int scrollBarPosition = VerticalScroll.Value;
            VerticalScroll.Value = 0;

            SuspendLayout();
            try
            {
                int itemWidth = twitchItems.First().PreferredSize.Width;

                int numColumns = Math.Max(1, Math.Min(numControls, ClientSize.Width / itemWidth));

                int neededWidth = numColumns * (itemWidth + Pad) - Pad;
                int marginH = Math.Max(0, (ClientSize.Width - neededWidth) / 2);

                int rowIndex = 0;
                int rowHeight = 0;
                int height = 0;
                foreach (var twitchItem in twitchItems)
                {
                    rowHeight = Math.Max(rowHeight, twitchItem.PreferredSize.Height);
                    rowIndex++;

                    if (rowIndex != numColumns)
                        continue;

                    height += rowHeight + Pad;
                    rowHeight = 0;
                    rowIndex = 0;
                }

                height -= Pad;
                int marginV = Math.Max(0, (ClientSize.Height - height) / 3);

                rowIndex = 0;
                rowHeight = 0;
                height = marginV;
                foreach (var twitchItem in twitchItems)
                {
                    twitchItem.SetBounds(marginH + rowIndex * (itemWidth + Pad), height, twitchItem.PreferredSize.Width,
                        twitchItem.PreferredSize.Height);
                    rowHeight = Math.Max(rowHeight, twitchItem.PreferredSize.Height);
                    rowIndex++;

                    if (rowIndex != numColumns)
                        continue;

                    height += rowHeight + Pad;
                    rowHeight = 0;
                    rowIndex = 0;
                }
            }
            finally
            {
                ResumeLayout(true);
                labelNoLivestreams.Visible = !GangOSClient.Livestreams.Any();

                //VScroll = true;

                VerticalScroll.Value = scrollBarPosition;
            }
        }

        #endregion

        #region Events

        void GangOSClient_LivestreamsUpdated(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
                Invoke(new VoidCallback(UpdateContent));
            else
                UpdateContent();
        }

        private void item_Click(object sender, EventArgs e)
        {
            TwitchItem item = sender as TwitchItem;

            Process.Start(((Livestream)item.Tag).URL);
        }

        #endregion
    }
}
