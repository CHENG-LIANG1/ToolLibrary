using System;

namespace ToolLibrary
{
    // Author: Cheng Liang
    // N10346911
    class Program
    {
        static void Main(string[] args)
        {
            iBSTree memberBST = new MemberCollection();

            Member member01 = new Member("Cheng", "Liang", "12423354", "1234");


            Member member02 = new Member("sdf", "rty", "12423354", "1234");
            Member member03 = new Member("sdf", "tyu", "12423354", "1234");
            Member member04 = new Member("tyu", "tuy", "12423354", "1234");
            Member member05 = new Member("sdf", "uyt", "12423354", "1234");
            Member member06 = new Member("wer", "uyt", "12423354", "1234");
            Member member07 = new Member("sdf", "tuy", "12423354", "1234");
            Member member08 = new Member("Cheng", "uyt", "12423354", "1234");



            memberBST.add(member01);
            memberBST.add(member02);
            memberBST.add(member03);
            memberBST.add(member04);
            memberBST.add(member05);
            memberBST.add(member06);


            Tool tool = new Tool("Garden helper");
            Tool dick = new Tool("Dick cutter");

            ToolCollection toolCollection = new ToolCollection();
            toolCollection.add(tool);
            toolCollection.add(dick);


            int length = toolCollection.toArray().Length;

            for (int i = 0; i < length; i++) {
                Console.WriteLine(toolCollection.toArray()[i].Name);
            }
                
            toolCollection.delete(dick);

             length = toolCollection.toArray().Length;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(toolCollection.toArray()[i].Name);
            }


            tool.addBorrower(member01);

            Console.WriteLine(tool.GetBorrowers.toArray()[0].FirstName);

            member01.addTool(tool);
            Console.WriteLine(member01.Tools[0]);


            Console.WriteLine(memberBST.toArray()[0].FirstName);

            ToolCollection lineTrimmers = new ToolCollection();
            ToolCollection lawnMowers = new ToolCollection();
            ToolCollection gardenHandTools = new ToolCollection();
            ToolCollection wheelBarrows = new ToolCollection();
            ToolCollection gardenPowerTools = new ToolCollection();
            ToolCollection scrapers = new ToolCollection();
            ToolCollection floorLasers = new ToolCollection();
            ToolCollection floorLevellingTools = new ToolCollection();
            ToolCollection floorLevellingMaterials = new ToolCollection();
            ToolCollection floorHandTools = new ToolCollection();
            ToolCollection tilingTools = new ToolCollection();
            ToolCollection fencingHandTools = new ToolCollection();
            ToolCollection electricFencing = new ToolCollection();
            ToolCollection steelFencingTools = new ToolCollection();
            ToolCollection powerTools = new ToolCollection();
            ToolCollection fencingAccessories = new ToolCollection();
            ToolCollection distanceTools = new ToolCollection();
            ToolCollection laserMeature = new ToolCollection();
            ToolCollection measuringJugs = new ToolCollection();
            ToolCollection temperatureAndHumidityTools = new ToolCollection();
            ToolCollection messuringLevellingTools = new ToolCollection();
            ToolCollection markers = new ToolCollection();
            ToolCollection draning = new ToolCollection();
            ToolCollection carCleaning = new ToolCollection();
            ToolCollection vacuum = new ToolCollection();
            ToolCollection pressureCleaners = new ToolCollection();
            ToolCollection poolCleaning = new ToolCollection();
            ToolCollection floorCleaning = new ToolCollection();
            ToolCollection sandingTools = new ToolCollection();
            ToolCollection brushes = new ToolCollection();
            ToolCollection rollers = new ToolCollection();
            ToolCollection paintRemovalTools = new ToolCollection();
            ToolCollection paintScrapers = new ToolCollection();
            ToolCollection sprayers = new ToolCollection();
            ToolCollection voltageTester = new ToolCollection();
            ToolCollection oscilloscopes = new ToolCollection();
            ToolCollection thermalImaging = new ToolCollection();
            ToolCollection dataTestTool = new ToolCollection();
            ToolCollection insulationTesters = new ToolCollection();
            ToolCollection testEquipment = new ToolCollection();
            ToolCollection safetyEquipment = new ToolCollection();
            ToolCollection basicHandTools = new ToolCollection();
            ToolCollection circuitProtection = new ToolCollection();
            ToolCollection cableTools = new ToolCollection();
            ToolCollection jacks = new ToolCollection();
            ToolCollection airCompressors = new ToolCollection();
            ToolCollection batteryChargers = new ToolCollection();
            ToolCollection socketTools = new ToolCollection();
            ToolCollection braking = new ToolCollection();
            ToolCollection driveTrain = new ToolCollection();




        }
    }
}
