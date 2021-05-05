using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrary
{
    class ToolLibrarySystem : iToolLibrarySystem
    {

        private Tool aTool;
        private ToolCollection toolCollection;

        private Member aMember;

        private MemberCollection members;


        private ToolCollection[] toolCollections;
        private ToolCollection lineTrimmers;
        private ToolCollection lawnMowers;
        private ToolCollection gardenHandTools;
        private ToolCollection wheelBarrows;
        private ToolCollection gardenPowerTools;
        private ToolCollection scrapers;
        private ToolCollection floorLasers;
        private ToolCollection floorLevellingTools;
        private ToolCollection floorLevellingMaterion;
        private ToolCollection floorHandTools;
        private ToolCollection tilingTools;
        private ToolCollection fencingHandTools;
        private ToolCollection electricFencing;
        private ToolCollection steelFencingTools;
        private ToolCollection powerTools;
        private ToolCollection fencingAccessories;
        private ToolCollection distanceTools;
        private ToolCollection laserMeature;
        private ToolCollection measuringJugs;
        private ToolCollection temperatureAndHumidiection;
        private ToolCollection messuringLevellingToon;
        private ToolCollection markers;
        private ToolCollection draning;
        private ToolCollection carCleaning;
        private ToolCollection vacuum;
        private ToolCollection pressureCleaners;
        private ToolCollection poolCleaning;
        private ToolCollection floorCleaning;
        private ToolCollection sandingTools;
        private ToolCollection brushes;
        private ToolCollection rollers;
        private ToolCollection paintRemovalTools;
        private ToolCollection paintScrapers;
        private ToolCollection sprayers;
        private ToolCollection voltageTester;
        private ToolCollection oscilloscopes;
        private ToolCollection thermalImaging;
        private ToolCollection dataTestTool;
        private ToolCollection insulationTesters;
        private ToolCollection testEquipment;
        private ToolCollection safetyEquipment;
        private ToolCollection basicHandTools;
        private ToolCollection circuitProtection;
        private ToolCollection cableTools;
        private ToolCollection jacks;
        private ToolCollection airCompressors;
        private ToolCollection batteryChargers;
        private ToolCollection socketTools;
        private ToolCollection braking;
        private ToolCollection driveTrain;



        public ToolCollection ToolCollection { get { return toolCollection; } set { toolCollection = value; } }

        public ToolCollection[] ToolCollections
        {
            get
            {
                return
                new ToolCollection[] {
                lineTrimmers,
                lawnMowers,
                gardenHandTools,
                wheelBarrows,
                gardenPowerTools,
                scrapers,
                floorLasers,
                floorLevellingTools,
                floorLevellingMaterion,
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
                temperatureAndHumidiection,
                messuringLevellingToon,
                markers,
                draning,
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
            }
        }

        public ToolLibrarySystem()
        {
        }


        public void add(Tool aTool)
        {
            toolCollection.add(aTool);
            aTool.Quantity++;
        }

        public void add(Tool aTool, int quantity)
        {
            toolCollection.add(aTool);
            aTool.Quantity += quantity;
        }

        public void add(Member aMember)
        {
            members.add(aMember);
        }

        public void borrowTool(Member aMember, Tool aTool)
        {
            if (aTool.AvailableQuantity > 0)
            {
                aMember.addTool(aTool);
                aTool.addBorrower(aMember);
            }
            else
            {
                Console.WriteLine("Tool unavailable, please come back later");
            }
        }

        public void delete(Tool aTool)
        {
            toolCollection.delete(aTool);
        }

        public void delete(Tool aTool, int quantity)
        {
            aTool.AvailableQuantity -= quantity;
            if (aTool.AvailableQuantity < 0)
            {
                aTool.AvailableQuantity += quantity;
                Console.WriteLine("Cannot delete " + quantity + " pieces of tool");
            }
        }

        public void delete(Member member)
        {
            members.delete(member);
        }


        public void displayTools(string aToolType)
        {
            for (int i = 0; i < toolCollections.Length; i++) {
                if (toolCollections[i].Name == aToolType) {
                    for (int j = 0; j < toolCollections[i].toArray().Length; i++) {
                        if (toolCollections[i].toArray()[j] != null) {
                            Console.WriteLine(toolCollections[i].toArray()[j].Name);
                        }
                    }
                    break;
                }
            }
        }


        private Tool findMaxBorrowing(List<Tool> tools) {

            int numOfBoroowings = 0;
            Tool result = null;
            for (int i = 0; i < tools.Count; i++)
            {
                if (tools[i].NoBorrowings > numOfBoroowings) {
                    numOfBoroowings = tools[i].NoBorrowings;
                    result = tools[i];
                    tools.RemoveAt(i); // remove the top borrowing tool
                }
            }
            return result;
        }

        public void displayTopTHree()
        {
            List<Tool> allTools = new List<Tool>();
            for (int i = 0; i < toolCollections.Length; i++) {
                for (int j = 0; j < toolCollections[i].toArray().Length; j++) {
                    allTools.Add(toolCollections[i].toArray()[j]);
                }
            }

            Tool top = null;
            for (int i = 0; i < 3; i++) {
                top = findMaxBorrowing(allTools);
                Console.WriteLine(top.Name);
            }


        }

        public string[] listTools(Member aMember)
        {
            return aMember.Tools;
        }

        public void returnTool(Member aMember, Tool aTool)
        {
            aMember.deleteTool(aTool);
            aTool.deleteBorrower(aMember);
        }

        public void displayBorrowingTools(Member aMember)
        {
            string[] borrowingTools = aMember.Tools;
            for (int i = 0; i < borrowingTools.Length; i++) {
                if (borrowingTools[i] != null) {
                    Console.WriteLine(borrowingTools[i]);
                }
            }
        }
    }
}
