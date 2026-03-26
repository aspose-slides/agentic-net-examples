using System;
using System.IO;
using System.Drawing;
using Aspose.Slides.Export;

namespace BubbleShapeStyling
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load existing presentation if it exists; otherwise create a new one
            Aspose.Slides.Presentation presentation;
            if (File.Exists(inputPath))
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();
            }

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a bubble (ellipse) shape
            Aspose.Slides.IAutoShape bubbleShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Ellipse,
                150,   // X position
                100,   // Y position
                300,   // Width
                200);  // Height

            // Set solid fill color for the bubble
            bubbleShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            bubbleShape.FillFormat.SolidFillColor.Color = Color.FromArgb(255, 135, 206, 250); // Light sky blue

            // Customize the border (line) of the bubble
            bubbleShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            bubbleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(255, 30, 144, 255); // Dodger blue
            bubbleShape.LineFormat.Width = 3; // Border thickness

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}