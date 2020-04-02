using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace hw2
{
    public partial class Form1 : Form
    {
        private Model1Container db;
        public Form1()
        {
            InitializeComponent();

            //Database.SetInitializer(new DropCreateDatabaseAlways<Model1Container>());
            //db = new Model1Container();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myDatabase2DataSet.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.myDatabase2DataSet.Users);
            //db.Users.Load();
            //dataGridView1.DataSource = db.Users.Local.ToBindingList();
        }
    }
}
