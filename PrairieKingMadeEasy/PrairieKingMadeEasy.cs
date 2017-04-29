using System;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace PrairieKingMadeEasy
{
    public class PrairieKingMadeEasy : Mod
    {
        /*********
        ** Properties
        *********/
        private ModConfig Config;


        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            this.Config = helper.ReadConfig<ModConfig>();
            GameEvents.UpdateTick += this.Event_UpdateTick;
        }


        /*********
        ** Private methods
        *********/
        private void Event_UpdateTick(object sender, EventArgs e)
        {
            if (Game1.currentMinigame == null || Game1.currentMinigame.GetType().Name != "AbigailGame")
                return;

            Type minigameType = Game1.currentMinigame.GetType();

            if (this.Config.InfiniteLives)
                minigameType.GetField("lives").SetValue(Game1.currentMinigame, 99);
            if (this.Config.InfiniteCoins)
                minigameType.GetField("coins").SetValue(Game1.currentMinigame, 99);
            if (this.Config.RapidFire)
                minigameType.GetField("shootingDelay").SetValue(Game1.currentMinigame, 25);
            if (this.Config.AlwaysInvincible)
                minigameType.GetField("playerInvincibleTimer").SetValue(Game1.currentMinigame, 5000);
        }

    }
}
