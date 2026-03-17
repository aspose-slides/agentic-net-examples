using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing PPTX file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                // Iterate through all shapes on the current slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                    // Determine if the shape is an Ink object
                    if (shape is Aspose.Slides.Ink.Ink)
                    {
                        // Ink objects represent freehand drawing strokes captured as ink data
                        Console.WriteLine($"Slide {slideIndex + 1}, Shape {shapeIndex + 1}: Ink object");
                    }
                    else
                    {
                        // Standard slide elements include AutoShapes, pictures, tables, SmartArt, etc.
                        Console.WriteLine($"Slide {slideIndex + 1}, Shape {shapeIndex + 1}: Standard element ({shape.GetType().Name})");
                    }
                }
            }

            // Save the presentation (required before exiting)
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}