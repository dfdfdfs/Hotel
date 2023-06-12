using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel
{
    public partial class HotelForm : Form
    {
        // Список гостиниц
        private List<Hotel> hotels = new List<Hotel>();

        // Конструктор формы
        public HotelForm()
        {
            InitializeComponent();
        }

        // Действия при загрузке формы
        private void HotelForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = comboBox2.SelectedIndex
                = comboBox3.SelectedIndex = 0;
        }

        // Действия при нажатии на кнопку
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Добавление хостела
                if (comboBox1.SelectedIndex == 0)
                    hotels.Add(new Hostel(textBox1.Text, textBox2.Text,
                        (Category)comboBox2.SelectedIndex, (int)numericUpDown1.Value,
                        double.Parse(textBox3.Text), (int)numericUpDown2.Value));
                // Добавление гостиницы с завтраком
                else
                    hotels.Add(new BedBreakfastHotel(textBox1.Text, textBox2.Text,
                        (Category)comboBox2.SelectedIndex, (int)numericUpDown1.Value,
                        double.Parse(textBox3.Text), (Breakfast)comboBox3.SelectedIndex));

                // Сохранение данных в файл
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    hotels[hotels.Count - 1].Save(Path.GetFileName(saveFileDialog1.FileName),
                        Path.GetDirectoryName(saveFileDialog1.FileName));
                }
                // Вывод данных в текстовое поле
                textBox4.Text += hotels[hotels.Count - 1].Info() + Environment.NewLine;
                textBox4.Text += hotels[hotels.Count - 1].ToString() + Environment.NewLine;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Действия при изменения типа гостиницы
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Включение режима Хостел или С завтраком
            label7.Enabled = numericUpDown2.Enabled = comboBox1.SelectedIndex == 0;
            label8.Enabled = comboBox3.Enabled = comboBox1.SelectedIndex != 0;
        }
    }
}
