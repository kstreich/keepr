
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Vault
  {
    [Required]
    public string Title { get; set; }

    public string Description { get; set; }

  }
}