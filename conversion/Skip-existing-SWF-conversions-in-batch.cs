using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchSwfConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputDirectory;
            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
            {
                inputDirectory = args[0];
            }
            else
            {
                inputDirectory = Directory.GetCurrentDirectory();
            }

            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine("Input directory does not exist: " + inputDirectory);
                return;
            }

            string[] supportedExtensions = new string[] { ".ppt", ".pptx", ".odp", ".pot", ".potx", ".potm", ".pptm", ".pps", ".ppsx", ".ppsm", ".otp", ".fodp" };
            string[] files = Directory.GetFiles(inputDirectory);

            foreach (string filePath in files)
            {
                string extension = Path.GetExtension(filePath).ToLowerInvariant();
                bool isSupported = false;
                foreach (string ext in supportedExtensions)
                {
                    if (extension == ext)
                    {
                        isSupported = true;
                        break;
                    }
                }

                if (!isSupported)
                {
                    // Format not supported
                    // Comment: format not supported
                    continue;
                }

                string outputPath = Path.ChangeExtension(filePath, ".swf");

                if (File.Exists(outputPath))
                {
                    // Skip conversion as SWF already exists
                    continue;
                }

                try
                {
                    Presentation presentation = new Presentation(filePath);
                    SwfOptions swfOptions = new SwfOptions();
                    // Example option: include viewer
                    swfOptions.ViewerIncluded = true;

                    presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                    presentation.Dispose();
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error processing file: " + filePath);
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}