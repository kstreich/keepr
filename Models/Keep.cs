using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Keep
  {
    [Required]
    public string Name { get; set; }

    public int Id { get; set; }

    public string Description { get; set; }

    public string UserId { get; set; }

    public string Img { get; set; }

    public int IsPrivate { get; set; } = 1;

    public int Views { get; set; } = 0;

    public int Shares { get; set; } = 0;

    public int Keeps { get; set; } = 0;



  }
}