namespace TheHeistII
{
    public interface IRobber
    {
        string Name { get; set; }
        int SkillLevel { get; set; }
        int PercentageCut { get; set; }

        string Specialty { get; set; }

        void PerformSkill(int bank);
    }
}