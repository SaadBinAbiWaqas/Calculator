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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Calculator
{
    // class form 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string expression1 = "";
        decimal res = 0;
        int x = 0;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // below is all the functions which do operations
        private void button4_Click(object sender, EventArgs e)
        {

       
            textBox1.Text += "1";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text += "-";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            // Code to display history from database
            string connectionString = "Data Source=DESKTOP-L3K1GKN\\SQLEXPRESS;Initial Catalog=Calculator1;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // 3. Open connection
                connection.Open();

                // 4. Prepare query
                string query = "SELECT * FROM RESULT";

                // 5. Execute query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        // Create DataTable to hold the results
                        DataTable dataTable = new DataTable();

                        // Fill the DataTable with the query results
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                }

                // 6. Close connection (not necessary due to using statement)
                connection.Close();
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text += "/";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text += "+";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text += "*";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            string connectionString = "Data Source=DESKTOP-L3K1GKN\\SQLEXPRESS;Initial Catalog=Calculator1;Integrated Security=True";

            try
            {
                string expression = textBox1.Text;
                expression1 = expression;
                DataTable dt = new DataTable();
                var result = dt.Compute(expression, "");
                res = (int)result;
             
                textBox1.Text = result.ToString();
              
                
            }
            catch (Exception ex)
            {
                textBox1.Text = "Error";
            }

            
               using (SqlConnection connection = new SqlConnection(connectionString))
               {
                connection.Open();
                
                
                   string query = "INSERT INTO RESULT (id,EXPRESSION, result) VALUES ('"+x+"','"+expression1+"', '"+res+"')";
                   SqlCommand command = new SqlCommand(query, connection);
                   command.ExecuteNonQuery();
                x = x + 1;
            }
               
        }



        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double number = double.Parse(textBox1.Text);
                double result = Math.Sqrt(number);
                textBox1.Text = result.ToString();
            }
            catch (FormatException)
            {
                textBox1.Text = "Invalid Input";
            }
            catch (Exception ex)
            {
                textBox1.Text = "Error";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button19_Click(object sender, EventArgs e)
        {
            // 1. address of database and sql server
            string connectionString = "Data Source=DESKTOP-L3K1GKN\\SQLEXPRESS;Initial Catalog=Calculator1;Integrated Security=True";

            // 2. establish connection
            SqlConnection connection = new SqlConnection(connectionString);

            // 3. open connection
            connection.Open();

            //4. prepapre query
            string deleteid = textBox2.Text;
            //string secondname = textBox2.Text;
            string query = "DELETE FROM RESULT WHERE id = '" + deleteid + "'";

            // 5. execute query
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();

            // 6. close connection
            connection.Close();


            MessageBox.Show("Row is deleted Successfully");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string connectionstring = "Data Source=DESKTOP-L3K1GKN\\SQLEXPRESS;Initial Catalog=Calculator1;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand cmd = new SqlCommand("update RESULT set EXPRESSION = @Expression, result = @RESULT where id = @ID", connection);
            cmd.Parameters.AddWithValue("@ID", textBox2.Text);
            cmd.Parameters.AddWithValue("@Expression", textBox5.Text);
            cmd.Parameters.AddWithValue("@Result", textBox4.Text);
            cmd.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Data Updated Successfully");
        }

        private void button21_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            string connectionstring = "Data Source=DESKTOP-L3K1GKN\\SQLEXPRESS;Initial Catalog=Calculator1;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand cmd = new SqlCommand("insert into RESULT values (@id, @EXPRESSION, @result)", connection);
            cmd.Parameters.AddWithValue("@ID", textBox2.Text);
            cmd.Parameters.AddWithValue("@Expression", textBox5.Text);
            cmd.Parameters.AddWithValue("@Result", textBox4.Text);
            cmd.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Data Saved Successfully");

        }

        private void button22_Click(object sender, EventArgs e)
        {

        }
    }
}
