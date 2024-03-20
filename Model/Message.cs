using System;
namespace CARPOOL.Model
{
	public class Message
	{
		public int ID_Message { get; set; }
		public string MessageImagePath { get; set; }
		public string Content { get; set; }
		public DateTime SendDate { get; set; }
		public DateTime ReceptionDate { get; set; }

	}
}

