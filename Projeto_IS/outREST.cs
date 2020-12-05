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
    public partial class outREST : Form
    {
        Main formAux;

        public outREST(Main mainAux)
        {
            InitializeComponent();
            formAux = mainAux;
            method.SelectedIndex = 0;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okOut_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(url.Text))
            {
                MessageBox.Show("Erro! Por favor introduza um URL");
            }
            else
            {
                //validacao se URI inserida é válida com recurso à biblioteca URI
                Uri outUri;

                if (Uri.TryCreate(url.Text, UriKind.Absolute, out outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps))
                {
                    MessageBox.Show("Sucesso!");
                    //guardar na main form a uri validada
                    formAux.outRestURI = url.Text;
                    formAux.outRestMethod = method.SelectedItem.ToString(); 
                    this.Close();
                }
                MessageBox.Show("Erro! URI Inválida!");
            }
        }
    }
}
