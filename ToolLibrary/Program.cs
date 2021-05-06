using System;

namespace ToolLibrary
{
    // Author: Cheng Liang
    // N10346911
    class Program
    {
        private static void DisplayMainMenu() {
            Console.WriteLine("===============Main Menu===============");
            Console.WriteLine("1. Staff Login");
            Console.WriteLine("2. Member Login");
            Console.WriteLine("0. Exit");
            Console.WriteLine("=======================================");
            Console.WriteLine("\n\nPlease make a selection (1-2) or 0 to exit: ");
            
        }

        private static void ProcessMainMenu(ToolLibrarySystem toolSystem) {
            Console.Clear();
            DisplayMainMenu();
            string mainMenuChoice = Console.ReadLine();
            while (mainMenuChoice != "0")
            {
                if (mainMenuChoice == "1")
                {
                    Console.Write("Please enter the staff name: ");
                    string staffName = Console.ReadLine();

                    if (staffName.ToLower() == "staff")
                    {
                        Console.Write("Please enter the staff pin: ");
                        string staffPin = Console.ReadLine();
                        if (staffPin == "today123")
                        {

                            DisplayStaffMenu();
                            string staffChoice = Console.ReadLine();
                            if (staffChoice != "0")
                            {
                                ProcessStaffChoice(staffChoice, toolSystem);
                            }
                            else
                            {
                                ProcessMainMenu(toolSystem);
                            }
                        }
                    }



                }
                else if (mainMenuChoice == "2")
                {
                    Console.Clear();
                    DisplayMemberMenu();
                    string memberChoice = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Wrong input! Please make a selection (1-2) or 0 to exit: ");
                    mainMenuChoice = Console.ReadLine();
                }



            }

        }

        private static void DisplayStaffMenu() {
            Console.Clear();
            Console.WriteLine("===============Staff Menu===============");
            Console.WriteLine("1. Add a new tool");
            Console.WriteLine("2. Add new pieces of an existing tool");
            Console.WriteLine("3. Remove some pieces of a tool");
            Console.WriteLine("4. Register a new member");
            Console.WriteLine("5. Remove a member");
            Console.WriteLine("6. Find the contact number of a member");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("========================================");
            Console.WriteLine("\n\nPlease make a selection (1-6) or 0 to return to main menu: ");
        }

        private static void DisplayMemberMenu()
        {
            Console.WriteLine("===============Member Menu===============");
            Console.WriteLine("1. Display all the tools of a tool type");
            Console.WriteLine("2. Borrow a tool");
            Console.WriteLine("3. Return a tool");
            Console.WriteLine("4. List all the tools that I am renting");
            Console.WriteLine("5. Display top (3) most frequently rented tools");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("========================================");
            Console.WriteLine("\n\nPlease make a selection (1-5) or 0 to return to main menu: ");
        }

        private static void DisplayCategories() {
            Console.Clear();
            Console.WriteLine("=============Tool Categories============");
            Console.WriteLine("1. Gardening tools");
            Console.WriteLine("2. Flooring tools");
            Console.WriteLine("3. Fencing tools");
            Console.WriteLine("4. Measuring tools");
            Console.WriteLine("5. Cleaning tools");
            Console.WriteLine("6. Painting tools");
            Console.WriteLine("7. Electronic tools");
            Console.WriteLine("8. Electricity tools");
            Console.WriteLine("9. Automotive tools");
            Console.WriteLine("========================================");
            Console.WriteLine("\n\nPlease make a selection (1-9) or 0 to return to main menu: ");
        }

        private static string DisplayAndGetTooType(string choice) {
            Console.Clear();
            string toolTypeChoice;
            Console.WriteLine("=============Tool Types============");
            if (choice == "1")
            {
                Console.WriteLine("1. Line Trimmers");
                Console.WriteLine("2. Lawn Mowers");
                Console.WriteLine("3. Gardening Hand Tools");
                Console.WriteLine("4. Wheelbarrows");
                Console.WriteLine("5. Garden Power Tools");
                Console.WriteLine("\n\nPlease make a selection (1-5/6) or 0 to return to main menu: ");
                toolTypeChoice = Console.ReadLine();

                switch (toolTypeChoice) {
                    case "1":
                        return "Line Trimmers";
                    case "2":
                        return "Lawn Mowers";
                    case "3":
                        return "Gardening Hand Tools";
                    case "4":
                        return "Wheelbarrows";
                    case "5":
                        return "Garden Power Tools";
                    default:
                        Console.WriteLine("\n\nPlease make a selection (1-5/6) or 0 to return to main menu: ");
                        break;

                }
   

            }
            else if (choice == "2")
            {
                Console.WriteLine("1. Scrapers");
                Console.WriteLine("2. Floor Lasers");
                Console.WriteLine("3. Floor Levelling Tools");
                Console.WriteLine("4. Floor Levelling Materials");
                Console.WriteLine("5. Tiling Tools");
                Console.WriteLine("\n\nPlease make a selection (1-5/6) or 0 to return to main menu: ");
            }
            else if (choice == "3")
            {
                Console.WriteLine("1. Hand Tools");
                Console.WriteLine("2. Electric Fencing");
                Console.WriteLine("3. Steel Fencing Tools");
                Console.WriteLine("4. Power Tools");
                Console.WriteLine("5. Fencing Accessories");
                Console.WriteLine("\n\nPlease make a selection (1-5/6) or 0 to return to main menu: ");

            }
            else if (choice == "4")
            {
                Console.WriteLine("1. Distance Tools");
                Console.WriteLine("2. Laser Measurer");
                Console.WriteLine("3. Measuring Jugs");
                Console.WriteLine("4. Temperature & Humidity Tools");
                Console.WriteLine("5. Levelling Tools");
                Console.WriteLine("6. Markers");
                Console.WriteLine("\n\nPlease make a selection (1-5/6) or 0 to return to main menu: ");

            }
            else if (choice == "5")
            {
                Console.WriteLine("1. Draining");
                Console.WriteLine("2. Car Cleaning");
                Console.WriteLine("3. Vacuum");
                Console.WriteLine("4. Pressure Cleaners");
                Console.WriteLine("5. Pool Cleaning");
                Console.WriteLine("6. Floor Cleaning");
                Console.WriteLine("\n\nPlease make a selection (1-5/6) or 0 to return to main menu: ");

            }
            else if (choice == "6")
            {
                Console.WriteLine("1. Sanding Tools");
                Console.WriteLine("2. Brushes");
                Console.WriteLine("3. Rollers");
                Console.WriteLine("4. Paint Removal Tools");
                Console.WriteLine("5. Paint Scrapers");
                Console.WriteLine("6. Sprayers");
                Console.WriteLine("\n\nPlease make a selection (1-5/6) or 0 to return to main menu: ");
            }
            else if (choice == "7")
            {
                Console.WriteLine("1. Voltage Tester");
                Console.WriteLine("2. Oscilloscopes");
                Console.WriteLine("3. Thermal Imaging");
                Console.WriteLine("4. Data Test Tool");
                Console.WriteLine("5. Insulation Testers");
                Console.WriteLine("\n\nPlease make a selection (1-5/6) or 0 to return to main menu: ");
            }
            else if (choice == "8")
            {
                Console.WriteLine("1. Test Equipment");
                Console.WriteLine("2. Safety Equipment");
                Console.WriteLine("3. Basic Hand Tools");
                Console.WriteLine("4. Circuit Protection");
                Console.WriteLine("5. Cable Tools");
                Console.WriteLine("\n\nPlease make a selection (1-5/6) or 0 to return to main menu: ");
            }
            else if (choice == "9")
            {
                Console.WriteLine("1. Jacks");
                Console.WriteLine("2. Air Compressors");
                Console.WriteLine("3. Battery Chargers");
                Console.WriteLine("4. Socket Tools");
                Console.WriteLine("5. Braking");
                Console.WriteLine("6. Drivetrain");
                Console.WriteLine("\n\nPlease make a selection (1-5/6) or 0 to return to main menu: ");
            }
            Console.WriteLine("===================================");


            return "Wrong choice";
        }


        private static void ProcessStaffChoice(string staffChoice, ToolLibrarySystem system) {
;
            if (staffChoice == "1")
            {
                DisplayCategories();
                string categoryChoice = Console.ReadLine();

                string toolType = DisplayAndGetTooType(categoryChoice);
                while (toolType == "Wrong choice") {
                    toolType = DisplayAndGetTooType(categoryChoice);
                }

            }

        }


        static void Main(string[] args)
        {
            //iBSTree memberBST = new MemberCollection();

            //Member member01 = new Member("Cheng", "Liang", "12423354", "1234");


            //Member member02 = new Member("sdf", "rty", "12423354", "1234");
            //Member member03 = new Member("sdf", "tyu", "12423354", "1234");
            //Member member04 = new Member("tyu", "tuy", "12423354", "1234");
            //Member member05 = new Member("sdf", "uyt", "12423354", "1234");
            //Member member06 = new Member("wer", "uyt", "12423354", "1234");
            //Member member07 = new Member("sdf", "tuy", "12423354", "1234");
            //Member member08 = new Member("Cheng", "uyt", "12423354", "1234");



            //memberBST.add(member01);
            //memberBST.add(member02);
            //memberBST.add(member03);
            //memberBST.add(member04);
            //memberBST.add(member05);
            //memberBST.add(member06);


            //Tool tool = new Tool("Garden helper");
            //Tool dick = new Tool("Dick cutter");

            //ToolCollection toolCollection = new ToolCollection("Gardern Tools");
            //toolCollection.add(tool);
            //toolCollection.add(dick);


            //int length = toolCollection.toArray().Length;

            //for (int i = 0; i < length; i++) {
            //    Console.WriteLine(toolCollection.toArray()[i].Name);
            //}

            //toolCollection.delete(dick);

            // length = toolCollection.toArray().Length;
            //for (int i = 0; i < length; i++)
            //{
            //    Console.WriteLine(toolCollection.toArray()[i].Name);
            //}


            //tool.addBorrower(member01);

            //Console.WriteLine(tool.GetBorrowers.toArray().Length);

            //member01.addTool(tool);
            //Console.WriteLine(member01.Tools[0]);


            //Console.WriteLine(memberBST.toArray()[0].FirstName);

            ToolCollection lineTrimmers = new ToolCollection("lineTrimmers");
            ToolCollection lawnMowers = new ToolCollection("lawnMowers");
            ToolCollection gardenHandTools = new ToolCollection("gardenHandTools");
            ToolCollection wheelBarrows = new ToolCollection("wheelBarrows");
            ToolCollection gardenPowerTools = new ToolCollection("gardenPowerTools");
            ToolCollection scrapers = new ToolCollection("scrapers");
            ToolCollection floorLasers = new ToolCollection("floorLasers");
            ToolCollection floorLevellingTools = new ToolCollection("floorLevellingTools");
            ToolCollection floorLevellingMaterials = new ToolCollection("floorLevellingMaterials");
            ToolCollection floorHandTools = new ToolCollection("floorHandTools");
            ToolCollection tilingTools = new ToolCollection("tilingTools");
            ToolCollection fencingHandTools = new ToolCollection("fencingHandTools");
            ToolCollection electricFencing = new ToolCollection("electricFencing");
            ToolCollection steelFencingTools = new ToolCollection("steelFencingTools");
            ToolCollection powerTools = new ToolCollection("powerTools");
            ToolCollection fencingAccessories = new ToolCollection("fencingAccessories");
            ToolCollection distanceTools = new ToolCollection("distanceTools");
            ToolCollection laserMeature = new ToolCollection("laserMeature");
            ToolCollection measuringJugs = new ToolCollection("measuringJugs");
            ToolCollection temperatureAndHumidityTools = new ToolCollection("temperatureAndHumidityTools");
            ToolCollection messuringLevellingTools = new ToolCollection("messuringLevellingTools");
            ToolCollection markers = new ToolCollection("markers");
            ToolCollection draining = new ToolCollection("draining");
            ToolCollection carCleaning = new ToolCollection("carCleaning");
            ToolCollection vacuum = new ToolCollection("vacuum");
            ToolCollection pressureCleaners = new ToolCollection("pressureCleaners");
            ToolCollection poolCleaning = new ToolCollection("poolCleaning");
            ToolCollection floorCleaning = new ToolCollection("floorCleaning");
            ToolCollection sandingTools = new ToolCollection("sandingTools");
            ToolCollection brushes = new ToolCollection("brushes");
            ToolCollection rollers = new ToolCollection("rollers");
            ToolCollection paintRemovalTools = new ToolCollection("paintRemovalTools");
            ToolCollection paintScrapers = new ToolCollection("paintScrapers");
            ToolCollection sprayers = new ToolCollection("sprayers");
            ToolCollection voltageTester = new ToolCollection("voltageTester");
            ToolCollection oscilloscopes = new ToolCollection("oscilloscopes");
            ToolCollection thermalImaging = new ToolCollection("thermalImaging ");
            ToolCollection dataTestTool = new ToolCollection("dataTestTool");
            ToolCollection insulationTesters = new ToolCollection("insulationTesters");
            ToolCollection testEquipment = new ToolCollection("testEquipment");
            ToolCollection safetyEquipment = new ToolCollection("safetyEquipment");
            ToolCollection basicHandTools = new ToolCollection("basicHandTools");
            ToolCollection circuitProtection = new ToolCollection("circuitProtection");
            ToolCollection cableTools = new ToolCollection("cableTools");
            ToolCollection jacks = new ToolCollection("jacks");
            ToolCollection airCompressors = new ToolCollection("airCompressors");
            ToolCollection batteryChargers = new ToolCollection("batteryChargers");
            ToolCollection socketTools = new ToolCollection("socketTools");
            ToolCollection braking = new ToolCollection("braking");
            ToolCollection driveTrain = new ToolCollection("driveTrain");

            ToolLibrarySystem toolSystem = new ToolLibrarySystem();



  

            ProcessMainMenu( toolSystem);



        }
    }
}
