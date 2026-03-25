using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CalloutExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found - " + inputPath);
                return;
            }

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a callout shape to annotate content
                Aspose.Slides.IAutoShape calloutShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Callout1, // Callout shape type
                    150,   // X position
                    150,   // Y position
                    300,   // Width
                    100);  // Height

                // Add text to the callout
                calloutShape.AddTextFrame("Important Note");

                // Optional: customize appearance
                calloutShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                calloutShape.FillFormat.SolidFillColor.Color = System.Drawing.Color.Yellow;
                calloutShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                calloutShape.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;
                calloutShape.LineFormat.Width = 2;

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }

            Console.WriteLine("Presentation saved to " + outputPath);
        }
    }
}