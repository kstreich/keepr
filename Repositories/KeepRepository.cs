using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;
using Microsoft.AspNetCore.Http;

namespace keepr.Repositories
{
  public class KeepRepository
  {
    private readonly IDbConnection _db;
    public KeepRepository(IDbConnection db)
    {
      _db = db;

    }
    //GetAll
    public IEnumerable<Keep> GetAll()
    {
      return _db.Query<Keep>("SELECT * FROM Keeps");
    }

    //GetById

    public Keep GetById(int id)
    {
      return _db.QueryFirstOrDefault<Keep>($"SELECT * FROM Keeps WHERE id = @id", new { id });
    }

    //AddKeep
    public Keep AddKeep(Keep newKeep)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO Keeps(name, description, userId, img, isPrivate, views, shares, keeps)
      VALUES(@Name, @Description, @UserId, @Img, @isPrivate, @Views, @Shares, @Keeps);
      SELECT LAST_INSERT_ID();
      ", newKeep);
      newKeep.Id = id;
      return newKeep;
    }

    //DeleteVault
    public bool DeleteKeep(int id)
    {
      int success = _db.Execute(@"DELETE FROM Keeps WHERE id = @id", new { id });
      return success != 0;

    }

    public Keep EditKeep(int id, Keep newKeep)
    {
      {
        return _db.QueryFirstOrDefault<Keep>($@"
       UPDATE keeps SET 
          views = @views,
          shares = @shares,
          keeps = @keeps
          WHERE id = { id };
          SELECT * FROM keeps WHERE id= {id};", newKeep);

      }
    }
  }
}