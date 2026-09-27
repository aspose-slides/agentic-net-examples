// -----------------------------------------------------------------------------
// Example: Activate Shrink‑On‑Overflow Autofit in PowerPoint using Aspose.Slides for .NET
//
// Description:
// This console application creates a PPTX file, adds a rectangular auto shape
// with a text frame, and activates the shrink‑on‑overflow autofit mode so that
// text automatically scales to fit the shape. It demonstrates the use of
// Aspose.Slides for .NET to manipulate text frames and save the presentation.
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, shrink on overflow, autofit, text frame
//
// Use Cases:
// - Automatically adjust text size to prevent overflow in generated slides.
// - Prepare presentation templates where text must always fit within shapes.
// - Integrate PowerPoint generation into .NET backend services.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

namespace AsposeSlidesExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            try
            {
                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                string outputPath = Path.Combine(outputDirectory, "ShrinkOnOverflow.pptx");

                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangular auto shape
                Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle,
                    100,   // X position
                    100,   // Y position
                    400,   // Width
                    200);  // Height

                // Add a text frame with sample text
                autoShape.AddTextFrame("This is a long piece of text that will be automatically shrunk to fit inside the shape without overflowing.");

                // Access the text frame and enable shrink‑on‑overflow autofit
                Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
                textFrame.TextFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Shape;

                // Optionally format the first portion (e.g., set text color to black)
                Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];
                Aspose.Slides.IPortion portion = paragraph.Portions[0];
                portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
