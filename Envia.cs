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
namespace Tela_infor
{
    public partial class Envia : Form
    {


        Envia_Info envi = new Envia_Info();
        public Envia()
        {
            InitializeComponent();
        }

        private void Envia_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            envi.Name = textBox1.Text;



            MySqlConnection conexao = new MySqlConnection("server=localhost; UserId=root; database=infor; password=''");
            MySqlCommand sqlQuery = new MySqlCommand($"INSERT INTO tabela VALUES(0,'{envi.Name}');", conexao);

            try
            {
                conexao.Open();
                sqlQuery.ExecuteReader();

            }
            catch (Exception ex)
            {
                MessageBox.Show("erro: " + ex, "erro atençao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }

            MessageBox.Show("dados enviado", "salvo os dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
