using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GangOS.APIManager;
using GangOS.Common;
using GangOS.Common.API;
using GangOS.Common.GUI.Controls;

namespace GangOS
{
    public partial class MainWindow : Form
    {
        private delegate void VoidCallback();

        public MainWindow()
        {
            InitializeComponent();

            GangOSClient.PlayersUpdated += GangOSClient_PlayerAdded;
            charOverview.ItemClicked += charOverview_ItemClicked;
        }

        void charOverview_ItemClicked(object sender, EventArgs e)
        {
            CharacterItem item = (CharacterItem)sender;

            Player player = (Player)item.Tag;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.TabPages[i].Tag == player)
                {
                    tabControl.SelectedIndex = i;
                    break;
                }
            }
        }

        void GangOSClient_PlayerAdded(object sender, EventArgs e)
        {
            if (InvokeRequired)
                Invoke(new VoidCallback(UpdateTabs));
            else
                UpdateTabs();
        }

        private void UpdateTabs()
        {
            SuspendLayout();

            List<TabPage> pages = new List<TabPage>();

            pages.Add(tabOverview);
            pages.Add(tabLivestreams);

            foreach (TabPage page in tabControl.TabPages)
            {
                if (GangOSClient.PlayerList.Contains((Player)page.Tag))
                    pages.Add(page);
            }

            tabControl.TabPages.Clear();

            foreach (Player player in GangOSClient.PlayerList)
            {
                if (!pages.Where(page => page.Tag == player).Any())
                {
                    TabPage newPage = new TabPage();
                    newPage.Location = new Point(4, 22);
                    newPage.Name = "tab" + player.Username;
                    newPage.Padding = new Padding(3);
                    newPage.Size = new Size(504, 409);
                    newPage.TabIndex = pages.Count;
                    newPage.Text = player.Username;
                    newPage.UseVisualStyleBackColor = true;
                    newPage.Tag = player;
                    CharacterPage charPage = new CharacterPage(player);
                    charPage.Dock = DockStyle.Fill;
                    newPage.Controls.Add(charPage);

                    pages.Add(newPage);
                }
            }

            foreach (TabPage page in pages)
            {
                tabControl.TabPages.Add(page);
            }

            ResumeLayout(true);
        }

        private void addAPIKey_Click(object sender, EventArgs e)
        {
            using (APIDialog apid = new APIDialog())
            {
                apid.ShowDialog();
            }
        }

        private string formatTime(TimeSpan ts)
        {
            return string.Format("{0}d {1}h {2}m {3}s", ts.Days, ts.Hours, ts.Minutes, ts.Seconds);
        }
    }
}
