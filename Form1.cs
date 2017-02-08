using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void fillButton_Click(object sender, EventArgs e)
        {
            Storage.GetSharedInstance().GetData("../../db.txt");
            
            dataGridView1.DataSource = Storage.GetSharedInstance().users;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            CreateForm createForm = new CreateForm();
            createForm.ShowDialog();
            dataGridView1.DataSource = Storage.GetSharedInstance().users;
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Storage.GetSharedInstance().users;
            dataGridView1.Refresh();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

            var crud = new CRUD();
            var idCellValue = Convert.ToInt32(dataGridView1["Id", 1].Value);

            for (int i = 0; i < Storage.GetSharedInstance().users.Count; i += 1)
            {
               if (idCellValue == (Storage.GetSharedInstance().users[i].Id))
               {
                   crud.Delete(Storage.GetSharedInstance().users[i]);
               }
            }

            dataGridView1.Refresh();
        }
    }
}
