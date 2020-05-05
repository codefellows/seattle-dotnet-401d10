using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CMSD10DemoCode.Models
{
    // Install-Package 
    public class Blob
    {
        public CloudStorageAccount CloudStorageAccount { get; set; }
        public CloudBlobClient CloudBlobClient { get; set; }

        public Blob(IConfiguration configuration)
        {
            var storageCreds = new StorageCredentials(configuration["Storage-Account-Name"], configuration["BlobKey"]);
            CloudStorageAccount = new CloudStorageAccount(storageCreds, true);
            CloudBlobClient = CloudStorageAccount.CreateCloudBlobClient();

        }

        /// <summary>
        /// Gets the container from Azure Blob
        /// </summary>
        /// <param name="containerName">target name of specific container</param>
        /// <returns>The full Container of a blob</returns>
        public async Task<CloudBlobContainer> GetContainer(string containerName)
        {
            CloudBlobContainer cbc = CloudBlobClient.GetContainerReference(containerName);
            await cbc.CreateIfNotExistsAsync();

            await cbc.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Container
            });

            return cbc;
        }

        // get the images from the container
        public async Task<CloudBlob> GetBlob(string imageName, string containerName)
        {
            var container = await GetContainer(containerName);
            CloudBlob blob = container.GetBlobReference(imageName);

            return blob;
        }

        public async Task UploadFile(string containerName, string fileName, string filePath)
        {
            // get the container
            var container = await GetContainer(containerName);
            var blobFile = container.GetBlockBlobReference(fileName);
            await blobFile.UploadFromFileAsync(filePath);

        }

        public async Task DeleteBlob(string containerName, string fileName)
        {
            var container = await GetContainer(containerName);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);

            await blockBlob.DeleteAsync();
        }
    }
}
