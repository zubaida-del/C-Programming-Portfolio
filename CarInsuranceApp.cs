using System;

namespace CarInsurance
{
    interface IQuotable
    {
        void GetQuote();
    }

    class Customer : IQuotable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int CarYear { get; set; }
        public bool HasAccidents { get; set; }

        public void GetQuote()
        {
            double baseRate = 500; // base annual rate in $
            double premium = baseRate;

            // Age adjustment
            if (Age < 25)
                premium += 150;
            else if (Age > 60)
                premium += 100;

            // Car age adjustment
            int currentYear = DateTime.Now.Year;
            if (CarYear < currentYear - 10)
                premium += 100;
            else if (CarYear > currentYear - 2)
                premium += 50;

            // Accident history
            if (HasAccidents)
                premium += 200;

            Console.WriteLine($"\nQuote for {Name}:");
            Console.WriteLine($"Your estimated annual premium is: ${premium:F2}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();

            Console.Write("Enter your full name: ");
            customer.Name = Console.ReadLine();

            Console.Write("Enter your age: ");
            customer.Age = int.Parse(Console.ReadLine());

            Console.Write("Enter your car's model year (2020): ");
            customer.CarYear = int.Parse(Console.ReadLine());

            Console.Write("Have you had any accidents in the past 5 years? (yes/no): ");
            string accidentInput = Console.ReadLine().ToLower();
            customer.HasAccidents = accidentInput == "yes";

            customer.GetQuote();

            Console.WriteLine("\nThank you for using our insurance calculator!");
        }
    }
}
