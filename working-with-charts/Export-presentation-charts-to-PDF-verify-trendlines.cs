using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ExportChartsToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pdf";

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
                    // Iterate through all slides and shapes to find charts
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            if (slide.Shapes[shapeIndex] is IChart)
                            {
                                IChart chart = (IChart)slide.Shapes[shapeIndex];

                                // Verify if the chart type supports trend lines
                                bool supportsTrendLines = ChartTypeCharacterizer.HasSeriesTrendLines(chart.Type);
                                Console.WriteLine("Slide " + (slideIndex + 1) + " Chart Type: " + chart.Type + " Supports Trend Lines: " + supportsTrendLines);
                            }
                        }
                    }

                    // Create PDF export options (default options are sufficient for this example)
                    PdfOptions pdfOptions = new PdfOptions();

                    // Save the presentation as a single PDF file
                    presentation.Save(outputPath, SaveFormat.Pdf, pdfOptions);
                }
            }
            catch (PptUnsupportedFormatException)
            {
                // Format not supported comment
                Console.WriteLine("The presentation format is not supported for PDF export.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL or web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}