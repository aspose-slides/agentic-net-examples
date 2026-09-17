// -----------------------------------------------------------------------------
// Example: Compress PPTX Presentation While Preserving Embedded 3D Assets
//
// Description:
// This console application loads a PowerPoint PPTX file, compresses embedded
// fonts to reduce file size while keeping all embedded 3D assets intact, and
// saves the presentation using Zip64 mode for efficient distribution. It
// validates input file existence and handles any runtime exceptions.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, compress presentation, embedded 3D, Zip64
//
// Use Cases:
// - Reducing the size of large presentations that contain 3D models before sharing.
// - Preparing PPTX files for web upload where bandwidth is limited.
// - Automating batch compression of presentations in a CI/CD pipeline.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
class Program
{
    static void Main(string[] args)
    {
        string inputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "input.pptx");
        string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output_compressed.pptx");

        if (!System.IO.File.Exists(inputPath))
        {
            System.Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Compress embedded fonts; this does not affect embedded 3D assets.
            Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(presentation);

            // Save using Zip64 mode to handle large files efficiently.
            Aspose.Slides.Export.PptxOptions saveOptions = new Aspose.Slides.Export.PptxOptions();
            saveOptions.Zip64Mode = Aspose.Slides.Export.Zip64Mode.Always;

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx, saveOptions);
            presentation.Dispose();

            System.Console.WriteLine("Presentation compressed and saved to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error during compression: " + ex.Message);
        }
    }
}
