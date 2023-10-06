using System;
namespace Jazani.Api.Exceptions
{
	public class ErrorValidationModel : ErrorModel
	{
		public string? FieldName { get; set; }
	}
}

