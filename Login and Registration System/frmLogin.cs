using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Login_and_Registration_System
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void checkboxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
             
            }
            else
            {
                txtPassword.PasswordChar = '•';
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            new frmRegister().Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string login = "Select * from tbl_users where Username = '" + txtUsername.Text + "' and password = '" + txtPassword.Text + "'";
            cmd = new OleDbCommand(login, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                count = count + 1;
            }
            if (count == 1)
            {


                this.Hide();
                Form2 f2 = new Form2();
                f2.Show();
                con.Close();
                con.Dispose();
                // MessageBox.Show("UserName and Password is Correct");

            }
            else if (count > 1)
            {
                MessageBox.Show("Duplicate");
            }
            else
            {
                MessageBox.Show("Password is not correct");
            }
        }
    }
}
