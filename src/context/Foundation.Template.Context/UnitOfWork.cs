using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using Bones.Flow;
using Bones.Exceptions;

namespace Foundation.Template.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private readonly ILogger _logger;

        public UnitOfWork(ApplicationContext context, ILogger<UnitOfWork> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Commit()
        {
            try
            {
                var saves = await _context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {
                _logger.LogCritical(ex, "Unable to update Database");
                throw new DbUpdateException(ex.Message, ex);
            }
        }
    }
}