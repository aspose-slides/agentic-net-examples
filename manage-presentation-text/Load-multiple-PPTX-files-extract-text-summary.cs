using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace PresentationTextSummary
{
    class Program
    {
        static void Main(string[] args)
        {
            // Directory containing PPT files
            string inputDirectory = "InputPresentations";
            // Output summary text file
            string summaryFilePath = "PresentationSummary.txt";
            // Output summary presentation file
            string summaryPresentationPath = "PresentationSummary.pptx";

            // Check if the input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine("Input directory does not exist: " + inputDirectory);
                return;
            }

            // Prepare a StringBuilder for the summary report
            StringBuilder reportBuilder = new StringBuilder();

            // Get all supported presentation files in the directory
            string[] presentationFiles = Directory.GetFiles(inputDirectory, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string filePath in presentationFiles)
            {
                string extension = Path.GetExtension(filePath).ToLowerInvariant();
                if (extension != ".ppt" && extension != ".pptx" && extension != ".odp")
                {
                    // Skip unsupported extensions
                    continue;
                }

                try
                {
                    // Extract raw text from the presentation using Unarranged mode
                    IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(
                        filePath,
                        Aspose.Slides.TextExtractionArrangingMode.Unarranged);

                    // Build text for this file
                    reportBuilder.AppendLine("File: " + Path.GetFileName(filePath));
                    foreach (ISlideText slideText in presentationText.SlidesText)
                    {
                        if (!string.IsNullOrEmpty(slideText.Text))
                        {
                            reportBuilder.AppendLine(slideText.Text);
                        }
                    }
                    reportBuilder.AppendLine(new string('-', 40));
                }
                catch (Aspose.Slides.PptxUnsupportedFormatException)
                {
                    // Handle PPTX unsupported format
                    Console.WriteLine("Unsupported PPTX format: " + filePath);
                }
                catch (Aspose.Slides.PptUnsupportedFormatException)
                {
                    // Handle PPT unsupported format
                    Console.WriteLine("Unsupported PPT format: " + filePath);
                }
                catch (Exception ex)
                {
                    // General exception handling (e.g., file access issues)
                    Console.WriteLine("Error processing file '" + filePath + "': " + ex.Message);
                }
            }

            // Write the summary report to a text file
            try
            {
                File.WriteAllText(summaryFilePath, reportBuilder.ToString());
                Console.WriteLine("Summary report written to: " + summaryFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to write summary file: " + ex.Message);
            }

            // Create a presentation that contains the summary text
            try
            {
                Presentation summaryPresentation = new Presentation();
                // Use the first slide (already present) to add the summary
                IAutoShape textShape = summaryPresentation.Slides[0].Shapes.AddAutoShape(
                    ShapeType.Rectangle,
                    50,
                    50,
                    600,
                    400);
                textShape.AddTextFrame(reportBuilder.ToString());
                // Save the summary presentation
                summaryPresentation.Save(summaryPresentationPath, SaveFormat.Pptx);
                // Dispose the presentation (handled by using statement is not used per lifecycle rule)
                summaryPresentation.Dispose();
                Console.WriteLine("Summary presentation saved to: " + summaryPresentationPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create summary presentation: " + ex.Message);
            }
        }
    }
}