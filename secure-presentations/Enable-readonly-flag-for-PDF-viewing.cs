using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Define output folder and ensure it exists
            var outputFolder = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Output");
            if (!System.IO.Directory.Exists(outputFolder))
                System.IO.Directory.CreateDirectory(outputFolder);

            // Define output file path
            var outputPath = System.IO.Path.Combine(outputFolder, "ReadOnlyPresentation.pptx");

            // Create a new presentation and set it as read‑only recommended
            var presentation = new Aspose.Slides.Presentation();
            presentation.ProtectionManager.ReadOnlyRecommended = true;

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();

            Console.WriteLine("Presentation saved as read‑only at: " + outputPath);
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format, I/O issues)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}