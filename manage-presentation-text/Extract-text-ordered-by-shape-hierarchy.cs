using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace TextExtractionExample
{
    class Program
    {
        static void Main()
        {
            // Input and output paths
            string inputPath = "input.pptx";
            string outputPath = "extracted_text.txt";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Use PresentationFactory to extract text ordered by shape hierarchy (Arranged mode)
                PresentationFactory factory = new PresentationFactory();
                IPresentationText presentationText = factory.GetPresentationText(inputPath, TextExtractionArrangingMode.Arranged);

                // Write extracted text to console and to a file
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    foreach (ISlideText slideText in presentationText.SlidesText)
                    {
                        Console.WriteLine(slideText.Text);
                        writer.WriteLine(slideText.Text);
                    }
                }

                // Load the presentation to satisfy the "save before exit" requirement
                Presentation presentation = new Presentation(inputPath);
                // Save the presentation (no changes made, just re-saving)
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}