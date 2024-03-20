using System;
using ConnectionString.DTO.Requests;
using FastEndpoints;
using FluentValidation;

namespace ConnectionString.Validator
{
	public class CreateUserValidator : Validator<CreateUserRequest>
	{
		//public CreateUserRequestValidator()
		//{
		//	RuleFor(x => x.Firstname)
		//		.NotEmpty().WithMessage("Name cannot be empty")
		//		.MinimumLength(2).WithMessage("Length should be bigger than 2 characters");

		//}
	}
}

