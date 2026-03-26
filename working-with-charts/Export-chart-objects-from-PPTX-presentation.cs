using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ExportCharts
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Directory to store exported chart images and data
            string outputDirectory = "ExportedCharts";
            Directory.CreateDirectory(outputDirectory);

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                int chartCounter = 0;

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IChart chart = slide.Shapes[shapeIndex] as IChart;
                        if (chart != null)
                        {
                            // Export chart as an image (PNG)
                            IImage chartImage = chart.GetImage();
                            string imagePath = Path.Combine(outputDirectory, $"chart_{chartCounter}.png");
                            chartImage.Save(imagePath, Aspose.Slides.ImageFormat.Png);

                            // Export chart data workbook (XLSX)
                            IChartData chartData = chart.ChartData;
                            using (MemoryStream workbookStream = new MemoryStream())
                            {
                                chartData.ReadWorkbookStream().CopyTo(workbookStream);
                                string workbookPath = Path.Combine(outputDirectory, $"chart_{chartCounter}.xlsx");
                                File.WriteAllBytes(workbookPath, workbookStream.ToArray());
                            }

                            chartCounter++;
                        }
                    }
                }

                // Save the (potentially unchanged) presentation before exiting
                string outputPresentationPath = Path.Combine(outputDirectory, "presentation_out.pptx");
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);
            }
        }
    }
}