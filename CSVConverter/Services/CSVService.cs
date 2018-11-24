using System;
using System.Collections.Generic;
using System.Text;

namespace WeMicroIt.Utils.CSVConverter.Services
{
    public static class CSVService
    {
        public void AddCSV(this IServiceCollection Services, CSVSettings settings)
        {
            services.AddSingleton<ICSVConverter, CSVConverter(settings)>();
        }
    }
}
