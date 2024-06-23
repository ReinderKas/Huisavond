using Kassen.Games;
using Kassen.Models;
using Microsoft.EntityFrameworkCore;

namespace Kassen.Database;
public class KassenContext : DbContext
{
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        

        
    public KassenContext(DbContextOptions<KassenContext> options)
        : base(options)
    { }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Game>()
            .HasDiscriminator<string>("GameName")
            .HasValue<Jackpot>("JackPot");
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
            options.AddPolicy("AllowAllHeaders",
                builder =>
                {
                    builder
                        .SetIsOriginAllowed(origin => true)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .SetPreflightMaxAge(TimeSpan.FromSeconds(600));
                })
        );
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHttpsRedirection();
        }

        app.UseCors("AllowAllHeaders");
        app.UseRouting();
        app.UseResponseCompression();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
