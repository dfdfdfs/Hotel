using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace City
{
    // Страны
    public enum Country
    {
        Russia, // Россия
        Kazakhstan, // Казахстан
        Kyrgyzstan, // Кыргызстан
        China // Китай
    }

    // Море
    public enum Sea
    {
        Baltic,
        Black,
        Caspian,
        Yellow
    }

    // Класс "Город"
    public abstract class City
    {
        // Параметры города
        protected string name; // Название 
        protected DateTime date; // Дата основания
        protected double area; // Площадь
        protected int population; // Население
        protected Country country; // Страна

        // Сохранение в файл
        public abstract void Save(string filename, string path);

        // Получение информации
        public abstract string Info();
    }

    // Закрытый город
    public class SecretCity : City
    {
        protected string codename; // кодовое имя

        // Конструктор закрытого города
        public SecretCity(string n, DateTime d, double a, int p, Country c, string cn)
        {
            name = n;
            date = d;
            area = a;
            population = p;
            country = c;
            codename = cn;
        }

        // Строковое представление
        public override string ToString()
        {
            return $"Название: {name}. Дата основания: {date}. Площадь: {area}." +
                $" Население: {population}. Страна: {country}." +
                $" Кодовое название: {codename}.";
        }

        // Сохранение в файл
        public override void Save(string filename, string path)
        {
            File.WriteAllText(path + "/" + filename, ToString());
        }

        // Получение информации
        public override string Info()
        {
            TypeInfo t = typeof(SecretCity).GetTypeInfo();
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

    public class Harbor : City
    {
        protected Sea sea; // море

        // Конструктор порта
        public Harbor(string n, DateTime d, double a, int p, Country c, Sea s)
        {
            name = n;
            date = d;
            area = a;
            population = p;
            country = c;
            sea = s;
        }

        // Строковое представление
        public override string ToString()
        {
            return $"Название: {name}. Дата основания: {date}. Площадь: {area}." +
                $" Население: {population}. Страна: {country}." +
                $" Море: {sea}.";
        }

        // Сохранение в файл
        public override void Save(string filename, string path)
        {
            File.WriteAllText(path + "/" + filename, ToString());
        }

        // Получение информации
        public override string Info()
        {
            TypeInfo t = typeof(Harbor).GetTypeInfo();
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
