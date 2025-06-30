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
            BindData();

        }
        void BindData()
        {
           
            SqlCommand command = new SqlCommand("select * from inventory",connection); 
            SqlDataAdapter obj = new SqlDataAdapter(command); //SqlDataAdapter is used to fill the DataTable with data from the database
            DataTable table = new DataTable(); //create empty DataTable
            obj.Fill(table);
            dataGridView.DataSource = table;//set the DataSource of the DataGridView
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
            BindData(); // To refresh the view after intering new data(To see the latest changes) 


        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("update inventory set productName ='" + productName.Text + "',productType ='" + productType.Text + "',productQuantity ='" + productQuantity.Text + "' ,productColour = '" + productColour.Text + "' ,  productDate = '" + productDate.Text + "'" + "where  productId = '" + int.Parse(productId.Text)+"'", connection);
            //Sql query should be a string
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Product Updated Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


            connection.Close();
            BindData(); // To refresh the view after intering new data(To see the latest changes) 

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (productId.Text != "")
            {
                if (MessageBox.Show("Are you sure you want to delete this product?", "Delete Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("delete from inventory where productId = '" + int.Parse(productId.Text) + "'", connection);
                    //Sql query should be a string
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Product Deleted Successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    connection.Close();
                    BindData(); // To refresh the view after intering new data(To see the latest changes) 
                }
            }
            else 
            { 
                MessageBox.Show("Please enter a Product ID to delete.");

            }
        }
    }
}
