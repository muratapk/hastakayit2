using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace hastakayit
{
    public partial class Sehirler : Form
    {
        public Sehirler()
        {
            InitializeComponent();
        }
        kutuphane veri = new kutuphane();
        private void Sehirler_Load(object sender, EventArgs e)
        {

            veri.openConnection();
            doldur();
           

        }
        private void doldur()
        {
          dataGridView1.DataSource  =veri.doldur("Select * from sehirler");
        }

        private void Sehirler_FormClosing(object sender, FormClosingEventArgs e)
        {
            veri.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cumle = "insert into sehirler (sehirAdi) values ('" + textBox1.Text + "')";
            veri.ekle(cumle);
            doldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cumle = "Update sehirler set sehirAdi='" + textBox1.Text + "' where Id='" + textBox2.Text + "'";
            veri.ekle(cumle);
            doldur();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cumle = "Delete from sehirler where Id='" + textBox2.Text + "'";
            veri.ekle(cumle);
            doldur();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.CurrentCell.RowIndex;
            textBox1.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string cumle="Select * from sehirler where sehirAdi like '%"+textBox3.Text + "%'";
            dataGridView1.DataSource = veri.doldur(cumle);
            if(dataGridView1.Rows.Count > 1)
            {
                MessageBox.Show("Kayıt Bulundu");
            }
            else
            {
                MessageBox.Show("Kayıt Bulunamadı");
            }
        }
    }
}
