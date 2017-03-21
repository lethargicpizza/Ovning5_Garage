using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5_Garage
{
    class UserInput
    {
        /// <summary>
        /// Tryck på valfri tangent för att fortsätta
        /// </summary>
        /// <param name="message">Valfritt meddelande</param>
        public static void PressAnyKey(string message = "Tryck valfri tangent för att fortsätta")
        {
            Console.WriteLine("\n" + message);
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Tar in allmän information som alla fordon ska ha
        /// </summary>
        /// <param name="color">Färg</param>
        /// <param name="owner">Ägare</param>
        /// <param name="height">Höjd</param>
        /// <param name="length">Längd</param>
        /// <param name="width">Bredd</param>
        /// <param name="manufacturer">Tillverkare</param>
        /// <param name="maxspeed">Max hastighet</param>
        /// <param name="regno">Registreringsnummer</param>
        /// <param name="weight">Vikt</param>
        public static void GeneralInfo(out string color, out string owner, out double height, out double length, out double width, out string manufacturer, out int maxspeed, out string regno, out double weight)
        {
            color = AskForString("Ange färg: ");
            owner = AskForString("Ange ägare: ");
            height = AskForDouble("Ange höjd (m): ");
            length = AskForDouble("Ange längd (m): ");
            width = AskForDouble("Ange bredd (m): ");
            maxspeed = AskForInt("Ange max hastighet (km/h alt knop): ");
            regno = AskForString("Ange registreringsnummer: ").ToUpper();   // inga gemener i registreringsnumret!
            weight = AskForDouble("Ange vikt (kg): ");
            manufacturer = AskForString("Ange tillverkare: ");
        }

        /// <summary>
        /// Frågar efter en loktyp
        /// </summary>
        /// <returns>En loktyp</returns>
        public static LocomotiveEngineTypes AskForLocomotiveEngineType()
        {
            bool validInput = false;
            LocomotiveEngineTypes locotype = 0;

            do
            {
                Console.WriteLine("\nVälj alternativ:\n");
                Console.WriteLine("1. Ellok");
                Console.WriteLine("2. Diesellok");
                Console.WriteLine("3. Diesel-elektriskt lok");
                Console.WriteLine("4. Ånglok");
                Console.WriteLine("5. Tunnelbanetåg");
                Console.WriteLine("6. Spårvagn");
                Console.WriteLine("7. Dressin");

                int input = AskForInt("\nAnge alternativ: ");

                if (input > 7)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nOgiltigt val, försök igen!\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                }
                else
                {
                    locotype = (LocomotiveEngineTypes)input;
                    validInput = true;
                }

            } while (!validInput);

            return locotype;
        }

        /// <summary>
        /// Frågar efter en bränsletyp
        /// </summary>
        /// <returns>En bränsletyp</returns>
        public static Fueltypes AskForFueltype()
        {
            Fueltypes fuelType = 0;

            bool validInput = false;

            do
            {
                Console.Write("Välj bränsle (G=Bensin, D=Diesel, B=Batteri): ");
                char ch = Console.ReadKey().KeyChar;
                string choice = ch.ToString().ToUpper();   // valet får inte vara case-sensitive

                switch (choice)
                {
                    case "G":
                        fuelType = Fueltypes.Gasoline;
                        validInput = true;
                        break;
                    case "D":
                        fuelType = Fueltypes.Diesel;
                        validInput = true;
                        break;
                    case "B":
                        fuelType = Fueltypes.Battery;
                        validInput = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nOgiltigt val, försök igen!\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            } while (!validInput);

            return fuelType;
        }

        /// <summary>
        /// Frågar efter en båttyp
        /// </summary>
        /// <returns>En båttyp</returns>
        public static Boattypes AskForBoattype()
        {
            Boattypes boatType = 0;

            bool validInput = false;

            do
            {
                Console.Write("Välj alternativ (F=Färja, M=Motorbåt, S=Segelbåt): ");
                char ch = Console.ReadKey().KeyChar;
                string choice = ch.ToString().ToUpper();   // valet får inte vara case-sensitive

                switch (choice)
                {
                    case "F":
                        boatType = Boattypes.Ferry;
                        validInput = true;
                        break;
                    case "M":
                        boatType = Boattypes.Motorboat;
                        validInput = true;
                        break;
                    case "S":
                        boatType = Boattypes.SailingBoat;
                        validInput = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\nOgiltigt val, försök igen!\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            } while (!validInput);

            return boatType;
        }

        /// <summary>
        /// Frågar efter en flagga
        /// </summary>
        /// <returns>En flagga</returns>
        public static Flags AskForFlag()
        {
            Flags flag = 0;

            bool validInput = false;

            do
            {
                Console.WriteLine("\nVälj flagg:\n");
                Console.WriteLine("1. Sverige");
                Console.WriteLine("2. Norge");
                Console.WriteLine("3. Danmark");
                Console.WriteLine("4. Tyskland");
                Console.WriteLine("5. Polen");
                Console.WriteLine("6. Estland");
                Console.WriteLine("7. Finland");

                int input = AskForInt("\nAnge alternativ: ");

                if (input > 7)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nOgiltigt val, försök igen!\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                }
                else
                {
                    flag = (Flags)input;
                    validInput = true;
                }
            } while (!validInput);

            return flag;
        }

        /// <summary>
        /// Tar emot ett flyttal
        /// </summary>
        /// <param name="question">Fråga i konsolen</param>
        /// <returns>Inmatning</returns>
        public static double AskForDouble(string question)
        {
            double value;
            bool parsed;
            string error = "";

            do
            {
                string input = AskForString(error + question);
                parsed = double.TryParse(input, out value);
                Console.ForegroundColor = ConsoleColor.Red;
                error = "Jag kunde inte tolka värdet, det får bara innehålla siffror och vara större än noll!\n\n";
                Console.ForegroundColor = ConsoleColor.Gray;

                if (value < 1)      // värdet får inte vara mindre än 1
                    parsed = false;

            } while (!parsed);

            return value;
        }

        /// <summary>
        /// Tar emot ett heltal
        /// </summary>
        /// <param name="question">Fråga i konsolen</param>
        /// <returns>Inmatning</returns>
        public static int AskForInt(string question)
        {
            int value;
            bool parsed;
            string error = "";

            do
            {
                string input =AskForString(error + question);
                parsed = int.TryParse(input, out value);
                error = "Jag kunde inte tolka värdet, det måste vara heltal och större än noll!\n\n";

                if (value < 1)      // värdet får inte vara mindre än 1
                    parsed = false;

            } while (!parsed);

            return value;
        }

        /// <summary>
        /// Tar emot en sträng
        /// </summary>
        /// <param name="question">Fråga i konsolen</param>
        /// <returns>Inmatning</returns>
        public static string AskForString(string question)
        {
            bool parsed = false;
            string input;

            do
            {
                Console.Write(question);
                input = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(input))
                    parsed = true;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du måste ange ett värde!\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

            } while (!parsed);

            return input;
        }
    }
}
