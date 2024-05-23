
namespace GamesETL.Common;

public static class ExtensionMethod
{
    public static R Apply<T, R>(this T item, Func<T, R> mapper) => mapper(item);

    public static bool EqualsIgnoreCase(this string s1,  string s2) => string.Equals(s1, s2, StringComparison.InvariantCultureIgnoreCase);

    public static T GetNonNullOrThrow<T>(this T item, string paramName)
       where T : class
    {
        ArgumentNullException.ThrowIfNull(item, paramName);
        return item;
    }
    public static bool IsNullOrEmpty(this string? s) => 
        string.IsNullOrEmpty(s);

    public static bool HasText(this string? s) =>
        (s?.Trim()?.Length ?? 0) > 0;
    public static DateOnly ToDateOnly(this DateTime date) =>
       new DateOnly(date.Year, date.Month, date.Day);

    public static DateTime? ToDateTime(this DateOnly? date) =>
        date is null ? new DateTime?() : date.Value.ToDateTime(TimeOnly.MinValue);

    public static T GetValueOrThrow<T>
        (this T? item,
        Func<string> errorMessage,
        Func<T?, bool>? errorCheckFx = null
        )
        {

        errorCheckFx ??= x => x is null;

        if (item is null || errorCheckFx(item))
        {
            throw new Exception(errorMessage());
        }
        
        return item!;
    }

    public static void AssertArgumentNotNull(this object item, string paramName) =>
        ArgumentNullException.ThrowIfNull(item, paramName);


}


