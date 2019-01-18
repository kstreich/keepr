
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Vault
  {
    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    public int Id { get; set; }

    public int IsPrivate { get; set; } = 1;

    public string UserId { get; set; }

  }
}