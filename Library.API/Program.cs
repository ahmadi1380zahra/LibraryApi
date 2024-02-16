using Library.API;
using Library.Persistance.EF.Authors;
using Library.Persistance.EF.Books;
using Library.Persistance.EF.Genres;
using Library.Persistance.EF.Users;
using Library.Persistance.EF;
using Library.Services.Authors.Contracts;
using Library.Services.Authors;
using Library.Services.Books.Contracts;
using Library.Services.Books;
using Library.Services.Genres.Contracts;
using Library.Services.Genres;
using Library.Services.Users.Contracts;
using Library.Services.Users;
using Taav.Contracts;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<EFDataContext>();
builder.Services.AddScoped<BookService, BookAppService>();
builder.Services.AddScoped<BookRepository, EFBookRepository>();
builder.Services.AddScoped<UserService, UserAppService>();
builder.Services.AddScoped<UserRepository, EFUserRepository>();
builder.Services.AddScoped<AuthorService, AuthorAppService>();
builder.Services.AddScoped<AuthorRepository, EFAuthorRepository>();
builder.Services.AddScoped<GenreService, GenreAppService>();
builder.Services.AddScoped<GenreRepository, EFGenreRepository>();
builder.Services.AddScoped<UnitOfWork, EFUnitOfWork>();
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
