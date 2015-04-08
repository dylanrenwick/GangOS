using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GangOS.Common.GUI.Controls
{
    public partial class CharacterOverview : UserControl
    {
        private delegate void VoidCallback();

        public event EventHandler ItemClicked;

        public CharacterOverview()
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

            GangOSClient.PlayersUpdated += GangOSClient_PlayersUpdated;
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
            GangOSClient.PlayersUpdated -= GangOSClient_PlayersUpdated;
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
            if (!GangOSClient.PlayerList.Any())
            {
                if (Controls.OfType<CharacterItem>().Any())
                    CleanUp(Controls.OfType<CharacterItem>().ToList());

                labelNoCharacters.Visible = true;
                return;
            }

            Dictionary<Player, CharacterItem> items = Controls.OfType<CharacterItem>().ToDictionary(page => (Player)page.Tag);

            List<Player> players = new List<Player>();

            players.AddRange(GangOSClient.PlayerList);

            int index = 0;
            List<CharacterItem> CharacterItems = Controls.OfType<CharacterItem>().ToList();
            foreach (var ls in players)
            {
                CharacterItem currentCharacterItem = (index < CharacterItems.Count ? CharacterItems[index] : null);
                Player currentTag = currentCharacterItem != null ? (Player)currentCharacterItem.Tag : null;

                if (currentTag != ls)
                {
                    CharacterItem CharacterItem;
                    if (items.TryGetValue(ls, out CharacterItem))
                        CharacterItems.Remove(CharacterItem);
                    else
                        CharacterItem = GetCharacterItem(ls);

                    CharacterItems.Insert(index, CharacterItem);
                }

                if (ls != null)
                    items.Remove(ls);

                index++;
            }

            CleanUp(items.Values.ToList());
            foreach (var item in items.Values)
            {
                CharacterItems.Remove(item);
            }

            Controls.AddRange(CharacterItems.ToArray<Control>());

            PerformCustomLayout();
        }

        private void CleanUp(IEnumerable<CharacterItem> items)
        {
            foreach (var item in items)
            {
                item.onClick -= item_Click;
                item.Dispose();
            }

            Controls.Clear();
            Controls.Add(labelNoCharacters);
        }
        
        private CharacterItem GetCharacterItem(Player player)
        {
            CharacterItem CharacterItem;
            CharacterItem tempCharacterItem = null;
            try
            {
                tempCharacterItem = new CharacterItem(player);
                tempCharacterItem.onClick += item_Click;
                tempCharacterItem.Clickable = true;

                tempCharacterItem.CreateControl();

                CharacterItem = tempCharacterItem;
                tempCharacterItem = null;
            }
            finally
            {
                if (tempCharacterItem != null)
                    tempCharacterItem.Dispose();
            }

            return CharacterItem;
        }

        private void PerformCustomLayout()
        {
            if (!Visible)
                return;

            IEnumerable<CharacterItem> CharacterItems = Controls.OfType<CharacterItem>();

            int numControls = CharacterItems.Count();
            if (numControls == 0)
                return;

            const int Pad = 20;

            int scrollBarPosition = VerticalScroll.Value;
            VerticalScroll.Value = 0;

            SuspendLayout();
            try
            {
                int itemWidth = CharacterItems.First().PreferredSize.Width;

                int numColumns = Math.Max(1, Math.Min(numControls, ClientSize.Width / itemWidth));

                int neededWidth = numColumns * (itemWidth + Pad) - Pad;
                int marginH = Math.Max(0, (ClientSize.Width - neededWidth) / 2);

                int rowIndex = 0;
                int rowHeight = 0;
                int height = 0;
                foreach (var CharacterItem in CharacterItems)
                {
                    rowHeight = Math.Max(rowHeight, CharacterItem.PreferredSize.Height);
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
                foreach (var CharacterItem in CharacterItems)
                {
                    CharacterItem.SetBounds(marginH + rowIndex * (itemWidth + Pad), height, CharacterItem.PreferredSize.Width,
                        CharacterItem.PreferredSize.Height);
                    rowHeight = Math.Max(rowHeight, CharacterItem.PreferredSize.Height);
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
                labelNoCharacters.Visible = !GangOSClient.PlayerList.Any();

                //VScroll = true;

                VerticalScroll.Value = scrollBarPosition;
            }
        }

        #endregion

        #region Events

        void GangOSClient_PlayersUpdated(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
                Invoke(new VoidCallback(UpdateContent));
            else
                UpdateContent();
        }

        private void item_Click(object sender, EventArgs e)
        {
            if (ItemClicked != null)
                ItemClicked(sender, e);
        }

        #endregion
    }
}
