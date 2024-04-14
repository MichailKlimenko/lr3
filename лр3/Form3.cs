using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace лр3
{
    public partial class Form3 : Form
    {
        private const int ROWS = 4;
        private const int COLS = 6;
        public Form3()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            Random random = new Random();

            dataGridView1.ColumnCount = COLS;
            dataGridView1.RowCount = ROWS;

            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    dataGridView1[j, i].Value = random.Next(1, 101).ToString(); // случайные числа от 1 до 100dataGridView1[j, i].Value = (i * COLS + j + 1).ToString();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] rowSums = new int[ROWS];
            int maxElement = int.MinValue;

            for (int i = 0; i < ROWS; i++)
            {
                int sum = 0;
                for (int j = 0; j < COLS; j++)
                {
                    sum += int.Parse(dataGridView1[j, i].Value.ToString());
                }
                rowSums[i] = sum;
                if (sum > maxElement)
                {
                    maxElement = sum;
                }
            }

            // Отображение результата во втором DataGridView
            dataGridView2.Rows.Clear();
            dataGridView2.ColumnCount = 1;
            dataGridView2.RowCount = ROWS + 1;

            for (int i = 0; i < ROWS; i++)
            {
                dataGridView2[0, i].Value = rowSums[i];
            }

            dataGridView2[0, ROWS].Value = $"Максимальный элемент: {maxElement}";
        }
    }
}
