namespace PhysicalPersonDirectory.Infra.Persistence.DAL;

public class FileRepository
{
    private readonly string _path=AppDomain.CurrentDomain.BaseDirectory;
    public async Task<bool> Save(Stream  content,string fileName)
    {
        try
        {
            string directoryPath = Path.Combine(_path, "PersonPhotos");
            string filePath = Path.Combine(directoryPath,fileName);
        
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        
            await using (FileStream fileStream = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write))
            {
                await content.CopyToAsync(fileStream);
            }
        }
        catch (Exception e)
        {
            return true;

        }
        return true;
    }
}