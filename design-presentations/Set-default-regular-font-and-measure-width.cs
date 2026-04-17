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
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Set default regular font to a sans‑serif typeface using LoadOptions
                LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
                loadOptions.DefaultRegularFont = "Arial";

                // Load the presentation with the specified load options
                Presentation pres = new Presentation(inputPath, loadOptions);

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a rectangle auto shape
                IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);

                // Add a text frame with sample text
                shape.AddTextFrame("Sample text for width measurement");

                // Retrieve the text portion
                IPortion portion = shape.TextFrame.Paragraphs[0].Portions[0];

                // Simple width estimation: character count * average character width (approx. 0.5 * font height)
                float fontHeight = portion.PortionFormat.FontHeight;
                int charCount = portion.Text.Length;
                float estimatedWidth = charCount * (fontHeight * 0.5f);

                Console.WriteLine("Estimated text width: " + estimatedWidth + " points");

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}