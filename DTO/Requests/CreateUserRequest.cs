using System;
namespace ConnectionString.DTO.Requests;

public class CreateUserRequest
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Mail { get; set; }
    public int PhoneNumber { get; set; }
    public string Password { get; set; }
}




