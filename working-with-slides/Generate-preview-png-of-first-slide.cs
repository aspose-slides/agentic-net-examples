using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace GeneratePreview
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath;
            if (args.Length > 0)
            {
                inputPath = args[0];
            }
            else
            {
                Console.WriteLine("Please provide the path to the presentation file.");
                return;
            }

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("File does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    if (presentation.Slides.Count == 0)
                    {
                        Console.WriteLine("Presentation contains no slides.");
                    }
                    else
                    {
                        IImage thumbnail = presentation.Slides[0].GetImage();
                        string outputImage = Path.ChangeExtension(inputPath, ".png");
                        thumbnail.Save(outputImage, Aspose.Slides.ImageFormat.Png);
                        thumbnail.Dispose();
                        Console.WriteLine("Preview saved to: " + outputImage);
                    }

                    // Save presentation before exit
                    string tempSavePath = Path.Combine(Path.GetDirectoryName(inputPath), "temp_saved.pptx");
                    presentation.Save(tempSavePath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}