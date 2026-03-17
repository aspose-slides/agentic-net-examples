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
            Presentation presentation = new Presentation();

            // Path to the external theme file (.thmx)
            string themePath = "MyTheme.thmx";

            // Apply the external theme to the first master slide and all dependent slides
            IMasterSlide masterSlide = presentation.Masters[0];
            masterSlide.ApplyExternalThemeToDependingSlides(themePath);

            // Save the themed presentation
            presentation.Save("ThemedPresentation.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}