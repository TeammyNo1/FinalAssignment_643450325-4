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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "CSV(.csv)|*csv";
            openFile.Title = "Please select fiel";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = null;

                DataTable dt = new DataTable();
                string[] colName = { "รายการ", "ราคา", "จ่าย", "ทอน" };

                foreach (string col in colName)
                {
                    dt.Columns.Add(col);
                }

                foreach (string file in openFile.FileNames)
                {
                    try
                    {
                        if (File.Exists(file) == true)
                        {
                            StreamReader csv = new StreamReader(file);
                            string textLine;
                            string[] spLitline;
                            do
                            {
                                textLine = csv.ReadLine();
                                spLitline = textLine.Split(",");
                                dt.Rows.Add(spLitline);

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
    }
}