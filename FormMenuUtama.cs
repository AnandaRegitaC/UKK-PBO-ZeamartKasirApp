using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ZeamartKasirApp
{
    public partial class FormMenuUtama : Form
    {
        SqlConnection co = new SqlConnection(@"Server = LAPTOP-UPB13FNG\SQLPROJECT; Database = DB_KASIR; integrated security = true");
        SqlCommand mycommand = new SqlCommand();
        SqlDataAdapter myadapter = new SqlDataAdapter();


        public FormMenuUtama()
        {
            InitializeComponent();
            Bersihkan();
            readdata();
        }

        void Bersihkan()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "";
        }

        void readdata()
        {
            try
            {
                mycommand.Connection = co;
                myadapter.SelectCommand = mycommand;
                mycommand.CommandText = "select * from TBL_BARANG";
                DataSet ds = new DataSet();
                if (myadapter.Fill(ds, "TBL_BARANG") > 0)
                {
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "TBL_BARANG";
                }
                co.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "")
            {
                MessageBox.Show("Isi kolom terlebih dahulu!");
            }
            else
            {
                try
                {
                    mycommand.Connection = co;
                    myadapter.SelectCommand = mycommand;
                    mycommand.CommandText = "INSERT INTO TBL_BARANG VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                    DataSet ds = new DataSet();
                    if (myadapter.Fill(ds, "TBL_BARANG") > 0)
                    {
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "TBL_BARANG";
                    }
                    MessageBox.Show("Data berhasil di input");
                    readdata();
                    Bersihkan();
                    co.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data gagal di input");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["KodeBarang"].Value.ToString();
                textBox2.Text = row.Cells["NamaBarang"].Value.ToString();
                textBox3.Text = row.Cells["HargaBeli"].Value.ToString();
                textBox4.Text = row.Cells["HargaJual"].Value.ToString();
                textBox5.Text = row.Cells["JumlahBarang"].Value.ToString();
                textBox6.Text = row.Cells["SatuanBarang"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox6.Text.Trim() == "")
            {
                MessageBox.Show("Isi kolom terlebih dahulu!");
            }
            else
            {
                try
                {
                    mycommand.Connection = co;
                    myadapter.SelectCommand = mycommand;
                    mycommand.CommandText = "UPDATE TBL_BARANG SET KodeBarang='" + textBox1.Text + "', NamaBarang='" + textBox2.Text + "', HargaBeli='" + textBox3.Text + "', HargaJual='" + textBox4.Text + "', JumlahBarang='" + textBox5.Text + "', SatuanBarang='" + textBox6.Text + "'where KodeBarang='" + textBox1.Text + "'";
                    DataSet ds = new DataSet();
                    if (myadapter.Fill(ds, "TBL_BARANG") > 0)
                    {
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "TBL_BARANG";
                    }
                    MessageBox.Show("Data berhasil di input");
                        readdata();
                        Bersihkan();
                    co.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin ingin menghapus "+textBox2.Text+"?", "Hapus Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    mycommand.Connection = co;
                    myadapter.SelectCommand = mycommand;
                    mycommand.CommandText = "DELETE FROM TBL_BARANG WHERE KodeBarang='" + textBox1.Text + "'";
                    DataSet ds = new DataSet();
                    if (myadapter.Fill(ds, "TBL_BARANG") > 0)
                    {
                        dataGridView1.DataSource = ds;
                        dataGridView1.DataMember = "TBL_BARANG";
                    }
                    MessageBox.Show("Hapus data berhasil!");
                        readdata();
                        Bersihkan();
                    co.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }
    }
}
