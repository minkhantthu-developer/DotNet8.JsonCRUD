namespace DotNet8.JsonCRUD.WebApi.Enums;

public enum EnumStatusCode
{
    None,
    Success = 200,
    Create = 201,
    Accepted = 202,
    BadRequest = 400,
    NotFound = 404,
    Conflict = 409,
    Lock = 423,
    InternalServerError = 500
}
