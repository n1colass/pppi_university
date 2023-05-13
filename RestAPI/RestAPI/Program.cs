using RestAPI.Services.Books;
using RestAPI.Services.Comics;
using RestAPI.Services.Journals;

var builder = WebApplication.CreateBuilder(args);

// Add DI, I choose AddTransient because it test cases of using this API and dont have much logic like real project.
builder.Services.AddTransient<IBooks, Books>();
builder.Services.AddTransient<IComics, Comics>(); 
builder.Services.AddTransient<IJournals, Journals>();

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
