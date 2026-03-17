using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_accessible.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through each slide
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];

                // Iterate through each shape on the slide
                for (int j = 0; j < slide.Shapes.Count; j++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[j];

                    // Process only AutoShape objects
                    Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                    if (autoShape != null)
                    {
                        // Set alternative text for screen readers
                        shape.AlternativeText = "Description of shape " + (j + 1);
                        // Set title for the alternative text
                        shape.AlternativeTextTitle = "Shape " + (j + 1);
                        // Mark the shape as decorative (if appropriate)
                        shape.IsDecorative = true;
                    }
                }

                // Ensure the slide is visible during a slide show
                slide.Hidden = false;
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}