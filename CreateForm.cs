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
    public partial class CreateForm : Form
    {
        public CreateForm()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            var crud = new CRUD();
            var id = Storage.GetSharedInstance().users.Count + 1;
            crud.Create(id.ToString(),  nameTextBox.Text, surnameTextBox.Text, 
                phoneTextBox.Text, emailTextBox.Text);

            this.Dispose();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
