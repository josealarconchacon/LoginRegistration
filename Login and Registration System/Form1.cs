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
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "" && txtPassword.Text =="" && txtComPassword.Text == "")
            {
                MessageBox.Show("Username and Password fileds are empty"," Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }    
            else if (txtPassword.Text == txtComPassword.Text)
            {
                con.Open();
                string register = "insert into tbl_users values ('"+txtUsername.Text+"','"+txtPassword.Text+"')";
                cmd = new OleDbCommand(register, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your Account has been successfully created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
            }
            else
            {
                MessageBox.Show("Password does not match", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtComPassword.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtComPassword.Text = "";
            txtUsername.Focus();
        }

        private void checkboxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if(checkboxShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtComPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtComPassword.PasswordChar = '•';
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }

        private void txtComPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
