using System;
using System.Collections.Generic;
using System.Threading;

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
                    Specialty = "Hacker",
                },
                new LockSpecialist()
                {
                    Name = "Alfred Hobbs",
                    SkillLevel = 70,
                    PercentageCut = 80,
                    Specialty = "Lock Specialist",
                },
                new Muscle()
                {
                    Name = "Randy Savage",
                    SkillLevel = 80,
                    PercentageCut = 10,
                    Specialty = "Muscle",
                },
                new Hacker()
                {
                    Name = "Acid Burn",
                    SkillLevel = 80,
                    PercentageCut = 20,
                    Specialty = "Hacker",
                },
                new LockSpecialist()
                {
                    Name = "Harry Houdini",
                    SkillLevel = 65,
                    PercentageCut = 40,
                    Specialty = "Lock Specialist",
                },
                new Muscle()
                {
                    Name = "A.C. Slater",
                    SkillLevel = 20,
                    PercentageCut = 5,
                    Specialty = "Muscle",
                },
            };


            bool enterMembers = true;

            while (enterMembers)
            {
                Console.Clear();
                int rolodexCount = rolodex.Count;
                Console.WriteLine($"Your rolodex currently has {rolodexCount} members in it.");
                Console.Write("Enter the name of a new crew member: ");
                string name = Console.ReadLine();

                if (name == "")
                {
                    break;
                }

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

                if (specialty == 1)
                {
                    rolodex.Add(new Hacker()
                    {
                        Name = name,
                        SkillLevel = skill,
                        PercentageCut = cut,
                        Specialty = "Hacker",
                    });
                }
                else if (specialty == 2)
                {
                    rolodex.Add(new Muscle()
                    {
                        Name = name,
                        SkillLevel = skill,
                        PercentageCut = cut,
                        Specialty = "Muscle",
                    });
                }
                else
                {
                    rolodex.Add(new LockSpecialist()
                    {
                        Name = name,
                        SkillLevel = skill,
                        PercentageCut = cut,
                        Specialty = "Lock Specialist",
                    });
                }
            }

            Bank theBank = new Bank()
            {
                AlarmScore = new Random().Next(0, 100),
                VaultScore = new Random().Next(0, 100),
                SecurityGuardScore = new Random().Next(0, 100),
                CashOnHand = new Random().Next(50000, 1000000),
            };

            string mostSecure = "Most Secure: ";
            string leastSecure = "Least Secure: ";

            if (theBank.AlarmScore > theBank.VaultScore && theBank.AlarmScore > theBank.SecurityGuardScore)
            {
                mostSecure += "Alarm";
            }
            else if (theBank.VaultScore > theBank.AlarmScore && theBank.VaultScore > theBank.SecurityGuardScore)
            {
                mostSecure += "Vault";
            }
            else
            {
                mostSecure += "Guards";
            }


            if (theBank.AlarmScore < theBank.VaultScore && theBank.AlarmScore < theBank.SecurityGuardScore)
            {
                leastSecure += "Alarm";
            }
            else if (theBank.VaultScore < theBank.AlarmScore && theBank.VaultScore < theBank.SecurityGuardScore)
            {
                leastSecure += "Vault";
            }
            else
            {
                leastSecure += "Guards";
            }

            Console.WriteLine("<-------Recon report------->");
            Console.WriteLine($"{mostSecure}");
            Console.WriteLine($"{leastSecure}");
            Console.WriteLine("<-------------------------->");


            List<IRobber> crew = new List<IRobber>();
            bool addingCrew = true;
            int cutLeft = 100;

            while (addingCrew)
            {
                int choice = 0;
                int index = 0;
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("<------ Rolodex Info ");
                Console.WriteLine($"<------ Cut Left: {cutLeft}");


                foreach (var contact in rolodex)
                {
                    index++;
                    Console.WriteLine($"{index}. {contact.Name} specializes in {contact.Specialty} with a skill level of {contact.SkillLevel}. They want a {contact.PercentageCut}% cut for the job.");
                }

                Console.Write($"Choose a crew member to add to your crew: [1-{rolodex.Count}] ");
                string answer = Console.ReadLine();

                if (answer == "")
                {
                    break;
                }

                choice = Int32.Parse(answer) - 1;

                cutLeft -= rolodex[choice].PercentageCut;

                if (cutLeft >= 0)
                {
                    crew.Add(rolodex[choice]);
                    rolodex.Remove(rolodex[choice]);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine($"We don't have enough of the cut left to hire {rolodex[choice].Name}");

                    cutLeft += rolodex[choice].PercentageCut;
                    Thread.Sleep(2000);
                }
            }


            foreach (var member in crew)
            {
                if (member.Specialty == "Hacker")
                {
                    theBank.AlarmScore -= member.SkillLevel;
                }
                else if (member.Specialty == "Muscle")
                {
                    theBank.SecurityGuardScore -= member.SkillLevel;
                }
                else
                {
                    theBank.VaultScore -= member.SkillLevel;
                }
            }

            if (theBank.IsSecure)
            {
                Console.WriteLine("You failed!");
            }
            else
            {
                Console.WriteLine("You win!");
                Console.WriteLine("");
                Console.WriteLine($"Total Stolen: ${theBank.CashOnHand}");
                Console.WriteLine("");

                foreach (var member in crew)
                {
                    Console.WriteLine($"{member.Name} took home ${theBank.CashOnHand / 100 * member.PercentageCut}");
                }

                Console.WriteLine($"You took home ${theBank.CashOnHand / 100 * cutLeft}");
            }
        }
    }
}
