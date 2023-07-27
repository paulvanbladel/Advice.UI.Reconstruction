using InvestmentAnalysis.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using InvestmentAnalysis.Core.Attributes;

namespace InvestmentAnalysis.Core.DomainExtensions
{
    public static class DebitCreditExtensions
    {
        public static Money GetTotals<T>(this T entity) where T : class
        {
            return GetCascadingTotals<T>(entity);
        }
        
        private static Money GetCascadingTotals<T>(T entity) where T : class
        {
            Money total = Money.FromDouble(0);
            

            var properties = entity.GetType().GetProperties();

            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(Money))
                {
                    bool propIsCredit = property.GetCustomAttribute<MoneyCreditAttribute>() != null;
                    bool propIsDebit = property.GetCustomAttribute<MoneyDebetAttribute>() != null;
                    
                    var value = (Money)property.GetValue(entity);
                    if (value != null & (propIsCredit || propIsDebit))
                    {
                        total += propIsDebit ? value : -value;
                    }
                }
                else if (property.PropertyType.IsClass)
                {
                    var value = property.GetValue(entity);
                    if (value != null)
                    {
                        total = total + GetCascadingTotals(value);
                    }
                }
            }
            return total;
        }
    }
}
