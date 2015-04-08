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
    public partial class CharacterPage : UserControl
    {
        public CharacterPage(Player player)
        {
            InitializeComponent();

            this.Tag = player;
            characterPageHeader.Tag = player;

            UpdateContent();
        }

        private void UpdateContent()
        {
            characterPageHeader.UpdateContent();
        }
    }
}
