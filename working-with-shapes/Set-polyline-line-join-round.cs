// -----------------------------------------------------------------------------
// Example: Set Polyline Line Join Style to Round using Aspose.Slides
//
// Description:
// This console application creates a new PowerPoint presentation, adds a line
// shape (used as a polyline placeholder) to the first slide, configures the
// line join style to round, and saves the result as a PPTX file. It demonstrates
// how to manipulate line formatting with Aspose.Slides for .NET.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, line join style, round join, polyline
//
// Use Cases:
// - Automating slide generation with specific line join configurations.
// - Preparing presentation assets for graphic design workflows.
// - Generating technical diagrams where rounded line joins are required.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

namespace AsposeSlidesPolylineJoinRound
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "PolylineJoinRound.pptx";

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a line shape (used as a polyline placeholder)
                Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Line,
                    100,   // X position
                    100,   // Y position
                    300,   // Width
                    0      // Height (zero height creates a straight line)
                );

                // Configure line formatting
                shape.LineFormat.Width = 5;
                shape.LineFormat.JoinStyle = Aspose.Slides.LineJoinStyle.Round;
                shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + Path.GetFullPath(outputPath));
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
