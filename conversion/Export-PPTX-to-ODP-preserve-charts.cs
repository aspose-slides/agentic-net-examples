// -----------------------------------------------------------------------------
// Example: Export PPTX to ODP Preserving Charts Using Aspose.Slides for .NET
//
// Description:
// This console application loads an existing PowerPoint PPTX file, then
// converts and saves it as an OpenDocument Presentation (ODP) file while
// preserving all chart objects. It demonstrates the use of Aspose.Slides for
// .NET to perform format conversion with chart fidelity, suitable for batch
// processing or automated workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, ODP, Aspose.Slides for .NET, chart conversion, format export
//
// Use Cases:
// - Convert corporate slide decks from PPTX to ODP for use with LibreOffice.
// - Automate batch conversion of presentations while retaining chart data.
// - Integrate PPTX to ODP conversion into CI/CD pipelines for documentation.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;

class Program
{
    static void Main(string[] args)
    {
        // Validate arguments
        if (args.Length < 1)
        {
            Console.WriteLine("Usage: ExportPptxToOdp <input-pptx-path> [output-odp-path]");
            return;
        }

        string inputPath = args[0];
        string outputPath;

        if (args.Length >= 2)
        {
            outputPath = args[1];
        }
        else
        {
            string inputDirectory = System.IO.Path.GetDirectoryName(inputPath);
            string inputFileNameWithoutExt = System.IO.Path.GetFileNameWithoutExtension(inputPath);
            outputPath = System.IO.Path.Combine(inputDirectory, inputFileNameWithoutExt + ".odp");
        }

        // Check if input file exists
        if (!System.IO.File.Exists(inputPath))
        {
            Console.WriteLine($"Error: Input file \"{inputPath}\" does not exist.");
            return;
        }

        try
        {
            // Load the PPTX presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Save as ODP format. Charts are preserved by default.
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Odp);

            Console.WriteLine($"Successfully exported \"{inputPath}\" to ODP format at \"{outputPath}\".");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}
