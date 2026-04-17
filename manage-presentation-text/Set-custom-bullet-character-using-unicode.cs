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