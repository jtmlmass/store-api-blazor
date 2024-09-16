using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using StacyStore;
using StacyStore.Data;
using StacyStore.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<ProductService>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("TestDb"));

var app =  builder.Build();

// app.UseOpenApi();
// app.UseSwaggerUi3();
// app.UseReDoc(configure => configure.Path = "/redoc");
//
// app.UseRouting();

await app.RunAsync();