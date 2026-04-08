using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output directory and file name
        string outputDir = "Output";
        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);
        string outPath = Path.Combine(outputDir, "NewPresentation.pptx");

        // Create a new presentation
        Presentation presentation = new Presentation();

        // Set Subject and Keywords
        presentation.DocumentProperties.Subject = "Sample Subject";
        presentation.DocumentProperties.Keywords = "Sample Keywords";

        try
        {
            // Save as PPTX
            presentation.Save(outPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        finally
        {
            // Dispose presentation
            presentation.Dispose();
        }
    }
}