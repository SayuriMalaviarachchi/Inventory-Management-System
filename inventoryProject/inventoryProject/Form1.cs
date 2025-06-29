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

namespace inventoryProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-1U6OUD2;Initial Catalog=inventory_DB;Integrated Security=True;TrustServerCertificate=True");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into inventory values ('"+int.Parse(productId.Text)+"','"+(productName.Text)+"','"+(productType.Text)+"','"+(productQuantity.Text)+"' , '"+(productColour.Text)+"' , '"+(productDate.Text)+"')" , connection);
            //Sql query should be a string
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Product Inserted Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            
            
            connection.Close();
            

        }
    }
}
