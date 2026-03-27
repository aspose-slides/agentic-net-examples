using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddHyperlinksToSlides
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!System.IO.File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through each slide and add a hyperlink text box
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];

                // Add a rectangle auto shape to the slide
                Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle,
                    50,   // X position
                    50,   // Y position
                    200,  // Width
                    50,   // Height
                    false // isGrouped
                );

                // Add a text frame with display text
                shape.AddTextFrame("Click Here");

                // Set the hyperlink for the text portion
                shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Aspose.Slides.Hyperlink("http://example.com");
                shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Go to example website";

                // Set font size for better visibility
                shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 14;
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();

            Console.WriteLine("Presentation saved with hyperlinks to: " + outputPath);
        }
    }
}