using FastResults.Controllers;
using FastResults.Errors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace devRank.Presentation.Abstractions;

[Authorize]
[ProducesErrorResponseType(typeof(Error))]
[ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
[ProducesResponseType(typeof(Error), StatusCodes.Status401Unauthorized)]
[ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
[ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
public abstract class ApiController(ISender sender) : BaseController
{
}