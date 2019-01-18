using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Keep
  {
    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    public int Likes { get; set; }

    public int Views { get; set; }
  }
}