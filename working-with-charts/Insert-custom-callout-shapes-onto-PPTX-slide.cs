using System;
using System.IO;
using Aspose.Slides.Export;
using System.Drawing;

namespace CalloutExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a callout shape with specified position and size
                Aspose.Slides.IAutoShape callout = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Callout1, // Callout shape type
                    100, // X position
                    100, // Y position
                    300, // Width
                    100  // Height
                );

                // Set the annotation text
                callout.TextFrame.Text = "Annotation text";

                // Set fill color of the callout
                callout.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                callout.FillFormat.SolidFillColor.Color = Color.Yellow;

                // Set line color and width of the callout
                callout.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                callout.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
                callout.LineFormat.Width = 2;

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}