using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.swf");

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Add a rectangle shape with a JavaScript hyperlink to act as a bridge
            ISlide slide = presentation.Slides[0];
            IAutoShape shape = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 50);
            shape.AddTextFrame("Click me");
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("javascript:alert('SlideChanged');");

            // Configure SWF export options to include JavaScript links
            SwfOptions options = new SwfOptions();
            options.SkipJavaScriptLinks = false; // Do not skip JavaScript links

            // Save the presentation as SWF
            presentation.Save(outputPath, SaveFormat.Swf, options);

            // Dispose the presentation
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle errors (e.g., unsupported format)
            Console.WriteLine("An error occurred: " + ex.Message);
            // Format not supported: comment added above
        }
    }
}