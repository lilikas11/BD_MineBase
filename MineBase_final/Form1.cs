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

namespace MineBase_final
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            var cn = DatabaseHelper.getSGBDConnection();
            if (DatabaseHelper.verifySGBDConnection(cn))
                return;
            SqlCommand cmd = new SqlCommand();
            var Email = EmailTextBox.Text;
            var Password = PasswordTextBox.Text;
            //if (string.IsNullOrEmpty(password))

            // Verificação 
               
            cmd.CommandText = "INSERT OCEAN.PERSON (Email, Password)  VALUES (@Email, @Password) "; //Função de login
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Password", Password);

            cmd.Connection = cn;
            
            try
            {
                cmd.ExecuteNonQuery();
                loginPanel.Visible = false;
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

        private void SoundButton_Click(object sender, EventArgs e)
        {
            SoundPlayer splayer = new SoundPlayer(@"C:\Users\liarc\Downloads\Minecraft.wav");
            splayer.Play();
        }
    }
}
