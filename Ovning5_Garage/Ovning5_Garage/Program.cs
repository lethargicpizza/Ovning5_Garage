using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5_Garage
{
    class Program
    {
        /// <summary>
        /// Visar en text med en bestämd färg
        /// </summary>
        /// <param name="output">Text som ska visas</param>
        /// <param name="color">Textens färg</param>
        public static void TextColor(string output, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(output);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static Garage<Vehicle> garage;

        static void Main(string[] args)
        {
            // Vårt fina garage!
            Console.Clear();
            int antal = UserInput.AskForInt("Ange antal fordon du vill ha i ditt garage: ");
            garage = new Garage<Vehicle>(antal);

            #region Huvudmeny
            Console.Clear();
            bool doItAgain = true;
            int fordonsval = -1;

            do
            {
                bool isFull = garage.Count == garage.Capacity;   // är garaget fullt?

                TextColor("Välkommen till Garage 1.0", ConsoleColor.White);
                Console.WriteLine();
                Console.WriteLine("Antal platser: " + garage.Capacity);
                Console.WriteLine("Uthyrda platser: " + garage.Count);
                Console.WriteLine("\n\nAnge det typ av fordon du vill lägga till:");
                Console.WriteLine();
                Console.WriteLine("1. Bil");
                Console.WriteLine("2. Buss");
                Console.WriteLine("3. Båt");
                Console.WriteLine("4. Flygplan");
                Console.WriteLine("5. Motorcykel");
                Console.WriteLine("6. Tåg");
                Console.WriteLine();
                Console.WriteLine("7. Visa registrerade fordon");
                Console.WriteLine("8. Visa fordon av en typ");
                Console.WriteLine();
                Console.WriteLine("9. Sök efter ett fordon");
                Console.WriteLine("10. Sök efter färg på fordon");
                Console.WriteLine();
                Console.WriteLine("11. Avsluta programmet");
                Console.WriteLine();

                fordonsval = UserInput.AskForInt("\nAnge alternativ: ");
                Console.WriteLine();
                switch (fordonsval)
                {
                    case 1:
                        if (!isFull)
                            AddCar();
                        else
                        {
                            TextColor("Garaget är fullt", ConsoleColor.Red);
                            UserInput.PressAnyKey();
                        }
                        Console.Clear();
                        break;

                    case 2:
                        if (!isFull)
                            AddBus();
                        else
                        {
                            TextColor("Garaget är fullt", ConsoleColor.Red);
                            UserInput.PressAnyKey();
                        }
                        Console.Clear();
                        break;

                    case 3:
                        if (!isFull)
                            AddBoat();
                        else
                        {
                            TextColor("Garaget är fullt", ConsoleColor.Red);
                            UserInput.PressAnyKey();
                        }
                        Console.Clear();
                        break;

                    case 4:
                        if (!isFull)
                            AddAirplane();
                        else
                        {
                            TextColor("Garaget är fullt", ConsoleColor.Red);
                            UserInput.PressAnyKey();
                        }
                        Console.Clear();
                        break;

                    case 5:
                        if (!isFull)
                            AddMotorcycle();
                        else
                        {
                            TextColor("Garaget är fullt", ConsoleColor.Red);
                            UserInput.PressAnyKey();
                        }
                        Console.Clear();
                        break;

                    case 6:
                        if (!isFull)
                            AddLocomotive();
                        else
                        {
                            TextColor("Garaget är fullt", ConsoleColor.Red);
                            UserInput.PressAnyKey();
                        }
                        Console.Clear();
                        break;

                    case 8:
                        ListVehicleType();
                        break;

                    case 7:
                        ListVehicles();
                        break;

                    case 9:
                        string regNo = UserInput.AskForString("Ange registreringsnummer: ");
                        ListVehicles(regNo);
                        break;

                    case 10:
                        string color = UserInput.AskForString("Ange en färg: ");
                        var vehicles = garage.ListColorVehicles(color);

                        Console.Clear();
                        PrintList(vehicles);
                        break;

                    case 11:
                        doItAgain = false;
                        break;

                    default:
                        break;
                }

            } while (doItAgain);
            #endregion
        }

        /// <summary>
        /// Visar ett svar
        /// </summary>
        /// <param name="isSucceed">Misslyckat eller ej?</param>
        /// <param name="success">Meddelande</param>
        /// <param name="fail">Felmeddelande</param>
        private static void ShowResponse(bool isSucceed, string success = "Åtgärden lyckades", string fail = "Åtgärden misslyckades")
        {
            if (isSucceed) TextColor("\n\n" + success, ConsoleColor.Green);
            else TextColor("\n\n" + fail, ConsoleColor.Red);

            Console.ReadKey();
        }

        /// <summary>
        /// Lägger till ett nytt tåg
        /// </summary>
        /// <returns>Om tåget blev inlagt eller ej</returns>
        private static bool AddLocomotive()
        {
            Console.Clear();
            TextColor("Nytt tåg:\n", ConsoleColor.White);
            string color, owner, manufacturer, regno, name, series;
            double height, length, width, weight;
            int maxspeed, numberofwheels, gauge;

            name = UserInput.AskForString("Ange namn: ");
            UserInput.GeneralInfo(out color, out owner, out height, out length, out width, out manufacturer, out maxspeed, out regno, out weight);
            series = UserInput.AskForString("Ange littera: ");
            numberofwheels = UserInput.AskForInt("Antal hjul: ");
            gauge = UserInput.AskForInt("Ange spårvidd (mm): ");
            LocomotiveEngineTypes enginetype = UserInput.AskForLocomotiveEngineType();

            bool succeed = garage.Add(new Locomotive(color, owner, weight, width, height, length, maxspeed, manufacturer, series, gauge, enginetype, name, numberofwheels, regno));
            ShowResponse(succeed, "Tåget har lagts till", "Åtgärden misslyckades (Har du redan registrerat angivet registreringsnummer?)");

            return succeed;
        }

        /// <summary>
        /// Lägger till en ny motorcykel
        /// </summary>
        /// <returns>Om motorcykeln blev inlagd eller ej</returns>
        private static bool AddMotorcycle()
        {
            Console.Clear();
            TextColor("Ny motorcykel:\n", ConsoleColor.White);
            string color, owner, manufacturer, regno;
            double height, length, width, weight;
            int maxspeed, cylindervolume;

            UserInput.GeneralInfo(out color, out owner, out height, out length, out width, out manufacturer, out maxspeed, out regno, out weight);
            cylindervolume = UserInput.AskForInt("Ange cylindervolym (liter): ");
            var v = new Motorcycle(color, owner, weight, width, height, length, maxspeed, manufacturer, regno, cylindervolume);

            bool succeed = garage.Add(v);
            ShowResponse(succeed, "Motorcykeln har lagts till", "Åtgärden misslyckades (Har du redan registrerat angivet registreringsnummer?)");

            return succeed;
        }

        /// <summary>
        /// Lägger till ett nytt flygplan
        /// </summary>
        /// <returns>Om flygplanet blev inlagt eller ej</returns>
        private static bool AddAirplane()
        {
            Console.Clear();
            TextColor("Nytt flygplan:\n", ConsoleColor.White);
            string color, owner, manufacturer, regno, aviation;
            double height, length, width, weight;
            int maxspeed, maxaltitude, crewsize, numberofengines, numberofpassengers, numberofwheels;

            UserInput.GeneralInfo(out color, out owner, out height, out length, out width, out manufacturer, out maxspeed, out regno, out weight);
            numberofwheels = UserInput.AskForInt("Antal hjul: ");
            maxaltitude = UserInput.AskForInt("Max höjd (m): ");
            crewsize = UserInput.AskForInt("Besättningsstorlek: ");
            numberofengines = UserInput.AskForInt("Antal motorer: ");
            numberofpassengers = UserInput.AskForInt("Antal passagerare: ");
            aviation = UserInput.AskForString("Flygbolag: ");

            bool succeed = garage.Add(new Airplane(color, owner, weight, width, height, length, maxspeed, manufacturer, numberofengines, crewsize, numberofpassengers, aviation, maxaltitude, numberofwheels, regno));
            ShowResponse(succeed, "Flygplanet har lagts till", "Åtgärden misslyckades (Har du redan registrerat angivet registreringsnummer?)");

            return succeed;
        }

        /// <summary>
        /// Lägger till en ny båt
        /// </summary>
        /// <returns>Om båten blev inlagd eller ej</returns>
        private static bool AddBoat()
        {
            Console.Clear();
            TextColor("Ny båt:\n", ConsoleColor.White);
            string color, owner, manufacturer, regno, name, registrationport, imo;
            double height, length, width, weight;
            int maxspeed, numberofengines;

            name = UserInput.AskForString("Ange båtens namn: ");
            UserInput.GeneralInfo(out color, out owner, out height, out length, out width, out manufacturer, out maxspeed, out regno, out weight);
            numberofengines = UserInput.AskForInt("Antal motorer: ");
            registrationport = UserInput.AskForString("Ange hemmahamn: ");
            imo = UserInput.AskForString("Ange IMO-kod: ");
            Flags flag = UserInput.AskForFlag(); ;
            Boattypes boattype = UserInput.AskForBoattype();

            bool succeed = garage.Add(new Boat(color, owner, weight, width, height, length, maxspeed, manufacturer, numberofengines, flag, boattype, name, registrationport, regno, imo));
            ShowResponse(succeed, "Båten har lagts till", "Åtgärden misslyckades (Har du redan registrerat angivet registreringsnummer?)");

            return succeed;
        }

        /// <summary>
        /// Lägger till en ny buss
        /// </summary>
        /// <returns>Om bussen blev inlagd eller ej</returns>
        private static bool AddBus()
        {
            Console.Clear();
            TextColor("Ny buss:\n", ConsoleColor.White);
            string color, owner, manufacturer, regno;
            double height, length, width, weight;
            int maxspeed, numberofseats, numberofwheels;

            UserInput.GeneralInfo(out color, out owner, out height, out length, out width, out manufacturer, out maxspeed, out regno, out weight);
            numberofseats = UserInput.AskForInt("Antal sittplatser: ");
            numberofwheels = UserInput.AskForInt("Antal hjul: ");

            bool succeed = garage.Add(new Bus(color, owner, weight, width, height, length, maxspeed, manufacturer, regno, numberofseats, numberofwheels));
            ShowResponse(succeed, "Bussen har lagts till", "Åtgärden misslyckades (Har du redan registrerat angivet registreringsnummer?)");

            return succeed;
        }

        /// <summary>
        /// Lägger till en ny bil
        /// </summary>
        /// <returns>Om bilen blev inlagd eller ej</returns>
        private static bool AddCar()
        {
            Console.Clear();
            TextColor("Ny bil:\n", ConsoleColor.White);
            string color, manufacturer, regno, model, owner, year;
            double height, length, width, weight;
            int maxspeed, numberofcylinders, numberofwheels;
            

            UserInput.GeneralInfo(out color, out owner, out height, out length, out width, out manufacturer, out maxspeed, out regno, out weight);
            model = UserInput.AskForString("Ange modell: ");
            year = UserInput.AskForString("Tillverkningsår: ");
            numberofcylinders = UserInput.AskForInt("Antal cylindrar: ");
            numberofwheels = UserInput.AskForInt("Antal hjul: ");
            Fueltypes fuelType = UserInput.AskForFueltype();

            bool succeed = garage.Add(new Car(color, owner, weight, width, height, length, maxspeed, manufacturer, regno, numberofcylinders, fuelType, numberofwheels, model, year));
            ShowResponse(succeed, "Bilen har lagts till", "Åtgärden misslyckades (Har du redan registrerat angivet registreringsnummer?)");

            return succeed;
        }

        /// <summary>
        /// Tar fram en lista över vald fordonstyp
        /// </summary>
        private static void ListVehicleType()
        {
            Console.Write("Välj fordonstyp (B=Bil, U=Buss, Å=Båt, F=Flygplan, M=Motorcykel, T=Tåg): ");

            bool validChoice = false;
            string svenskaordet = "";
            string type = "";

            do
            {
                char ch = Console.ReadKey().KeyChar;


                validChoice = true;
                switch (ch.ToString().ToUpper())
                {
                    case "B":
                        type = "Car";
                        svenskaordet = "bilar";
                        break;

                    case "U":
                        type = "Bus";
                        svenskaordet = "bussar";
                        break;

                    case "Å":
                        type = "Boat";
                        svenskaordet = "båtar";
                        break;

                    case "F":
                        type = "Airplane";
                        svenskaordet = "flygplan";
                        break;

                    case "M":
                        type = "Motorcycle";
                        svenskaordet = "motorcyklar";
                        break;

                    case "T":
                        type = "Locomotive";
                        svenskaordet = "tåg";
                        break;

                    default:
                        TextColor("\nOgiltigt val\n", ConsoleColor.Red);
                        validChoice = false;
                        break;
                }
            } while (!validChoice);

            Console.Clear();
            int i = 0;

            if (garage.Count == 0)
            {
                Console.WriteLine($"Inga {svenskaordet} finns registrerade\n");
            }
            else {

                TextColor($"Följande {svenskaordet} finns registrerade\n\n", ConsoleColor.White);

                foreach (var vehicle in garage.Where(v => v.GetType().Name == type))
                {
                    Console.WriteLine(vehicle.ToString());
                    Console.WriteLine("Registreringsnummer: " + vehicle.RegNo);
                    Console.WriteLine($"Ägare: {vehicle.Owner} \n");
                    Console.WriteLine("Märke: " + vehicle.Manufacturer);
                    Console.WriteLine("Färg: " + vehicle.Color);
                    Console.WriteLine($"Dimensioner: {vehicle.Length} x {vehicle.Width} x {vehicle.Height} meter");
                    Console.WriteLine($"Vikt: {vehicle.Weight} kg");
                    Console.WriteLine("--------------------------------");

                    i += 1;   // räknar antalet
                }

                if (i == 0)  // visar det sig att inga fordon har skrivts ut visas nedanstående
                {
                    Console.WriteLine($"Inga {svenskaordet} finns registrerade\n");
                }
            }

            UserInput.PressAnyKey();
        }

        /// <summary>
        /// Visar en lista
        /// </summary>
        /// <param name="list">Array med fordon som ska visas</param>
        /// <param name="parkedOnly">Om endast parkerade fordon ska visas</param>
        private static void PrintList(IEnumerable<Vehicle> list, bool parkedOnly = false)
        {
            if (list.Count() == 0)
            {
                TextColor("Det finns inga fordon med vald färg registrerade!", ConsoleColor.Red);
                UserInput.PressAnyKey();

                return;
            }

            TextColor("Följande fordon finns registrerade:\n", ConsoleColor.White);

            foreach (var item in list)
            {
                if (item == null)
                {
                    continue;
                }

                // om parkedOnly-flaggan inte är null ska man ta ställning till ifall de är de som är parkerade eller inte är parkerade som ska visas
                if (parkedOnly)
                {
                    if (!item.Parked) continue;
                }

                Console.WriteLine();
                switch (item.GetType().Name)
                {
                    case "Car": Console.WriteLine("Fordonstyp: Bil"); break;
                    case "Bus": Console.WriteLine("Fordonstyp: Buss"); break;
                    case "Boat": Console.WriteLine("Fordonstyp: Båt"); break;
                    case "Airplane": Console.WriteLine("Fordonstyp: Flygplan"); break;
                    case "Motorcycle": Console.WriteLine("Fordonstyp: Motorcykel"); break;
                    case "Locomotive": Console.WriteLine("Fordonstyp: Tåg"); break;
                }

                Console.WriteLine("Registreringsnummer: " + item.RegNo);
                Console.WriteLine($"Ägare: {item.Owner} \n");
                Console.WriteLine("Märke: " + item.Manufacturer);
                Console.WriteLine("Färg: " + item.Color);
                Console.WriteLine($"Dimensioner: {item.Length} x {item.Width} x {item.Height} meter");
                Console.WriteLine($"Vikt: {item.Weight} kg");
                Console.Write("\nParkerad: ");
                if (item.Parked)
                    Console.WriteLine("Ja");
                else
                    TextColor("Nej", ConsoleColor.Red);
                Console.WriteLine("--------------------------------");

                #region Gammalt skräp
                //#region Knappval - visas endast om det finns fordon
                //if (garage.Count > 0)
                //{
                //    bool exit = false;

                //    do
                //    {
                //        Console.Write("Välj alternativ (P=Parkera/Lämna garage, T=Ta bort, H=Huvudmeny, V=Visa endast parkerade): ");
                //        char ch = Console.ReadKey().KeyChar;
                //        string choice = ch.ToString().ToUpper();   // valet får inte vara case-sensitive

                //        string input;
                //        switch (choice)
                //        {
                //            case "P":
                //                input = UserInput.AskForString("\n\nAnge registreringsnummer: ");
                //                var vehicle = garage.Find(input.ToUpper());
                //                garage.ParkUnpark(vehicle);
                //                exit = true;
                //                ListVehicles();
                //                break;
                //            case "T":
                //                input = UserInput.AskForString("\n\nAnge registreringsnummer: ");
                //                var vehicleToRemove = garage.Find(input.ToUpper());
                //                garage.Remove(vehicleToRemove);
                //                exit = true;
                //                ListVehicles();
                //                break;
                //            case "H":
                //                exit = true;
                //                Console.Clear();
                //                break;
                //            case "V":
                //                exit = true;
                //                ListVehicles(null, true);
                //                break;
                //            default:
                //                TextColor("\n\nOgiltigt val, försök igen!", ConsoleColor.Red);
                //                break;
                //        }
                //    } while (!exit);

                //}
                //#endregion
                #endregion
            }

            ShowChoices();
        }

        /// <summary>
        /// Visar knappval
        /// </summary>
        private static void ShowChoices()
        {
            #region Knappval - visas endast om det finns fordon
            if (garage.Count > 0)
            {
                bool exit = false;

                do
                {
                    Console.Write("\n\nVälj alternativ (P=Parkera/Lämna garage, T=Ta bort, H=Huvudmeny, V=Visa parkerade fordon, A=Visa alla fordon): ");
                    char ch = Console.ReadKey().KeyChar;
                    string choice = ch.ToString().ToUpper();   // valet får inte vara case-sensitive

                    string input;
                    switch (choice)
                    {
                        case "P":
                            input = UserInput.AskForString("\n\nAnge registreringsnummer: ");
                            var vehicle = garage.Find(input.ToUpper());
                            garage.TogglePark(vehicle);
                            exit = true;
                            ListVehicles();
                            break;
                        case "T":
                            input = UserInput.AskForString("\n\nAnge registreringsnummer: ");
                            var vehicleToRemove = garage.Find(input.ToUpper());
                            garage.Remove(vehicleToRemove);
                            exit = true;
                            ListVehicles();
                            break;
                        case "H":
                            exit = true;
                            Console.Clear();
                            break;
                        case "V":
                            exit = true;
                            ListVehicles(null, true);
                            break;
                        case "A":
                            exit = true;
                            ListVehicles();
                            break;
                        default:
                            TextColor("\n\nOgiltigt val, försök igen!", ConsoleColor.Red);
                            break;
                    }
                } while (!exit);

            }
            #endregion
        }

        /// <summary>
        /// Visar fordon
        /// </summary>
        /// <param name="regno">Endast fordon med ett visst registreringsnummer</param>
        /// <param name="parkedOnly">Om endast parkerade fordon ska visas</param>
        private static void ListVehicles(string regno = null, bool parkedOnly = false)
        {
            if (regno == null)
            {
                if (garage.Count == 0 || garage == null)
                {
                    Console.Clear();
                    TextColor("Det finns inga fordon i garaget registrerade!", ConsoleColor.Red);
                    UserInput.PressAnyKey();
                    return;
                }

                Console.Clear();
                TextColor("Följande fordon finns registrerade:\n", ConsoleColor.White);

               // var vehicles = garage.ListAllVehicles();    //  Använd inte den metoden, då får du tillgång till hela garaget utan skrivskydd.....

                foreach (var item in garage)
                {
                    //if (item == null)         // .....dessutom måste man hoppa över null-elementen
                    //{
                    //    continue;
                    //}

                    // om parkedOnly-flaggan inte är null ska man ta ställning till ifall de är de som är parkerade eller inte är parkerade som ska visas
                    if (parkedOnly)
                    {
                        if (!item.Parked) continue;     
                    }

                    Console.WriteLine();
                    switch (item.GetType().Name)
                    {
                        case "Car": Console.WriteLine("Fordonstyp: Bil"); break;
                        case "Bus": Console.WriteLine("Fordonstyp: Buss"); break;
                        case "Boat": Console.WriteLine("Fordonstyp: Båt"); break;
                        case "Airplane": Console.WriteLine("Fordonstyp: Flygplan"); break;
                        case "Motorcycle": Console.WriteLine("Fordonstyp: Motorcykel"); break;
                        case "Locomotive": Console.WriteLine("Fordonstyp: Tåg"); break;
                    }

                    Console.WriteLine("Registreringsnummer: " + item.RegNo);
                    Console.WriteLine($"Ägare: {item.Owner} \n");
                    Console.WriteLine("Märke: " + item.Manufacturer);
                    Console.WriteLine("Färg: " + item.Color);
                    Console.WriteLine($"Dimensioner: {item.Length} x {item.Width} x {item.Height} meter");
                    Console.WriteLine($"Vikt: {item.Weight} kg");
                    Console.Write("\nParkerad: ");
                    if (item.Parked)
                        Console.WriteLine("Ja");
                    else
                        TextColor("Nej", ConsoleColor.Red);
                    Console.WriteLine("--------------------------------");
                }
            }
            else
            {
                regno = regno.ToUpper();    // inga gemener i registreringsnumret!
                var vehicle = garage.Find(regno);

                if (vehicle != null)
                {
                    Console.Clear();

                    if (vehicle.GetType().Name == "Car")
                    {
                        Car c = vehicle as Car;
                        Console.WriteLine("Fordonstyp: Bil");
                        Console.WriteLine("Registreringsnummer: " + c.RegNo);
                        Console.WriteLine($"Ägare: {c.Owner}\n");
                        Console.WriteLine("Märke: " + c.Manufacturer);
                        Console.WriteLine("Modell: " + c.Model);
                        Console.WriteLine("Tillverkningsår: " + c.Year);
                        Console.WriteLine("Färg: " + c.Color);
                        Console.WriteLine("Bränsle: " + c.Fueltype.ToString());
                        Console.WriteLine($"Dimensioner: {c.Length} x {c.Width} x {c.Height} meter");
                        Console.WriteLine($"Vikt: {c.Weight} kg");
                        Console.WriteLine($"Max hastighet: {c.MaxSpeed} km/h");
                        Console.WriteLine("Antal cylindrar: " + c.NumberOfCylinders);
                        Console.WriteLine("Antal hjul: " + c.NumberOfWheels);
                        Console.Write("\nParkerad: ");
                        if (c.Parked)
                            Console.WriteLine("Ja");
                        else
                            TextColor("Nej", ConsoleColor.Red);

                        Console.WriteLine("--------------------------------");
                    }
                    else if (vehicle.GetType().Name == "Bus")
                    {
                        Bus b = vehicle as Bus;
                        Console.WriteLine("Fordonstyp: Buss");
                        Console.WriteLine("Registreringsnummer: " + b.RegNo);
                        Console.WriteLine($"Ägare: {b.Owner}\n");
                        Console.WriteLine("Märke: " + b.Manufacturer);
                        Console.WriteLine("Färg: " + b.Color);
                        Console.WriteLine($"Dimensioner: {b.Length} x {b.Width} x {b.Height} meter");
                        Console.WriteLine($"Vikt: {b.Weight} kg");
                        Console.WriteLine($"Max hastighet: {b.MaxSpeed} km/h");
                        Console.WriteLine("Max antal passagerare: " + b.NumberOfSeats);
                        Console.WriteLine("Antal hjul: " + b.NumberOfWheels);
                        Console.Write("\nParkerad: ");
                        if (b.Parked)
                            Console.WriteLine("Ja");
                        else
                            TextColor("Nej", ConsoleColor.Red);

                        Console.WriteLine("--------------------------------");
                    }
                    else if (vehicle.GetType().Name == "Boat")
                    {
                        Boat b = vehicle as Boat;
                        Console.WriteLine("Fordonstyp: Båt");
                        Console.WriteLine("Kategori: " + b.Boattype);
                        Console.WriteLine("Registreringsnummer: " + b.RegNo);
                        Console.WriteLine($"Ägare: {b.Owner}\n");
                        Console.WriteLine("Tillverkare: " + b.Manufacturer);
                        Console.WriteLine("Färg: " + b.Color);
                        Console.WriteLine($"Dimensioner: {b.Length} x {b.Width} x {b.Height} meter");
                        Console.WriteLine($"Vikt: {b.Weight} kg");
                        Console.WriteLine($"Max hastighet: {b.MaxSpeed} knop");
                        Console.WriteLine("Antal motor: " + b.NumberOfEngines);
                        Console.WriteLine("Flagg: " + b.Flag);
                        Console.WriteLine("Hemmahamn: " + b.RegistrationPort);
                        Console.WriteLine("IMO: " + b.IMO);
                        Console.Write("\nParkerad: ");
                        if (b.Parked)
                            Console.WriteLine("Ja");
                        else
                            TextColor("Nej", ConsoleColor.Red);

                        Console.WriteLine("--------------------------------");
                    }
                    else if (vehicle.GetType().Name == "Airplane")
                    {
                        Airplane a = vehicle as Airplane;
                        Console.WriteLine("Fordonstyp: Flygplan");
                        Console.WriteLine("Registreringsnummer: " + a.RegNo);
                        Console.WriteLine($"Ägare: {a.Owner}\n");
                        Console.WriteLine("Tillverkare: " + a.Manufacturer);
                        Console.WriteLine("Färg: " + a.Color);
                        Console.WriteLine($"Dimensioner: {a.Length} x {a.Width} x {a.Height} meter");
                        Console.WriteLine($"Vikt: {a.Weight} kg");
                        Console.WriteLine($"Max hastighet: {a.MaxSpeed} km/h");
                        Console.WriteLine("Antal motor: " + a.NumberOfEngines);
                        Console.WriteLine("Flygbolag: " + a.Aviation);
                        Console.WriteLine("Max antal passagerare: " + a.NumberOfPassengers);
                        Console.WriteLine("Antal hjul: " + a.NumberOfWheels);
                        Console.WriteLine("Max höjd: " + a.MaxAltitude);
                        Console.WriteLine("Besättningstorlek: " + a.CrewSize);
                        Console.Write("\nParkerad: ");
                        if (a.Parked)
                            Console.WriteLine("Ja");
                        else
                            TextColor("Nej", ConsoleColor.Red);

                        Console.WriteLine("--------------------------------");
                    }
                    else if (vehicle.GetType().Name == "Motorcycle")
                    {
                        Motorcycle m = vehicle as Motorcycle;
                        Console.WriteLine("Fordonstyp: Motorcykel");
                        Console.WriteLine("Registreringsnummer: " + m.RegNo);
                        Console.WriteLine($"Ägare: {m.Owner}\n");
                        Console.WriteLine("Tillverkare: " + m.Manufacturer);
                        Console.WriteLine("Färg: " + m.Color);
                        Console.WriteLine($"Dimensioner: {m.Length} x {m.Width} x {m.Height} meter");
                        Console.WriteLine($"Vikt: {m.Weight} kg");
                        Console.WriteLine($"Max hastighet: {m.MaxSpeed} km/h");
                        Console.WriteLine($"Cylindervolym: {m.CylinderVolume} liter");
                        Console.Write("\nParkerad: ");
                        if (m.Parked)
                            Console.WriteLine("Ja");
                        else
                            TextColor("Nej", ConsoleColor.Red);

                        Console.WriteLine("--------------------------------");
                    }
                    else if (vehicle.GetType().Name == "Locomotive")
                    {
                        Locomotive l = vehicle as Locomotive;
                        Console.WriteLine("Fordonstyp: Tåg");
                        Console.WriteLine("Namn: " + l.Name);
                        Console.WriteLine("Loktyp: " + l.Enginetype);
                        Console.WriteLine("Littera: " + l.Series);
                        Console.WriteLine("Registreringsnummer: " + l.RegNo);
                        Console.WriteLine($"Ägare: {l.Owner}\n");
                        Console.WriteLine("Tillverkare: " + l.Manufacturer);
                        Console.WriteLine("Färg: " + l.Color);
                        Console.WriteLine($"Dimensioner: {l.Length} x {l.Width} x {l.Height} meter");
                        Console.WriteLine($"Vikt: {l.Weight} kg");
                        Console.WriteLine($"Max hastighet: {l.MaxSpeed} km/h");
                        Console.WriteLine($"Spårvidd: {l.Gauge} mm");
                        Console.WriteLine("Antal hjul: " + l.NumberOfWheels);
                        Console.Write("\nParkerad: ");
                        if (l.Parked)
                            Console.WriteLine("Ja");
                        else
                            TextColor("Nej", ConsoleColor.Red);

                        Console.WriteLine("--------------------------------");
                    }
                }
                else
                {
                    TextColor("Fordon saknas", ConsoleColor.Red);
                    UserInput.PressAnyKey();
                }
            }

            ShowChoices();

            #region Gammalt skräp
            //#region Knappval - visas endast om det finns fordon
            //if (garage.Count > 0)
            //{
            //    bool exit = false;

            //    do
            //    {
            //        Console.Write("Välj alternativ (P=Parkera/Lämna garage, T=Ta bort, H=Huvudmeny, V=Visa endast parkerade): ");
            //        char ch = Console.ReadKey().KeyChar;
            //        string choice = ch.ToString().ToUpper();   // valet får inte vara case-sensitive

            //        string input;
            //        switch (choice)
            //        {
            //            case "P":
            //                input = UserInput.AskForString("\n\nAnge registreringsnummer: ");
            //                var vehicle = garage.Find(input.ToUpper());
            //                garage.ParkUnpark(vehicle);
            //                exit = true;
            //                ListVehicles();
            //                break;
            //            case "T":
            //                input = UserInput.AskForString("\n\nAnge registreringsnummer: ");
            //                var vehicleToRemove = garage.Find(input.ToUpper());
            //                garage.Remove(vehicleToRemove);
            //                exit = true;
            //                ListVehicles();
            //                break;
            //            case "H":
            //                exit = true;
            //                Console.Clear();
            //                break;
            //            case "V":
            //                exit = true;
            //                ListVehicles(null, true);
            //                break;
            //            default:
            //                TextColor("\n\nOgiltigt val, försök igen!", ConsoleColor.Red);
            //                break;
            //        }
            //    } while (!exit);

            //}
            //#endregion
            #endregion
        }

    }
}
