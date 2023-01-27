using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Entities;

namespace Todo.Infrastructure.Persistence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>{
    public void Configure(EntityTypeBuilder<User> builder){
        ConfigureUserTable(builder);
    }

    public void ConfigureUserTable(EntityTypeBuilder<User> builder){
        builder.ToTable("User");
        builder.HasKey("Id");
        builder.Property(u => u.Id).HasColumnType("varchar").HasMaxLength(40).IsRequired();
        builder.Property(u => u.FirstName).HasColumnType("varchar").HasMaxLength(30).IsRequired();
        builder.Property(u => u.LastName).HasColumnType("varchar").HasMaxLength(30).IsRequired();
        builder.Property(u => u.Email).HasColumnType("varchar").HasMaxLength(20).IsRequired();
        builder.Property(u => u.Password).HasColumnType("varchar").HasMaxLength(50).IsRequired();
        builder.Property(u => u.CreatedAt).HasColumnType("datetime");
        builder.Property(u => u.UpdateAt).HasColumnType("datetime");

        builder.HasMany<TodoTask>(u => u.TodoTasks)
            .WithOne(t => t.User);
    }
}