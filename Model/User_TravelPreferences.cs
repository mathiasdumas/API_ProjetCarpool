using System;
namespace CARPOOL.Model
{
	public class User_TravelPreferences
	{
		public int ID_User { get; set; }
		public User User { get; set; }
		public int ID_TravelPreferences { get; set; }
		public TravelPreferences TravelPreferences { get; set; }

	}
}

