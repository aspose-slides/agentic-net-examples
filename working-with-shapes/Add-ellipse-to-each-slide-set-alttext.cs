using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchEllipse
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add additional slides for demonstration
            for (int i = 0; i < 2; i++)
            {
                presentation.Slides.AddClone(presentation.Slides[0]);
            }

            // Iterate through each slide and add an ellipse with sequential AltText
            int shapeId = 1;
            foreach (ISlide slide in presentation.Slides)
            {
                IAutoShape ellipse = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 100, 200, 100);
                ellipse.AlternativeText = "Ellipse_" + shapeId;
                shapeId++;
            }

            // Define output path
            string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Output");
            if (!System.IO.Directory.Exists(outputDir))
            {
                System.IO.Directory.CreateDirectory(outputDir);
            }
            string outPath = System.IO.Path.Combine(outputDir, "BatchEllipse_out.pptx");

            // Save presentation with exception handling for unsupported format
            try
            {
                presentation.Save(outPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Format not supported or other save error
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}