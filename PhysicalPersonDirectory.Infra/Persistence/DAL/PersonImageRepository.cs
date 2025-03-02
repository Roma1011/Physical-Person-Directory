namespace PhysicalPersonDirectory.Infra.Persistence.DAL;

public class PersonImageRepository
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
    public async Task<byte[]?> GetAsync(string? sourceName)
    {
        if (sourceName is null)
            return null;
        
        try
        {
            byte[]? result = null;
            string directoryPath = Path.Combine(_path, "PersonPhotos");
            string filePath = Path.Combine(directoryPath,sourceName);
        
            if (!Directory.Exists(directoryPath))
                return null;
        
            await using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                result=new byte[fileStream.Length];
                var readAsync = await fileStream.ReadAsync(result);
            }
            return result;
        }
        catch (Exception e)
        {
            return null;

        }
    }
}