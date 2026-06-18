using RecipeHaven.Models;

namespace RecipeHaven.Services;

public class RecipeStateService
{
    public event Action? OnChange;

    public List<Recipe> Recipes { get; private set; } = new();

    public void NotifyStateChanged() => OnChange?.Invoke();

    public void UpdateRecipes(List<Recipe> recipes)
    {
        Recipes = recipes ?? new List<Recipe>();
        NotifyStateChanged();
    }
}