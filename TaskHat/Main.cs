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
    public partial class Main : Form
    {
        private void Main_Load(object sender, EventArgs e)
        {
            Load l = new Load();
            l.Visible = false;
            getName();
        }

        public Main()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lstTasks.Items.Add(txtItems.Text);
            string text = txtItems.Text;
            Load l = new Load();
            System.IO.File.WriteAllText(@"C:\TEMP\"+getName()+".txt" , text);
            txtItems.Text = null;
        }
        public string getName()
        {
            Load l = new Load();
            string strName = l.txtName.Text;
            return strName;
        }
    }
}
