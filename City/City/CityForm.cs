using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace City
{
    public partial class CityForm : Form
    {
        // Список гостиниц
        private List<City> cities = new List<City>();

        // Конструктор формы
        public CityForm()
        {
            InitializeComponent();
        }

        // Действия при загрузке формы
        private void CityForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = comboBox2.SelectedIndex
                = comboBox3.SelectedIndex = 0;
        }

        // Действия при нажатии на кнопку
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Добавление закрытого города
                if (comboBox1.SelectedIndex == 0)
                    cities.Add(new SecretCity(textBox1.Text, dateTimePicker1.Value,
                        double.Parse(textBox2.Text), int.Parse(textBox3.Text),
                        (Country)comboBox2.SelectedIndex, textBox5.Text));
                // Добавление порта
                else
                    cities.Add(new Harbor(textBox1.Text, dateTimePicker1.Value,
                        double.Parse(textBox2.Text), int.Parse(textBox3.Text),
                        (Country)comboBox2.SelectedIndex, (Sea)comboBox3.SelectedIndex));

                // Сохранение данных в файл
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    cities[cities.Count - 1].Save(Path.GetFileName(saveFileDialog1.FileName),
                        Path.GetDirectoryName(saveFileDialog1.FileName));
                }
                // Вывод данных в текстовое поле
                textBox4.Text += cities[cities.Count - 1].Info() + Environment.NewLine;
                textBox4.Text += cities[cities.Count - 1].ToString() + Environment.NewLine;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Действия при изменении типа города
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Включение режима Хостел или С завтраком
            label7.Enabled = textBox5.Enabled = comboBox1.SelectedIndex == 0;
            label8.Enabled = comboBox3.Enabled = comboBox1.SelectedIndex != 0;
        }
    }
}
