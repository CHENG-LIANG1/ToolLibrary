using System;

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
            UserInterface.ProcessMainMenu(mainMenuChoice, toolSystem);

  




        }
    }
}
