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

        /*private void btnSubmit_Click_2(object sender, EventArgs e)
        {
            Product product = new Product { name = txtName.Text, description = txtDescription.Text, startingPrice = txtStartPrice.Text, imageURL = txtImageURL.Text, };
            SubmitPersonToAPIAsync(product).Wait();
            MessageBox.Show("Posted!", "Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }*/

        private void btnSubmit_Click_2(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtName.Text) && !String.IsNullOrEmpty(txtStartPrice.Text) && !String.IsNullOrEmpty(txtDescription.Text) && !String.IsNullOrEmpty(txtImageURL.Text))
            {
                Product product = new Product { name = txtName.Text, description = txtDescription.Text, startingPrice = txtStartPrice.Text, imageURL = txtImageURL.Text, };
                SubmitPersonToAPIAsync(product).Wait();
                MessageBox.Show("Posted!", "Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No fields should be left empty!");
            }


        }



        private void btnScanBarcode_Click_1(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string[] name = { "Statue", "Car", "House", "Painting", "Sword" };
            string[] description = { "Exotic", "Antique", "Basic", "Boring", "Exquisite" };
            string[] price = { "10000", "2000", "42000", "500000", "3000000" };
            string[] imgurl = { "https://thumbor.forbes.com/thumbor/fit-in/1200x0/filters%3Aformat%28jpg%29/https%3A%2F%2Fspecials-images.forbesimg.com%2Fimageserve%2F5d35eacaf1176b0008974b54%2F0x0.jpg%3FcropX1%3D790%26cropX2%3D5350%26cropY1%3D784%26cropY2%3D3349", "https://images.adsttc.com/media/images/5ecd/d4ac/b357/65c6/7300/009d/large_jpg/02C.jpg?1590547607", "https://www.dhresource.com/0x0/f2/albu/g10/M00/74/29/rBVaWV4tRHWAf5FUAAJU33_koOQ340.jpg/abstract-thinker-people-shape-modern-sculpture.jpg", "https://n4.sdlcdn.com/imgs/i/i/h/100yellow-Oil-Painting-Canvas-Painting-SDL472745786-1-8708f.jpeg", "https://images.partydelights.co.uk/WEAP/07/4/front/v3/fac/1.jpg" };
            int i1 = rnd.Next(name.Length);
            int i2 = rnd.Next(description.Length);
            int i3 = rnd.Next(price.Length);
            int i4 = rnd.Next(imgurl.Length);
            txtName.Text = name[i1].ToString();
            txtDescription.Text = description[i2].ToString();
            txtStartPrice.Text = price[i3].ToString();
            txtImageURL.Text = imgurl[i4].ToString();
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