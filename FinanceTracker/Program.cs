
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependancies(builder.Configuration);

builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(x =>
    {
        x.WithTitle("Finance Tracker API").WithTheme(ScalarTheme.Mars);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapIdentityApi<IdentityUser>();

app.MapControllers();

app.Run();
