using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FastWeb.Storage;

internal class DatabaseInitializer
{
    private readonly ILogger _logger;
    private readonly AppDbContext _context;

    public DatabaseInitializer(IServiceProvider serviceProvider)
    {
        _logger = serviceProvider.GetRequiredService<ILogger<DatabaseInitializer>>();
        _context = serviceProvider.GetRequiredService<AppDbContext>();
    }

    public void Execute()
    {
        _context.Database.Migrate();
        _logger.LogInformation("Initialize database successfully!");
    }
}
