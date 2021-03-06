using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BidItWarehouse
{
    public partial class Inventory : Form
    {
        string idToDelete;
        string selectedName;
        string selectedDescription;
        string selectedStartPrice;
        string selectedImageURL;
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
            new About().Show();
            this.Hide();
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
            panelDeleteConfirm.Visible = false;
            panelUpdate.Visible = false;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://biditwarehouse.herokuapp.com/products ");
            HttpResponseMessage response = client.GetAsync("/products").Result;
            var prod = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            dataGridView1.DataSource = prod;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://biditwarehouse.herokuapp.com/products ");
            HttpResponseMessage response = client.GetAsync("/products").Result;
            var prod = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            dataGridView1.DataSource = prod;
            dataGridView1.Refresh();
        }

        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idToDelete = this.dataGridView1.Rows[e.RowIndex].Cells["_ID"].Value.ToString();
            selectedName = this.dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
            selectedDescription = this.dataGridView1.Rows[e.RowIndex].Cells["description"].Value.ToString();
            selectedStartPrice = this.dataGridView1.Rows[e.RowIndex].Cells["startingPrice"].Value.ToString();
            selectedImageURL = this.dataGridView1.Rows[e.RowIndex].Cells["imageURL"].Value.ToString();
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panelDeleteConfirm.Visible = true;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            panelUpdate.Visible = true;
            txtUpdateName.Text = selectedName;
            txtUpdateDescription.Text = selectedDescription;
            txtUpdateStartPrice.Text = selectedStartPrice;
            txtUpdateImageURL.Text = selectedImageURL;
        }

        private void btnUpdateCancel_Click(object sender, EventArgs e)
        {
            panelUpdate.Visible = false;
        }

        private void panelUpdate_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDescription_Click(object sender, EventArgs e)
        {

        }

        private void panelDeleteConfirm_Paint(object sender, PaintEventArgs e)
        {
            panelDeleteConfirm.Location = new Point(ClientSize.Width / 2 - panelDeleteConfirm.Size.Width / 2,
              ClientSize.Height / 2 - panelDeleteConfirm.Size.Height / 2);

            panelDeleteConfirm.Anchor = AnchorStyles.None;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteConfirm_Click(object sender, EventArgs e)
        {
            deleteProduct(idToDelete);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://biditwarehouse.herokuapp.com/products ");
            HttpResponseMessage response = client.GetAsync("/products").Result;
            var prod = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            dataGridView1.DataSource = prod;
            dataGridView1.Refresh();
            panelDeleteConfirm.Visible = false;
            new Inventory().Show();
            this.Hide();
        }

        private void btnDeleteDeny_Click(object sender, EventArgs e)
        {
            panelDeleteConfirm.Visible = false;
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile("https://biditwarehouse.herokuapp.com/products", "bidIt_printFile.txt");
                MessageBox.Show("Successfully printed file! Please check your Debug folder!");
            }
        }
    }
}