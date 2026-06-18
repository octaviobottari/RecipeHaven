using Microsoft.AspNetCore.Components.Forms;

namespace RecipeHaven.Services;

public class ImageService
{
    private readonly IWebHostEnvironment _env;

    public ImageService(IWebHostEnvironment env)
    {
        _env = env;
    }

    public async Task<string?> SaveImageAsync(IBrowserFile file)
    {
        if (file == null) return null;

        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        var extension = Path.GetExtension(file.Name).ToLower();
        if (!allowedExtensions.Contains(extension))
            return null;

        var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.Name)}";
        var folderPath = Path.Combine(_env.WebRootPath, "images", "recipes");
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        var filePath = Path.Combine(folderPath, fileName);
        await using var stream = new FileStream(filePath, FileMode.Create);
        await file.OpenReadStream(maxAllowedSize: 5 * 1024 * 1024).CopyToAsync(stream);

        return $"/images/recipes/{fileName}";
    }

    

    public void DeleteImage(string? imageUrl)
    {
        if (string.IsNullOrEmpty(imageUrl)) return;
        var fileName = Path.GetFileName(imageUrl);
        var filePath = Path.Combine(_env.WebRootPath, "images", "recipes", fileName);
        if (File.Exists(filePath))
            File.Delete(filePath);
    }
}