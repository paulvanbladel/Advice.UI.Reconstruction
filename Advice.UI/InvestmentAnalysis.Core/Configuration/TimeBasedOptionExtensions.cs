using InvestmentAnalysis.Core.Exceptions;

namespace InvestmentAnalysis.Core.Configuration;
public static class TimeBasedOptionExtensions
{
    /// <summary>
    /// retrieves a single configuration item based on a reference date
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="stringBasedOptions"></param>
    /// <param name="referenceDate"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static T? GetSingleTimeBasedOption<T>(this IntervalBasedOption<T>[] stringBasedOptions, DateTime referenceDate)
    {

        if (stringBasedOptions == null)
        {
            throw new ConfigurationManagementException("Configuration parameter not found");
        }
        var dateTimeMax = DateTime.MaxValue;
        var items = stringBasedOptions
            .Where(d => d.From <= referenceDate && (d.To.HasValue ? referenceDate <= d.To.Value : true));
        if (items == null || items.Count() == 0)
        {
            throw new ConfigurationManagementException("No time based options found");
        }

        if (items.Count() > 1)
        {
            throw new ConfigurationManagementException("Overlapping configurations found");

        }
        var item = items.FirstOrDefault();
        if (item == null)
        {
            throw new ConfigurationManagementException("No time based option found");
        }
        return item.Value;
    }
    /// <summary>
    /// retrieves a series of configuration items based on a reference date
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="stringBasedOptions"></param>
    /// <param name="referenceDate"></param>
    /// <returns></returns>
    public static IList<T> GetTimeBasedOptionList<T>(this IntervalBasedOption<T>[] stringBasedOptions, DateTime referenceDate)
    {
        if (stringBasedOptions == null)
        {
            throw new ConfigurationManagementException("Configuration parameter not found");
        }
        var items = stringBasedOptions
            .Where(d => d.From <= referenceDate && d.To.HasValue && referenceDate <= d.To || !d.To.HasValue);
        return items.Select(i => i.Value).ToList();
    }
}
