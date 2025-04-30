using Microsoft.EntityFrameworkCore;

namespace MachineLicenseManagement.WebKeyGen.Models;

public partial class PraMaschlizenzContext : DbContext
{


    public PraMaschlizenzContext(DbContextOptions<PraMaschlizenzContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TestTab> TestTabs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=PRA1;database=pra_maschlizenz;User ID=mali;Password=Hjert!223h;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestTab>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_xx_TestTa__0DAF0CB0");

            entity.ToTable("TestTab");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Kommentar)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Mlm02).HasColumnName("MLM02");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
