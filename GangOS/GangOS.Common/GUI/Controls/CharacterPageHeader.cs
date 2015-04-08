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
    public partial class CharacterPageHeader : UserControl
    {
        public CharacterPageHeader()
        {
            InitializeComponent();
        }

        public void UpdateContent()
        {
            Player p = (Player)Tag;

            lblUsername.Text = p.Username;
            lblDNA.Text = string.Format("DNA: {0}", p.DNA.ToString());
            lblMedals.Text = string.Format("Medals: {0}", p.Medals.ToString());
            lblGang.Text = p.gang.Name;
        }
    }
}
