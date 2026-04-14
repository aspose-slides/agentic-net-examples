using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartLegendBranding
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                Presentation presentation = new Presentation(inputPath);

                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];

                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];

                        if (shape is IChart)
                        {
                            IChart chart = (IChart)shape;

                            // Ensure legend is visible
                            chart.HasLegend = true;

                            // Adjust legend to match branding guidelines
                            ILegend legend = chart.Legend;
                            legend.Position = LegendPositionType.Bottom;
                            legend.X = 0.1f;      // 10% from left
                            legend.Y = 0.9f;      // 90% from top
                            legend.Width = 0.8f;  // 80% width of chart
                            legend.Height = 0.1f; // 10% height of chart

                            // Set legend font size
                            legend.TextFormat.PortionFormat.FontHeight = 12f;
                        }
                    }
                }

                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // If the file format is not supported, an exception will be thrown.
                // Format not supported.
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}