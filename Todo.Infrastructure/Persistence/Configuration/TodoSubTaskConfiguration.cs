using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Entities;

namespace Todo.Infrastructure.Persistence.Configuration;

public class TodoSubTaskConfiguration : IEntityTypeConfiguration<TodoSubTask>{
    public void Configure(EntityTypeBuilder<TodoSubTask> builder){
        ConfigureTodoSubTaskTable(builder);
    }

    private void ConfigureTodoSubTaskTable(EntityTypeBuilder<TodoSubTask> builder){
        builder.ToTable("TodoSubTask");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).HasColumnType("varchar").HasMaxLength(40).IsRequired();
        builder.Property(t => t.Description).HasColumnType("varchar").HasMaxLength(30).IsRequired();
        builder.Property(t => t.Name).HasColumnType("varchar").HasMaxLength(30).IsRequired();
        builder.Property(t => t.CreatedAt).HasColumnType("datetime");
        builder.Property(t => t.UpdatedAt).HasColumnType("datetime");

        builder.HasOne<TodoTask>(t => t.TodoTask)
            .WithMany(t => t.TodoSubTasks)
            .HasForeignKey(t => t.TodoTaskId);
    }
}