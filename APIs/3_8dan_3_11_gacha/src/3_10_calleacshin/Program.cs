namespace _3_10_calleacshin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            for (var i = 1; i <= 10; i++)
            {
                Random random = new Random();
                stack.Push(random.Next(1, 100));
                if (stack.Peek() % 2 == 0) Console.WriteLine(stack.Peek());
            }
            Car car = new Car()
            {
                Id = Guid.NewGuid(),
                Make = "Toyota",
                
               
            };

            Car car1 = new Car()
            {
                Id = Guid.NewGuid(),
                Make = "Toyota",


            };

            Dictionary<Car, Car> carDictionary = new Dictionary<Car, Car>();


            carDictionary.Add(car, new Car { Id = Guid.NewGuid(), Make = "Hudat" });
            carDictionary.Add(car1, new Car { Id = Guid.NewGuid(), Make = "Nissan" });

            Console.WriteLine(carDictionary.Count());

        }
    }
}
