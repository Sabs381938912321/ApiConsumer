var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("ApiExterna", client =>
{
    client.BaseAddress = new Uri("https://api.telepatia.ai"); // <-- AQUÍ PONES TU LINK
    client.DefaultRequestHeaders.Authorization =
        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "b9b5cdd9-9230-40a8-9a93-567b0134d4c8");
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
