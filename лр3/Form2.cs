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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int size) || size <= 0 || size > 10)
            {
                MessageBox.Show("Пожалуйста, введите целое число от 1 до 10 в текстовом поле.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int[] array = GenerateArray(size);

            int difference = CheckArithmeticProgression(array);

            if (difference != 0)
            {
                textBox2.Text = ($"Элементы массива образуют арифметическую прогрессию. Разность прогрессии: {difference}");
            }
            else
            {
                textBox2.Text = ("Элементы массива не образуют арифметическую прогрессию.");
            }
        }
        private int[] GenerateArray(int size)
        {
            // Генерация массива случайных чисел без повторений
            Random random = new Random();
            int[] array = Enumerable.Range(1, size * 2).OrderBy(x => random.Next()).Take(size).ToArray();
            return array;
        }

        private int CheckArithmeticProgression(int[] array)
        {
            // Проверка на арифметическую прогрессию
            int difference = array[1] - array[0];

            for (int i = 2; i < array.Length; i++)
            {
                if (array[i] - array[i - 1] != difference)
                {
                    return 0;
                }
            }

            return difference;
        }
    }
}
