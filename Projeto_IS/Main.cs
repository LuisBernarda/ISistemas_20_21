using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_IS
{
    public partial class Main : Form
    {
        public String urlAux { get; set; }

        public Main()
        {
            InitializeComponent();
        }

        private void outHTML_Click(object sender, EventArgs e)
        {

        }

        private void inREST_Click(object sender, EventArgs e)
        {
            inREST formAux = new inREST();
            formAux.ShowDialog();
        }
    }
}
