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
  public class VaultsController : ControllerBase
  {
    private readonly VaultRepository _repo;

    public VaultsController(VaultRepository repo)
    {
      _repo = repo;
    }


    // GETs all vaults api/values
    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      return Ok(_repo.GetAll());
    }

    [HttpGet("user/{userId}")]
    public ActionResult<IEnumerable<Vault>> GetAction(string userId)
    {
      IEnumerable<Vault> result = _repo.GetByUserId(userId);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
    {
      Vault result = _repo.GetById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }

    // POST api/values
    [HttpPost]
    public ActionResult<Vault> Post([FromBody] Vault value)
    {
      value.UserId = HttpContext.User.Identity.Name;

      Vault result = _repo.AddVault(value);

      return Created("/api/vault/" + result.Id, result);
    }

    // PUT api/values/5
    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody] string value)
    // {
    // }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      if (_repo.DeleteVault(id))
      {
        return Ok("Successfully deleted!");
      }
      return BadRequest("Unable to delete!");
    }
  }
}