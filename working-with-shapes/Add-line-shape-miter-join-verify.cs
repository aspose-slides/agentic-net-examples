using System;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            try
            {
                // Add a line shape to the first slide
                Aspose.Slides.IAutoShape lineShape = (Aspose.Slides.IAutoShape)presentation.Slides[0].Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);

                // Set the line join style to Miter
                lineShape.LineFormat.JoinStyle = Aspose.Slides.LineJoinStyle.Miter;

                // Optionally set a custom miter limit
                lineShape.LineFormat.MiterLimit = 10f;

                // Retrieve effective line format data
                Aspose.Slides.ILineFormatEffectiveData effectiveData = lineShape.LineFormat.GetEffective();

                // Verify the join style and miter limit
                Console.WriteLine("Effective JoinStyle: " + effectiveData.JoinStyle);
                Console.WriteLine("Effective MiterLimit: " + effectiveData.MiterLimit);
                
                // Save the presentation
                presentation.Save("LineJoinMiterDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException ex)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                // Ensure the presentation is disposed
                presentation.Dispose();
            }
        }
    }
}