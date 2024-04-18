
using Library.DB.Db_Context;
using Library.DB.Model;
using Library.Reposatory.Impelmentation;
using Library.Reposatory.Repository;
using Library.Services.Interface;
using Library.Services.services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json.Serialization;

namespace Library.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //independance injection
            builder.Services.AddScoped<IUnitOfWork<LibraryDbContext>, UnitOfWork<LibraryDbContext>>();
            builder.Services.AddScoped<IBookServices, BookServices>();
            builder.Services.AddScoped<IAuthorServices, AuthorServices>();
            builder.Services.AddScoped<ICategoriesServices, CategoryServices>();
            builder.Services.AddScoped<IBaseRepository<Book>, BaseRepository<Book>>();
            builder.Services.AddScoped<IBaseRepository<Author>, BaseRepository<Author>>();
            builder.Services.AddScoped<IBaseRepository<Category>, BaseRepository<Category>>();
            builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<ICatogeryRepository, CatogeryRepository>();
            builder.Services.AddScoped<UserRepository, UserRepository>();
            
            //Add connection string 
            var connectionString = builder.Configuration.GetConnectionString("Connection");
            builder.Services.AddDbContext<LibraryDbContext>(options =>
            options.UseSqlServer(connectionString));


            // Add services to the container.
            builder.Services.AddControllers();
                   

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}