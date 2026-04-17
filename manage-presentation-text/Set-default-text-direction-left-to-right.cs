using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.DefaultTextLanguage = "en-US";

            using (var presentation = new Aspose.Slides.Presentation(loadOptions))
            {
                // Add a new slide based on the first slide's layout
                var layoutSlide = presentation.Slides[0].LayoutSlide;
                var newSlide = presentation.Slides.AddEmptySlide(layoutSlide);

                // Add a rectangle shape with a text frame to demonstrate left‑to‑right direction
                var shape = newSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
                shape.AddTextFrame("Sample left‑to‑right text");

                // Save the presentation
                presentation.Save("Output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}