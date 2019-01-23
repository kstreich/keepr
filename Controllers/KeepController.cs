using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {
    private readonly KeepRepository _repo;

    public KeepsController(KeepRepository repo)
    {
      _repo = repo;
    }


    // GET all api/values
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      return Ok(_repo.GetAll());
    }


    //GET keeps by the userID
    [HttpGet("user")]
    public ActionResult<IEnumerable<Keep>> GetAll()
    {

      string userId = HttpContext.User.Identity.Name;
      IEnumerable<Keep> result = _repo.GetByUserId(userId);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }



    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Keep> Get(int id)
    {
      Keep result = _repo.GetById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }

    // POST api/values
    [HttpPost]
    public ActionResult<Keep> Post([FromBody] Keep value)
    {
      value.UserId = HttpContext.User.Identity.Name;

      Keep result = _repo.AddKeep(value);

      return Created("/api/keep/" + result.Id, result);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult<Keep> Put(int id, [FromBody] Keep keep)
    {
      Keep result = _repo.EditKeep(id, keep);
      if (result != null)
      {
        return result;
      }
      return NotFound();
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      if (_repo.DeleteKeep(id))
      {
        return Ok("Successfully deleted!");
      }
      return BadRequest("Unable to delete!");
    }
  }
}