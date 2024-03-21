using System;
namespace CARPOOL.Model
{
	public class User_Travel
	{
		public int ID_User { get; set; }
		public Users User { get; set; }
		public int ID_Travel { get; set; }
		public Travel Travel { get; set; }
		public DateTime ReservationDate { get; set; }
		public DateTime ResponseDate { get; set; }
		public bool Agree { get; set; }

	}
}

