using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vega.Persistence
{
    public class UnitOfwork : IUnitOfWork
    {
        private readonly VegaDbContext context;

        public UnitOfwork(VegaDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
