using System;
namespace CARPOOL.Model
{
	public class User_Reward
	{
		public string ID_User { get; set; }
		public User User { get; set; }
		public int ID_Reward { get; set; }
		public Reward Reward { get; set; }
		public DateTime ObtainedRewardDate { get; set; }

	}
}

