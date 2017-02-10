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
    public partial class ReadForm : Form
    {
        public ReadForm()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            var crud = new CRUD();

            var args = new Dictionary<string, string>();
            args.Add("id", IdTextBox.Text);
            args.Add("name", NameTextBox.Text);
            args.Add("surname", SurnameTextBox.Text);
            args.Add("phoneNumber", PhoneTextBox.Text.ToString());
            args.Add("email", EmailTextBox.Text);

            var matchList = crud.Read(args);
            Storage.GetSharedInstance().matchList = matchList;

            this.Dispose();

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ReadForm_Load(object sender, EventArgs e)
        {

        }


    }
}
