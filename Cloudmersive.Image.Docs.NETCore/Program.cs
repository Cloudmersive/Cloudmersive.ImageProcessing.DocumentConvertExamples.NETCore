using System;
using System.Diagnostics;
using System.IO;
using Cloudmersive.APIClient.NETCore.DocumentAndDataConvert.Api;
using Cloudmersive.APIClient.NETCore.DocumentAndDataConvert.Client;
using Cloudmersive.APIClient.NETCore.DocumentAndDataConvert.Model;
using Cloudmersive.APIClient.NETCore.ImageRecognition.Api;
using Cloudmersive.APIClient.NETCore.ImageRecognition.Client;
using Cloudmersive.APIClient.NETCore.ImageRecognition.Model;

namespace Cloudmersive.Image.Docs.NETCore
{
    class Program
    {
        static void Main(string[] args)
        {
            // Resizing an image

            Cloudmersive.APIClient.NETCore.ImageRecognition.Client.Configuration.Default.AddApiKey("Apikey", "YOUR-API-KEY");



            var apiInstance1 = new ResizeApi();
            var maxWidth = 56;  // int? | Maximum width of the output image - final image will be as large as possible while less than or equial to this width
            var maxHeight = 56;  // int? | Maximum height of the output image - final image will be as large as possible while less than or equial to this height
            var imageFile = new System.IO.FileStream("C:\\temp\\input.jpg", System.IO.FileMode.Open); // System.IO.Stream | Image file to perform the operation on.  Common file formats such as PNG, JPEG are supported.

            try
            {
                // Resize an image with parameters
                byte[] result = apiInstance1.ResizePost(maxWidth, maxHeight, imageFile);
                Debug.WriteLine("Completed 1");

                File.WriteAllBytes("C:\\temp\\output.png", result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ResizeApi.ResizePost: " + e.Message);
            }

            // Converting a Word Document (DOCX) to PDF

            Cloudmersive.APIClient.NETCore.DocumentAndDataConvert.Client.Configuration.Default.AddApiKey("Apikey", "YOUR-API-KEY");

            var apiInstance2 = new ConvertDocumentApi();
            var inputFile = new System.IO.FileStream("C:\\temp\\input.docx", System.IO.FileMode.Open); // System.IO.Stream | Input file to perform the operation on.

            try
            {
                // Word DOCX to PDF
                byte[] result = apiInstance2.ConvertDocumentDocxToPdf(inputFile);
                Debug.WriteLine("Completed 2");

                File.WriteAllBytes("C:\\temp\\output.pdf", result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ConvertDocumentApi.ConvertDocumentDocxToPdf: " + e.Message);
            }
        }
    }
}
