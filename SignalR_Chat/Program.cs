using Microsoft.EntityFrameworkCore;
using SignalR_Chat;
using SignalR_Chat.Models;   // ������������ ���� ������ ChatHub

var builder = WebApplication.CreateBuilder(args);

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ChatContext>(options => options.UseSqlServer(connection));

// ��� ������������� ���������������� ���������� SignalR,
// � ���������� ���������� ���������������� ��������������� �������
builder.Services.AddSignalR();  

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapHub<ChatHub>("/chat");   // ChatHub ����� ������������ ������� �� ���� /chat

app.Run();
