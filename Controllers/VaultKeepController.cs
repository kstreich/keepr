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
  public class VaultKeepController : ControllerBase
  {
    private readonly VaultKeepRepository _repo;

    public VaultKeepController(VaultKeepRepository repo)
    {
      _repo = repo;
    }


    // GET api/values
    // [HttpGet]
    // public ActionResult<IEnumerable<VaultKeep>> Get()
    // {
    //   return Ok(_repo.GetAll());
    // }

    //GET api/values/5

    //Get VaultKeeps by the vault id
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Keep>> GetKeepByVaultId(int id)
    {
      var uid = HttpContext.User.Identity.Name;
      var result = _repo.GetKeepByVaultId(id, uid);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }

    [HttpGet("vk")]

    // POST api/values
    [HttpPost]
    public ActionResult<VaultKeep> Post([FromBody] VaultKeep value)
    {
      value.UserId = HttpContext.User.Identity.Name;

      VaultKeep result = _repo.AddVaultKeep(value);

      return Created("/api/vaultkeep/" + result.Id, result);
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
      if (_repo.DeleteVaultKeep(id))
      {
        return Ok("Successfully deleted!");
      }
      return BadRequest("Unable to delete!");
    }
  }
}