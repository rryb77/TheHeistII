using System;
using System.Collections.Generic;

namespace TheHeistII
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IRobber> rolodex = new List<IRobber>()
            {
                new Hacker()
                {
                    Name = "Zero Cool",
                    SkillLevel = 60,
                    PercentageCut = 20,
                },
                new LockSpecialist()
                {
                    Name = "Alfred Hobbs",
                    SkillLevel = 70,
                    PercentageCut = 40,
                },
                new Muscle()
                {
                    Name = "Randy Savage",
                    SkillLevel = 80,
                    PercentageCut = 10,
                },
                new Hacker()
                {
                    Name = "Acid Burn",
                    SkillLevel = 80,
                    PercentageCut = 20,
                },
                new LockSpecialist()
                {
                    Name = "Harry Houdini",
                    SkillLevel = 65,
                    PercentageCut = 30,
                },
                new Muscle()
                {
                    Name = "A.C. Slater",
                    SkillLevel = 20,
                    PercentageCut = 5,
                },
            };

            int rolodexCount = rolodex.Count;
            Console.WriteLine($"Your rolodex currently has {rolodexCount} members in it.");
            bool enterMembers = true;

            while (enterMembers)
            {
                Console.Write("Enter the name of a new crew member: ");
                string name = Console.ReadLine();
                Console.WriteLine($"What specialty does {name} have?");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("| 1. Hacker (Disabled Alarms)       |");
                Console.WriteLine("| 2. Muscle (Disarms Guards)        |");
                Console.WriteLine("| 3. Lock Specialists (Cracks Vault)|");
                Console.WriteLine("-------------------------------------");
                Console.Write("> ");
                int specialty = Int32.Parse(Console.ReadLine());
                Console.Write($"What skill level does {name} have? (1-100): ");
                int skill = Int32.Parse(Console.ReadLine());
                Console.Write($"What percentage of the cut does {name} want? (1-100): ");
                int cut = Int32.Parse(Console.ReadLine());
            }
        }

    }
}
