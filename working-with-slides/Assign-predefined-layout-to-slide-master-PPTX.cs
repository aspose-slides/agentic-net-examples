using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            var presentation = new Aspose.Slides.Presentation();

            // Access the first master slide
            var master = presentation.Masters[0];

            // Add a custom layout slide to the presentation's master
            var customLayout = presentation.LayoutSlides.Add(master, Aspose.Slides.SlideLayoutType.Custom, "MyCustomLayout");

            // Insert a new empty slide using the custom layout
            presentation.Slides.InsertEmptySlide(0, customLayout);

            // Save the presentation to a PPTX file
            presentation.Save("CustomLayoutPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}