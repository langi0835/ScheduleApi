using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleApi.Models
{

  public class ScheduleInfo
  {
    // PK,自動遞增
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    public string InfoName { get; set; }
    [Required]
    [MaxLength(20)]
    public string Schema { get; set; }
  }

}