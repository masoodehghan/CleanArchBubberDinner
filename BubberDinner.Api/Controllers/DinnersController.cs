using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.Api.Controllers;

[Route("[controller]")]
public class DinnersController : ApiController
{
    [HttpGet]
    public IActionResult List()
    {
        return Ok(Array.Empty<string>());
    }
}
