using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Prepare output directory
        string outputDir = Path.Combine(Environment.CurrentDirectory, "Output");
        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);
        string outputPdfPath = Path.Combine(outputDir, "CombinedNotes.pdf");

        // Destination presentation that will hold all notes
        Presentation destPres = new Presentation();

        // Input presentation files (could be supplied via args)
        string[] inputFiles = new string[] { "Presentation1.pptx", "Presentation2.pptx" };

        foreach (string inputFile in inputFiles)
        {
            try
            {
                // Verify file existence
                if (!File.Exists(inputFile))
                {
                    Console.WriteLine($"File not found: {inputFile}");
                    continue;
                }

                // Load source presentation
                Presentation srcPres = new Presentation(inputFile);

                // Clone each slide (including its notes) into the destination
                for (int i = 0; i < srcPres.Slides.Count; i++)
                {
                    destPres.Slides.AddClone(srcPres.Slides[i]);
                }

                srcPres.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine($"Format not supported for file: {inputFile}");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine($"Error processing file {inputFile}: {ex.Message}");
            }
        }

        // Configure PDF options to include notes at the bottom
        PdfOptions pdfOptions = new PdfOptions();
        pdfOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions()
        {
            NotesPosition = NotesPositions.BottomFull
        };

        // Save the combined presentation as a PDF
        destPres.Save(outputPdfPath, SaveFormat.Pdf, pdfOptions);
        destPres.Dispose();
    }
}