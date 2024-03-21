using System;
namespace CARPOOL.Model
{
	public class User_TravelPreferences
	{
		public int ID_User { get; set; }
		public Users User { get; set; }
		public int ID_TravelPreferences { get; set; }
		public TravelPreferences TravelPreferences { get; set; }

	}
}

