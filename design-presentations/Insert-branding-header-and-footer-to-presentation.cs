using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output file paths
            string dataDir = "Data";
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Custom header and footer text
                string headerText = "Company Header";
                string footerText = "Company Footer";

                // Apply header and footer to all slides
                presentation.HeaderFooterManager.SetAllHeadersText(headerText);
                presentation.HeaderFooterManager.SetAllHeadersVisibility(true);
                presentation.HeaderFooterManager.SetAllFootersText(footerText);
                presentation.HeaderFooterManager.SetAllFootersVisibility(true);

                // Save the updated presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}