using devRank.Presentation.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AdicionarConfiguracoes(builder.Configuration);

var app = builder.Build();

app.UseExceptionHandler(o => { });
app.UseHttpsRedirection();
app.UseCors("Productions");
app.UseSwaggerDocumentacao();
app.MapControllers();
app.Run();