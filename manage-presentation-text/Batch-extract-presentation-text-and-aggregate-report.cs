using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchTextExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            // Directory containing presentations
            string dataDirectory = Directory.GetCurrentDirectory();

            // Collect supported presentation files
            string[] pptxFiles = Directory.GetFiles(dataDirectory, "*.pptx");
            string[] pptFiles = Directory.GetFiles(dataDirectory, "*.ppt");
            string[] allFiles = new string[pptxFiles.Length + pptFiles.Length];
            pptxFiles.CopyTo(allFiles, 0);
            pptFiles.CopyTo(allFiles, pptxFiles.Length);

            // Aggregate extracted text
            StringBuilder reportBuilder = new StringBuilder();

            foreach (string filePath in allFiles)
            {
                // Verify file existence
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File not found: " + filePath);
                    continue;
                }

                try
                {
                    // Extract raw text without arranging
                    Aspose.Slides.IPresentationText presentationText = Aspose.Slides.PresentationFactory.Instance.GetPresentationText(
                        filePath,
                        Aspose.Slides.TextExtractionArrangingMode.Unarranged);

                    reportBuilder.AppendLine("=== File: " + Path.GetFileName(filePath) + " ===");

                    for (int i = 0; i < presentationText.SlidesText.Length; i++)
                    {
                        Aspose.Slides.ISlideText slideText = presentationText.SlidesText[i];
                        string slideContent = slideText.Text;
                        reportBuilder.AppendLine($"--- Slide {i + 1} ---");
                        reportBuilder.AppendLine(slideContent);
                        reportBuilder.AppendLine();
                    }
                }
                catch (Aspose.Slides.PptxUnsupportedFormatException)
                {
                    // Format not supported for PPTX
                    Console.WriteLine("Unsupported PPTX format: " + filePath);
                }
                catch (Aspose.Slides.PptUnsupportedFormatException)
                {
                    // Format not supported for PPT
                    Console.WriteLine("Unsupported PPT format: " + filePath);
                }
                catch (Exception ex)
                {
                    // General exception handling
                    Console.WriteLine("Error processing file " + filePath + ": " + ex.Message);
                }
            }

            // Create a new presentation to hold the aggregated report
            Aspose.Slides.Presentation reportPresentation = new Aspose.Slides.Presentation();

            // Use the first slide (created by default) as the report slide
            Aspose.Slides.ISlide reportSlide = reportPresentation.Slides[0];

            // Add a rectangle shape covering the whole slide
            Aspose.Slides.IShape shape = reportSlide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                0,
                0,
                reportPresentation.SlideSize.Size.Width,
                reportPresentation.SlideSize.Size.Height);

            // Cast to AutoShape to add a text frame
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
            autoShape.AddTextFrame(reportBuilder.ToString());

            // Save the aggregated report presentation
            string reportPath = Path.Combine(dataDirectory, "AggregatedReport.pptx");
            reportPresentation.Save(reportPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}