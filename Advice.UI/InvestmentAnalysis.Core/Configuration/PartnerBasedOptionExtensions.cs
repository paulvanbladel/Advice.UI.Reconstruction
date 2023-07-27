using InvestmentAnalysis.Core.Exceptions;

namespace InvestmentAnalysis.Core.Configuration
{
    public static class PartnerBasedOptionExtensions
    {
        /// <summary>
        /// retrieves a single configuration item based on a partnerId and a reference date
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="partnerBasedOptions"></param>
        /// <param name="partnerId"></param>
        /// <param name="referenceDate"></param>
        /// <returns></returns>
        /// <exception cref="ConfigurationManagementException"></exception>
        public static T? GetSingleTimeBasedPartnerOption<T>(this PartnerBasedOption<T>[] partnerBasedOptions, int partnerId, DateTime referenceDate)
        {
            if (partnerBasedOptions == null)
            {
                throw new ConfigurationManagementException("Partner based configuration parameter not found");
            }

            var items = partnerBasedOptions.Where(p => p.PartnerId == partnerId);
            if (items == null || !items.Any())
            {
                //default opzoeken
                items = partnerBasedOptions.Where(p => p.PartnerId == -1);
                if (items == null || !items.Any())
                {
                    throw new ConfigurationManagementException("No partner based options found");
                }
            }

            if (items.Count() > 1)
            {
                throw new ConfigurationManagementException("Overlapping partner based configurations found");
            }

            var item = items.FirstOrDefault();

            var returnValue = item.PartnerData.GetSingleTimeBasedOption(referenceDate);

            return returnValue;
        }

        /// <summary>
        /// retrieves a series of configuration items based on a partnerId and a reference date
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="partnerBasedOptions"></param>
        /// <param name="partnerId"></param>
        /// <param name="referenceDate"></param>
        /// <returns></returns>
        /// <exception cref="ConfigurationManagementException"></exception>
        public static IList<T> GetTimeBasedPartnerOptionList<T>(this PartnerBasedOption<T>[] partnerBasedOptions, int partnerId, DateTime referenceDate)
        {
            if (partnerBasedOptions == null)
            {
                throw new ConfigurationManagementException("Partner based configuration parameter not found");
            }

            var items = partnerBasedOptions.Where(p => p.PartnerId == partnerId);
            if (items == null || !items.Any())
            {
                //default opzoeken
                items = partnerBasedOptions.Where(p => p.PartnerId == 0);
                if (items == null || !items.Any())
                {
                    throw new ConfigurationManagementException("No partner based options found");
                }
            }

            if (items.Count() > 1)
            {
                throw new ConfigurationManagementException("Overlapping partner based configurations found");
            }

            var item = items.FirstOrDefault();

            var returnValue = item.PartnerData.GetTimeBasedOptionList(referenceDate);

            return returnValue;
        }
    }
}