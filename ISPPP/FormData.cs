using ISPPP;
using System;
using System.Data;
using System.Windows.Forms;

namespace ISPPP
{
    public partial class FormData : Form
    {
        public Workpiece[] Workpieces { get; private set; }
        public FormData(Workpiece[] workpieces)
        {
            InitializeComponent();
            if (workpieces != null)
            {
                Workpieces = Workpiece.Copy(workpieces);

                UpdateDataGridView(workpieces);
                numericUpDown_M.Value = workpieces.Length;
                numericUpDown_N.Value = workpieces[0].times.Length;
            }
        }

        public void UpdateDataGridView(Workpiece[] workpieces)
        {
            DataTable table = new DataTable();

            for (int i = 0; i < workpieces.Length; i++)
            {
                table.Columns.Add(workpieces[i].number.ToString(), typeof(int));
            }

            for (int j = 0; j < workpieces[0].times.Length; j++)
            {
                DataRow row = table.NewRow();

                for (int i = 0; i < workpieces.Length; i++)
                {
                    row[i] = workpieces[i].times[j];
                }

                table.Rows.Add(row);
            }

            dataGridView1.DataSource = table;
        }

        private void FormData_Load(object sender, EventArgs e)
        {

        }

        private void generate_Click(object sender, EventArgs e)
        {
            Workpiece[] workpieces =  Workpiece.Generate((int)numericUpDown_N.Value, (int)numericUpDown_M.Value, (int)numericUpDown_MinTime.Value, (int)numericUpDown_MaxTime.Value + 1);

            Workpieces = workpieces;
            UpdateDataGridView(workpieces);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Workpieces.Length; i++)
            {
                for (int j = 0; j < Workpieces[0].times.Length; j++)
                {
                    Workpieces[i].times[j] = (int)dataGridView1.Rows[j].Cells[i].Value;
                }
            }
            DialogResult = DialogResult.Yes;
            //onButtonClick();
            DialogResult result = MessageBox.Show("Сохранить данные","Подтверждение действий",MessageBoxButtons.YesNo);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
