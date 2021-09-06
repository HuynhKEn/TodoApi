using System.Linq;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;

namespace TodoApi.Core.Helpers {
    public static class ShowRouter {
        public static void ShowInfo(
            Microsoft.AspNetCore.Mvc.Infrastructure.IActionDescriptorCollectionProvider actionDescriptorCollectionProvider,
            IHostApplicationLifetime applicationLifetime,
            ILogger logger
            ) {
            applicationLifetime.ApplicationStarted.Register(() => {
                Console.WriteLine(new string('-', 100));
                var routes = actionDescriptorCollectionProvider.ActionDescriptors.Items.Where(
                    ad => ad.AttributeRouteInfo != null).Select(ad => new {
                        Controller = ad.RouteValues["controller"],
                        Action = ad.RouteValues["action"],
                        Method = ad.ActionConstraints?.OfType<HttpMethodActionConstraint>().FirstOrDefault()?.HttpMethods.First(),
                    }).ToList();
                
                foreach (var route in routes) {
                    logger.LogInformation(1, $"{route}");
                }
                Console.WriteLine(new string('-', 100));
            });
        }
    }
}
