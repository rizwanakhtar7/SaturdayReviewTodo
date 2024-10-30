using Microsoft.EntityFrameworkCore;
using SaturdayReviewTodo.Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaturdayReviewTodo.Domain.Infrastructure.Persistence
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
            


        }


        public DbSet<Todo> Todos { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoDbContext).Assembly);
            //modelBuilder.Entity<Todo>().HasData(new Todo {  Id = 1 , Description = "To do 1", Title = "To do 1"});

            base.OnModelCreating(modelBuilder);
        }
    }
}
