using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace AdvancedGodVanish
{
	public class CommandRemoteVanish : IRocketCommand
	{
		public string directory = Directory.GetCurrentDirectory() + "/..";

		public AllowedCaller AllowedCaller => AllowedCaller.Player;

		public string Name => "remotevanish";

		public string Help => "Remotely toggle the given player's vanish";

		public string Syntax => "<Player>";

		public List<string> Aliases => new List<string>();

		public List<string> Permissions
		{
			get
			{
				List<string> list = new List<string>();
				list.Add("remotevanish");
				return list;
			}
		}

		public void Execute(IRocketPlayer caller, string[] command)
		{
			
			if (command.Length == 0)
			{
				UnturnedChat.Say(caller, AdvancedGodVanish.Instance.Translate("usage_remotevanish"));
			}
			UnturnedPlayer unturnedPlayer = UnturnedPlayer.FromName(command[0]);
			if (unturnedPlayer == null)
			{
				AdvancedGodVanish.Instance.Translate("player_not_found");
				UnturnedChat.GetColorFromName(AdvancedGodVanish.Instance.Configuration.Instance.PlayerNotFoundColor, Color.red);
			}
			unturnedPlayer.Features.VanishMode = false;
			if (unturnedPlayer.VanishMode)
			{
				UnturnedChat.Say(unturnedPlayer, AdvancedGodVanish.Instance.Translate("your_vanishmode_turned_off"), UnturnedChat.GetColorFromName(AdvancedGodVanish.Instance.Configuration.Instance.YourVanishModeTurnedOffColor, Color.red));
				UnturnedChat.Say(caller, AdvancedGodVanish.Instance.Translate("players_vanishmode_turned_off") + unturnedPlayer.DisplayName, UnturnedChat.GetColorFromName(AdvancedGodVanish.Instance.Configuration.Instance.playersvanishmodeturnedoffColor, Color.red));
				if (AdvancedGodVanish.Instance.Configuration.Instance.RemoteAnnouncerEnabled)
				{
					UnturnedChat.Say(caller.DisplayName + AdvancedGodVanish.Instance.Translate("global_players_vanishmode_turned_off") + unturnedPlayer.DisplayName, UnturnedChat.GetColorFromName(AdvancedGodVanish.Instance.Configuration.Instance.globalplayersvanishmodeturnedoffColor, Color.red));
					if (AdvancedGodVanish.Instance.Configuration.Instance.LoggingEnabled)
					{
						using (StreamWriter streamWriter = File.AppendText(directory + "/GodVanishLog.txt"))
						{
							streamWriter.WriteLine(caller.DisplayName + AdvancedGodVanish.Instance.Translate("Log_Vanish_Turned_On") + unturnedPlayer.DisplayName + streamWriter.NewLine);
							streamWriter.Close();
						}
					}
				}
				return;
			}
			unturnedPlayer.Features.VanishMode = true;
			UnturnedChat.Say(unturnedPlayer, AdvancedGodVanish.Instance.Translate("your_vanishmode_turned_on"), UnturnedChat.GetColorFromName(AdvancedGodVanish.Instance.Configuration.Instance.YourGodModeTurnedOnColor, Color.red));
			UnturnedChat.Say(caller, AdvancedGodVanish.Instance.Translate("players_vanishmode_turned_on") + unturnedPlayer.CharacterName, UnturnedChat.GetColorFromName(AdvancedGodVanish.Instance.Configuration.Instance.playersvanishmodeturnedonColor, Color.red));
			if (AdvancedGodVanish.Instance.Configuration.Instance.RemoteAnnouncerEnabled)
			{
				UnturnedChat.Say(caller.DisplayName + AdvancedGodVanish.Instance.Translate("global_players_vanishmode_turned_on") + unturnedPlayer.DisplayName, UnturnedChat.GetColorFromName(AdvancedGodVanish.Instance.Configuration.Instance.globalplayersvanishmodeturnedonColor, Color.red));
				if (AdvancedGodVanish.Instance.Configuration.Instance.LoggingEnabled)
				{
					using (StreamWriter streamWriter2 = File.AppendText(directory + "/GodVanishLog.txt"))
					{
						streamWriter2.WriteLine(caller.DisplayName + AdvancedGodVanish.Instance.Translate("Log_Vanish_Turned_On") + unturnedPlayer.DisplayName + streamWriter2.NewLine);
						streamWriter2.Close();
					}
				}
			}
		}
	}
}
