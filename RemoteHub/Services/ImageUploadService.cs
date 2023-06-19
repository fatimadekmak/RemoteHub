namespace RemoteHub.Services
{
    public class ImageUploadService
    {
        public static bool CheckExtensionValidity(IFormFile file)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            return allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower());
        }
        public static string UploadFile(IFormFile? file)
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", file.FileName);
            var filestream = new FileStream(filepath, FileMode.Create);
            file.CopyToAsync(filestream);
            filestream.Close();
            return "/images/" + file.FileName;
        }
    }
}
