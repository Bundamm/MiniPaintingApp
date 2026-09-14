using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniPaintingApp.Models;

public class PaintModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long PaintId{ get; set; }
    
    public string? Name { get; set; }
    
    public string? Brand { get; set; }
    
    public string? Line { get; set; }
    
    public byte Red { get; set; }
    
    public byte Green { get; set; }
    
    public byte Blue { get; set; }
    
    public byte Alpha { get; set; }
    
}
