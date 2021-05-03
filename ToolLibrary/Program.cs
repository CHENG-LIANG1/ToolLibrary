using System;

namespace ToolLibrary
{
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

            memberBST.InOrderTraverse();





            Tool tool = new Tool("Garden helper");
            ToolCollection toolCollection = new ToolCollection();
            toolCollection.add(tool);

            Console.WriteLine(toolCollection.toArray()[0].Name);
        }
    }
}
