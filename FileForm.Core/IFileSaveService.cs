namespace FileForm.Core;

public interface IFileSaveService
{
    Task SaveFileRecordAsync(FileRecord fileRecord);
}