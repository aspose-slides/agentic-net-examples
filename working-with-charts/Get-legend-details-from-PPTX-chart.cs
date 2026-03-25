using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartLegendInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                    Console.WriteLine($"Slide {slideIndex + 1}:");

                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                        Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
                        if (chart != null)
                        {
                            chart.ValidateChartLayout();
                            Aspose.Slides.Charts.ILegend legend = chart.Legend;

                            Console.WriteLine($"  Chart {shapeIndex + 1}:");
                            Console.WriteLine($"    Legend Position: {legend.Position}");
                            Console.WriteLine($"    Legend Overlay: {legend.Overlay}");
                            Console.WriteLine($"    Legend X (fraction of chart width): {legend.X}");
                            Console.WriteLine($"    Legend Y (fraction of chart height): {legend.Y}");
                            Console.WriteLine($"    Legend Width (fraction of chart width): {legend.Width}");
                            Console.WriteLine($"    Legend Height (fraction of chart height): {legend.Height}");
                            Console.WriteLine($"    Legend Actual X: {legend.ActualX}");
                            Console.WriteLine($"    Legend Actual Y: {legend.ActualY}");
                            Console.WriteLine($"    Legend Actual Width: {legend.ActualWidth}");
                            Console.WriteLine($"    Legend Actual Height: {legend.ActualHeight}");
                            Console.WriteLine($"    Legend Text Font Height: {legend.TextFormat.PortionFormat.FontHeight}");
                        }
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Processing completed. Presentation saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}