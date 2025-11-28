using System;
using System.Text;

namespace Decorator.ChristmasTree
{
    class MainApp
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Створюємо звичайну ялинку (ConcreteComponent)
            ChristmasTree tree = new RealChristmasTree();

            // Створюємо декоратори
            OrnamentsDecorator ornaments = new OrnamentsDecorator();
            GarlandDecorator garland = new GarlandDecorator();

            // Одягаємо ялинку
            ornaments.SetComponent(tree);
            // Потім на ялинку з іграшками вішаємо гірлянду
            garland.SetComponent(ornaments);

            // Виконуємо операцію
            Console.WriteLine("--- Результат декорування ---");
            garland.Operation();

            Console.Read();
        }
    }

    // Component
    abstract class ChristmasTree
    {
        public abstract void Operation();
    }

    // ConcreteComponent
    class RealChristmasTree : ChristmasTree
    {
        public override void Operation()
        {
            Console.WriteLine("Ялинка: Стоїть зелена лісова красуня.");
        }
    }

    // Decorator
    abstract class TreeDecorator : ChristmasTree
    {
        protected ChristmasTree component;

        public void SetComponent(ChristmasTree component)
        {
            this.component = component;
        }

        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    // ConcreteDecoratorA
    class OrnamentsDecorator : TreeDecorator
    {
        // декорувати полями 
        private string _toyType;

        public override void Operation()
        {
            base.Operation();
            // Встановлюємо стан
            _toyType = "скляні кульки та зірка";
            Console.WriteLine($"Декор (поля): На гілки додано {_toyType}.");
        }
    }

    // ConcreteDecoratorB
    class GarlandDecorator : TreeDecorator
    {
        public override void Operation()
        {
            base.Operation();
            // Викликаємо додану поведінку
            Glow();
        }

        // Метод що відповідає за те, що ялинка світиться
        void Glow()
        {
            Console.WriteLine("Декор (метод): Гірлянда увімкнена! Ялинка яскраво світиться.");
        }
    }
}
