using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input and output files
            string inputPath = "input.pptx";
            string outputPath = "output.ppt";

            // Load existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access document properties
            Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

            // Modify built‑in properties
            docProps.Author = "John Doe";
            docProps.Title = "Custom Presentation";
            docProps.Subject = "Demo";

            // Add custom properties
            docProps.SetCustomPropertyValue("Project", "AsposeDemo");
            docProps.SetCustomPropertyValue("Version", 2);
            docProps.SetCustomPropertyValue("Reviewed", true);
            docProps.SetCustomPropertyValue("ReviewDate", DateTime.UtcNow);

            // Save the presentation (preserving existing slides)
            presentation.Save(outputPath, SaveFormat.Ppt);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}