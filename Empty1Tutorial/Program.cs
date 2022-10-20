using Empty1Tutorial;
using Microsoft.AspNetCore;

var builder = WebHost.CreateDefaultBuilder(args);
app.Run(async (context) =>
await context.Response.WriteAsync("Hello world")
);
var app = builder.Build();


;
