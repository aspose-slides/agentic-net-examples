using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "LineJoinMiter.pptx";

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a line shape to the slide
                Aspose.Slides.IAutoShape lineShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Line, 100, 100, 300, 0);

                // Set line join style to Miter
                lineShape.LineFormat.JoinStyle = Aspose.Slides.LineJoinStyle.Miter;

                // Optionally set line width
                lineShape.LineFormat.Width = 5;

                // Retrieve effective line format data
                Aspose.Slides.ILineFormatEffectiveData effectiveData = lineShape.LineFormat.GetEffective();

                // Verify the miter limit (read‑only property)
                float miterLimit = effectiveData.MiterLimit;
                Console.WriteLine("Effective Miter Limit: " + miterLimit);

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found: " + ex.Message);
            }
            catch (NotSupportedException ex)
            {
                // Format not supported
                Console.WriteLine("Format not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}