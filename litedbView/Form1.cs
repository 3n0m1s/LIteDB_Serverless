using System;
using System.ComponentModel;
using System.Windows.Forms;
using LiteDB;

namespace litedbView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Console.Write("load");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new LiteDatabase(@"db.db"))
                {

                        // Get customer collection
                        var persone = db.GetCollection<Person>("persons");
                        // Create your new customer instance
                        var persona = new Person 
                        {
                            Name = txtnome.Text,
                            Phones = txtphone1.Text,
                            IsActive = true
                        };
                        // Insert new customer document (Id will be auto-incremented)
                        persone.Insert(persona);

                        var results = persone.FindAll();

                        BindingList<Person> doclist = new BindingList<Person>();

                        // Ricarica di nuovo la collection dopo l aggiunta

                        // To display ALL columns of 'results'
                        foreach (var person in results)
                        {
                            //Console.WriteLine("Name: "+ person.Name + ", phones1 " + person.Phones[0] +", phones2 " + person.Phones[1] + ",is active: " + person.IsActive);
                            doclist.Add(person);

                        }

                        dataGridView1.DataSource = doclist;
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new LiteDatabase(@"db.db"))
                {


                    // Get customer collection
                    var persons = db.GetCollection<Person>("persons");
                    var results = persons.FindAll();

                    BindingList<Person> doclist = new BindingList<Person>();

                    // Ricarica di nuovo la collection dopo l aggiunta

                    // To display ALL columns of 'results'
                    foreach (var person in results)
                    {
                        //Console.WriteLine("Name: "+ person.Name + ", phones1 " + person.Phones[0] +", phones2 " + person.Phones[1] + ",is active: " + person.IsActive);
                        doclist.Add(person);

                    }

                    dataGridView1.DataSource = doclist;


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                using (var db = new LiteDatabase(@"db.db"))
                {
                    // Get customer collection
                    var persons = db.GetCollection<Person>("persons");
                    var results = persons.FindAll();

                    // To display ALL columns of 'results'
                    foreach (var person in results)
                    {
                        //Console.WriteLine("Name: "+ person.Name + ", phones1 " + person.Phones[0] +", phones2 " + person.Phones[1] + ",is active: " + person.IsActive);
                        persons.Delete(i => i.Name == person.Name);
                        

                    }

                    // Ricarica di nuovo la collection dopo l eliminazione

                    BindingList<Person> doclist = new BindingList<Person>();

                    // Ricarica di nuovo la collection dopo l aggiunta

                    // To display ALL columns of 'results'
                    foreach (var person in results)
                    {
                        //Console.WriteLine("Name: "+ person.Name + ", phones1 " + person.Phones[0] +", phones2 " + person.Phones[1] + ",is active: " + person.IsActive);
                        doclist.Add(person);

                    }

                    dataGridView1.DataSource = doclist;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    Console.WriteLine(dataGridView1.CurrentCell.RowIndex);
                    string id = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    string name = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
                    string phones = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
                    string active = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
                    MessageBox.Show("id: " + id + ",Nome: " + name + ",Telefono: " + phones + "attivo: " + active, "Info");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }

    }
}