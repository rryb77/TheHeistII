using System;

namespace TheHeistII
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string Specialty { get; set; }

        public void PerformSkill(int Bank)
        {
            int NewSecurityGuardScore = Bank - SkillLevel;
            Console.WriteLine($"{Name} is taking out Security Guards. Bank security has been reduced by {SkillLevel}");
            if (NewSecurityGuardScore <= 0)
            {
                Console.WriteLine($"{Name} has completely wiped out the Security Guard Team!");
            }
        }
    }
}