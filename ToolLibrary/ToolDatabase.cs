using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrary
{
    // Author:    Cheng Liang
    // Studen ID: N10346911
    class ToolDatabase
    {



        public static ToolCollection[] GetToolDatabase() {


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
            ToolCollection circuitProtection = new ToolCollection("Circuit Protect");
            ToolCollection cableTools = new ToolCollection("Cable Tools");
            ToolCollection jacks = new ToolCollection("Jacks");
            ToolCollection airCompressors = new ToolCollection("Air Compressors");
            ToolCollection batteryChargers = new ToolCollection("Battery Chargers");
            ToolCollection socketTools = new ToolCollection("Socket Tools");
            ToolCollection braking = new ToolCollection("Braking");
            ToolCollection driveTrain = new ToolCollection("Drivetrain");




            ToolCollection[] allToolCollections = new ToolCollection[] {
            lineTrimmers,
            lawnMowers,
            gardenHandTools,
            wheelBarrows,
            gardenPowerTools,
            scrapers,
            floorLasers,
            floorLevellingTools,
            floorLevellingMaterials,
            floorHandTools,
            tilingTools,
            fencingHandTools,
            electricFencing,
            steelFencingTools,
            powerTools,
            fencingAccessories,
            distanceTools,
            laserMeature,
            measuringJugs,
            temperatureAndHumidityTools,
            messuringLevellingTools,
            markers,
            draining,
            carCleaning,
            vacuum,
            pressureCleaners,
            poolCleaning,
            floorCleaning,
            sandingTools,
            brushes,
            rollers,
            paintRemovalTools,
            paintScrapers,
            sprayers,
            voltageTester,
            oscilloscopes,
            thermalImaging,
            dataTestTool,
            insulationTesters,
            testEquipment,
            safetyEquipment,
            basicHandTools,
            circuitProtection,
            cableTools,
            jacks,
            airCompressors,
            batteryChargers,
            socketTools,
            braking,
            driveTrain
            };


            for (int i = 0; i < allToolCollections.Length; i++) {

                allToolCollections[i].add(new Tool(allToolCollections[i].Name + " Tool 1"));
                allToolCollections[i].add(new Tool(allToolCollections[i].Name + " Tool 2"));

            }

            return allToolCollections;



        }

        

    }
}
