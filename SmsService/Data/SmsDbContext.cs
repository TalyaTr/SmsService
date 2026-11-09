using Microsoft.EntityFrameworkCore;

namespace SmsService.Data
{
    public class SmsDbContext : DbContext
    {
        public SmsDbContext(DbContextOptions<SmsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.To)
                      .IsRequired()
                      .HasMaxLength(20);

                entity.Property(e => e.Body)
                      .IsRequired()
                      .HasMaxLength(160);

                entity.Property(e => e.Status)
                      .IsRequired();

                entity.Property(e => e.CreatedAt)
                      .IsRequired();

                entity.Property(e => e.UpdatedAt)
                      .IsRequired();
            });
        }
    }
}
