using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();

            // Ensure there are at least three master slides
            while (presentation.Masters.Count < 3)
            {
                presentation.Masters.AddClone(presentation.Masters[0]);
            }

            // Access the third slide master (index 2)
            var master = presentation.Masters[2];

            // Add a rectangle placeholder shape with predefined dimensions and text
            var placeholder = master.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100f, 100f, 300f, 50f);
            placeholder.AddTextFrame("Placeholder Text");

            // Save the presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions
        }
    }
}