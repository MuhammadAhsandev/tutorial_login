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

namespace Login_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Function func = new Function();

        void login()
        {
            try
            {
                if (func.conn.State == ConnectionState.Closed) func.conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT id_user, tipe_user FROM tbl_user WHERE username = '" + txtUsername.Text + "' AND password = '"+txtPassword.Text+"'", func.conn);
                DataTable dt = new DataTable();

                sda.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        Function.tipe_user = "";
                        Function.id_user = "";

                        MessageBox.Show("Login Berhasil", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (dr["tipe_user"].ToString() == "Admin")
                        {
                            //pergi ke halaman selanjutnya
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if(func.conn.State == ConnectionState.Open)func.conn.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void cbShow_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShow.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }
    }
}
