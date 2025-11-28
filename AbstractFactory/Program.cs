using System;

namespace AbstractFactory
{
    // AbstractProductA
    public abstract class Car
    {
        public abstract void Info();
        public void Interact(Engine engine)
        {
            Info();
            Console.WriteLine("Set Engine: ");
            engine.GetPower();
        }
    }

    // ConcreteProductA1
    public class Ford : Car
    {
        public override void Info()
        {
            Console.WriteLine("Ford");
        }
    }

    // ConcreteProductA2
    public class Toyota : Car
    {
        public override void Info()
        {
            Console.WriteLine("Toyota");
        }
    }

    // додано ConcreteProductA3 ---
    public class Mercedes : Car
    {
        public override void Info()
        {
            Console.WriteLine("Mercedes");
        }
    }

    // AbstractProductB
    public abstract class Engine
    {
        public virtual void GetPower()
        {
        }
    }

    // ConcreteProductB1
    public class FordEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Ford Engine");
        }
    }

    // ConcreteProductB2
    public class ToyotaEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Toyota Engine");
        }
    }

    // додано ConcreteProductB3 ---
    public class MercedesEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Mercedes Engine");
        }
    }

    // AbstractFactory
    public interface ICarFactory
    {
        Car CreateCar();
        Engine CreateEngine();
    }

    // ConcreteFactory1
    public class FordFactory : ICarFactory
    {
        // from CarFactory
        Car ICarFactory.CreateCar()
        {
            return new Ford();
        }

        Engine ICarFactory.CreateEngine()
        {
            return new FordEngine();
        }
    }

    // ConcreteFactory2
    public class ToyotaFactory : ICarFactory
    {
        // from CarFactory
        Car ICarFactory.CreateCar()
        {
            return new Toyota();
        }

        Engine ICarFactory.CreateEngine()
        {
            return new ToyotaEngine();
        }
    }

    //  додано ConceteFactory3
    public class MercedesFactory : ICarFactory
    {
        // Реалізація методів інтерфейсу для створення продуктів Mercedes
        Car ICarFactory.CreateCar()
        {
            return new Mercedes();
        }

        Engine ICarFactory.CreateEngine()
        {
            return new MercedesEngine();
        }
    }

    public class ClientFactory
    {
        private Car car;
        private Engine engine;

        public ClientFactory(ICarFactory factory)
        {
            //Абстрагування процесів інстанціювання
            car = factory.CreateCar();
            engine = factory.CreateEngine();
        }

        public void Run()
        {
            car.GetType();
            //Абстрагування варіантів використання
            car.Interact(engine);
        }
    }

    class AbstractFactoryApp
    {
        static void Main(string[] args)
        {
            // Тест Toyota
            ICarFactory carFactory = new ToyotaFactory();
            ClientFactory client1 = new ClientFactory(carFactory);
            Console.WriteLine("--- Toyota Factory ---");
            client1.Run();
            Console.WriteLine();

            // Тест Ford
            carFactory = new FordFactory();
            ClientFactory client2 = new ClientFactory(carFactory);
            Console.WriteLine("--- Ford Factory ---");
            client2.Run();
            Console.WriteLine();

            //  додано Тест Mercedes ---
            carFactory = new MercedesFactory();
            ClientFactory client3 = new ClientFactory(carFactory);
            Console.WriteLine("--- Mercedes Factory ---");
            client3.Run();

            Console.ReadKey();
        }
    }
}
