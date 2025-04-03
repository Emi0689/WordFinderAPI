using Microsoft.AspNetCore.Mvc;
using WordFinder.Models;
namespace WordFinder.Controllers
{
    [ApiController]
    [Route("api/wordfinder")]
    public class WordFinderController : ControllerBase
    {
        //Only an endpoint proposal
        [HttpPost("findWords")]
        public ActionResult<IEnumerable<string>> FindWords([FromBody] WordFinderRequest request)
        {
            if (request == null || request.Matrix == null || request.WordStream == null)
            {
                return BadRequest("Invalid input");
            }

            WordFinder _wordFinder = new(request.Matrix);
            var result = _wordFinder.Find(request.WordStream);
            return Ok(result);
        }
    }
}
