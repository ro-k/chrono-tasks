namespace Lib.Models;

public static class PgErrorCodes
{
    public static string ConcurrencyError => "P0001";
}


public enum CategoryType
{
    Vehicle = 1,
}

public enum EntityType
{
    Task = 1,
    Event = 2,
    Media = 3,
}

public enum Status
{
    Active = 1,
    Inactive = 2,
    Deleted = 3,
    Archived = 4,
    
}