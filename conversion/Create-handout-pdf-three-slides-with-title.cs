using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HandoutPdfExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = "handout.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Set header text on the master handout slide (if it exists)
                    IMasterHandoutSlide masterHandout = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
                    if (masterHandout != null)
                    {
                        // HeaderFooterManager is of type MasterHandoutSlideHeaderFooterManager
                        MasterHandoutSlideHeaderFooterManager headerManager = (MasterHandoutSlideHeaderFooterManager)masterHandout.HeaderFooterManager;
                        headerManager.SetHeaderVisibility(true);
                        string title = presentation.DocumentProperties.Title;
                        if (string.IsNullOrEmpty(title))
                        {
                            title = Path.GetFileNameWithoutExtension(inputPath);
                        }
                        headerManager.SetHeaderText(title);
                    }

                    // Configure PDF options for three slides per page handout
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.SlidesLayoutOptions = new HandoutLayoutingOptions
                    {
                        Handout = HandoutType.Handouts3 // Three slides per page
                    };

                    // Save the handout PDF
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
                }

                Console.WriteLine("Handout PDF created successfully: " + outputPath);
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Handle unsupported PPTX format
                Console.WriteLine("The PPTX format of the input file is not supported.");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Handle unsupported PPT format
                Console.WriteLine("The PPT format of the input file is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}