using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using static Terraria.ModLoader.ModContent;

namespace SimpleDisplayClock
{
	public class SimpleDisplayClock : Mod
	{
		private GameTime _lastUpdateUiGameTime;
		
		internal UserInterface clockInterface;
		internal SdClockUi clockUi;
		
		public SimpleDisplayClock()
		{
			
		}
		
		public override void Load() 
		{
			if (!Main.dedServ)
			{
				clockInterface = new UserInterface();
    
				clockUi = new SdClockUi();
				clockUi.Activate();
				
				ShowClockUI();
			}	
		}
		
		public override void Unload() 
		{
			clockUi = null;
		}
		
		public override void UpdateUI(GameTime gameTime)
		{
			_lastUpdateUiGameTime = gameTime;

			if (clockInterface?.CurrentState != null)
			{
				clockInterface.Update(gameTime);
			}
		}
		
		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (mouseTextIndex != -1)
			{
				layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
					"SimpleDisplayClock: clockInterface",
					delegate
					{
						if ( _lastUpdateUiGameTime != null && clockInterface?.CurrentState != null)
						{
							clockInterface.Draw(Main.spriteBatch, _lastUpdateUiGameTime);
						}
						return true;
					},
					InterfaceScaleType.UI));
			}
		}
		
		internal void ShowClockUI()
		{
			clockInterface?.SetState(clockUi);
		}

		internal void HideClockUI()
		{
			clockInterface?.SetState(null);
		}
	}
}
