using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace AdvancedGodVanish
{
	public class CommandGod : IRocketCommand
	{
		public string directory = Directory.GetCurrentDirectory() + "/..";

		public AllowedCaller AllowedCaller => AllowedCaller.Player;

		public string Name => "God";

		public string Help => "Toggle godmode";

		public string Syntax => string.Empty;

		public List<string> Aliases => new List<string>();

		public List<string> Permissions
		{
			get
			{
				List<string> list = new List<string>();
				list.Add("God");
				return list;
			}
		}

		public void Execute(IRocketPlayer caller, string[] command)
		{
			
			UnturnedPlayer unturnedPlayer = (UnturnedPlayer)caller;
			if (unturnedPlayer.Features.GodMode)
			{
				unturnedPlayer.Features.GodMode = false;
				Logger.LogWarning(unturnedPlayer.CharacterName + AdvancedGodVanish.Instance.Translate("god_off_console"));
				UnturnedChat.Say(caller, AdvancedGodVanish.Instance.Translate("God_off_Private"), UnturnedChat.GetColorFromName(AdvancedGodVanish.Instance.Configuration.Instance.GodOffPrivateColor, Color.red));
				if (AdvancedGodVanish.Instance.Configuration.Instance.AnnouncerEnabled)
				{
					UnturnedChat.Say(unturnedPlayer.CharacterName + AdvancedGodVanish.Instance.Translate("God_off_Public"), UnturnedChat.GetColorFromName(AdvancedGodVanish.Instance.Configuration.Instance.GodOffPublicColor, Color.red));
					if (AdvancedGodVanish.Instance.Configuration.Instance.LoggingEnabled)
					{
						using (StreamWriter streamWriter = File.AppendText(directory + "/GodVanishLog.txt"))
						{
							streamWriter.WriteLine("[God]" + unturnedPlayer.CharacterName + "[" + unturnedPlayer.DisplayName + "]" + AdvancedGodVanish.Instance.Translate("god_off_console") + " Steam64ID: " + unturnedPlayer.CSteamID + streamWriter.NewLine);
							streamWriter.Close();
						}
					}
				}
				return;
			}
			unturnedPlayer.Features.GodMode = true;
			Logger.LogWarning(unturnedPlayer.CharacterName + AdvancedGodVanish.Instance.Translate("god_on_console"));
			if (AdvancedGodVanish.Instance.Configuration.Instance.AnnouncerEnabled)
			{
				UnturnedChat.Say(unturnedPlayer.CharacterName + AdvancedGodVanish.Instance.Translate("God_on_Public"), UnturnedChat.GetColorFromName(AdvancedGodVanish.Instance.Configuration.Instance.GodOnPublicColor, Color.red));
				UnturnedChat.Say(caller, AdvancedGodVanish.Instance.Translate("God_on_Private"), UnturnedChat.GetColorFromName(AdvancedGodVanish.Instance.Configuration.Instance.GodOnPrivateColor, Color.red));
				if (AdvancedGodVanish.Instance.Configuration.Instance.LoggingEnabled)
				{
					using (StreamWriter streamWriter2 = File.AppendText(directory + "/GodVanishLog.txt"))
					{
						streamWriter2.WriteLine("[God]" + unturnedPlayer.CharacterName + "[" + unturnedPlayer.DisplayName + "]" + AdvancedGodVanish.Instance.Translate("god_on_console") + " Steam64ID: " + unturnedPlayer.CSteamID + streamWriter2.NewLine);
						streamWriter2.Close();
					}
				}
			}
		}
	}
}
