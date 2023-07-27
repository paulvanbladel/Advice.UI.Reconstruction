using InvestmentAnalysis.Core.Abstractions;
using Microsoft.Extensions.Configuration;

namespace InvestmentAnalysis.Core.Configuration;

public static class ConfigurationExtensions
{
#pragma warning disable CA2252
    public static T GetConfig<T>(this IConfiguration configuration) where T : IConfigOptions, new()
    {
        var sectionName = T.SectionName;
        return configuration.GetRequiredSection(sectionName).Get<T>();
    }
#pragma warning restore CA2252
}
