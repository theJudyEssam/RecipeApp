using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recipe_App
{
    public partial class Form1 : Form
    {


        DataTable table;
        Hashtable hashtable = new Hashtable();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string recipe = textBox2.Text;
            string title = textBox1.Text;

            table.Rows.Add(title);
            hashtable.Add(title, recipe);

            textBox1.Clear();
            textBox2.Clear();

            dataGridView1.DataSource = table;
            dataGridView1.Columns["Recipe Name"].Width = 265;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("Recipe Name");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            // gets the current 
            int index = dataGridView1.CurrentCell.RowIndex;
            if (index > -1)
            {
                string title = table.Rows[index].ItemArray[0].ToString();
                textBox1.Text = table.Rows[index].ItemArray[0].ToString();
                textBox2.Text = hashtable[title].ToString();


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.CurrentCell.RowIndex;


                table.Rows[index].Delete();
            }
            catch (Exception error)
            {
                textBox2.Text = "The List is Already Empty.";

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string new_text = textBox1.Text;
            string new_ingred = textBox2.Text;

            int index = dataGridView1.CurrentCell.RowIndex;

            table.Rows[index].SetField(0 /*column index*/, new_text);
            hashtable[new_text] = new_ingred;


            textBox1.Clear();
            textBox2.Clear();

        }
    }
}
