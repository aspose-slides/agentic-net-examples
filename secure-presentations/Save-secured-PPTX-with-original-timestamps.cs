using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "secured.pptx";
        string outputPath = "secured_copy.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Save the presentation preserving original metadata
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }

            // Preserve original file timestamps
            DateTime creationTime = File.GetCreationTime(inputPath);
            DateTime lastWriteTime = File.GetLastWriteTime(inputPath);
            File.SetCreationTime(outputPath, creationTime);
            File.SetLastWriteTime(outputPath, lastWriteTime);
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported for saving.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}