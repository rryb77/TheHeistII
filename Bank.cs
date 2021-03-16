namespace TheHeistII
{
    public class Bank
    {
        public int CashOnHand { get; set; }
        public int AlarmScore { get; set; }
        public int VaultScore { get; set; }
        public int SecurityGuardScore { get; set; }
        public bool IsSecure
        {
            get
            {
                int TotalScore = AlarmScore + VaultScore + SecurityGuardScore;
                if (TotalScore > 0)
                {
                    return true;
                }

                return false;
            }
        }

    }
}