using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Propking.Api.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SystemContext context)
        {
            if (context.Fiis.Any())
            {
                return;
            }

            context.Fiis.Add(new Models.Fii()
            {
                Code = "ABCP11",
                CategoryTag = "shopping",
                Name = "ABC Plaza"
            });

            context.SaveChanges();
        }
    }
}
