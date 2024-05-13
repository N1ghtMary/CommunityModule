using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.ArticleRepository;
using Repository.CategoryRepository;
using Repository.CommentRepository;
using Repository.FavoriteArticleRepository;
using Repository.GroupRepository;
using Repository.StatisticsRepository;
using Repository.SubscriptionAuthorRepository;
using Repository.UserRepository;
using Services.ArticleService;
using Services.CategoryService;
using Services.CommentService;
using Services.FavoriteArticleService;
using Services.GroupService;
using Services.StatisticsService;
using Services.SubscriptionAuthorService;
using Services.UserService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped(typeof(ICategoryRepository),
    typeof(CategoryRepository));
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddScoped(typeof(IGroupRepository),
    typeof(GroupRepository));
builder.Services.AddTransient<IGroupService, GroupService>();
builder.Services.AddScoped(typeof(IUserRepository),
    typeof(UserRepository));
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddScoped(typeof(IArticleRepository),
    typeof(ArticleRepository));
builder.Services.AddTransient<IArticleService, ArticleService>();
builder.Services.AddScoped(typeof(ICommentRepository),
    typeof(CommentRepository));
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddScoped(typeof(IStatisticsRepository),
    typeof(StatisticsRepository));
builder.Services.AddTransient<IStatisticsService, StatisticsService>();
builder.Services.AddScoped(typeof(IFavoriteArticleRepository),
    typeof(FavoriteArticleRepository));
builder.Services.AddTransient<IFavoriteArticleService, FavoriteArticleService>();
builder.Services.AddScoped(typeof(ISubscriptionAuthorRepository),
    typeof(SubscriptionAuthorRepository));
builder.Services.AddTransient<ISubscriptionAuthorService, SubscriptionAuthorService>();

var app=builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();