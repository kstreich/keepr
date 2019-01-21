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
    #region 
    //GetAll
    // public IEnumerable<VaultKeep> GetAll()
    // {
    //   return _db.Query<VaultKeep>("SELECT * FROM Keeps");
    // }


    //GetById


    //Get Key By Vault Id
    //Needs to return a list of the keeps
    //then go in an update the controller to reflect what I need
    //iemnuerable
    //vaultkeep table needs data so, do the vault keep post to be able to test it laters
    #endregion
    public IEnumerable<Keep> GetKeepByVaultId(int vaultId, string userId)
    {
      /*
      SELECT * FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId 
      WHERE (vaultId = @vaultId AND vk.userId = @userId) 
       */
      return _db.Query<Keep>(@"
      SELECT * FROM vaultkeeps vk 
      INNER JOIN keeps k ON k.id = vk.keepId
      WHERE (vaultId = @vaultId AND vk.userId = @userId)", new { vaultId, userId });
      //   SELECT* FROM vaultkeeps vk
      // --INNER JOIN keeps k ON k.id = vk.keepId
      // -- WHERE(vaultId = @vaultId AND vk.userId = @userId)
    }

    //AddKeep
    public VaultKeep AddVaultKeep(VaultKeep newVaultKeep)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO VaultKeeps(vaultId, keepId, userId)
      VALUES(@vaultId, @keepId, @userId);
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