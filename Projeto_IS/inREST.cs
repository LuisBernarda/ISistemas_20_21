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
        Main formAux;

        public inREST(Main mainAux)
        {
            InitializeComponent();
            formAux = mainAux;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(url.Text))
            {
                MessageBox.Show("Erro! Por favor introduza um URL");
            } else
            {
                Uri outUri;

                if (Uri.TryCreate(url.Text, UriKind.Absolute, out outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps))
                {
                    MessageBox.Show("Sucesso!");
                    formAux.inRESTuriAux = url.Text;
                    this.Close();
                }
                MessageBox.Show("Erro! URI Inválida!");
            }

        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}