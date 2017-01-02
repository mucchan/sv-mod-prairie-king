using StardewModdingAPI;

namespace PrairieKingMadeEasy
{
    public class ModConfig
    {
        public bool alwaysInvincible { get; set; }
        public bool infiniteCoins { get; set; }
        public bool infiniteLives { get; set; }
        public bool rapidFire { get; set; }
		public int fireDelay { get; set; }

		public ModConfig()
        {
            this.alwaysInvincible = false;
            this.infiniteCoins = false;
            this.infiniteLives = false;
            this.rapidFire = false;
			this.fireDelay = 25;
        }
    }
}
