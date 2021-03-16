using System;

namespace TheHeistII
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public void PerformSkill(int Bank)
        {
            int NewVaultScore = Bank - SkillLevel;
            Console.WriteLine($"{Name} is picking the lock of the vault. Bank security has been reduced by {SkillLevel}");
            if (NewVaultScore <= 0)
            {
                Console.WriteLine($"{Name} has finished picking the lock!");
            }
        }
    }
}