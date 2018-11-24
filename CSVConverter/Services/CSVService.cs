using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using WeMicroIt.Utils.CSVConverter.Interfaces;

namespace WeMicroIt.Utils.CSVConverter.Services
{
    /// <include file='./Docs/Services.xml' path='Doc/Service[@name="CSVService"]/CSVService/*' />
    public static class CSVService
    {
        /// <include file='./Docs/Services.xml' path='Doc/Service[@name="CSVService"]/AddCSV/*' />
        public static void AddCSV(this IServiceCollection services)
        {
            services.AddSingleton<ICSVConverter, CSVConverter>();
        }
    }
}
