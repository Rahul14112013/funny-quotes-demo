﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Description;
using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Steeltoe.Common.HealthChecks;
using Steeltoe.Extensions.Logging;
using Steeltoe.Management.Endpoint;

namespace FunnyQuotesUIForms
{
    public static class ManagementConfigExtensions
    {
        public static void StartActuators(this IContainer container)
        {
            var configuration = container.Resolve<IConfiguration>();
            var dynamicLogger = container.Resolve<IEnumerable<ILoggerProvider>>().OfType<DynamicLoggerProvider>().First();
            var healthContributors = container.Resolve<IEnumerable<IHealthContributor>>();
            container.TryResolve<IApiExplorer>(out var apiExplorer);
            var loggerFactory = container.Resolve<ILoggerFactory>();
            ActuatorConfigurator.UseAllActuators(configuration, dynamicLogger, healthContributors, apiExplorer, loggerFactory);
        }
        
    }
    
}