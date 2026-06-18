using Microsoft.EntityFrameworkCore;
using RecipeHaven.Models;

namespace RecipeHaven.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Recipe> Recipes => Set<Recipe>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Favorite> Favorites => Set<Favorite>();
    public DbSet<Rating> Ratings => Set<Rating>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 1,
            Name = "Demo Chef",
            Email = "demo@recipehaven.com"
        });

        modelBuilder.Entity<Recipe>().HasData(new Recipe
        {
            Id = 1,
            Title = "Quick Pasta",
            Description = "A simple and tasty pasta dish.",
            Ingredients = "200g pasta\n2 tbsp olive oil\n2 garlic cloves\nSalt and pepper",
            Instructions = "Boil pasta.\nSauté garlic in oil.\nMix and serve.",
            CookingTimeMinutes = 15,
            ImageUrl = "/images/recipes/sample.jpg",
            CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),  // ✅ Static date
            CreatedByUserId = 1
        });
    }
}