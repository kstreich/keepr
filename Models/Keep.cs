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

    public bool IsPrivate { get; set; }

    public int Views { get; set; }

    public int Shares { get; set; }

    public int Keeps { get; set; }



  }
}