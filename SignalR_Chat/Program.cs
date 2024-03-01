using Microsoft.EntityFrameworkCore;
using SignalR_Chat;
using SignalR_Chat.Models;   // пространство имен класса ChatHub

var builder = WebApplication.CreateBuilder(args);

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ChatContext>(options => options.UseSqlServer(connection));

// ƒл€ использовани€ функциональности библиотеки SignalR,
// в приложении необходимо зарегистрировать соответствующие сервисы
builder.Services.AddSignalR();  

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapHub<ChatHub>("/chat");   // ChatHub будет обрабатывать запросы по пути /chat

app.Run();
