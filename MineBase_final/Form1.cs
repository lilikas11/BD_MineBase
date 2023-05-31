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
        private int ID_ItemSelectedL1;
        private int ID_SelectedItemL2;
        private int ID_CurrentBioma;
        private string nomeBioma;
        private int Nome_ItemSelectedL3;
        private List<InventarioDoMundo> inventarioMundo;
        private List<InventarioDoMundo> inventarioPersonagem;



        public Form1()
        {
            InitializeComponent();
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            inventarioMundo = new List<InventarioDoMundo>();
            inventarioPersonagem = new List<InventarioDoMundo>();
            this.MouseClick += Form1_MouseClick;
        }

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
                            ID_Jogador = int.Parse(reader["ID"].ToString()); // ver se isto funcionou
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
                    var nomeElemento = reader["Nome"].ToString();
                    var obj1 = new InventarioDoMundo
                    {
                        ID = int.Parse(reader["ID"].ToString()),
                        Nome = reader["Nome"].ToString(),
                        Tipo = reader["Tipo"].ToString()
                    };
                    inventarioPersonagem.Add(obj1);  // inventarioMundo.Find(x => x.ID == 12)  ---> Aprende burra                                              
                    listBox1.Items.Add(nomeElemento);
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
            cmd2.CommandText = "SELECT * FROM dbo.BiomaFunction(1)";
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
                    inventarioMundo.Add(obj1);  // inventarioMundo.Find(x => x.ID == 12)  ---> Aprende burra                                              
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

            var cn3 = DatabaseHelper.getSGBDConnection();
            if (!DatabaseHelper.verifySGBDConnection(cn3))
                return;
            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = "SELECT ID, Nome FROM dbo.Bioma order by Nome asc";
            cmd3.Connection = cn3;
            try
            {
                SqlDataReader reader = cmd3.ExecuteReader();
                while (reader.Read())
                {
                    var nomeBioma = reader["Nome"].ToString();
                    if(string.IsNullOrEmpty(comboBox2.Text)) comboBox2.Text = nomeBioma;
                    comboBox2.Items.Add(nomeBioma);
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn3.Close();
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int selectedItem = listBox1.SelectedIndex;
                ID_ItemSelectedL1 = selectedItem;
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
            if (listBox2.SelectedIndex != -1)
            {
                int selectedIndex = listBox2.SelectedIndex;
                ID_SelectedItemL2 = selectedIndex;
                infoButton2.Visible = true;

            }
        }

        //SHOW STATS DO INVENTÁRIO 
        private void infoButton_Click(object sender, EventArgs e)
        {
            var cn = DatabaseHelper.getSGBDConnection();
            if (!DatabaseHelper.verifySGBDConnection(cn))
                return;
            SqlCommand cmd = new SqlCommand();
            if (inventarioPersonagem[ID_ItemSelectedL1].Tipo == "Item")
            {
                int ID_Item = inventarioPersonagem[ID_ItemSelectedL1].ID;
                cmd.CommandText = "SELECT * FROM dbo.ItemInfo(@ID_Item)";
                cmd.Parameters.AddWithValue("@ID_Item", ID_Item);

                cmd.Connection = cn;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        textBox1.Text = reader["Nome"].ToString();
                        textDurabilidade.Text = reader["Durabilidade"].ToString();
                        textBox2.Text = reader["Dano"].ToString();
                        textBox3.Text = reader["Fome"].ToString();
                        textBox4.Text = reader["Tempo"].ToString();
                        textBox5.Text = reader["Efeito"].ToString();
                    }
                    panel1.Visible = true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
                }

                finally
                {
                    cn.Close();
                }
            }
            else if (inventarioPersonagem[ID_ItemSelectedL1].Tipo == "Bloco")
            {
                int ID_Bloco = inventarioPersonagem[ID_ItemSelectedL1].ID;
                cmd.CommandText = "SELECT * FROM dbo.BlocoInfo(@ID_Bloco)";
                cmd.Parameters.AddWithValue("@ID_Bloco", ID_Bloco);
                cmd.Connection = cn;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        textBox1.Text = reader["Nome"].ToString();
                        textBox10.Text = reader["Dureza"].ToString();
                    }
                    panel1.Visible = true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
                }

                finally
                {
                    cn.Close();
                }
            }
        }
      private void infoButton2_Click(object sender, EventArgs e)
            {
            var cn = DatabaseHelper.getSGBDConnection();
            if (!DatabaseHelper.verifySGBDConnection(cn))
                return;
            SqlCommand cmd = new SqlCommand();

            if (inventarioMundo[ID_SelectedItemL2].Tipo == "Bloco")
            {
                int ID_Bloco = inventarioMundo[ID_SelectedItemL2].ID;
                cmd.CommandText = "SELECT * FROM dbo.BlocoInfo(@ID_Bloco)";
                cmd.Parameters.AddWithValue("@ID_Bloco", ID_Bloco);
                cmd.Connection = cn;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        textBox1.Text = reader["Nome"].ToString();
                        textBox10.Text = reader["Dureza"].ToString();
                    }
                    panel1.Visible = true;
                }
                catch (Exception ex) {
                    throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
                }

                finally {
                    cn.Close(); 
                }
            }

            else if (inventarioMundo[ID_SelectedItemL2].Tipo == "Mob" || inventarioMundo[ID_SelectedItemL2].Tipo == "Villager")
            {
                int ID_Mob = inventarioMundo[ID_SelectedItemL2].ID;
                cmd.CommandText = "SELECT * FROM dbo.MobInfo(@ID_Mob)";
                cmd.Parameters.AddWithValue("@ID_Mob", ID_Mob);
                cmd.Connection = cn;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        textBox1.Text = reader["Nome"].ToString();
                        textBox6.Text = reader["Personalidade"].ToString();
                        textBox12.Text = reader["Dano_Facil"].ToString();
                        textBox7.Text = reader["Dano_Normal"].ToString();
                        textBox9.Text = reader["Dano_Dificil"].ToString();
                        textBox8.Text = reader["Drop"].ToString();
                        textBox11.Text = reader["Trabalho"].ToString();
                    }
                    panel1.Visible = true;
                }
                catch (Exception ex) {
                    throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
                }

                finally {
                    cn.Close();
                }
            }

        }
        //comboBox 2 ----> Biomas - perguntar ao pedroooo porque é que não funciona
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                ID_CurrentBioma = comboBox2.SelectedIndex + 1;

            }

            var cn = DatabaseHelper.getSGBDConnection();
            if (!DatabaseHelper.verifySGBDConnection(cn))
                return;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM dbo.BiomaFunction(@ID_CurrentBioma)";
            cmd.Parameters.AddWithValue("@ID_CurrentBioma", ID_CurrentBioma);
            cmd.Connection = cn;
            try
            {
                inventarioMundo.Clear();
                listBox2.Items.Clear();
                SqlDataReader reader = cmd.ExecuteReader();
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
                    listBox2.Items.Add(nomeElemento);
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


        }

        private void FecharInfoButton_Click(object sender, EventArgs e)
        {
            textDurabilidade.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox9.Clear();
            textBox8.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            panel1.Visible = false;
        }

        private void AddInvent_Click(object sender, EventArgs e)
        {
            var cn = DatabaseHelper.getSGBDConnection();
            if (!DatabaseHelper.verifySGBDConnection(cn))
                return;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select Nome from dbo.TipoItem";
            cmd.Connection = cn;
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var nomeElemento = reader["Nome"].ToString();
                    listBox3.Items.Add(nomeElemento);
                }
                panel4.Visible = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
            }

            finally
            {
                cn.Close();
            }
            
        }



        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void FilterMund_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NextDayButton_Click(object sender, EventArgs e)
        {

        }

        private void MatarMob_Click(object sender, EventArgs e)
        {
            //apagar tudo dos dois inventários 
            int ID_Mob = inventarioMundo[ID_SelectedItemL2].ID;
            inventarioMundo.Clear();
            inventarioPersonagem.Clear();

            var cn = DatabaseHelper.getSGBDConnection();
            if (!DatabaseHelper.verifySGBDConnection(cn))
                return;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXEC Matar @ID_Jogador, @ID_Mob";
            cmd.Parameters.AddWithValue("@ID_Jogador", ID_Jogador);
            cmd.Parameters.AddWithValue("@ID_Mob", ID_Mob);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
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
            cmd2.CommandText = "SELECT * FROM dbo.Inventário (@ID_Personagem)";
            cmd2.Parameters.AddWithValue("@ID_Personagem", ID_Personagem);
            cmd2.Connection = cn2;
            try
            {
                inventarioMundo.Clear();
                listBox2.Items.Clear();
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    var nomeElemento = reader2["Nome"].ToString();
                    var obj1 = new InventarioDoMundo
                    {
                        ID = int.Parse(reader2["ID"].ToString()),
                        Nome = reader2["Nome"].ToString(),
                        Tipo = reader2["Tipo"].ToString()
                    };
                    inventarioPersonagem.Add(obj1);                                            
                    listBox1.Items.Add(nomeElemento);
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


            var cn3 = DatabaseHelper.getSGBDConnection();
            if (!DatabaseHelper.verifySGBDConnection(cn3))
                return;
            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = "SELECT * FROM dbo.BiomaFunction(@ID_CurrentBioma)";
            cmd3.Parameters.AddWithValue("@ID_CurrentBioma", ID_CurrentBioma);
            cmd3.Connection = cn3;
            try
            {
                inventarioMundo.Clear();
                listBox2.Items.Clear();
                SqlDataReader reader3 = cmd3.ExecuteReader();
                while (reader3.Read())
                {
                    var nomeElemento = reader3["Nome"].ToString();
                    var obj1 = new InventarioDoMundo
                    {
                        ID = int.Parse(reader3["ID"].ToString()),
                        Nome = reader3["Nome"].ToString(),
                        Tipo = reader3["Tipo"].ToString(),
                    };
                    inventarioMundo.Add(obj1);
                    listBox2.Items.Add(nomeElemento);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn3.Close();
            }


        }

        private void Minerar_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void AddButon2_Click(object sender, EventArgs e)
        {
            var cn = DatabaseHelper.getSGBDConnection();
            if (!DatabaseHelper.verifySGBDConnection(cn))
                return;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = cn;
                cmd.CommandText = "EXEC dbo.AddItem @id_tipoItem, @id_personagem";
                Nome_ItemSelectedL3 += 1;
                cmd.Parameters.AddWithValue("@id_tipoItem", Nome_ItemSelectedL3);
                cmd.Parameters.AddWithValue("@id_personagem", ID_Personagem);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to add item to inventory. \n ERROR MESSAGE: \n" + ex.Message);
                }
                finally
                {
                    cn.Close();
                }
            }
            panel4.Visible = false;
            var cn4 = DatabaseHelper.getSGBDConnection();
            if (!DatabaseHelper.verifySGBDConnection(cn4))
                return;
            SqlCommand cmd4 = new SqlCommand();
            cmd4.CommandText = "SELECT * FROM dbo.Inventário (@ID_Personagem)";
            cmd4.Parameters.AddWithValue("@ID_Personagem", ID_Personagem);
            cmd4.Connection = cn4;
            try
            {
                inventarioPersonagem.Clear();
                listBox1.Items.Clear();
                SqlDataReader reader4 = cmd4.ExecuteReader();
                while (reader4.Read())
                {
                    var nomeElemento = reader4["Nome"].ToString();
                    var obj1 = new InventarioDoMundo
                    {
                        ID = int.Parse(reader4["ID"].ToString()),
                        Nome = reader4["Nome"].ToString(),
                        Tipo = reader4["Tipo"].ToString()
                    };

                    inventarioPersonagem.Add(obj1);
                    listBox1.Items.Add(nomeElemento);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn4.Close();
            }


        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int selectedItem = listBox3.SelectedIndex;
                Nome_ItemSelectedL3 = selectedItem;
                AddButon2.Visible = true;

            }
        }
    }
}
