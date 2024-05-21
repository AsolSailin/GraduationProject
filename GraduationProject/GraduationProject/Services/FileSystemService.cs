using GraduationProject.DataBase;

namespace GraduationProject.Services
{
    public class FileSystemService
    {
        string path = "";

        public async Task UploadFileAsync(string name, Stream stream, string animalOrEmployee)
        {

            switch (animalOrEmployee)
            {
                case "animal":
                    path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\Animals", name);
                    break;
                case "user":
                    path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\Users", name);
                    break;
            }

            using var fs = new FileStream(path, FileMode.Create);
            await stream.CopyToAsync(fs);
        }
    }
}
