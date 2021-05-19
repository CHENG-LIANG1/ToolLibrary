using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrary
{

    // Author:    Cheng Liang
    // Studen ID: N10346911
    class UserInterface
    {
        // these are used to keep the staff signed in, they are set to empty string when staff goes back to main menu
        static string staffName = "";
        static string staffPin = "";

        // these are used to keep the member signed in, they are set to empty string when member goes back to main menu
        static string memberName = "";

        static string pin = "";
        static Member loggedInMember;

        static int validMemberNum = 0;

        static string currentlySelectedToolType = "";

        static bool toolHasSameName = false; // handle the situation where staff tries to add a new tool while this tool already exists in the system

        static ToolCollection[] allToolCollections = ToolDatabase.GetToolDatabase();

        static MemberCollection members = new MemberCollection();


        /// <summary>
        /// Get the location of a tool by a given tool name
        /// </summary>
        /// <param name="toolName"> a given tool name </param>
        /// <returns> a int array, {1, 1} means first category, first tool type </returns>
        public static int[] GetAToolByToolName(string toolName) {
            for (int i = 0; i < allToolCollections.Length; i++) {
                for (int j = 0; j < allToolCollections[i].toArray().Length; j++) {
                    if(allToolCollections[i].toArray()[j].Name == toolName)
                    {

                        return new int[] { i, j };
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// get the currently selected tool type
        /// </summary>
        /// <returns> a string tool type </returns>
        public static string GetCurrentlySelectedToolType() {
            return currentlySelectedToolType;
        }

        /// <summary>
        /// get all tool collections
        /// </summary>
        /// <returns>a tool collection array </returns>
        public static ToolCollection[] GetAllToolCollections() {
            return allToolCollections;
        }

        /// <summary>
        /// get the member collection
        /// </summary>
        /// <returns> a member collection </returns>
        public static MemberCollection GetMemberCollection() {
            return members;
        }

        /// <summary>
        /// get the tool collection by a string tool type
        /// </summary>
        /// <param name="aToolType"></param>
        /// <returns></returns>
        public static ToolCollection GetDisplayedTools(string aToolType) {
            ToolCollection[] toolCollections = allToolCollections;
            ToolCollection displayedTools = new ToolCollection("Displayed Tools");
            for (int i = 0; i < toolCollections.Length; i++)
            {
                if (toolCollections[i].Name == aToolType)
                {
                    for (int j = 0; j < toolCollections[i].Number; j++)
                    {
                        Tool tool = toolCollections[i].toArray()[j];
                        displayedTools.add(tool);
                    }
                    break;
                }
            }

            return displayedTools;
        }

        /// <summary>
        /// display the main menu and get the selection
        /// </summary>
        /// <returns> a selection string</returns>
        public static string DisplayMainMenu()
        {
            Console.WriteLine("===============Main Menu===============");
            Console.WriteLine("1. Staff Login");
            Console.WriteLine("2. Member Login");
            Console.WriteLine("0. Exit");
            Console.WriteLine("=======================================");
            Console.Write("\n\nPlease make a selection (1-2) or 0 to exit: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// log a member into the system
        /// </summary>
        /// <returns> true if login is successfull, false other wise</returns>
        public static bool LoginAMember() {
            Console.Clear();


            if (memberName == "")
            {
                Console.Write("Please enter your last name and first name(LastnameFirstname):");
                memberName = Console.ReadLine();
                Console.Write("Please enter password(4 digits): ");
                pin = Console.ReadLine();
            }

            Member[] memberArray = members.toArray();

            for (int i = 0; i < memberArray.Length; i++)
            {
                if (memberArray[i] != null &&
                    (memberArray[i].LastName + memberArray[i].FirstName) == memberName && memberArray[i].PIN == pin)
                {
                    memberName = memberArray[i].LastName + memberArray[i].FirstName;
                    pin = memberArray[i].PIN;
                    loggedInMember = memberArray[i];
                    return true;
                }   
            }
            return false;
        }


        /// <summary>
        /// display the staff menu
        /// </summary>
        public static void DisplayStaffMenu()
        {
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
            Console.WriteLine("\n\nPlease make a selection (1-6) or 0 to return to Main menu: ");

        }

        /// <summary>
        /// display the member menu
        /// </summary>
        public static void DisplayMemberMenu()
        {
            Console.WriteLine("===============Member Menu===============");
            Console.WriteLine("1. Display all the tools of a tool type");
            Console.WriteLine("2. Borrow a tool");
            Console.WriteLine("3. Return a tool");
            Console.WriteLine("4. List all the tools that I am renting");
            Console.WriteLine("5. Display top (3) most frequently rented tools");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("========================================");
            Console.WriteLine("\n\nPlease make a selection (1-5) or 0 to return to Main menu: ");
        }

        /// <summary>
        /// display the memebrs
        /// </summary>
        public static void DisplayMembers()
        {
            Console.WriteLine("==========================Members=========================");

            Console.WriteLine("   {0, -15}{1, -15}{2, 15}", "First Name", "Last Name", "Contact Number");

            if (members != null)
            {
                Member[] memberArray = members.toArray();

                for (int i = 0; i < memberArray.Length; i++)
                {
                    if (memberArray[i] != null)
                    {
                        validMemberNum++;
                        Console.WriteLine(i + 1 + ". " + memberArray[i].ToString());
                    }

                }
            }

            Console.WriteLine("==========================================================");
        }

        /// <summary>
        /// display the categories and get the selected category
        /// </summary>
        /// <param name="role"> staff/member </param>
        /// <returns> the selected category </returns>
        public static string DisplayAndGetCategories(string role)
        {
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
            Console.WriteLine("0. Return to Staff menu");
            Console.WriteLine("========================================");
            Console.WriteLine("\n\nPlease make a selection (1-9) or 0 to return to " + role + " menu: ");
            string choice = Console.ReadLine();
            return choice;

        }

        /// <summary>
        /// display the tool types and get the selected tool type
        /// </summary>
        /// <param name="choice"> selection made</param>
        /// <param name="system"> the tool library system</param>
        /// <param name="role"> staff/member </param>
        /// <returns> the selected tool type </returns>
        public static string DisplayAndGetTooType(string choice, ToolLibrarySystem system, string role)
        {
            while (choice != "0" && choice != "1" && choice != "2" &&
                   choice != "3" && choice != "4" && choice != "5" && choice != "6" && choice != "7" && choice != "8" && choice != "9")
            {
                Console.WriteLine("Wrong Selection! Please make a selection (1-9) or 0 to return to Staff menu: ");
                choice = Console.ReadLine();
            }

            if (choice == "1")
            {
                string toolType = GetGardeningToolTypes();
                if (toolType == "back")
                {
                    string categoryChoice = DisplayAndGetCategories("Staff");
                    toolType = DisplayAndGetTooType(categoryChoice, system, role);
                }
                return toolType;
            }
            else if (choice == "2")
            {
                string toolType = GetFlooringToolTypes();
                if (toolType == "back")
                {
                    string categoryChoice = DisplayAndGetCategories("Staff");
                    toolType = DisplayAndGetTooType(categoryChoice, system, role);
                }
                return toolType;
            }
            else if (choice == "3")
            {
                string toolType = GetFencingToolTypes();
                if (toolType == "back")
                {
                    string categoryChoice = DisplayAndGetCategories("Staff");
                    toolType = DisplayAndGetTooType(categoryChoice, system, role);
                }
                return toolType;
            }
            else if (choice == "4")
            {
                string toolType = GetMeasuringToolTypes();
                if (toolType == "back")
                {
                    string categoryChoice = DisplayAndGetCategories("Staff");
                    toolType = DisplayAndGetTooType(categoryChoice, system, role);
                }
                return toolType;
            }
            else if (choice == "5")
            {
                string toolType = GetCleaningToolTypes();
                if (toolType == "back")
                {
                    string categoryChoice = DisplayAndGetCategories("Staff");
                    toolType = DisplayAndGetTooType(categoryChoice, system, role);
                }
                return toolType;
            }
            else if (choice == "6")
            {
                string toolType = GetPaintingToolTypes();
                if (toolType == "back")
                {
                    string categoryChoice = DisplayAndGetCategories("Staff");
                    toolType = DisplayAndGetTooType(categoryChoice, system, role);
                }
                return toolType;
            }
            else if (choice == "7")
            {
                string toolType = GetElectronicToolTypes();
                if (toolType == "back")
                {
                    string categoryChoice = DisplayAndGetCategories("Staff");
                    toolType = DisplayAndGetTooType(categoryChoice, system, role);
                }
                return toolType;
            }
            else if (choice == "8")
            {

                string toolType = GetElectricityToolTypes();
                if (toolType == "back")
                {
                    string categoryChoice = DisplayAndGetCategories("Staff");
                    toolType = DisplayAndGetTooType(categoryChoice, system, role);
                }
                return toolType;
            }
            else if (choice == "9")
            {
                string toolType = GetAutomotiveToolTypes();
                if (toolType == "back")
                {
                    string categoryChoice = DisplayAndGetCategories("Staff");
                    toolType = DisplayAndGetTooType(categoryChoice, system, role);
                }
                return toolType;
            }
            else
            {
                ProcessMainMenu(role, system);
            }

            return "Wrong choice";
        }


        /// <summary>
        /// display the tool types in gardening tools category and get the selected tool type
        /// </summary>
        /// <returns> the selected tool type</returns>
        public static string GetGardeningToolTypes()
        {
            Console.Clear();
            Console.WriteLine("=============Gardening Tools============");
            Console.WriteLine("1. Line Trimmers");
            Console.WriteLine("2. Lawn Mowers");
            Console.WriteLine("3. Gardening Hand Tools");
            Console.WriteLine("4. Wheelbarrows");
            Console.WriteLine("5. Garden Power Tools");
            Console.WriteLine("0. Return to Category");
            Console.WriteLine("========================================");
            Console.WriteLine("\n\nPlease make a selection (1-5) or 0 to return to Category menu");

            string choice = Console.ReadLine();

            while (choice != "0" && choice != "1" && choice != "2" &&
                   choice != "3" && choice != "4" && choice != "5")
            {
                Console.WriteLine("Wrong Selection! Please make a selection (1-5) or 0 to return to Category menu: ");
                choice = Console.ReadLine();
            }


            switch (choice)
            {
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
                case "0":
                    return "back";
                default:
                    return "Wrong choice";
            }
        }

        /// <summary>
        /// display the tool types in flooring tools category and get the selected tool type
        /// </summary>
        /// <returns> the selected tool type</returns>
        public static string GetFlooringToolTypes()
        {
            Console.Clear();
            Console.WriteLine("=============Flooring Tools============");
            Console.WriteLine("1. Scrapers");
            Console.WriteLine("2. Floor Lasers");
            Console.WriteLine("3. Floor Levelling Tools");
            Console.WriteLine("4. Floor Levelling Materials");
            Console.WriteLine("5. Floor Hand Tools");
            Console.WriteLine("6. Tiling Tools");
            Console.WriteLine("0. Return to Category menu");
            Console.WriteLine("=======================================");
            Console.WriteLine("\n\nPlease make a selection (1-6) or 0 to return to Category menu");
            string choice = Console.ReadLine();

            while (choice != "0" && choice != "1" && choice != "2" &&
                   choice != "3" && choice != "4" && choice != "5" && choice != "6")
            {
                Console.WriteLine("Wrong Selection! Please make a selection (1-6) or 0 to return to Category menu: ");
                choice = Console.ReadLine();
            }

            switch (choice)
            {
                case "1":
                    return "Scrapers";
                case "2":
                    return "Floor Lasers";
                case "3":
                    return "Floor Levelling Tools";
                case "4":
                    return "Floor Levelling Materials";
                case "5":
                    return "Floor Hand Tools";
                case "6":
                    return "Tiling Tools";
                case "0":
                    return "back";
                default:
                    return "Wrong choice";
            }
        }

        /// <summary>
        /// display the tool types in fencing tools category and get the selected tool type
        /// </summary>
        /// <returns> the selected tool type</returns>
        public static string GetFencingToolTypes()
        {
            Console.Clear();
            Console.WriteLine("=============Fencing Tools============");
            Console.WriteLine("1. Hand Tools");
            Console.WriteLine("2. Electric Fencing");
            Console.WriteLine("3. Steel Fencing Tools");
            Console.WriteLine("4. Power Tools");
            Console.WriteLine("5. Fencing Accessories");
            Console.WriteLine("0. Return to Category menu");
            Console.WriteLine("======================================");
            Console.WriteLine("\n\nPlease make a selection (1-5) or 0 to return to Category menu");
            string choice = Console.ReadLine();


            while (choice != "0" && choice != "1" && choice != "2" &&
                   choice != "3" && choice != "4" && choice != "5")
            {
                Console.WriteLine("Wrong Selection! Please make a selection (1-5) or 0 to return to Category menu: ");
                choice = Console.ReadLine();
            }

            switch (choice)
            {
                case "1":
                    return "Hand Tools";
                case "2":
                    return "Electric Fencing";
                case "3":
                    return "Steel Fencing Tools";
                case "4":
                    return "Power Tools";
                case "5":
                    return "Fencing Accessories";
                case "0":
                    return "back";
                default:
                    return "Wrong choice";
            }
        }

        /// <summary>
        /// display the tool types in measuring tools category and get the selected tool type
        /// </summary>
        /// <returns> the selected tool type</returns>
        public static string GetMeasuringToolTypes()
        {
            Console.Clear();
            Console.WriteLine("=============Measuring Tools============");
            Console.WriteLine("1. Distance Tools");
            Console.WriteLine("2. Laser Measurer");
            Console.WriteLine("3. Measuring Jugs");
            Console.WriteLine("4. Temperature & Humidity Tools");
            Console.WriteLine("5. Levelling Tools");
            Console.WriteLine("6. Markers");
            Console.WriteLine("0. Return to Category menu");
            Console.WriteLine("========================================");
            Console.WriteLine("\n\nPlease make a selection (1-6) or 0 to return to Category menu");
            string choice = Console.ReadLine();

            while (choice != "0" && choice != "1" && choice != "2" &&
                   choice != "3" && choice != "4" && choice != "5" && choice != "6")
            {
                Console.WriteLine("Wrong Selection! Please make a selection (1-6) or 0 to return to Category menu: ");
                choice = Console.ReadLine();
            }


            switch (choice)
            {
                case "1":
                    return "Distance Tools";
                case "2":
                    return "Laser Measurer";
                case "3":
                    return "Measuring Jugs";
                case "4":
                    return "Temerature & Humidity Tools";
                case "5":
                    return "Levelling Tools";
                case "6":
                    return "Markers";
                case "0":
                    return "back";
                default:
                    return "Wrong choice";
            }
        }

        /// <summary>
        /// display the tool types in cleaning tools category and get the selected tool type
        /// </summary>
        /// <returns> the selected tool type</returns>
        public static string GetCleaningToolTypes()
        {
            Console.Clear();
            Console.WriteLine("=============Cleaning Tools============");
            Console.WriteLine("1. Draining");
            Console.WriteLine("2. Car Cleaning");
            Console.WriteLine("3. Vacuum");
            Console.WriteLine("4. Pressure Cleaners");
            Console.WriteLine("5. Pool Cleaning");
            Console.WriteLine("6. Floor Cleaning");
            Console.WriteLine("0. Return to Category menu");
            Console.WriteLine("=======================================");
            Console.WriteLine("\n\nPlease make a selection (1-6) or 0 to return to Category menu");
            string choice = Console.ReadLine();


            while (choice != "0" && choice != "1" && choice != "2" &&
                   choice != "3" && choice != "4" && choice != "5" && choice != "6")
            {
                Console.WriteLine("Wrong Selection! Please make a selection (1-6) or 0 to return to Category menu: ");
                choice = Console.ReadLine();
            }

            switch (choice)
            {
                case "1":
                    return "Draining";
                case "2":
                    return "Car Cleaning";
                case "3":
                    return "Vacuum";
                case "4":
                    return "Pressure Cleaners";
                case "5":
                    return "Pool Cleaning";
                case "6":
                    return "Floor Cleaning";
                case "0":
                    return "back";
                default:
                    return "Wrong choice";
            }
        }

        /// <summary>
        /// display the tool types in painting tools category and get the selected tool type
        /// </summary>
        /// <returns> the selected tool type</returns>
        public static string GetPaintingToolTypes()
        {
            Console.Clear();
            Console.WriteLine("=============Painting Tools============");
            Console.WriteLine("1. Sanding Tools");
            Console.WriteLine("2. Brushes");
            Console.WriteLine("3. Rollers");
            Console.WriteLine("4. Paint Removal Tools");
            Console.WriteLine("5. Paint Scrapers");
            Console.WriteLine("6. Sprayers");
            Console.WriteLine("0. Return to Category menu");
            Console.WriteLine("=======================================");
            Console.WriteLine("\n\nPlease make a selection (1-6) or 0 to return to Category menu");
            string choice = Console.ReadLine();

            while (choice != "0" && choice != "1" && choice != "2" &&
                   choice != "3" && choice != "4" && choice != "5" && choice != "6")
            {
                Console.WriteLine("Wrong Selection! Please make a selection (1-6) or 0 to return to Category menu: ");
                choice = Console.ReadLine();
            }

            switch (choice)
            {
                case "1":
                    return "Sanding Tools";
                case "2":
                    return "Brushes";
                case "3":
                    return "Rollers";
                case "4":
                    return "Paint Removal Tools";
                case "5":
                    return "Paint Scrapers";
                case "6":
                    return "Sprayers";
                case "0":
                    return "back";
                default:
                    return "Wrong choice";
            }
        }

        /// <summary>
        /// display the tool types in electronic tools category and get the selected tool type
        /// </summary>
        /// <returns> the selected tool type</returns>
        public static string GetElectronicToolTypes()
        {
            Console.Clear();
            Console.WriteLine("=============Electronic Tools============");
            Console.WriteLine("1. Voltage Tester");
            Console.WriteLine("2. Oscilloscopes");
            Console.WriteLine("3. Thermal Imaging");
            Console.WriteLine("4. Data Test Tool");
            Console.WriteLine("5. Insulation Testers");
            Console.WriteLine("0. Return to Category menu");
            Console.WriteLine("=========================================");
            Console.WriteLine("\n\nPlease make a selection (1-5) or 0 to return to Category menu");
            string choice = Console.ReadLine();

            while (choice != "0" && choice != "1" && choice != "2" &&
                   choice != "3" && choice != "4" && choice != "5")
            {
                Console.WriteLine("Wrong Selection! Please make a selection (1-5) or 0 to return to Category menu: ");
                choice = Console.ReadLine();
            }

            switch (choice)
            {
                case "1":
                    return "Voltage Tester";
                case "2":
                    return "Oscilloscopes";
                case "3":
                    return "Thermal Imaging";
                case "4":
                    return "Data Test Tool";
                case "5":
                    return "Insulation Testers";
                case "0":
                    return "back";
                default:
                    return "Wrong choice";
            }

        }

        /// <summary>
        /// display the tool types in electricity tools category and get the selected tool type
        /// </summary>
        /// <returns> the selected tool type</returns>
        public static string GetElectricityToolTypes()
        {
            Console.Clear();
            Console.WriteLine("=============Electricity Tools============");
            Console.WriteLine("1. Test Equipment");
            Console.WriteLine("2. Safety Equipment");
            Console.WriteLine("3. Basic Hand Tools");
            Console.WriteLine("4. Circuit Protection");
            Console.WriteLine("5. Cable Tools");
            Console.WriteLine("0. Return to Category menu");
            Console.WriteLine("==========================================");
            Console.WriteLine("\n\nPlease make a selection (1-5) or 0 to return to Category menu");
            string choice = Console.ReadLine();


            while (choice != "0" && choice != "1" && choice != "2" &&
                   choice != "3" && choice != "4" && choice != "5")
            {
                Console.WriteLine("Wrong Selection! Please make a selection (1-5) or 0 to return to Category menu: ");
                choice = Console.ReadLine();
            }

            switch (choice)
            {
                case "1":
                    return "Test Equipment";
                case "2":
                    return "Safety Equipment";
                case "3":
                    return "Basic Hand Tools";
                case "4":
                    return "Circuit Protection";
                case "5":
                    return "Cable Tools";
                case "0":
                    return "back";
                default:
                    return "Wrong choice";
            }
        }

        /// <summary>
        /// display the tool types in automotive tools category and get the selected tool type
        /// </summary>
        /// <returns> the selected tool type</returns>
        public static string GetAutomotiveToolTypes()
        {
            Console.Clear();
            Console.WriteLine("=============Tool Types============");
            Console.WriteLine("1. Jacks");
            Console.WriteLine("2. Air Compressors");
            Console.WriteLine("3. Battery Chargers");
            Console.WriteLine("4. Socket Tools");
            Console.WriteLine("5. Braking");
            Console.WriteLine("6. Drivetrain");
            Console.WriteLine("0. Return to Category menu");
            Console.WriteLine("===================================");
            Console.WriteLine("\n\nPlease make a selection (1-6) or 0 to return to Category menu");
            string choice = Console.ReadLine();


            while (choice != "0" && choice != "1" && choice != "2" &&
                   choice != "3" && choice != "4" && choice != "5" && choice != "6")
            {
                Console.WriteLine("Wrong Selection! Please make a selection (1-6) or 0 to return to Category menu: ");
                choice = Console.ReadLine();
            }


            switch (choice)
            {
                case "1":
                    return "Jacks";
                case "2":
                    return "Air Compressors";
                case "3":
                    return "Battery Chargers";
                case "4":
                    return "Socket Tools";
                case "5":
                    return "Braking";
                case "6":
                    return "Drivetrain";
                case "0":
                    return "back";
                default:
                    return "Wrong choice";
            }
        }


        /// <summary>
        /// add a tool to the given tool type to the system
        /// </summary>
        /// <param name="toolSystem"> the tool library system </param>
        /// <param name="toolType"> given tool type </param>
        /// <returns> the added tool </returns>
        public static Tool AddATool(ToolLibrarySystem toolSystem, string toolType)
        {
            Console.Write("Please enter a tool name: ");
            string toolName = Console.ReadLine();
            Console.Write("Please enter a quantity: ");

            string quantityString = Console.ReadLine();

            int quantity;

            while (!int.TryParse(quantityString, out quantity)) {
                Console.Write("Wrong input! Please enter an integer value: ");
                quantityString = Console.ReadLine();
            }


            Tool tool = new Tool(toolName);
            ToolCollection toolsInTheToolType = null;
            for (int i = 0; i < allToolCollections.Length; i++) {
                if (toolType == allToolCollections[i].Name) {
                    toolsInTheToolType = allToolCollections[i];
                }
            }

            for (int i = 0; i < toolsInTheToolType.Number; i++) {
                if (toolName == toolsInTheToolType.toArray()[i].Name) {
                    tool = toolsInTheToolType.toArray()[i];

                    Console.WriteLine("\nThe tool you want to add is already in the system, new pieces of this tool will be added.");
                    Console.Write("Press any key to continue.\n");
                    Console.ReadKey();
                    toolHasSameName = true;
                }
            }


            toolSystem.add(tool, quantity);
            return tool;
        }

        /// <summary>
        /// create a member
        /// </summary>
        /// <returns> the member created</returns>
        public static Member CreateMember() {
            Console.Write("\nPlease enter first name:         ");
            string firstName = Console.ReadLine();

            while (!Char.IsUpper(firstName[0])) {
                Console.Write("\nThe first letter needs to be capitalised, please try again: ");
                firstName = Console.ReadLine();
            }

            Console.Write("\nPlease enter last name:         ");
            string lastName = Console.ReadLine();

            while (!Char.IsUpper(lastName[0]))
            {
                Console.Write("\nThe first letter needs to be capitalised, please try again: ");
                lastName = Console.ReadLine();
            }

            Console.Write("\nPlease enter contact number:     ");

            string number = Console.ReadLine();
            while (!long.TryParse(number, out _))
            {
                Console.Write("Wrong input! Please enter numeric values: ");
                number = Console.ReadLine();
            }

            Console.Write("Please enter password(4 digits): ");
            string pin = Console.ReadLine();

            while (!int.TryParse(pin, out _) || pin.Length != 4)
            {
                Console.Write("Wrong input! Please enter 4 digits: ");
                pin = Console.ReadLine();
            }

            Member member = new Member(firstName, lastName, number, pin);

            return member;
        }

        /// <summary>
        /// return to the staff menu
        /// </summary>
        public static void ReturnToStaffMenu() {
            Console.WriteLine("\nPlease enter 0 to return to Staff menu:  ");
            staffName = "staff";
            staffPin = "today123";
            string choice = Console.ReadLine();
            while (choice != "0")
            {
                Console.Write("Wrong Selection! Please enter 0 to return to Staff menu: ");
                choice = Console.ReadLine();
            }

        }

        /// <summary>
        /// return to the member menu
        /// </summary>
        public static void ReturnToMemberMenu() {
            Console.WriteLine("\nPlease enter 0 to return to Member menu: ");
            string choice = Console.ReadLine();
            while (choice != "0")
            {
                Console.Write("Wrong Selection! Please enter 0 to return to Member menu: ");
                choice = Console.ReadLine();
            }
        }

        /// <summary>
        /// return to the main menu
        /// </summary>
        /// <param name="toolSystem"> the tool library system</param>
        public static void ReturnToMainMenu(ToolLibrarySystem toolSystem) {
            Console.Clear();
            string choice = DisplayMainMenu();
            ProcessMainMenu(choice, toolSystem);
         }

        /// <summary>
        /// process a selection in the main menu
        /// </summary>
        /// <param name="mainMenuChoice"> selection made in the main menu</param>
        /// <param name="toolSystem"> the tool library system </param>
        public static void ProcessMainMenu(string mainMenuChoice, ToolLibrarySystem toolSystem)
        {

            while (mainMenuChoice != "0")
            {
                if (mainMenuChoice == "1")
                {

                    while (staffName.ToLower() != "staff")
                    {
                        Console.Clear();
                        Console.Write("Please enter the staff name: ");
                        staffName = Console.ReadLine();
                        if (staffName.ToLower() != "staff")
                        {
                            Console.Write("\nWrong staff name! Enter 0 to return to main menu or ");
                            Console.Write("press any other key to try again: ");
                            string choice = Console.ReadLine();

                            while (choice == "0")
                            {
                                Console.Clear();
                                ReturnToMainMenu(toolSystem);
                            }
                        }
                    }


                    if (staffName.ToLower() == "staff")
                    {
                        staffName = "";
                        while (staffPin != "today123")
                        {
                            Console.Clear();
                            Console.Write("Please enter the staff pin: ");
                            staffPin = Console.ReadLine();
                            staffName = "staff";
                            if (staffPin != "today123")
                            {
                                Console.Write("\nWrong staff pin! Enter 0 to return to main menu or ");
                                Console.Write("press any other key to try again: ");

                                string choice = Console.ReadLine();

                                while (choice == "0")
                                {
                                    Console.Clear();
                                    ReturnToMainMenu(toolSystem);
                                }
                            }
                        }

                        DisplayStaffMenu();
                        string staffChoice = Console.ReadLine();

                        if (staffChoice != "0")
                        {
                            ProcessStaffChoice(staffChoice, toolSystem);
                        }
                        else
                        {
                            Console.Clear();
                            staffName = "";
                            staffPin = "";
                            Console.Clear();
                            ReturnToMainMenu(toolSystem);

                        }

                    }
                }
                else if (mainMenuChoice == "2")
                {

                    while (!LoginAMember())
                    {
                        Console.Clear();
                        Console.WriteLine("Wrong member name or pin! Please use the format LastnameFirstname to log in!");
                        Console.WriteLine("\nEnter 0 to return to Main menu or ");
                        Console.Write("press any other key to try again: ");

                        memberName = "";
                        string choice = Console.ReadLine();
                        while (choice == "0")
                        {
                            Console.Clear();
                            ReturnToMainMenu(toolSystem);
                        }
                    }

                    Console.Clear();
                    DisplayMemberMenu();

                    string memberChoice = Console.ReadLine();

                    if (memberChoice != "0")
                    {
                        ProcessMemberChoice(memberChoice, toolSystem);
                    }
                    else
                    {

                        memberName = "";
                        ReturnToMainMenu(toolSystem);
                    }

                }
                else
                {
                    Console.Write("Wrong selection! Please make a selection (1-2) or 0 to exit: ");
                    mainMenuChoice = Console.ReadLine();
                }
            }

            Environment.Exit(0);
        }

        /// <summary>
        /// process a selection in the staff menu
        /// </summary>
        /// <param name="staffChoice"> selection made in the staff menu </param>
        /// <param name="system"> the tool libary system</param>
        public static void ProcessStaffChoice(string staffChoice, ToolLibrarySystem system)
        {
            while (staffChoice != "0" && staffChoice != "1" && staffChoice != "2" &&
                   staffChoice != "3" && staffChoice != "4" && staffChoice != "5" && staffChoice != "6")
            {
                Console.WriteLine("Wrong Selection! Please make a selection (1-6) or 0 to return to Main menu: ");
                staffChoice = Console.ReadLine();
            }

            if (staffChoice == "1")
            {
                string categoryChoice = DisplayAndGetCategories("Staff");
                string toolType = DisplayAndGetTooType(categoryChoice, system, "1");
                Console.Clear();
                system.displayTools(toolType);

                currentlySelectedToolType = toolType;
                Tool toolToAdd = AddATool(system, toolType);

                if (!toolHasSameName)
                {
                    system.add(toolToAdd);
                    toolHasSameName = false;
                }
                Console.WriteLine("\n" + toolToAdd.Quantity + " pieces of " + toolToAdd.Name + " has been added");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                Console.Clear();
                system.displayTools(toolType);

                Console.WriteLine("\n\n1. Add a new tool");
                Console.WriteLine("0. Return to staff menu");
                Console.Write("\n\nPlease enter 1 to add a new tool or 0 to return to Staff menu: ");
                string choice = Console.ReadLine();

                while (choice != "1" && choice != "0")
                {
                    Console.WriteLine("Wrong Selection! Please enter 1 to add a new tool or 0 to return to Staff menu: ");
                    choice = Console.ReadLine();
                }


                if (choice == "1")
                {
                    ProcessStaffChoice(staffChoice, system);
                }
                else if (choice == "0")
                {
                    ProcessMainMenu("1", system);
                }
            }
            else if (staffChoice == "2")
            {
                string categoryChoice = DisplayAndGetCategories("Staff");
                string toolType = DisplayAndGetTooType(categoryChoice, system, "1");
                Console.Clear();
                system.displayTools(toolType);
                ToolCollection displayedTools = GetDisplayedTools(toolType);
                Console.Write("\n\nPlease make a selection from the tools above: ");
                string choiceString = Console.ReadLine();

                int indexChoice;

                while (!int.TryParse(choiceString, out indexChoice) || indexChoice > displayedTools.Number || indexChoice <= 0)
                {
                    Console.Write("Wrong input! Please make a selection from the tools above: ");
                    choiceString = Console.ReadLine();
                }

                Tool selectedTool = displayedTools.toArray()[indexChoice - 1];
                Console.Write("Please enter the quantity of this tool you want to add: ");
                string quantityString = Console.ReadLine();
                int quantity;

                while (!int.TryParse(quantityString, out quantity))
                {
                    Console.Write("Wrong input! Please enter an integer value: ");
                    quantityString = Console.ReadLine();
                }

                system.add(selectedTool, quantity);
                Console.WriteLine("\n" + quantity + " pieces of " + selectedTool.Name + " has been added");
                Console.WriteLine("Current quantity: " + selectedTool.Quantity);
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();

                Console.Clear();
                system.displayTools(toolType);

                Console.WriteLine("\n0. Return to staff menu");

                ReturnToStaffMenu();

            }
            else if (staffChoice == "3")
            {
                string categoryChoice = DisplayAndGetCategories("Staff");
                string toolType = DisplayAndGetTooType(categoryChoice, system, "1");
                Console.Clear();
                system.displayTools(toolType);
                ToolCollection displayedTools = GetDisplayedTools(toolType);
                Console.WriteLine("\n\nPlease make a selection from the tools above: ");
                string choiceString = Console.ReadLine();

                int indexChoice;

                while (!int.TryParse(choiceString, out indexChoice) || indexChoice > displayedTools.Number || indexChoice <= 0)
                {
                    Console.WriteLine("Wrong input! Please make a selection from the tools above: ");
                    choiceString = Console.ReadLine();
                }

                Tool selectedTool = displayedTools.toArray()[indexChoice - 1];
                Console.Write("Please enter the quantity of this tool you want to remove: ");
                string quantityString = Console.ReadLine();
                int quantity;

                while (!int.TryParse(quantityString, out quantity) || quantity > selectedTool.AvailableQuantity)
                {
                    Console.Write("Wrong input! Please enter an integer value less than available quantity: ");
                    quantityString = Console.ReadLine();
                }

                system.delete(selectedTool, quantity);

                Console.WriteLine("\n" + quantity + " pieces of " + selectedTool.Name + " has been deleted");
                Console.WriteLine("Current quantity: " + selectedTool.Quantity);
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
                Console.Clear();
                system.displayTools(toolType);

                Console.WriteLine("\n\n0. Return to staff menu");

                ReturnToStaffMenu();
            }
            else if (staffChoice == "4")
            {
                Console.Clear();
                DisplayMembers();

                Member member = CreateMember();
                system.add(member);

                Console.WriteLine("\n" + member.FirstName + " " + member.LastName + " has been added. ");
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();


                Console.Clear();
                DisplayMembers();

                ReturnToStaffMenu();
            }
            else if (staffChoice == "5")
            {
                Console.Clear();
                DisplayMembers();
                Console.WriteLine("\n\nPlease select the member you want to remove or enter 0 to return to Staff menu: ");

                int indexChoice;
                string choiceString = Console.ReadLine();

                while (!int.TryParse(choiceString, out indexChoice) || indexChoice <= 0 || indexChoice > validMemberNum)
                {
                    Console.WriteLine("Wrong input! Please make a selection from the member IDs above: ");
                    choiceString = Console.ReadLine();
                }

                if (indexChoice == 0)
                {
                    ProcessMainMenu("1", system);
                }

                Member memberToDelete = members.toArray()[indexChoice - 1];
                system.delete(memberToDelete);


                Console.Clear();
                DisplayMembers();
                Console.WriteLine("\n\n0. Return to staff menu");
                ReturnToStaffMenu();

            }
            else if (staffChoice == "6")
            {
                Console.Clear();
                Console.Write("Please enter a member first name: ");
                string firstName = Console.ReadLine();
                Console.Write("Please enter a member last name:  ");
                string lastName = Console.ReadLine();
                bool foundMember = false;

                Member[] memberArray = members.toArray();
                for (int i = 0; i < memberArray.Length; i++)
                {

                    if (memberArray[i] != null &&
                        memberArray[i].LastName.ToLower() == lastName.ToLower() && memberArray[i].FirstName.ToLower() == firstName.ToLower())
                    {
                        Console.Clear();
                        Console.WriteLine("Contact Number: " + memberArray[i].ContactNumber);
                        foundMember = true;
                        break;
                    }
                }

                if (!foundMember) {
                    Console.WriteLine("\nMember not found! Please try again.");
   
                }

                Console.WriteLine("\n\n0. Return to staff menu");
                ReturnToStaffMenu();
            }
            else {
                staffName = "";
                staffPin = "";
                ReturnToMainMenu(system);
            }
        }

        /// <summary>
        /// process a selection in the member menu
        /// </summary>
        /// <param name="memberChoice"> selection made</param>
        /// <param name="system"> the tool library system </param>
        public static void ProcessMemberChoice(string memberChoice, ToolLibrarySystem system) {
            while (memberChoice != "0" && memberChoice != "1" && memberChoice != "2" && memberChoice != "3" && memberChoice != "4" && memberChoice != "5")
            {
                Console.WriteLine("Wrong Selection! Please make a selection (1-5) or 0 to return to Main menu: ");
                memberChoice = Console.ReadLine();
            }

            if (memberChoice == "1")
            {
                string categoryChoice = DisplayAndGetCategories("Member");
                string toolType = DisplayAndGetTooType(categoryChoice, system, "2");
                Console.Clear();
                system.displayTools(toolType);

                ReturnToMemberMenu();
            }
            else if (memberChoice == "2")
            {
                string categoryChoice = DisplayAndGetCategories("Member");
                string toolType = DisplayAndGetTooType(categoryChoice, system, "2");
                Console.Clear();
                system.displayTools(toolType);
                ToolCollection displayedTools = GetDisplayedTools(toolType);
                Console.Write("\nPlease make a selection from the tools above: ");
                string choiceString = Console.ReadLine();

                int indexChoice;

                while (!int.TryParse(choiceString, out indexChoice) || indexChoice > displayedTools.Number || indexChoice <= 0)
                {
                    Console.Write("Wrong input! Please make a selection from the tools above: ");
                    choiceString = Console.ReadLine();
                }

                Tool selectedTool = displayedTools.toArray()[indexChoice - 1];

                if (system.borrowTool(loggedInMember, selectedTool))
                {
                    Console.Clear();
                    Console.WriteLine("You have successfully borrowed " + selectedTool.Name);
                    Console.WriteLine();
                    system.displayBorrowingTools(loggedInMember);
                    ReturnToMemberMenu();
                }


            }
            else if (memberChoice == "3")
            {

                string[] borrowedTools = system.listTools(loggedInMember);
                Console.Clear();
                system.displayBorrowingTools(loggedInMember);

                Console.Write("Please make a selection from the tools above or press 0 return to Member menu: ");

                string choiceString = Console.ReadLine();
                int indexChoice;

                while (!int.TryParse(choiceString, out indexChoice) || indexChoice <= 0 || indexChoice > borrowedTools.Length )
                {
                    if (indexChoice != 0)
                    {
                        Console.Write("Wrong input! Please make a selection from the tools above or press 0 return to Member menu: ");
                        choiceString = Console.ReadLine();
                    }
                    else {
                        ProcessMainMenu("2", system);

                    }
                }

                string toolToReturnName = system.listTools(loggedInMember)[indexChoice - 1];
                int[] location = GetAToolByToolName(toolToReturnName);
                Tool toolToReturn = allToolCollections[location[0]].toArray()[location[1]];

                system.returnTool(loggedInMember, toolToReturn);

                Console.WriteLine("\n" + borrowedTools[indexChoice - 1] + " has been returned. ");
                Console.Write("\nPress any key to continue.");
                Console.ReadKey();

                Console.Clear();
                system.displayBorrowingTools(loggedInMember);
                Console.Write("\nPress any key to continue.");
                Console.ReadKey();
            }
            else if (memberChoice == "4")
            {
                Console.Clear();
                system.displayBorrowingTools(loggedInMember);
                Console.Write("\nPress any key to continue.");
                Console.ReadKey();
            }
            else if (memberChoice == "5")
            {
                Console.Clear();
                Console.WriteLine("===============Top 3 Borrowed Tools===============");
                system.displayTopThree();
                Console.WriteLine("==================================================");
                Console.Write("\nPress any key to continue.");
                Console.ReadKey();
            }
            else {
                memberName = "";
                ReturnToMainMenu(system);
            }

        }


    }
        


}
