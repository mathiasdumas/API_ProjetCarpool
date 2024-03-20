using System;
namespace CARPOOL
{
	public class Users
	{
        public int ID_User { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string ProfilePicturePath { get; set; }
        public string Mail { get; set; }
        public int PhoneNumber { get; set; }
        public string Password { get; set; }

        public static int CreateUser(string firstname, string lastname, string mail, int phoneNumber, string password)
        {
            return 1;
        }
	}
}

