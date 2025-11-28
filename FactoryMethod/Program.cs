using System;
using System.Text;

namespace FactoryMethod.Figures
{
    class MainApp
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Створюємо фабрику
            FigureFactory factory = new ConcreteFigureFactory();

            Console.WriteLine("--- Початок створення фігур ---\n");

            // Проходимо циклом, імітуючи запит на створення різних типів
            for (int i = 1; i <= 2; i++)
            {
                try
                {
                    // Створюємо фігуру: 1 - Коло, 2 - Квадрат
                    Figure figure = factory.FactoryMethod(i);

                    Console.Write($"ID запиту = {i}: ");
                    figure.Info(); // Виводимо інформацію про створений об'єкт
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Помилка: " + ex.Message);
                }
            }

            Console.Read();
        }
    }

    // Creator
    public abstract class FigureFactory
    {
        // Фабричний метод, що приймає тип фігури
        public abstract Figure FactoryMethod(int type);
    }

    // ConcreteCreator
    public class ConcreteFigureFactory : FigureFactory
    {
        public override Figure FactoryMethod(int type)
        {
            switch (type)
            {
                // Повертає об'єкт Circle, якщо type == 1
                case 1: return new Circle();

                // Повертає об'єкт Square, якщо type == 2
                case 2: return new Square();

                default: throw new ArgumentException("Невідомий тип фігури.", nameof(type));
            }
        }
    }

    // "Product" — Абстрактний клас фігури
    public abstract class Figure
    {
        public abstract void Info();
    }

    // "ConcreteProductA" — Конкретна реалізація (Коло)
    public class Circle : Figure
    {
        public override void Info()
        {
            Console.WriteLine("Створено об'єкт: КОЛО (Circle)");
        }
    }

    // "ConcreteProductB" — Конкретна реалізація (Квадрат)
    public class Square : Figure
    {
        public override void Info()
        {
            Console.WriteLine("Створено об'єкт: КВАДРАТ (Square)");
        }
    }
}
