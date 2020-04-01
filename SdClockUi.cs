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
	internal class SdClockUi :  UIState 
	{
		internal UIText header;
		internal UIImage icon;
		internal bool isSun = true;
		public static bool UseDecoration;
		public static bool UseMilitary;
		
		
		public override void OnInitialize()
		{
			if(UseDecoration)
			{
				UIPanel panel = new UIPanel();
				panel.Width.Set(170, 0);
				panel.Height.Set(50, 0);
				panel.HAlign = 0.5f;
				panel.Top.Set(5, 0);
				Append(panel);
				
				icon = new UIImage(ModContent.GetTexture("SimpleDisplayClock/Images/Sun"));
				icon.HAlign = 0.1f;
				icon.VAlign = 0.5f;
				panel.Append(icon);
				
				header = new UIText(""+Main.time);
				header.HAlign = 0.9f;
				header.VAlign = 0.5f;
				panel.Append(header);
			}
			else
			{
				header = new UIText(""+Main.time);
				header.HAlign = 0.5f;
				header.Top.Set(5, 0);
				Append(header);
			}
		}
		
		public override void Update(GameTime gameTime)
		{
			string thtime = "";
			string tmtime = "";
			string tmk = "";
			int btime = 0;
			
			if(!Main.dayTime)
				btime = 54000;
			
			int ctime = (int) (btime +  Main.time);
			
			if(Main.dayTime && !isSun)
			{
				isSun = true;
				icon.SetImage(ModContent.GetTexture("SimpleDisplayClock/Images/Sun"));
			}
			else if(!Main.dayTime && isSun)
			{
				isSun = false;
				icon.SetImage(ModContent.GetTexture("SimpleDisplayClock/Images/Moon"));
			}
			
			int htime = ctime / 3600;
			htime = 4 + htime;
			
			if(htime >= 24)
				htime = htime - 24;
			
			
			int mtime = ctime % 3600;
			mtime = mtime / 60;
			mtime = 30 + mtime;
			
			if(mtime >= 60)
			{
				mtime = mtime - 60;
				htime = htime + 1;
			}
				
			if(!UseMilitary)
			{
				tmk = "A.M.";
				
				if(htime > 12)
				{
					tmk = "P.M.";
					htime = htime-12;
				}
			}
			
			if(htime < 10)
				thtime = "0" + htime;
			else
				thtime = "" + htime;
			
			if(mtime < 10)
				tmtime = "0" + mtime;
			else
				tmtime = "" + mtime;
			
			
			header.SetText(thtime + ":" + tmtime + " " +  tmk);
		}
	}
}
