using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeje.Platform
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnDelegate_Click(object sender, EventArgs e)
        {
            //frmDelegate objDelegate = new frmDelegate();
            //objDelegate.ShowDialog(this);
            Common.AutoDictManager adm = new Common.AutoDictManager();
            adm.Show();

        }
    }
}
