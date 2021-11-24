using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
//using Warehouse;

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

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
           
        }

        public static Task<HttpResponseMessage> SubmitPersonToAPIAsync(Product product)
        {
            HttpClient httpClient = new HttpClient();

            string productJson = JsonConvert.SerializeObject(product);

            HttpContent stringContent = new StringContent(productJson, Encoding.UTF8, "application/json");

            return httpClient.PostAsync("https://biditwarehouse.herokuapp.com/products", stringContent);
        }

        private void btnSubmit_Click_2(object sender, EventArgs e)
        {
            Product product = new Product { name = txtName.Text, description = txtDescription.Text, startingPrice = txtStartPrice.Text, imageURL = txtImageURL.Text, };
            SubmitPersonToAPIAsync(product).Wait();
            MessageBox.Show("Posted!", "Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public class Product
    {
        public string _ID { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("startingPrice")]
        public string startingPrice { get; set; }
        [JsonProperty("imageURL")]
        public string imageURL { get; set; }
    }
}