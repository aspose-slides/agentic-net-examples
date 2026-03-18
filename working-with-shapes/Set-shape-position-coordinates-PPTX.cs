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
            Presentation pres = new Presentation();

            // Get a blank layout slide
            ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);

            // Add a text placeholder (initial position can be arbitrary)
            IAutoShape placeholder = layout.PlaceholderManager.AddTextPlaceholder(0f, 0f, 300f, 100f);

            // Reposition the shape to exact X and Y coordinates
            placeholder.X = 50f; // X coordinate in points
            placeholder.Y = 150f; // Y coordinate in points

            // Save the presentation before exiting
            pres.Save("RepositionedShape.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}