using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace AdvancedGodVanish
{
	public class CommandRemoteGod : IRocketCommand
	{
		public string directory = Directory.GetCurrentDirectory() + "/..";

		public AllowedCaller AllowedCaller => AllowedCaller.Player;

		public string Name => "remotegod";

		public string Help => "Remotely toggle the given player's godmode";

		public string Syntax => "<Player>";

		public List<string> Aliases => new List<string>();

		public List<string> Permissions
		{
			get
			{
				List<string> list = new List<string>();
				list.Add("remotegod");
				return list;
			}
		}

		public void Execute(IRocketPlayer caller, string[] command)
		{
			
			UnturnedPlayer unturnedPlayer = UnturnedPlayer.FromName(command[0]);
			UnturnedPlayer unturnedPlayer2 = (UnturnedPlayer)caller;
			if (command.Length == 0)
			{
				UnturnedChat.Say(caller, AdvancedGodVanish.Instance.Translate("usage_remotevanish"));
			}
			if (unturnedPlayer == null)
			{
				AdvancedGodVanish.Instance.Translate("player_not_found");
				UnturnedChat.GetColorFromName(AdvancedGodVanish.Instance.Configuration.Instance.PlayerNotFoundColor, Color.red);
			}
			if (unturnedPlayer.GodMode)
			{
				unturnedPlayer.Features.GodMode = false;
				UnturnedChat.Say(unturnedPlayer, AdvancedGodVanish.Instance.Translate("your_godmode_turned_off"), UnturnedChat.GetColorFromName(AdvancedGodVanish.Instance.Configuration.Instance.YourGodModeTurnedOffColor, Color.red));
				UnturnedChat.Say(caller, AdvancedGodVanish.Instance.Translate("players_godmode_turned_off") + unturnedPlayer.DisplayName, UnturnedChat.GetColorFromName(AdvancedGodVanish.Instance.Configuration.Instance.playersgodmodeturnedoffColor, Color.red));
				if (AdvancedGodVanish.Instance.Configuration.Instance.RemoteAnnouncerEnabled)
				{
					UnturnedChat.Say(caller.DisplayName + AdvancedGodVanish.Instance.Translate("global_players_godmode_turned_off") + unturnedPlayer.DisplayName, UnturnedChat.GetColorFromName(AdvancedGodVanish.Instance.Configuration.Instance.globalplayersvanishmodeturnedoffColor, Color.red));
					if (AdvancedGodVanish.Instance.Configuration.Instance.LoggingEnabled)
					{
						using (StreamWriter streamWriter = File.AppendText(directory + "/GodVanishLog.txt"))
						{
							streamWriter.WriteLine("[RemoteGod]" + caller.DisplayName + AdvancedGodVanish.Instance.Translate("Log_God_Turned_Off") + streamWriter.NewLine);
							streamWriter.Close();
						}
					}
				}
				return;
			}
			unturnedPlayer.Features.GodMode = true;
			UnturnedChat.Say(unturnedPlayer, AdvancedGodVanish.Instance.Translate("your_godmode_turned_on"), UnturnedChat.GetColorFromName(AdvancedGodVanish.Instance.Configuration.Instance.YourGodModeTurnedOnColor, Color.red));
			UnturnedChat.Say(caller, AdvancedGodVanish.Instance.Translate("players_godmode_turned_on") + unturnedPlayer.DisplayName, UnturnedChat.GetColorFromName(AdvancedGodVanish.Instance.Configuration.Instance.playersgodmodeturnedonColor, Color.red));
			if (AdvancedGodVanish.Instance.Configuration.Instance.RemoteAnnouncerEnabled)
			{
				UnturnedChat.Say(caller.DisplayName + AdvancedGodVanish.Instance.Translate("global_players_godmode_turned_on") + unturnedPlayer.DisplayName, UnturnedChat.GetColorFromName(AdvancedGodVanish.Instance.Configuration.Instance.globalplayersvanishmodeturnedonColor, Color.red));
				if (AdvancedGodVanish.Instance.Configuration.Instance.LoggingEnabled)
				{
					using (StreamWriter streamWriter2 = File.AppendText(directory + "/GodVanishLog.txt"))
					{
						streamWriter2.WriteLine("[RemoteGod]" + caller.DisplayName + AdvancedGodVanish.Instance.Translate("Log_God_Turned_On") + unturnedPlayer.DisplayName + streamWriter2.NewLine);
						streamWriter2.Close();
					}
				}
			}
		}
	}
}
