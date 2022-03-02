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
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void Cadastro_Load(object sender, EventArgs e)
        {
            FormLogin f = new FormLogin();

            while (CadastroUsuario.UsuarioLogado == null)
            {
                Visible = false;
                f.ShowDialog();

                if (FormLogin.Cancelar == true)
                {
                    Application.Exit();
                    return;
                }
            }

            label_Bvindas.Text = "Bem Vindo(a) \n" + CadastroUsuario.UsuarioLogado.Nome;
            Visible = true;


        }

        private void button3_Click(object sender, EventArgs e)
        {

            Hide();
            PesquisarFun f = new PesquisarFun();
            f.ShowDialog();
            Show();


        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            {
                string strConnection1 = "server=127.0.0.1;User Id=root;password=vertrigo";
                //string strConnection2 = "server=127.0.0.1;User Id=root;database=curo_db;password=vertrigo";

                MySqlConnection conexao = new MySqlConnection(strConnection1);
                //conexao.ConnectionString = strConnection1;

                try
                {
                    conexao.Open();
                    lblResultadoPesquisa.Text = "Conectado com sucesso";

                    MySqlCommand comando = new MySqlCommand();

                    comando.Connection = conexao;
                    comando.CommandText = "CREATE DATABASE IF NOT EXISTS Base_de_dados_Colaborador";

                    comando.ExecuteNonQuery();
                    lblResultadoPesquisa.Text = "Base de dados criada com sucesso.";
                    comando.Dispose();

                }
                catch (Exception ex)
                {
                    lblResultadoPesquisa.Text = "Erro ao conectar \n" + ex;
                }
                finally
                {
                    conexao.Close();
                }
            }

        }
    }
}
