using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderingSystem.AOProgramming.Sample.Models;

public class ExecutionTimeMetadata
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string MethodName { get; set; } 
    public string DeclaringTime { get; set; }
    public long ExecutionTime { get; set; }
}
