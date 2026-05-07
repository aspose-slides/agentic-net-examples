using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pdf";
        string logPath = "conversion.log";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            string version = Aspose.Slides.BuildVersionInfo.AssemblyVersion;
            string logEntry = DateTime.Now.ToString("s") + " - Aspose.Slides version: " + version;
            File.AppendAllText(logPath, logEntry + Environment.NewLine);

            int[] slides = new int[] { 1 };
            presentation.Save(outputPath, slides, Aspose.Slides.Export.SaveFormat.Pdf);

            presentation.Save("saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The requested format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}