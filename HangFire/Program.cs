using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHangfire(x => x.UseSqlServerStorage(string.Format(@"Data Source=(localdb)\myInstance;Initial Catalog=HangFire;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")));
builder.Services.AddHangfireServer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.UseHangfireDashboard("/mydashboard");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
