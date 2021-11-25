using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BidItWarehouse
{
    public partial class Inventory : Form
    {
        string idToDelete;
        public Inventory()
        {
            InitializeComponent();

        }

        private void lblWarehouse_Click(object sender, EventArgs e)
        {

        }

        private void warehouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Warehouse().Show();
            this.Hide();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("API list", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://biditwarehouse.herokuapp.com/products ");
            HttpResponseMessage response = client.GetAsync("/products").Result;
            var prod = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            dataGridView1.DataSource = prod;
        }

        private void Inventory_Load_1(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://biditwarehouse.herokuapp.com/products ");
            HttpResponseMessage response = client.GetAsync("/products").Result;
            var prod = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            dataGridView1.DataSource = prod;
        }

        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idToDelete = this.dataGridView1.Rows[e.RowIndex].Cells["_ID"].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteProduct(idToDelete);
        }
        public static Task deleteProduct(string idToDelete)
        {
            HttpClient httpClient = new HttpClient();
            return httpClient.DeleteAsync("https://biditwarehouse.herokuapp.com/products/" + idToDelete);
        }
    }
}

//a