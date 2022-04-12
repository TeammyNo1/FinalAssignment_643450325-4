using System.Data;
using System.Text;

namespace FinalAssignment_643450325_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Class2 coupon = new Class2();   
        Class3 saleManagement = new Class3();
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "CSV(*.csv)|*.csv";
            openFile.Title = "Please select file";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                dataGridView2.DataSource = null;

                DataTable dt = new DataTable();
                string[] colNames = { "รายการ", "ราคา" };

                foreach (string col in colNames)
                {
                    dt.Columns.Add(col);

                }

                foreach (string file in openFile.FileNames)
                {
                    try
                    {
                        if (File.Exists(file) == true)
                        {
                            //import file data
                            StreamReader csv = new StreamReader(file);
                            string textLine; //string line data
                            string[] splitLine; // use array to save split data


                            do
                            {
                                textLine = csv.ReadLine();
                                splitLine = textLine.Split(",");
                                dt.Rows.Add(splitLine);
                            }
                            while (csv.Peek() != -1);
                            csv.Close();
                            csv.Dispose();
                        }
                        
  }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                dataGridView2.DataSource = dt;
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV(*.csv)|*csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        int columnCount = dataGridView1.Columns.Count;
                        string columnNames = "";
                        string[] outputCSV = new string[dataGridView1.Rows.Count + 1];
                        for (int i = 0; i < columnCount; i++)
                        {
                            columnNames += dataGridView1.Columns[i].HeaderText.ToString() + ",";

                        }
                        for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                        {
                            for (int j = 0; j < columnCount; j++)
                            {
                                outputCSV[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + ",";

                            }

                        }
                        File.WriteAllLines(sfd.FileName, outputCSV, Encoding.UTF8);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error :" + ex.Message);
                    }
                }
            }
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = comboBox1.Text;
            dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;
            dataGridView1.Rows[n].Cells[2].Value = textBox3.Text;
            dataGridView1.Rows[n].Cells[3].Value = textBox4.Text;
            dataGridView1.Rows[n].Cells[4].Value = textBox5.Text;

            string pay = this.textBox3.Text;
            string getmoney = this.textBox4.Text;

            double Pay = Convert.ToDouble(pay);
            double GetMoney = Convert.ToDouble(getmoney);
            saleManagement.Bill(Pay, GetMoney);
            double Tpay = saleManagement.payBill();
            textBox5.Text = Tpay.ToString();


        }


    
       

        private void button1_Click(object sender, EventArgs e)
        {
            string totalcoupon = this.textBox2.Text;
            double Coupon = Convert.ToDouble(totalcoupon);
            coupon.create(Coupon);

            double totalCoupon = coupon.getCoupon();
            textBox3.Text = totalCoupon.ToString();
            


        }
    }
}