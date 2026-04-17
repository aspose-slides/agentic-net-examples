using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.xps";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                Aspose.Slides.Export.XpsOptions xpsOptions = new Aspose.Slides.Export.XpsOptions();
                // XpsOptions does not provide a Compliance property; ISO29500 compliance is not applicable for XPS format.
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps, xpsOptions);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The specified format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}