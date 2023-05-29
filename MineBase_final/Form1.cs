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
        private string nomeItemSelecionadoL1;
        private string nomeItemSelecionadoL2;
        private int ID_CurrentBioma;
        private List<InventarioDoMundo> inventarioMundo;



        public Form1()
        {
            InitializeComponent();
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            inventarioMundo = new List<InventarioDoMundo>();
            this.MouseClick += Form1_MouseClick;
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

            var cn2 = DatabaseHelper.getSGBDConnection();
            if (!DatabaseHelper.verifySGBDConnection(cn2))
                return;
            SqlCommand cmd2 = new SqlCommand();
            inventarioMundo.Clear();
            // ALTERAR ---> JÁ NÃO EXISTE ESTA FUNCTION, APENAS OS BIOMAS             
            cmd2.CommandText = "SELECT * FROM dbo.MundoFunction()";
            cmd2.Connection = cn2;
            try
            {
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    var nomeElemento = reader["Nome"].ToString();
                    var obj1 = new InventarioDoMundo
                    {
                        ID = int.Parse(reader["ID"].ToString()),
                        Nome = reader["Nome"].ToString(),
                        Tipo = reader["Tipo"].ToString(),
                    };
                    inventarioMundo.Add(obj1);
                   // inventarioMundo.Find(x => x.ID == 12)  ---> Aprende burra

                    Console.WriteLine("ID: " + nomeElemento);
                    listBox2.Items.Add(nomeElemento);
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
                cn2.Close();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedItem = listBox1.SelectedItem.ToString();
                nomeItemSelecionadoL1 = selectedItem;
                infoButton.Visible = true;
                
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Control control = listBox1;
            Point relativePoint = control.PointToClient(Cursor.Position);
            if (!control.Bounds.Contains(relativePoint))
            {
                listBox1.ClearSelected();
                infoButton.Visible = false;
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                string selectedItem = listBox2.SelectedItem.ToString();
                nomeItemSelecionadoL2 = selectedItem;
                infoButton2.Visible = true;
            }
        }

        //SHOW STATS DO INVENTÁRIO
        private void button1_Click(object sender, EventArgs e)
        {

        }


    }
}
