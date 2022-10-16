namespace MovieApp.Infrastructure.Utilities
{
    public class CacheKeyUtil
    {
        public static string GetKeyFromPageNumberAndLength(string prefix, int pageNumber, int pageLength) => $"{prefix}_{pageNumber}_{pageLength}";
        

        public static string GetKeyFromId(string prefix, Guid id) => $"{prefix}_{id}";
        
    }
}
