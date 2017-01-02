using System;
using StardewValley;
using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace PrairieKingMadeEasy
{
	// The mod entry point.
	public class ModEntry : Mod
	{
		private ModConfig Config;
		/*********
        ** Public methods
        *********/
		// Initialise the mod.
		// Provides methods for interacting with the mod directory, such as reading/writing a config file or custom JSON files.
		public override void Entry(IModHelper helper)
		{
			// read file
			this.Config = this.Helper.ReadJsonFile<ModConfig>("config.json") ?? new ModConfig();
			// save file (if needed)
			this.Helper.WriteJsonFile("config.json", this.Config);
			GameEvents.UpdateTick += Event_UpdateTick;
		}

		private void Event_UpdateTick (object sender, EventArgs e)
		{
			if (Game1.currentMinigame != null && "AbigailGame".Equals(Game1.currentMinigame.GetType().Name))
			{
				Type minigameType = Game1.currentMinigame.GetType();

				if (Config.alwaysInvincible)
				{
					minigameType.GetField("playerInvincibleTimer").SetValue(Game1.currentMinigame, 5000);
				}

				if (Config.infiniteCoins)
				{
					minigameType.GetField("coins").SetValue(Game1.currentMinigame, 90);
				}

				if (Config.infiniteLives)
				{
					minigameType.GetField("lives").SetValue(Game1.currentMinigame, 20);
				}

				if (Config.rapidFire)
				{
					minigameType.GetField("shootingDelay").SetValue(Game1.currentMinigame, Config.fireDelay);
				}
			}
		}
	}
}
