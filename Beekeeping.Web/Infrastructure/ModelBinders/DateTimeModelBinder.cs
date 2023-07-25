namespace Beekeeping.Web.Infrastructure.ModelBinders
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    public class DateTimeModelBinder : IModelBinder
    {
        public static readonly Type[] SUPPORTED_DATETIME_TYPES = new Type[] { typeof(DateTime), typeof(DateTime?) };

        public Task BindModelAsync(ModelBindingContext modelBindingContext)
        {
            if (modelBindingContext == null)
            {
                throw new ArgumentNullException(nameof(modelBindingContext));
            }

            if (!SUPPORTED_DATETIME_TYPES.Contains(modelBindingContext.ModelType))
            {
                return Task.CompletedTask;
            }

            var modelName = modelBindingContext.ModelName;
            var valueProviderResult = modelBindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            modelBindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            var dateTimeToParse = valueProviderResult.FirstValue;

            if (string.IsNullOrEmpty(dateTimeToParse))
            {
                return Task.CompletedTask;
            }
            var formattedDateTime = ParseDateTime(dateTimeToParse);

            modelBindingContext.Result = ModelBindingResult.Success(formattedDateTime);

            return Task.CompletedTask;
        }
        static DateTime? ParseDateTime(string date)
        {
            var CUSTOM_DATETIME_FORMATS = new string[]
            {
            "dd-MM-yyyy",
            "dd-MM-yyyy-THH-mm-ss",
            "dd-MM-yyyy-HH-mm-ss",
            "dd-MM-yyyy-HH-mm",
            };

            foreach (var format in CUSTOM_DATETIME_FORMATS)
            {
                if (DateTime.TryParseExact(date, format, null, DateTimeStyles.None, out DateTime validDate))
                {
                    return validDate;
                }
            }

            return null;
        }
    }
}
