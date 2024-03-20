using System;
using CARPOOL;
using ConnectionString.DTO.Requests;
using ConnectionString.DTO.Responses;
using FastEndpoints;

namespace ConnectionString.Endpoints
{
	public class CreateUserEndpoint : Endpoint<CreateUserRequest, CreateUserResponse>
	{
        public override void Configure()
        {
            Post("/users");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateUserRequest request, CancellationToken ct)
        {
            var idResult = Users.CreateUser(request.Firstname, request.Firstname, request.Mail, request.PhoneNumber, request.Password);
            await SendAsync(new CreateUserResponse { Id = idResult });
        }
    }
}

