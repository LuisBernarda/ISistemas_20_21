﻿using System;
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
    public partial class inREST : Form
    {
        public inREST()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(url.Text))
            {
                MessageBox.Show("Erro! Por favor introduza um URL");
            } else
            {
                MessageBox.Show("Sucesso!");
                
                this.Close();
            }

        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
