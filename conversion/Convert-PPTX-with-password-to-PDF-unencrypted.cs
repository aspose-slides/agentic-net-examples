using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "protected.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");
        string password = "myPassword";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.Password = password;
            var presentation = new Aspose.Slides.Presentation(inputPath, loadOptions);
            presentation.Save(outputPath, SaveFormat.Pdf);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., web service errors)
        }
    }
}