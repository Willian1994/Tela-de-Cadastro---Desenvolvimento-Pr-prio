using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Tela_de_cadastro
{
    public partial class FormLogin : Form
    {
        public static bool Cancelar = false;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnSenha_Click(object sender, EventArgs e)
        {
            string nome = txtUsuario.Text;
            string senha = txtSenha.Text;

            if (CadastroUsuario.Login(nome, senha))
            {
                 Close();
            }
            else
            {
                MessageBox.Show("Acesso negado!");
                txtUsuario.Text = "";
                txtSenha.Text = "";
                txtUsuario.Focus();
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar = true;
            Close();
        }

        private void desenvolvedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("created and developed by Willian Ribeiro","teste");
        }

        private void versãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Versão 1.0");
        }

        private void btnTestarServidor_Click(object sender, EventArgs e)
        {
            string strConnection1 = "server=127.0.0.1;User Id=root;password=vertrigo";
            //string strConnection2 = "server=127.0.0.1;User Id=root;database=curo_db;password=vertrigo";

            MySqlConnection conexao = new MySqlConnection(strConnection1);
            //conexao.ConnectionString = strConnection1;

            try
            {
                conexao.Open();
                lblResultadoServidor.Text = "Conectado com sucesso";

            }
            catch (Exception ex)
            {
                lblResultadoServidor.Text = "Erro ao conectar" + ex;
            }
            finally 
            {
                conexao.Close();
            } 


        }
    }
}
