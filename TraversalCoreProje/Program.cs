using BusinessLayer.Container;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using TraversalCoreProje.CQRS.Handlers.DestinationHandlers;
using TraversalCoreProje.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<GetDestinationByIDQueryHandler>();
builder.Services.AddScoped<GetAllDestinationQueryHandler>();
builder.Services.AddScoped<CreateDestinationCommandHandler>();
builder.Services.AddScoped<RemoveDestinationCommandHandler>();
builder.Services.AddScoped<UpdateDestinationCommandHandler>();

builder.Services.AddMediatR(typeof(Program));


builder.Services.AddLogging(x =>
{

	
	x.ClearProviders();
	x.SetMinimumLevel( LogLevel.Debug);
	x.AddDebug();
	var path = Directory.GetCurrentDirectory();
	x.AddFile($"{path}\\Logs\\Log1.txt");
});
// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<Context>();




builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();



//builder.Services.AddScoped<ICommentService, CommentManager>();
//builder.Services.AddScoped<ICommentDal, EfCommentDal>();
//builder.Services.AddScoped<IDestinationService, DestinationManager>();
//builder.Services.AddScoped<IDestinationDal, EfDestinationDal>();
//builder.Services.AddScoped<IAppUserService, AppUserManager>();
//builder.Services.AddScoped<IAppUserDal, EfAppUserDal>();

builder.Services.AddMvc(config=>
{
	var policy=new AuthorizationPolicyBuilder()
	.RequireAuthenticatedUser()
	.Build();
	config.Filters.Add(new AuthorizeFilter(policy));
}
);


//alt satýrý sonradan ekledim. 
builder.Services.ContainerDependencies();
//üst satýrý sonradan ekledim. 
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.CustomValidator();
builder.Services.AddControllersWithViews().AddFluentValidation();


builder.Services.AddMvc();
builder.Services.ConfigureApplicationCookie(options =>
options.LoginPath = "/Login/SignIn/"
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404","?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
	
});


app.Run();
