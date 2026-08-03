// -----------------------------------------------------------------------------
// Example: Set custom bullet character using unicode using C#
//
// Description:
// Demonstrates how to set a custom bullet character using Unicode in a text
// paragraph with Aspose.Slides for .NET. The example creates or loads a PPTX
// file, adds a rectangle shape with a text frame, configures the paragraph to
// use a Symbol bullet type, assigns the Unicode bullet character (U+2022 •),
// and saves the presentation. This pattern helps developers automate PPTX
// workflows that require custom bullet styling.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Custom Bullet, Unicode Character,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting custom Unicode bullet characters in PowerPoint slides.
// - Build .NET tools for presentation content styling and processing.
// - Generate or modify PPTX files with specific bullet formatting.
// - Validate bullet character rendering before publishing presentations.
// -----------------------------------------------------------------------------
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
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist. Creating a new presentation.");
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Get the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add a rectangle shape with a text frame
                    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
                    shape.AddTextFrame("Sample bullet text");

                    // Access the first paragraph
                    IParagraph paragraph = shape.TextFrame.Paragraphs[0];

                    // Set bullet type to Symbol and assign a custom Unicode bullet character (e.g., U+2022 •)
                    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
                    paragraph.ParagraphFormat.Bullet.Char = '\u2022';

                    // Save the presentation
                    try
                    {
                        presentation.Save(outputPath, SaveFormat.Pptx);
                        Console.WriteLine("Presentation saved to " + outputPath);
                    }
                    catch (NotSupportedException)
                    {
                        // Format not supported
                        Console.WriteLine("The specified save format is not supported.");
                    }
                }
            }
            else
            {
                // Load existing presentation
                try
                {
                    using (Presentation presentation = new Presentation(inputPath))
                    {
                        // Get the first slide
                        ISlide slide = presentation.Slides[0];

                        // Add a rectangle shape with a text frame
                        IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
                        shape.AddTextFrame("Sample bullet text");

                        // Access the first paragraph
                        IParagraph paragraph = shape.TextFrame.Paragraphs[0];

                        // Set bullet type to Symbol and assign a custom Unicode bullet character (e.g., U+2022 •)
                        paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
                        paragraph.ParagraphFormat.Bullet.Char = '\u2022';

                        // Save the presentation
                        presentation.Save(outputPath, SaveFormat.Pptx);
                        Console.WriteLine("Presentation saved to " + outputPath);
                    }
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine("The specified file format is not supported.");
                }
                catch (Exception ex)
                {
                    // General exception handling (e.g., file access issues)
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }
    }
}
