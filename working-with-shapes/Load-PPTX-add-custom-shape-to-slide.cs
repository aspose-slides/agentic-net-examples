using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

public class Program
{
    public static void Main()
    {
        try
        {
            // Paths for input and output presentations
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the existing presentation
            Presentation presentation = new Presentation(inputPath);

            // Access the first slide (change index as needed)
            ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape to the slide
            IAutoShape autoShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                100,   // X position (points)
                100,   // Y position (points)
                300,   // Width (points)
                150);  // Height (points)

            // Set alternative text for identification (optional)
            autoShape.AlternativeText = "CustomUserShape";

            // Add a text frame with sample text
            ITextFrame textFrame = autoShape.AddTextFrame("Hello Aspose!");

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}