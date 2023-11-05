namespace Lib.Models;

public interface IHasConcurrencyStamp
{
    public Guid ConcurrencyStamp { get; set; }
}