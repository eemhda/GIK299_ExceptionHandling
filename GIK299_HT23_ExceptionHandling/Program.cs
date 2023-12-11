namespace GIK299_HT23_ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // i det här programmet frågar vi användaren efter dennes namn och ålder.
            // vi kontrollerar att namnet inte är tomt och att åldern är mellan 0 och 120.

            string name;
            int age;


            // i try-blocket har vi koden för att fråga efter namn och ålder
            try
            {
                Console.WriteLine("Enter your name: ");
                name = Console.ReadLine();

                //vi kontrollerar om namnet är tomt eller null
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }
                //vi frågar efter användarens ålder
                Console.WriteLine("Enter your age: ");
                string ageInput = Console.ReadLine();

                //vi kontrollerar om åldern är ett giltigt tal, om det är det så konverterar vi det till en int och tilldelar till age
                if (!int.TryParse(ageInput, out age))
                {
                    throw new FormatException("Age should be a valid number.");
                }

                //vi kontrollerar om åldern som finns i age-variabeln är en rimlig ålder (mellan 0 och 120)
                if (age < 0 || age > 120)
                {
                    //om den inte är det så kastar vi ett exception
                    throw new ArgumentOutOfRangeException("Age should be between 0 and 120.");
                }

                //Om användaren har skrivit in namn och ålder på ett sätt som överensstämmer med våra krav så skriver vi ut en hälsning
                Console.WriteLine($"Hello, {name}! You are {age} years old.");
            }

            //i catch-blocken nedan fångar vi upp de exceptions som kan kastas i try-blocket
            //vi gör detta i den ordning som de kan uppstå vilket vi behöver göra för att arvshierarkin
            //från Exception-klassen ser ut som den gör. Vi behöver fånga upp ArgumentOutOfRange först eftersom det
            //är barnbarns barn till Exception-klassen. Om vi skulle fånga upp Exception först så skulle vi aldrig nå
            // ArgumentOutOfRange eftersom Exception fångar upp alla exceptions som ärver från den.
            //Det är därför viktigt med ordningen i catch-blocken.
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            Console.WriteLine("End of program.");
        }
    }
}
