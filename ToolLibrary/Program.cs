using System;
using System.Collections.Generic;

namespace ToolLibrary
{
    // Author:    Cheng Liang
    // Studen ID: N10346911
    class Program
    {

        /// <summary>
        /// setup the tool collections and add dummy tools to them
        /// </summary>
        /// <returns>an array of tool collections</returns>
        public static ToolCollection[] GetToolDatabase()
        {
            ToolCollection lineTrimmers = new ToolCollection("Line Trimmers");
            ToolCollection lawnMowers = new ToolCollection("Lawn Mowers");
            ToolCollection gardenHandTools = new ToolCollection("Garden Hand Tools");
            ToolCollection wheelBarrows = new ToolCollection("Wheelbarrows");
            ToolCollection gardenPowerTools = new ToolCollection("Garden Power Tools");
            ToolCollection scrapers = new ToolCollection("Scrapers");
            ToolCollection floorLasers = new ToolCollection("Floor Lasers");
            ToolCollection floorLevellingTools = new ToolCollection("Floor Levelling Tools");
            ToolCollection floorLevellingMaterials = new ToolCollection("Floor Levelling Materials");
            ToolCollection floorHandTools = new ToolCollection("Floor Hand Tools");
            ToolCollection tilingTools = new ToolCollection("Tiling Tools");
            ToolCollection fencingHandTools = new ToolCollection("Hand Tools");
            ToolCollection electricFencing = new ToolCollection("Electric Fencing");
            ToolCollection steelFencingTools = new ToolCollection("Steel Fencing Tools");
            ToolCollection powerTools = new ToolCollection("Power Tools");
            ToolCollection fencingAccessories = new ToolCollection("Fencing Accessories");
            ToolCollection distanceTools = new ToolCollection("Distance Tools");
            ToolCollection laserMeature = new ToolCollection("Laser Measurer");
            ToolCollection measuringJugs = new ToolCollection("Measuring Jugs");
            ToolCollection temperatureAndHumidityTools = new ToolCollection("Temperature & Humidity Tools");
            ToolCollection messuringLevellingTools = new ToolCollection("Levelling Tools");
            ToolCollection markers = new ToolCollection("Markers");
            ToolCollection draining = new ToolCollection("Draining");
            ToolCollection carCleaning = new ToolCollection("Car Cleaning");
            ToolCollection vacuum = new ToolCollection("Vacuum");
            ToolCollection pressureCleaners = new ToolCollection("Pressure Cleaners");
            ToolCollection poolCleaning = new ToolCollection("Pool Cleaning");
            ToolCollection floorCleaning = new ToolCollection("Floor Cleaning");
            ToolCollection sandingTools = new ToolCollection("Sanding Tools");
            ToolCollection brushes = new ToolCollection("Brushes");
            ToolCollection rollers = new ToolCollection("Rollers");
            ToolCollection paintRemovalTools = new ToolCollection("Paint Removal Tools");
            ToolCollection paintScrapers = new ToolCollection("Paint Scrapers");
            ToolCollection sprayers = new ToolCollection("Sprayers");
            ToolCollection voltageTester = new ToolCollection("Voltage Tester");
            ToolCollection oscilloscopes = new ToolCollection("Oscilloscopes");
            ToolCollection thermalImaging = new ToolCollection("Thermal Imaging");
            ToolCollection dataTestTool = new ToolCollection("Data Test Tool");
            ToolCollection insulationTesters = new ToolCollection("Insulation Testers");
            ToolCollection testEquipment = new ToolCollection("Test Equipment");
            ToolCollection safetyEquipment = new ToolCollection("Safety Equipment");
            ToolCollection basicHandTools = new ToolCollection("Basic Hand Tools");
            ToolCollection circuitProtection = new ToolCollection("Circuit Protection");
            ToolCollection cableTools = new ToolCollection("Cable Tools");
            ToolCollection jacks = new ToolCollection("Jacks");
            ToolCollection airCompressors = new ToolCollection("Air Compressors");
            ToolCollection batteryChargers = new ToolCollection("Battery Chargers");
            ToolCollection socketTools = new ToolCollection("Socket Tools");
            ToolCollection braking = new ToolCollection("Braking");
            ToolCollection driveTrain = new ToolCollection("Drivetrain");

            ToolCollection[] allToolCollections = new ToolCollection[] {
            lineTrimmers, lawnMowers, gardenHandTools, wheelBarrows, gardenPowerTools, scrapers, floorLasers,
            floorLevellingTools, floorLevellingMaterials, floorHandTools, tilingTools, fencingHandTools, electricFencing, steelFencingTools,
            powerTools, fencingAccessories, distanceTools, laserMeature, measuringJugs, temperatureAndHumidityTools, messuringLevellingTools,
            markers, draining, carCleaning, vacuum, pressureCleaners, poolCleaning, floorCleaning, sandingTools, brushes,
            rollers, paintRemovalTools, paintScrapers, sprayers, voltageTester, oscilloscopes, thermalImaging, dataTestTool, insulationTesters, testEquipment, safetyEquipment, basicHandTools,
            circuitProtection, cableTools, jacks, airCompressors, batteryChargers, socketTools, braking, driveTrain };

            // adding dummy tools for testing
            for (int i = 0; i < allToolCollections.Length; i++)
            {
                allToolCollections[i].add(new Tool(allToolCollections[i].ToString() + " Tool 1"));
                allToolCollections[i].add(new Tool(allToolCollections[i].ToString() + " Tool 2"));
            }

            return allToolCollections;
        }
        static void Main(string[] args)
        {
            ToolLibrarySystem toolLibrarySystem = new ToolLibrarySystem();
            string mainMenuChoice = UserInterface.DisplayMainMenu();

            // Dummy members for testing
            Member member01 = new Member("Cheng", "Liang", "17887962464", "1234");
            Member member02 = new Member("Huanyi", "Qian", "17701449052", "1234");
            Member member03 = new Member("Ray", "Wenderlich", "1243536645", "1234");
            Member member04 = new Member("Bruce", "Wayne", "15423424123", "0789");

            toolLibrarySystem.add(member01);
            toolLibrarySystem.add(member02);
            toolLibrarySystem.add(member03);
            toolLibrarySystem.add(member04);

            UserInterface.ProcessMainMenu(mainMenuChoice, toolLibrarySystem);
        }
    }
}
