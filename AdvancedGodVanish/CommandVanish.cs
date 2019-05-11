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
	public class CommandVanish : IRocketCommand
	{
		public string directory = Directory.GetCurrentDirectory() + "/..";

		public AllowedCaller AllowedCaller => AllowedCaller.Player;

		public string Name => "vanish";

		public string Help => "Toggle vanish mode";

		public string Syntax => string.Empty;

		public List<string> Aliases => new List<string>();

		public List<string> Permissions
		{
			get
			{
				List<string> list = new List<string>();
				list.Add("vanish");
				return list;
			}
		}

		public void Execute(IRocketPlayer caller, string[] command)
		{
			
			UnturnedPlayer unturnedPlayer = (UnturnedPlayer)caller;
			if (unturnedPlayer.Features.VanishMode)
			{
				unturnedPlayer.Features.VanishMode = false;
				Logger.Log(unturnedPlayer.CharacterName + AdvancedGodVanish.Instance.Translate("vanish_off_console"));
				UnturnedChat.Say(caller, AdvancedGodVanish.Instance.Translate("Vanish_off_Private"), UnturnedChat.GetColorFromName(AdvancedGodVanish.Instance.Configuration.Instance.VanishOffPrivateColor, Color.red));
				if (AdvancedGodVanish.Instance.Configuration.Instance.AnnouncerEnabled)
				{
					UnturnedChat.Say(unturnedPlayer.CharacterName + AdvancedGodVanish.Instance.Translate("Vanish_off_Public"), UnturnedChat.GetColorFromName(AdvancedGodVanish.Instance.Configuration.Instance.VanishOffPublicColor, Color.red));
					if (AdvancedGodVanish.Instance.Configuration.Instance.LoggingEnabled)
					{
						using (StreamWriter streamWriter = File.AppendText(directory + "/GodVanishLog.txt"))
						{
							streamWriter.WriteLine("[Vanish]player.CharacterName[" + unturnedPlayer.DisplayName + "]" + AdvancedGodVanish.Instance.Translate("vanish_off_console") + " Steam64ID: " + unturnedPlayer.CSteamID + streamWriter.NewLine);
							streamWriter.Close();
						}
					}
				}
				return;
			}
			unturnedPlayer.Features.VanishMode = true;
			Logger.LogWarning(unturnedPlayer.CharacterName + AdvancedGodVanish.Instance.Translate("vanish_on_console"));
			if (AdvancedGodVanish.Instance.Configuration.Instance.AnnouncerEnabled)
			{
				UnturnedChat.Say(unturnedPlayer.CharacterName + AdvancedGodVanish.Instance.Translate("Vanish_on_Public"), UnturnedChat.GetColorFromName(AdvancedGodVanish.Instance.Configuration.Instance.VanishOnPublicColor, Color.red));
				UnturnedChat.Say(caller, AdvancedGodVanish.Instance.Translate("Vanish_on_Private"), UnturnedChat.GetColorFromName(AdvancedGodVanish.Instance.Configuration.Instance.VanishOnPrivateColor, Color.red));
				if (AdvancedGodVanish.Instance.Configuration.Instance.LoggingEnabled)
				{
					using (StreamWriter streamWriter2 = File.AppendText(directory + "/GodVanishLog.txt"))
					{
						streamWriter2.WriteLine("[Vanish]" + unturnedPlayer.CharacterName + "[" + unturnedPlayer.DisplayName + "]" + AdvancedGodVanish.Instance.Translate("vanish_on_console") + " Steam64ID: " + unturnedPlayer.CSteamID + streamWriter2.NewLine);
						streamWriter2.Close();
					}
				}
			}
		}
	}
}
