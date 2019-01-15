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
            helper.Events.GameLoop.UpdateTicked += this.OnUpdateTicked;
        }


        /*********
        ** Private methods
        *********/
        /// <summary>Raised after the game state is updated (≈60 times per second).</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void OnUpdateTicked(object sender, UpdateTickedEventArgs e)
        {
            Type minigameType = Game1.currentMinigame?.GetType();
            if (minigameType?.Name != "AbigailGame")
                return;

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
