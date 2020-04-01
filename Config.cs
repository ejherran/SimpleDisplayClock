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
		
		[Label("Use military time format?")]
		[Tooltip("Displays the time in 24-hour format.")]
		[DefaultValue(false)]
		public bool UseMilitary;
		
		public override void OnChanged() 
		{
			SdClockUi.UseDecoration = UseDecoration;
			SdClockUi.UseMilitary = UseMilitary;
		}
	}
	
}

