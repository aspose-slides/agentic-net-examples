using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Apply an external theme to all slides via the first master slide
            Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];
            masterSlide.ApplyExternalThemeToDependingSlides("theme.thmx");

            // Save the themed presentation
            presentation.Save("ThemedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}