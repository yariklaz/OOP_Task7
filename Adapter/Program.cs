using System;
using System.Text;

namespace AdapterExample
{
    class MainApp
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Робота з новою системою без адаптера
            Console.WriteLine("--- Тест 1: Підключення до нової системи ---");
            var newElectricitySystem = new NewElectricitySystem();
            ElectricityConsumer.ChargeNotebook(newElectricitySystem);

            // Робота зі старою системою через адаптер
            Console.WriteLine("\n--- Тест 2: Підключення до старої системи через адаптер ---");

            // Створюємо об'єкт старої системи
            var oldElectricitySystem = new OldElectricitySystem();

            // Створюємо адаптер і передаємо туди стару систему
            var adapter = new Adapter(oldElectricitySystem);
            ElectricityConsumer.ChargeNotebook(adapter);

            Console.ReadKey();
        }
    }

    // Adaptee
    class OldElectricitySystem
    {
        public string MatchThinSocket()
        {
            return "Стара система (тонкі розетки)";
        }
    }

    // Target
    interface INewElectricitySystem
    {
        string MatchWideSocket();
    }

    // ConcreteTarget
    class NewElectricitySystem : INewElectricitySystem
    {
        public string MatchWideSocket()
        {
            return "Нова система (широкі євро-розетки)";
        }
    }

    // Adapter
    class Adapter : INewElectricitySystem
    {
        // Посилання на адаптовуваний об'єкт
        private readonly OldElectricitySystem _adaptee;

        public Adapter(OldElectricitySystem adaptee)
        {
            _adaptee = adaptee;
        }
        public string MatchWideSocket()
        {
            return _adaptee.MatchThinSocket();
        }
    }

    // Client
    class ElectricityConsumer
    {
        // Зарядний пристрій, який розуміє тільки нову систему (INewElectricitySystem)
        public static void ChargeNotebook(INewElectricitySystem electricitySystem)
        {
            Console.WriteLine("Зарядка йде через: " + electricitySystem.MatchWideSocket());
        }
    }
}
