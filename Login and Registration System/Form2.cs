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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source = users.mdb");
        OleDbCommand cmd = new OleDbCommand();

        private void ClearField() {
            FirstNameTextBox.Clear();
            LastNameTextBox.Clear();
            PayTextBox.Clear();
            EIDTextBox.Clear();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand commanand = new OleDbCommand();
            commanand.Connection = con;
            commanand.CommandText = "insert into tbl_users (EID, Firstname, Lastname, Pay) values ('" + EIDTextBox.Text + "', '"
                                                                                                 + FirstNameTextBox.Text + "','"
                                                                                                 + LastNameTextBox.Text + "', '"
                                                                                                 + PayTextBox.Text + "')";
            commanand.ExecuteNonQuery();
            MessageBox.Show("Data Saved...!!!");
            ClearField();
            con.Close();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand commanand = new OleDbCommand();
            commanand.Connection = con;
            commanand.CommandText = "update tbl_users set Firstname='" + FirstNameTextBox.Text + "' ,Lastname='" + LastNameTextBox.Text + "' ,Pay='" + PayTextBox.Text + "' where EID=" + EIDTextBox.Text + "";

            commanand.ExecuteNonQuery();
            ClearField();
            con.Close();
            MessageBox.Show("Data Updated...!!!");
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand commanand = new OleDbCommand();
            commanand.Connection = con;
            commanand.CommandText = "delete from tbl_users where (EID =" + EIDTextBox.Text + ")";
            commanand.ExecuteNonQuery();
            ClearField();
            con.Close();
            MessageBox.Show("Data Deleted...!!!");
        }

        private void ViewDataBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand commanand = new OleDbCommand();
            commanand.Connection = con;
            commanand.CommandText = "select * from tbl_users";
            commanand.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            OleDbDataAdapter data = new OleDbDataAdapter(commanand);
            data.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            con.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
