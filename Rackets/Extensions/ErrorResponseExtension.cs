using Microsoft.AspNetCore.Mvc;

namespace Rackets.Extensions;

public static class ErrorResponseExtension
{
    public static ObjectResult NotFoundProblem(this ControllerBase controller, string detail)
    {
        return controller.Problem(
            detail: detail,
            statusCode: StatusCodes.Status404NotFound,
            title: "Resource not found",
            type: "https://httpstatuses.com/404"
        );
    }
}