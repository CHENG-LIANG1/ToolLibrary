using System;

namespace ToolLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Member member = new Member("Cheng", "Liang", "12423354");
            Tool tool = new Tool("Garden helper", "Gargening Tool");
            ToolCollection gardeningToolCollection = new ToolCollection();
            gardeningToolCollection.add(tool);

            Console.WriteLine(gardeningToolCollection.toolCollection[0].Name);
        }
    }
}
