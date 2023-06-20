using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TimedAssignment.Data;
using TimedAssignment.Services.CommentServices;
using TimedAssignment.Services.Configurations;
using TimedAssignment.Services.LikeServices;
using TimedAssignment.Services.PostServices;
using TimedAssignment.Services.ReplyServices;
using TimedAssignment.Services.UserServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICommentService,CommentService>();
builder.Services.AddScoped<ILikeService,LikeService>();
builder.Services.AddScoped<IPostService,PostService>();
builder.Services.AddScoped<IReplyService,ReplyService>();
builder.Services.AddScoped<IAuthenticationManager,AuthenticationManager>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer( builder.Configuration.GetConnectionString("DefaultConnection")));

// builder.Services.AddIdentityCore<User>()
//                 .AddRoles<IdentityRole>()
//                 .AddEntityFrameworkStores<ApplicationDbContext>();
                
builder.Services.AddAutoMapper(typeof(MappingConfigurations));
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
