using AspNetCoreRateLimit;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

// Add services to the container.
//builder.Services.Configure<IpRateLimitOptions>(options =>
//{
//    options.EnableEndpointRateLimiting = true;
//    options.StackBlockedRequests = false;
//    options.HttpStatusCode = 429;
//    options.RealIpHeader = "X-Real-IP";
//    options.GeneralRules = new List<RateLimitRule>
//        {
//            new RateLimitRule
//            {
//                Endpoint = "*",
//                Period = "10s",
//                Limit = 2
//            }
//        };
//});
//builder.Services.Configure<ClientRateLimitMiddleware>(builder.Configuration.GetSection("IpRateLimiting"));app.UseClientRateLimiting();
//builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting")); //app.UseClientRateLimiting();
//builder.Services.Configure<IpRateLimitPolicies>(builder.Configuration.GetSection("IpRateLimiting")); //app.UseClientRateLimiting();
builder.Services.Configure<ClientRateLimitOptions>(builder.Configuration.GetSection("ClientRateLimiting")); //app.UseClientRateLimiting();
builder.Services.Configure<ClientRateLimitPolicies>(builder.Configuration.GetSection("ClientRateLimitPolicies")); //app.UseClientRateLimiting();
builder.Services.AddInMemoryRateLimiting();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseClientRateLimiting();
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
