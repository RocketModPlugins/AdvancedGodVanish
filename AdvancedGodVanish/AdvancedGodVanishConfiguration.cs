using Rocket.API;

namespace AdvancedGodVanish
{
	public class AdvancedGodVanishConfiguration : IRocketPluginConfiguration, IDefaultable
	{
		public bool Enabled;

		public bool AnnouncerEnabled;

		public bool RemoteAnnouncerEnabled;

		public bool LoggingEnabled;

		public string VanishOffPrivateColor;

		public string VanishOffPublicColor;

		public string VanishOnPublicColor;

		public string VanishOnPrivateColor;

		public string GodOffPrivateColor;

		public string GodOffPublicColor;

		public string GodOnPublicColor;

		public string GodOnPrivateColor;

		public string YourGodModeTurnedOffColor;

		public string YourGodModeTurnedOnColor;

		public string playersgodmodeturnedonColor;

		public string playersgodmodeturnedoffColor;

		public string playersvanishmodeturnedonColor;

		public string playersvanishmodeturnedoffColor;

		public string YourVanishModeTurnedOffColor;

		public string YourVanishModeTurnedOnColor;

		public string globalplayersvanishmodeturnedoffColor;

		public string globalplayersvanishmodeturnedonColor;

		public string UsageColor;

		public string PlayerNotFoundColor;

		public void LoadDefaults()
		{
			Enabled = true;
			LoggingEnabled = true;
			AnnouncerEnabled = true;
			RemoteAnnouncerEnabled = false;
			VanishOffPrivateColor = "red";
			VanishOffPublicColor = "white";
			VanishOnPublicColor = "yellow";
			VanishOnPrivateColor = "green";
			GodOffPrivateColor = "cyan";
			GodOffPublicColor = "white";
			GodOnPublicColor = "blue";
			GodOnPrivateColor = "gray";
			YourGodModeTurnedOffColor = "yellow";
			YourGodModeTurnedOnColor = "blue";
			YourVanishModeTurnedOffColor = "green";
			YourVanishModeTurnedOnColor = "cyan";
			playersvanishmodeturnedoffColor = "red";
			playersvanishmodeturnedonColor = "yellow";
			playersgodmodeturnedoffColor = "blue";
			playersgodmodeturnedonColor = "green";
			globalplayersvanishmodeturnedoffColor = "red";
			globalplayersvanishmodeturnedonColor = "blue";
			UsageColor = "yellow";
			PlayerNotFoundColor = "red";
		}
	}
}
