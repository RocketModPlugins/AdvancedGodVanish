using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System.Collections.Generic;
using System.IO;

namespace AdvancedGodVanish
{
	public class AdvancedGodVanish : RocketPlugin<AdvancedGodVanishConfiguration>
	{
		public static AdvancedGodVanish Instance;

		public string Creator = " educatalan02";

		public string Version = "1.1";

        public static string Discord = "https://discord.gg/Q89FmUk";

        public string SteamContact = "http://steamcommunity.com/id/xXThe_HunterXx";

		public string directory = System.IO.Directory.GetCurrentDirectory() + "/..";

		public override TranslationList DefaultTranslations
		{
			get
			{
				TranslationList translationList = new TranslationList();
				translationList.Add("Log_God_Turned_On", " has turned on the god mode for the player: ");
				translationList.Add("Log_God_Turned_Off", " has turned off the god mode for the player: ");
				translationList.Add("Log_Vanish_Turned_On", " has turned on the vanish mode for the player: ");
				translationList.Add("Log_Vanish_Turned_Off", " has turned off the vanish mode for the player: ");
				translationList.Add("God_on_Public", " has turned on the god mode.");
				translationList.Add("God_off_Public", "  has turned off the god mode.");
				translationList.Add("Vanish_on_Public", " has turned on the vanish mode.");
				translationList.Add("Vanish_off_Public", " has turned off the vanish mode.");
				translationList.Add("God_on_Private", "You have turned on the god mode!");
				translationList.Add("God_off_Private", "You have turned off the god mode!");
				translationList.Add("Vanish_on_Private", "You have turned on the vanish mode!");
				translationList.Add("Vanish_off_Private", "You have turned off the vanish mode!");
				translationList.Add("god_on_console", " has turned on the god mode.");
				translationList.Add("god_off_console", " has turned off the god mode.");
				translationList.Add("vanish_on_console", " has turned on the vanish mode.");
				translationList.Add("vanish_off_console", " has turned off the vanish mode.");
				translationList.Add("players_godmode_turned_on", "God mode turned on for the player:");
				translationList.Add("players_godmode_turned_off", "God mode turned off for the player:");
				translationList.Add("players_vanishmode_turned_on", "Vanish mode turned on for the player:");
				translationList.Add("players_vanishmode_turned_off", "Vanish mode turned off for the player:");
				translationList.Add("your_vanishmode_turned_on", "Your vanish mode has been turned on.");
				translationList.Add("your_vanishmode_turned_off", "Your vanish mode has been turned off.");
				translationList.Add("your_godmode_turned_on", "Your god mode has been turned on.");
				translationList.Add("your_godmode_turned_off", "Your god mode has been turned off.");
				translationList.Add("global_players_godmode_turned_on", " turned on the godmode for the player: ");
				translationList.Add("global_players_godmode_turned_off", "turned off the godmode for the player: ");
				translationList.Add("global_players_vanishmode_turned_on", "turned on the vanishmode for the player: ");
				translationList.Add("global_players_vanishmode_turned_off", "turned off the vanishmode for the player: ");
				translationList.Add("usage_remotegod", "Usage: /RemoteGod");
				translationList.Add("usage_remotevanish", "Usage: /RemoteVanish");
				return translationList;
			}
		}

		protected override void Load()
		{
			Instance = this;
			if (Instance.Configuration.Instance.Enabled)
			{
				Logger.LogWarning("If the plugin is loaded at the first time, you need to restart your server once.");
				Logger.LogWarning("Checking Announcer...");
				Logger.LogWarning("Checking RemoteAnnouncer...");
				Logger.LogWarning("Checking GodVanishLog...");
				if (Instance.Configuration.Instance.AnnouncerEnabled)
				{
					Logger.LogWarning("Announcer Enabled!");
				}
				else
				{
					Logger.LogWarning("Announcer Disabled");
				}
				if (Instance.Configuration.Instance.RemoteAnnouncerEnabled)
				{
					Logger.LogWarning("RemoteAnnouncer Enabled!");
				}
				else
				{
					Logger.LogWarning("RemoteAnnouncer Disabled");
				}
				if (File.Exists(directory + "/GodVanishLog.txt"))
				{
					Logger.Log(directory + "/GodVanishLog.txt already exists. Loopholing the file...");
				}
				else
				{
					File.CreateText(directory + "/GodVanishLog.txt");
				}
				Logger.LogWarning("Plugin loaded");
				Logger.LogWarning("Plugin fixed by " + Creator);
				Logger.LogWarning("Version: " + Assembly.GetName().Version + "  Support: " + Discord);

			}
			else
			{
				base.UnloadPlugin();
				Logger.LogWarning("The plugin is disabled via the config file!");
			}
		}

		protected override void Unload()
		{
			Instance = null;
			if (!Instance.Configuration.Instance.Enabled)
			{
				Logger.LogWarning("Unloading plugin...");
				Logger.LogWarning("Plugin unloaded!");
			}
		}

		public List<UnturnedPlayer> Players()
		{
			List<UnturnedPlayer> list = new List<UnturnedPlayer>();
			foreach (SteamPlayer client in Provider.clients)
			{
				UnturnedPlayer item = UnturnedPlayer.FromSteamPlayer(client);
				list.Add(item);
			}
			return list;
		}
	}
}
