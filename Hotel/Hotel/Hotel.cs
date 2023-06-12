using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    // Категории гостиницы
    public enum Category
    {
        Deluxe, // Делюкс
        Superior, // Высший класс
        FirstClass, // Первый класс
        TouristClass // Туристический класс
    }

    // Тип завтрака
    public enum Breakfast
    {
        English, // Английский
        Continental // Континентальный
    }

    // Класс "Гостиница"
    public abstract class Hotel
    {
        // Параметры гостиницы
        protected string name; // Название 
        protected string address; // Адрес
        protected Category category; // Категория
        protected int stars; // Звездность
        protected double price; // Цена номера

        // Сохранение в файл
        public abstract void Save(string filename, string path);

        // Получение информации
        public abstract string Info();
    }

    // Класс "Хостел"
    public class Hostel : Hotel
    {
        protected int count; // Число жильцов в номере

        // Конструктор
        public Hostel(string n, string a, Category c, int s, double p, int cnt)
        {
            name = n;
            address = a;
            category = c; 
            stars = s; 
            price = p;
            count = cnt;
        }

        // Строковое представление
        public override string ToString()
        {
            return $"Название: {name}. Адрес: {address}. Категория: {category}." +
                $" Количество звезд: {stars}. Стоимость: {price}." +
                $" Человек в номере: {count}.";
        }

        // Сохранение в файл
        public override void Save(string filename, string path)
        {
            File.WriteAllText(path + "/" + filename, ToString());
        }

        // Получение информации
        public override string Info()
        {
            TypeInfo t = typeof(Hostel).GetTypeInfo();
            IEnumerable<MethodInfo> mList = t.DeclaredMethods;

            StringBuilder sb = new StringBuilder();

            // Получение методов и хэш-кодов
            sb.Append("Методы:" + Environment.NewLine);
            foreach (MethodInfo m in mList)
            {
                sb.Append(m.DeclaringType.Name + ": " + m.Name + " " + m.GetHashCode() + Environment.NewLine);
            }

            return sb.ToString();
        }
    }

    // Класс "Гостиница с завтраком"
    public class BedBreakfastHotel : Hotel
    {
        protected Breakfast breakfast; // Тип завтрака

        // Конструктор
        public BedBreakfastHotel(string n, string a, Category c, int s, double p, Breakfast b)
        {
            name = n;
            address = a;
            category = c;
            stars = s;
            price = p;
            breakfast = b;
        }

        // Строковое представление
        public override string ToString()
        {
            return $"Название: {name}. Адрес: {address}. Категория: {category}." +
                $" Количество звезд: {stars}. Стоимость: {price}." +
                $" Тип завтрака: {breakfast}.";
        }

        // Сохранение в файл
        public override void Save(string filename, string path)
        {
            File.WriteAllText(path + "/" + filename, ToString());
        }

        // Получение информации
        public override string Info()
        {
            TypeInfo t = typeof(BedBreakfastHotel).GetTypeInfo();
            IEnumerable<MethodInfo> mList = t.DeclaredMethods;

            StringBuilder sb = new StringBuilder();

            // Получение методов и хэш-кодов
            sb.Append("Методы:" + Environment.NewLine);
            foreach (MethodInfo m in mList)
            {
                sb.Append(m.DeclaringType.Name + ": " + m.Name + " " + m.GetHashCode() + Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}