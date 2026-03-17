using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Get the first master slide
            Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

            // Apply an external theme (.thmx) to the master slide and its dependent slides
            Aspose.Slides.IMasterSlide themedMaster = masterSlide.ApplyExternalThemeToDependingSlides("theme.thmx");

            // Save the updated presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}