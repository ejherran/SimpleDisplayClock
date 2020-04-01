using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Terraria.ModLoader.Config;
using Terraria.ID;

namespace SimpleDisplayClock
{
	[Label("SimpleDisplayClock Config")]
	
	public class Config : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;

		[Label("Use decoration?")]
		[Tooltip("Activate icon and frame for the clock.")]
		[DefaultValue(false)]
		[ReloadRequired]
		public bool UseDecoration;
		
		[Label("Use 24-hour format?")]
		[Tooltip("Shows the time in military format, from 00:00 to 23:59.")]
		[DefaultValue(false)]
		public bool UseMilitary;
		
		public override void OnChanged() 
		{
			SdClockUi.UseDecoration = UseDecoration;
			SdClockUi.UseMilitary = UseMilitary;
		}
	}
	
}

