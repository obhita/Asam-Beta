using System;
using System.IO;

namespace Asam.Ppc.Infrastructure.Services
{
    public interface IFileStorageService
    {
        void StoreFile(string filename, Stream stream);

        Func<Stream> RetrieveFile(string filename);

        void DeleteFile(string filename);
    }
}