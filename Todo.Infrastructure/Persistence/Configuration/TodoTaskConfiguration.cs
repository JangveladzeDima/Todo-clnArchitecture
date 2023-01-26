using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Entities;

namespace Todo.Infrastructure.Persistence.Configuration;

public class TodoTaskConfiguration : IEntityTypeConfiguration<TodoTask>{
    public void Configure(EntityTypeBuilder<TodoTask> builder){
        ConfigureTodoTaskTable(builder);
    }

    public void ConfigureTodoTaskTable(EntityTypeBuilder<TodoTask> builder){
        builder.ToTable("TodoTask");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).HasColumnType("varchar").HasMaxLength(40).IsRequired();
        builder.Property(t => t.Name).HasColumnType("varchar").HasMaxLength(30).IsRequired();
        builder.Property(t => t.Description).HasColumnType("varchar").HasMaxLength(30).IsRequired();
        builder.Property(t => t.CreatedAt).HasColumnType("datetime");
        builder.Property(t => t.UpdatedAt).HasColumnType("datetime");

        builder.HasMany<TodoSubTask>(t => t.TodoSubTasks)
            .WithOne(t => t.TodoTask)
            .HasForeignKey(t => t.TodoTaskId);
        
        builder.HasOne<User>(t => t.User)
            .WithMany(t => t.TodoTasks)
            .HasForeignKey(t => t.UserId);
    }
}