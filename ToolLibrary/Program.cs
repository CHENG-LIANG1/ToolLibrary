﻿using System;
using System.Collections.Generic;

namespace ToolLibrary
{
    // Author:    Cheng Liang
    // Studen ID: N10346911
    class Program
    {
     
        static void Main(string[] args)
        {
            ToolLibrarySystem toolSystem = ToolDatabase.GetToolDatabase();
            string mainMenuChoice = UserInterface.DisplayMainMenu();


            // Dummy members for testing
            Member member01 = new Member("Cheng", "Liang", "17887962464", "1234");
            Member member02 = new Member("Huanyi", "Qian", "17701449052", "1234");
            Member member03 = new Member("Ray", "Wenderlich", "1243536645", "1234");
            Member member04 = new Member("Bruce", "Wayne", "15423424123", "0789");

            toolSystem.add(member01);
            toolSystem.add(member02);
            toolSystem.add(member03);
            toolSystem.add(member04);

            UserInterface.ProcessMainMenu(mainMenuChoice, toolSystem);
        }
    }
}
