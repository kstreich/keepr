using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;
using Microsoft.AspNetCore.Http;

namespace keepr.Repositories
{
  public class VaultKeepRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepRepository(IDbConnection db)
    {
      _db = db;

    }
    //GetAll
    public IEnumerable<VaultKeep> GetAll()
    {
      return _db.Query<VaultKeep>("SELECT * FROM VaultKeeps");
    }

    //GetById

    public VaultKeep GetById(int id)
    {
      return _db.QueryFirstOrDefault<VaultKeep>($"SELECT * FROM VaultKeeps WHERE id = @id", new { id });
    }

    //AddKeep
    public VaultKeep AddVaultKeep(VaultKeep newVaultKeep)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO VaultKeeps()
      VALUES();
      SELECT LAST_INSERT_ID();
      ", newVaultKeep);
      newVaultKeep.Id = id;
      return newVaultKeep;
    }

    //DeleteVault
    public bool DeleteVaultKeep(int id)
    {
      int success = _db.Execute(@"DELETE FROM VaultKeeps WHERE id = @id", new { id });
      return success != 0;

    }
  }
}