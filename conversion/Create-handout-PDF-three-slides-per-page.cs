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
            string inputPath = "input.pptx";
            string outputPath = "handout.pdf";

            // Verify input file existence
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Set a header with the presentation title (placeholder - actual implementation may vary)
                    // Example: using the master handout slide's header/footer manager
                    // IMasterHandoutSlide masterHandout = presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();
                    // if (masterHandout != null && masterHandout.HeaderFooterManager != null)
                    // {
                    //     masterHandout.HeaderFooterManager.SetHeaderFooterText(presentation.DocumentProperties.Title, null);
                    // }

                    // Configure PDF export options for three slides per page handout
                    PdfOptions pdfOptions = new PdfOptions
                    {
                        SlidesLayoutOptions = new HandoutLayoutingOptions
                        {
                            Handout = HandoutType.Handouts3
                        }
                    };

                    // Save the handout PDF
                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
                }

                Console.WriteLine("Handout PDF created successfully: " + outputPath);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}