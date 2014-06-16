using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TaskHat
{
    public partial class Load : Form
    {
        public Load()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "Tasks.txt";
            try
            {
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                    {
                        file.WriteLine(txtName.Text);
                    }
                }
                listBox1.DataSource = null;
                listBox1.DataSource = File.ReadAllLines(path);
                txtName.Focus();
                txtName.Text = null;
        }

            catch(IOException)
            {
                lblWelcome.Text = "Hi";
            }
        }

        private void Load_Load(object sender, EventArgs e)
        {
            string path = "Tasks.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to. 
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(txtName.Text);
                }
            }
            listBox1.DataSource = File.ReadAllLines("Tasks.txt");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try { DeleteLinesFromFile(listBox1.SelectedItem.ToString()); }
            catch (IOException) { MessageBox.Show("You cleared an emtpy task list."); }
            catch (NullReferenceException) { MessageBox.Show("You cleared an emtpy task list. :)"); }
            listBox1.DataSource = null;
            listBox1.DataSource = File.ReadAllLines("Tasks.txt");
        }

        public void DeleteLinesFromFile(string strLineToDelete)
    {
        string strFilePath = "Tasks.txt";
        string strSearchText = strLineToDelete;
        string strOldText;
        string n = "";
        StreamReader sr = File.OpenText(strFilePath);
        while ((strOldText = sr.ReadLine()) != null)
        {
            if (!strOldText.Contains(strSearchText))
            {
                n += strOldText + Environment.NewLine;
            }
        }
        sr.Close();
        File.WriteAllText(strFilePath, n);
    }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string[] tasks = File.ReadAllLines("Tasks.txt");
            Random rnd1 = new Random();
            rnd1.Next(tasks.Length);
            MessageBox.Show("Your task is " + tasks[rnd1.Next(tasks.Length)]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
        }
        }
    }


