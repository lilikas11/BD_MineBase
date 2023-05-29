using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.Remoting.Messaging;

namespace MineBase_final
{
    public partial class Form1 : Form
    {
        private int ID_Jogador;
        private SoundPlayer splayer;
        private int ID_Personagem;


        public Form1()
        {
            InitializeComponent();
        }

        //pedir ID!!!! Só temos o nome
        private void login_Click(object sender, EventArgs e)
        {
            var cn = DatabaseHelper.getSGBDConnection();
            if (!DatabaseHelper.verifySGBDConnection(cn))
                return;
            SqlCommand cmd = new SqlCommand();
            var Email = EmailTextBox.Text;
            var Senha = PasswordTextBox.Text;
            if (string.IsNullOrEmpty(Senha) || string.IsNullOrEmpty(Email))
            {
                ErrorPopUpPanel.Visible = true;
                return;
            }
            // Verificação               
            cmd.CommandText = "SELECT * FROM dbo.login(@Email, @Senha)"; //Função de login
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Senha", Senha);
            cmd.Connection = cn;


            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                bool login = false;
                // Process the result set
                while (login == false)
                {
                    if (reader.Read()) {
                        if (!reader.IsDBNull(0))
                        {
                            // Access the values returned by the TVF e it is an int
                            ID_Jogador = reader.GetInt32(0);
                            Console.WriteLine("ID: " + ID_Jogador);
                            login = true;
                            // Close the reader
                            reader.Close();
                            loginPanel.Visible = false;
                            panel3.Visible = true;
                        }
                        else {
                            Console.WriteLine("No Player Found");
                            CredentialsNotPanel.Visible = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Player Found");
                        CredentialsNotPanel.Visible = true;
                        break;
                    }

                }
            }

            catch (Exception ex)
            {
                throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }

            var cn2 = DatabaseHelper.getSGBDConnection();
            if (!DatabaseHelper.verifySGBDConnection(cn2))
                return;
            SqlCommand cmd2 = new SqlCommand();              
            cmd2.CommandText = "SELECT ID, Nome FROM dbo.Personagem WHERE ID_Jogador = (@ID_Jogador)";
            cmd2.Parameters.AddWithValue("@ID_Jogador", ID_Jogador);
            cmd2.Connection = cn2;


            try
            {
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read()) {
                    ID_Personagem = int.Parse(reader2["ID"].ToString());
                    var nomePersonagem = reader2["Nome"].ToString();
                    Console.WriteLine("ID: " + ID_Personagem);
                    comboBoxPersonagem.Items.Add(nomePersonagem);
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn2.Close();
            }

        }

        private void SoundButton_Click(object sender, EventArgs e)
        {
            if (splayer == null)
            {
                // A música não está tocando, então comece a reprodução
                splayer = new SoundPlayer(@"C:\Users\liarc\Downloads\Minecraft.wav");
                splayer.Play();
            }
            else
            {
                // A música está tocando, então pare a reprodução
                splayer.Stop();
                splayer.Dispose(); // Libere os recursos do SoundPlayer
                splayer = null;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TryAgainButton_Click(object sender, EventArgs e)
        {
            ErrorPopUpPanel.Visible = false;
            //voltar a tentar preencher campos
        }

        //eliminar esta merda
        private void TryAgain2Button_Click(object sender, EventArgs e)
        {
            CredentialsNotPanel.Visible = false;
        }

        //button2 ---> selecionar personagem
        private void button2_Click(object sender, EventArgs e)
        {
            var cn = DatabaseHelper.getSGBDConnection();
            if (!DatabaseHelper.verifySGBDConnection(cn))
                return;
            SqlCommand cmd = new SqlCommand();
           
            // Verificação               
            cmd.CommandText = "SELECT * FROM dbo.Inventário (@ID_Personagem)"; 
            cmd.Parameters.AddWithValue("@ID_Personagem", ID_Personagem);
            cmd.Connection = cn;
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var nomeItem = reader["Nome"].ToString();
                    Console.WriteLine("ID: " + nomeItem);
                    listBox1.Items.Add(nomeItem);
                }
                panel3.Visible = false;
                panel2.Visible = true;

            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }

            //var cn2 = DatabaseHelper.getSGBDConnection();
            //if (!DatabaseHelper.verifySGBDConnection(cn))
            //    return;
            //SqlCommand cmd2 = new SqlCommand();

            //// Verificação               
            //cmd2.CommandText = "SELECT * FROM dbo. InventárioMundo (@ID_Personagem)";
            //cmd2.Parameters.AddWithValue("@ID_Personagem", ID_Personagem);
            //cmd2.Connection = cn2;
            //try
            //{
            //    SqlDataReader reader = cmd2.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        var nomeElemento = reader["Nome"].ToString();
            //        Console.WriteLine("ID: " + nomeElemento);
            //        listBox2.Items.Add(nomeElemento);
            //    }
            //    panel3.Visible = false;
            //    panel2.Visible = true;

            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
            //}
            //finally
            //{
            //    cn2.Close();
            //}
        }
    }
}
