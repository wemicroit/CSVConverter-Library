using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using WeMicroIt.Utils.CSVConverter.Interfaces;

namespace WeMicroIt.Utils.CSVConverter.Services
{
    public static class CSVService
    {
        public static void AddCSV(this IServiceCollection services)
        {
            services.AddSingleton<ICSVConverter, CSVConverter>();
        }
    }
}
