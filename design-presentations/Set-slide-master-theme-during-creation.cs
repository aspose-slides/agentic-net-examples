using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = "C:\\Data\\";
            string outputPath = dataDir + "output.pptx";
            string themePath = dataDir + "theme.thmx";

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Apply external theme to the first master slide
            IMasterSlide master = presentation.Masters[0];
            master.ApplyExternalThemeToDependingSlides(themePath);

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}