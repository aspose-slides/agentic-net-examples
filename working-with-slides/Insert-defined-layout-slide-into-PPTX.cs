using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Get the first master slide
                var master = presentation.Masters[0];
                // Use the first layout slide from the master (e.g., Title layout)
                var layout = master.LayoutSlides[0];
                // Add a new empty slide based on the selected layout
                var newSlide = presentation.Slides.AddEmptySlide(layout);
                // Add a simple rectangle shape with text to the new slide
                var shape = newSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 100, 400, 50);
                shape.AddTextFrame("New slide using defined layout");
                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}