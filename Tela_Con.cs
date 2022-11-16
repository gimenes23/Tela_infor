using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tela_infor
{
    public partial class Tela_Con : Form
    {
        int qtd_registros = 0;


        Envia_Info envi = new Envia_Info();
        public Tela_Con()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost; UserId=root; database=infor; password=''");
            MySqlCommand sqlQuery = new MySqlCommand("SELECT * FROM tabela ", conexao);


            dataGridView1.Rows.Clear();

            string mensagem = "Name: " + envi.getName();

            try
            {
                conexao.Open();
                MySqlDataReader dataReader = sqlQuery.ExecuteReader();

                 while (dataReader.Read())
                 {
                     object[] registro = new object[dataReader.FieldCount];

                     if(dataGridView1.Rows.Count == 0)
                     {
                         for(int i = 0; i < dataReader.FieldCount; i++)
                         {
                             dataGridView1.Columns.Add(dataReader.GetName(i), dataReader.GetName(i));
                         }
                     }

                   for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                       registro[i] = dataReader.GetValue(i); // monta o registro.                        
                  }
                    dataGridView1.Rows.Add(registro); // Adiciona a linha

                    qtd_registros++;
                   

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex, "ERRO Atençao!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }

            //////////////////////////////////////////////////////////////////////////
            //Database
           
            /*MySqlConnection conexao = new MySqlConnection("server=localhost; UserId=root; database=infor; password=''");
            MySqlCommand sqlQuery = new MySqlCommand("SELECT * FROM tabela ", conexao);

            conexao.Open(); // Abrir Conexão
            MySqlDataReader dataReader = sqlQuery.ExecuteReader(); // Executa a instrução SQL;            
            dataReader.Read();

            String funcionario_dados = null;
            if (dataReader.HasRows) // se tiver dados
            {
                funcionario_dados = "Id:" + dataReader.GetValue(0) + // id
                                  "\nNome: " + dataReader.GetValue(1);    // nome
                                                 
                MessageBox.Show(funcionario_dados, "Exibir dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
        }

    }
    }

