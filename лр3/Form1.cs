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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void задание2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void задание3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int size) || size <= 0 || size > 10)
            {
                MessageBox.Show("Пожалуйста, введите целое число от 1 до 10 в текстовом поле.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Генерация массива и вывод нечетных чисел
            int[] array = GenerateArray(size);

            (int Index, int Value)[] oddNumbers = GetOddNumbers(array, out int count);

            listBox1.Items.Clear();

            for (int i = 0; i < count; i++)
            {
                listBox1.Items.Add($"Индекс: {oddNumbers[i].Index}, Значение: {oddNumbers[i].Value}");
            }

            listBox1.Items.Add($"Количество нечетных чисел: {count}");
        }
        private int[] GenerateArray(int size)
        {
            // Генерация массива случайных чисел
            Random random = new Random();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1, 101); // случайные числа от 1 до 100
            }

            return array;
        }

        private (int Index, int Value)[] GetOddNumbers(int[] array, out int count)
        {
            // Получение нечетных чисел и их индексов
            count = 0;
            (int Index, int Value)[] oddNumbers = new (int Index, int Value)[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    oddNumbers[count] = (i, array[i]);
                    count++;
                }
            }

            // Сортировка по возрастанию индексов
            oddNumbers = oddNumbers.OrderBy(x => x.Index).ToArray();

            return oddNumbers;
        }
    }
}
