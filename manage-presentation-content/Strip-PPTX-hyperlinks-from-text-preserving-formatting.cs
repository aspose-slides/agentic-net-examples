using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveHyperlinksExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output file paths
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Remove all hyperlinks from the presentation
                    presentation.HyperlinkQueries.RemoveAllHyperlinks();

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Output any errors that occur
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}