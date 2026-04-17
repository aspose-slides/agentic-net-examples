using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string presentationPath = "input.pptx";
        string themePath = "theme.thmx";
        string outputPath = "output.pptx";

        if (!File.Exists(presentationPath))
        {
            Console.WriteLine("Presentation file not found.");
            return;
        }

        if (!File.Exists(themePath))
        {
            Console.WriteLine("Theme file not found.");
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationPath);
            // Apply external theme to the first master slide, affecting all dependent slides
            Aspose.Slides.IMasterSlide newMaster = presentation.Masters[0].ApplyExternalThemeToDependingSlides(themePath);
            // Save the updated presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Aspose.Slides.PptxReadException ex)
        {
            // Theme could not be applied
            Console.WriteLine("Failed to apply theme: " + ex.Message);
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}