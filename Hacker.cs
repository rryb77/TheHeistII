using System;

namespace TheHeistII
{
    public class Hacker : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public void PerformSkill(int Bank)
        {
            int NewAlarmScore = Bank - SkillLevel;
            Console.WriteLine($"{Name} is hacking the alarm system. Bank security has been reduced by {SkillLevel}");
            if (NewAlarmScore <= 0)
            {
                Console.WriteLine($"{Name} has completely disabled the alarm system!");
            }
        }
    }
}