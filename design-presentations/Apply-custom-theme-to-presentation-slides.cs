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

            // Path to the external theme file (.thmx)
            string themePath = "customTheme.thmx";

            // Apply the external theme to the first master slide and all dependent slides
            Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];
            masterSlide.ApplyExternalThemeToDependingSlides(themePath);

            // Save the presentation
            presentation.Save("CustomThemePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}