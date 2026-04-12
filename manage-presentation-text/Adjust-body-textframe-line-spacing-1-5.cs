using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace AdjustLineSpacing
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
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                // Format not supported comment
                // The provided file format is not supported by Aspose.Slides.
                return;
            }

            // Retrieve all text frames in the presentation (excluding masters)
            ITextFrame[] textFrames = SlideUtil.GetAllTextFrames(presentation, false);

            // Adjust line spacing for each paragraph in each text frame
            foreach (ITextFrame textFrame in textFrames)
            {
                foreach (IParagraph paragraph in textFrame.Paragraphs)
                {
                    // Set line spacing to 1.5 (represented as 150%)
                    paragraph.ParagraphFormat.SpaceWithin = 150;
                    // Optional: reset additional spacing
                    paragraph.ParagraphFormat.SpaceBefore = 0;
                    paragraph.ParagraphFormat.SpaceAfter = 0;
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}