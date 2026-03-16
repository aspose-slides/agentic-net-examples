using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Apply3DProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the existing presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                        // Apply depth and extrusion properties if the shape supports 3D formatting
                        shape.ThreeDFormat.Depth = 15.0;
                        shape.ThreeDFormat.ExtrusionHeight = 30.0;
                    }
                }

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Aspose.Slides.PptxReadException readEx)
            {
                Console.WriteLine("Error reading the presentation: " + readEx.Message);
            }
            catch (Aspose.Slides.PptxEditException editEx)
            {
                Console.WriteLine("Error editing the presentation: " + editEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
        }
    }
}