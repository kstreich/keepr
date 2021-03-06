using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;
using Microsoft.AspNetCore.Http;

namespace keepr.Repositories
{
  public class VaultRepository
  {
    private readonly IDbConnection _db;
    public VaultRepository(IDbConnection db)
    {
      _db = db;

    }
    //GetAll
    public IEnumerable<Vault> GetAll()
    {
      return _db.Query<Vault>("SELECT * FROM Vaults");
    }

    //GetById

    public Vault GetById(int id)
    {
      return _db.QueryFirstOrDefault<Vault>($"SELECT * FROM Vaults WHERE id = @id", new { id });
    }

    public IEnumerable<Vault> GetByUserId(string id)
    {
      return _db.Query<Vault>($"SELECT * FROM Vaults WHERE userId = @id", new { id });
    }

    //AddVault
    public Vault AddVault(Vault newVault)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO Vaults(name, description, isPrivate, userId)
      VALUES(@Name, @Description, @isPrivate, @UserId);
      SELECT LAST_INSERT_ID();
      ", newVault);
      newVault.Id = id;
      return newVault;
    }

    //DeleteVault
    public bool DeleteVault(int id)
    {
      int success = _db.Execute(@"DELETE FROM Vaults WHERE id = @id", new { id });
      return success != 0;

    }
  }
}