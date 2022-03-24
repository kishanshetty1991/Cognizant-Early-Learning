//Be Aware I have used Linq library which wasn't provided by default
using System;
using System.Collections.Generic;
using System.Linq;

namespace BallsBowled        //DO NOT change the namespace name
{
    public class Program    //DO NOT change the class name
    {
        static void Main(string[] args)
        {
            //Implement code here  
            Console.WriteLine("Enter the number of overs");
            int oversBowled = int.Parse(Console.ReadLine());
            PlayerBO pb = new PlayerBO();
            pb.AddOversDetails(oversBowled);
            Console.ReadKey();
        }
    }

    public class PlayerBO      //DO NOT change the class name
    {
        public List<int> PlayerList { get; set; } = new List<int>();
        // PlayerList.Add(1);

        public void AddOversDetails(int oversBowled)       //DO NOT change the method signature
        {
            //Implement code here
            PlayerList.Add(oversBowled);
            int x = GetNoOfBallsBowled();
            Console.WriteLine("Balls Bowled : {0}", x);
        }

        public int GetNoOfBallsBowled()              //DO NOT change the method signature
        {
            //Implement code here
            int x = PlayerList.LastOrDefault();
            return x * 6;
        }


    }
}
