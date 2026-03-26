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
            if (args.Length > 0)
            {
                inputPath = args[0];
            }

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("File not found: " + inputPath);
                return;
            }

            Presentation presentation = new Presentation(inputPath);
            int slideCount = presentation.Slides.Count;

            for (int i = 0; i < slideCount; i++)
            {
                ISlide slide = presentation.Slides[i];
                int shapeCount = slide.Shapes.Count;
                for (int j = 0; j < shapeCount; j++)
                {
                    IChart chart = slide.Shapes[j] as IChart;
                    if (chart != null)
                    {
                        chart.ValidateChartLayout();
                        ILegend legend = chart.Legend;
                        Console.WriteLine($"Slide {i + 1}, Chart {j + 1}:");
                        Console.WriteLine($"  Has Legend: {chart.HasLegend}");
                        Console.WriteLine($"  Legend Position Enum: {legend.Position}");
                        Console.WriteLine($"  Legend Overlay: {legend.Overlay}");
                        Console.WriteLine($"  Legend X (fraction): {legend.X}");
                        Console.WriteLine($"  Legend Y (fraction): {legend.Y}");
                        Console.WriteLine($"  Legend Width (fraction): {legend.Width}");
                        Console.WriteLine($"  Legend Height (fraction): {legend.Height}");
                        Console.WriteLine($"  Legend Actual X: {legend.ActualX}");
                        Console.WriteLine($"  Legend Actual Y: {legend.ActualY}");
                        Console.WriteLine($"  Legend Actual Width: {legend.ActualWidth}");
                        Console.WriteLine($"  Legend Actual Height: {legend.ActualHeight}");
                        Console.WriteLine($"  Legend Font Height: {legend.TextFormat.PortionFormat.FontHeight}");
                    }
                }
            }

            string outputPath = "output.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}