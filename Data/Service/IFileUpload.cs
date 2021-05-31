using BlazorInputFile;
using System.Threading.Tasks;

namespace OnlineBlazorApp.Data.Service
{
    public interface IFileUpload
    {
        Task UploadAsync(IFileListEntry fileEntry);
    }
}