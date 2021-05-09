﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrary
{

    // Author:    Cheng Liang
    // Studen ID: N10346911
    class UserInterface
    {
        static string staffName = "";
        static string staffPin = "";
        static string memberFirstName = "";
        static string memberLastName = "";
        static string pin = "";
        private static MemberCollection members = null;
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

        static Member loggedInMember;
        public static bool LoginAMember(ToolLibrarySystem toolSystem) {
            Console.Clear();


            if (memberFirstName == "" && memberLastName == "")
            {
                Console.Write("Please enter your first name:   ");
                memberFirstName = Console.ReadLine();
                Console.Write("Please enter your last name:    ");
                memberLastName = Console.ReadLine();
                Console.Write("Please enter password(4 digits): ");
                pin = Console.ReadLine();
            }

            Member[] memberArray = toolSystem.Members.toArray();

            for (int i = 0; i < memberArray.Length; i++)
            {
                if (memberArray[i] != null &&
                    memberArray[i].LastName.ToLower() == memberLastName.ToLower() && memberArray[i].FirstName.ToLower() == memberFirstName.ToLower() && memberArray[i].PIN == pin)
                {
                    memberFirstName = memberArray[i].FirstName;
                    memberLastName = memberArray[i].LastName;
                    pin = memberArray[i].PIN;
                    loggedInMember = memberArray[i];
                    return true;
                }   
            }
            return false;
        }

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
                        if (staffName.ToLower() != "staff") {
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
                            if (staffPin != "today123") {
                                Console.Write("\nWrong staff pin! Enter 0 to return to main menu or ");
                                Console.Write("press any other key to try again: ");

                                string choice = Console.ReadLine();

                                while (choice == "0") {
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

                    while (!LoginAMember(toolSystem)) {
                        Console.Clear();
                        Console.WriteLine("Wrong member name or pin! Please try again!");
                        Console.WriteLine("\nEnter 0 to return to Main menu or ");
                        Console.Write("press any other key to try again: ");
                        memberFirstName = "";
                        memberLastName = "";
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
                    else {
                        Console.Clear();
                        memberFirstName = "";
                        memberLastName = "";
                        string choice = DisplayMainMenu();
                        ProcessMainMenu(choice, toolSystem);
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

        public static Tool CreateATool()
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
            tool.Quantity += quantity;
            tool.AvailableQuantity += quantity;

            return tool;
        }

        public static Member CreateMember() {
            Console.Write("\nPlease enter first name:         ");
            string firstName = Console.ReadLine();
            Console.Write("Please enter last name:          ");
            string lastName = Console.ReadLine();

            Console.Write("Please enter contact number:     ");


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
        static int validMemberNum = 0;

        public static void DisplayMembers(ToolLibrarySystem system) {
            Console.WriteLine("==========================Members=========================");

            Console.WriteLine("   {0, -15}{1, -15}{2, 15}", "First Name", "Last Name", "Contact Number");

            if (system.Members != null)
            {
                Member[] memberArray = system.Members.toArray();

                for (int i = 0; i < memberArray.Length; i++)
                {
                    if (memberArray[i] != null && memberArray[i].ContactNumber != "")
                    {
                        validMemberNum++;
                        Console.WriteLine(i + 1 + ". {0, -15}{1, -15} {2, -15}", memberArray[i].FirstName, memberArray[i].LastName, memberArray[i].ContactNumber);
                    }

                }
            }

            Console.WriteLine("==========================================================");
        }

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

        public static void ReturnToMemberMenu() {
            Console.WriteLine("\nPlease enter 0 to return to Member menu: ");
            string choice = Console.ReadLine();
            while (choice != "0")
            {
                Console.Write("Wrong Selection! Please enter 0 to return to Member menu: ");
                choice = Console.ReadLine();
            }
        }

        public static void ReturnToMainMenu(ToolLibrarySystem toolSystem) {
            string choice = DisplayMainMenu();
            ProcessMainMenu(choice, toolSystem);
         }

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
                Tool toolToAdd = CreateATool();
                system.add(toolToAdd, toolType);
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
                Tool[] displayedTools = system.displayTools(toolType);
                Console.Write("\n\nPlease make a selection from the tools above: ");
                string choiceString = Console.ReadLine();

                int indexChoice;

                while (!int.TryParse(choiceString, out indexChoice) || indexChoice > displayedTools.Length)
                {
                    Console.Write("Wrong input! Please make a selection from the tools above: ");
                    choiceString = Console.ReadLine();
                }

                Tool selectedTool = displayedTools[indexChoice - 1];
                Console.Write("Please enter the quantity of this tool you want to add: ");
                string quantityString = Console.ReadLine();
                int quantity;

                while (!int.TryParse(quantityString, out quantity))
                {
                    Console.Write("Wrong input! Please enter an integer value: ");
                    quantityString = Console.ReadLine();
                }

                selectedTool.AvailableQuantity += quantity;
                selectedTool.Quantity += quantity;
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
                Tool[] displayedTools = system.displayTools(toolType);
                Console.WriteLine("\n\nPlease make a selection from the tools above: ");
                string choiceString = Console.ReadLine();

                int indexChoice;

                while (!int.TryParse(choiceString, out indexChoice) || indexChoice > displayedTools.Length)
                {
                    Console.WriteLine("Wrong input! Please make a selection from the tools above: ");
                    choiceString = Console.ReadLine();
                }

                Tool selectedTool = displayedTools[indexChoice - 1];
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
                DisplayMembers(system);

                Member member = CreateMember();
                system.add(member);

                Console.WriteLine("\n" + member.FirstName + " " + member.LastName + " has been added. ");
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();


                Console.Clear();
                DisplayMembers(system);

                ReturnToStaffMenu();
            }
            else if (staffChoice == "5")
            {
                Console.Clear();
                DisplayMembers(system);
                Console.WriteLine("\n\nPlease select the member you want to remove or enter 0 to return to Staff menu: ");

                int indexChoice;
                string choiceString = Console.ReadLine();

                while (!int.TryParse(choiceString, out indexChoice) || indexChoice < 0 || indexChoice > validMemberNum)
                {
                    Console.WriteLine("Wrong input! Please make a selection from the member IDs above: ");
                    choiceString = Console.ReadLine();
                }

                if (indexChoice == 0)
                {
                    ProcessMainMenu("1", system);
                }

                Member memberToDelete = system.Members.toArray()[indexChoice - 1];
                system.delete(memberToDelete);


                Console.WriteLine("\n" + memberToDelete.FirstName + " " + memberToDelete.LastName + " has been removed. ");
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();

                memberToDelete.FirstName = "";
                memberToDelete.LastName = "";
                memberToDelete.PIN = "";
                memberToDelete.ContactNumber = "";

                Console.Clear();
                DisplayMembers(system);
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

                Member[] memberArray = system.Members.toArray();
                for (int i = 0; i < memberArray.Length; i++)
                {

                    if (memberArray[i] != null &&
                        memberArray[i].LastName.ToLower() == lastName.ToLower() && memberArray[i].FirstName.ToLower() == firstName.ToLower())
                    {
                        Console.Clear();
                        Console.WriteLine("Contact Number: " + memberArray[i].ContactNumber);
                    }
                }

             
                Console.WriteLine("\nMember not found! Please try again.");
                Console.WriteLine("\n\n0. Return to staff menu");
                ReturnToStaffMenu();

            }
            else {
                staffName = "";
                staffPin = "";
                string mainMenuChoice = DisplayMainMenu();
                ProcessMainMenu(mainMenuChoice, system);

            }
        }


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
                Tool[] displayedTools = system.displayTools(toolType);

                Console.Write("\nPlease make a selection from the tools above: ");
                string choiceString = Console.ReadLine();

                int indexChoice;

                while (!int.TryParse(choiceString, out indexChoice) || indexChoice > displayedTools.Length || indexChoice < 0)
                {
                    Console.Write("Wrong input! Please make a selection from the tools above: ");
                    choiceString = Console.ReadLine();
                }

                Tool selectedTool = displayedTools[indexChoice - 1];

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

                string[] borrowedTools = loggedInMember.Tools;
                Console.Clear();
                system.displayBorrowingTools(loggedInMember);

                Console.Write("Please make a selection from the tools above: ");

                string choiceString = Console.ReadLine();
                int indexChoice;

                while (!int.TryParse(choiceString, out indexChoice) || indexChoice > borrowedTools.Length)
                {
                    Console.Write("Wrong input! Please make a selection from the tools above: ");
                    choiceString = Console.ReadLine();
                }


                system.returnTool(loggedInMember, loggedInMember.BorrowedTools.toArray()[indexChoice - 1]);

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
                system.displayTopThree();
                Console.Write("\nPress any key to continue.");
                Console.ReadKey();

            }
            else {
                memberFirstName = "";
                string mainMenuChoice = DisplayMainMenu();
                ProcessMainMenu(mainMenuChoice, system);
            }

        }


    }
        


}
