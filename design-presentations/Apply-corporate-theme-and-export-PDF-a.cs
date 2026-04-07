using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CorporateThemeBatch
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input presentation files
            string[] inputFiles = new string[]
            {
                "Presentation1.pptx",
                "Presentation2.pptx"
                // Add more file paths as needed
            };

            // Path to the external corporate theme file (.thmx)
            string themePath = "CorporateTheme.thmx";

            // Output directory for PDF/A files
            string outputDir = "OutputPdfA";

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Process each presentation
            foreach (string inputPath in inputFiles)
            {
                // Check if the input file exists
                if (!File.Exists(inputPath))
                {
                    // Input file not found; skip to next
                    continue;
                }

                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Apply the external theme to all master slides
                    foreach (IMasterSlide masterSlide in presentation.Masters)
                    {
                        try
                        {
                            masterSlide.ApplyExternalThemeToDependingSlides(themePath);
                        }
                        catch (PptxReadException)
                        {
                            // Theme could not be applied; continue with next master slide
                        }
                    }

                    // Configure PDF/A export options
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.Compliance = PdfCompliance.PdfA1b; // PDF/A-1b compliance
                    pdfOptions.IncludeOleData = true; // Include OLE data if present

                    // Determine output PDF file path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                    string outputPath = Path.Combine(outputDir, outputFileName);

                    try
                    {
                        // Save the presentation as PDF/A
                        presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
                    }
                    catch (NotSupportedException)
                    {
                        // Format not supported; handle accordingly
                    }
                }
            }
        }
    }
}