using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BidItWarehouse
{
    public partial class Warehouse : Form
    {
        public Warehouse()
        {
            InitializeComponent();
        }


        //[{"_id":"6183cf926215e401a419aabf","name":"product1",
        //"description":"description1","startingPrice":"startingPrice1",
        //"imageURL":"imageURL1","__v":0},

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        private void Warehouse_Load(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This app does this and that!", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void warehouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Warehouse().Show();
            this.Hide();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Inventory().Show();
            this.Hide();
        }
    }
}
