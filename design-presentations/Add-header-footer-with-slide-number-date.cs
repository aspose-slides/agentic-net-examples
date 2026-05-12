using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddHeaderFooter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
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
                    // Set the current date/time for date-time placeholders (optional)
                    presentation.CurrentDateTime = DateTime.Now;

                    // Iterate through each slide and configure header/footer
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        ISlideHeaderFooterManager headerFooter = slide.HeaderFooterManager;

                        // Ensure footer placeholder is visible and set custom text
                        if (!headerFooter.IsFooterVisible)
                        {
                            headerFooter.SetFooterVisibility(true);
                        }
                        headerFooter.SetFooterText("Custom Footer Text");

                        // Ensure date-time placeholder is visible and set current date
                        if (!headerFooter.IsDateTimeVisible)
                        {
                            headerFooter.SetDateTimeVisibility(true);
                        }
                        headerFooter.SetDateTimeText(DateTime.Now.ToString("D"));

                        // Ensure slide number placeholder is visible
                        if (!headerFooter.IsSlideNumberVisible)
                        {
                            headerFooter.SetSlideNumberVisibility(true);
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // The file format is not supported for PPTX
                Console.WriteLine("The input file format is not supported (PPTX).");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // The file format is not supported for PPT
                Console.WriteLine("The input file format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}