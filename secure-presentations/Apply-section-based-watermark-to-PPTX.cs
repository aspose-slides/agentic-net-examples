using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ApplySectionBasedWatermark
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input file path
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Verify that the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation with exception handling for unsupported formats
            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through each section in the presentation
                    for (int sectionIndex = 0; sectionIndex < presentation.Sections.Count; sectionIndex++)
                    {
                        ISection section = presentation.Sections[sectionIndex];
                        string sectionName = section.Name;

                        // Determine watermark text based on section title
                        string watermarkText = sectionName.IndexOf("Confidential", StringComparison.OrdinalIgnoreCase) >= 0
                            ? "CONFIDENTIAL"
                            : "Sample Watermark";

                        // Get all slides belonging to the current section
                        ISectionSlideCollection slidesInSection = section.GetSlidesListOfSection();

                        // Apply watermark to each slide in the section
                        for (int i = 0; i < slidesInSection.Count; i++)
                        {
                            ISlide slide = slidesInSection[i];

                            // Add an AutoShape to act as watermark
                            IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
                                ShapeType.Rectangle, 50, 50, 400, 100);

                            // Add a TextFrame with the watermark text
                            watermarkShape.AddTextFrame(watermarkText);

                            // Optional: set transparency or formatting here if needed
                        }
                    }

                    // Save the modified presentation
                    string outputPath = "output.pptx";
                    presentation.Save(outputPath, SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved to: " + outputPath);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported for PPTX
                Console.WriteLine("The file format is not supported (PPTX).");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Format not supported for PPT
                Console.WriteLine("The file format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., network errors if external resources are used)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}