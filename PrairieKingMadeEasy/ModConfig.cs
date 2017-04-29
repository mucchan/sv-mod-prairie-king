using StardewModdingAPI;

namespace PrairieKingMadeEasy
{
    public class ModConfig : Config
    {
        /*********
        ** Accessors
        *********/
        public bool AlwaysInvincible { get; set; }
        public bool InfiniteCoins { get; set; }
        public bool InfiniteLives { get; set; }
        public bool RapidFire { get; set; }


        /*********
        ** Public methods
        *********/
        public override T GenerateDefaultConfig<T>()
        {
            this.AlwaysInvincible = false;
            this.InfiniteCoins = false;
            this.InfiniteLives = false;
            this.RapidFire = false;

            return this as T;
        }
    }
}
