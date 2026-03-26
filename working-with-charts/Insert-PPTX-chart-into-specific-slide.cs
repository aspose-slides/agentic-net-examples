using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace InsertChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input and output files
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input presentation exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Ensure the output directory exists to avoid DirectoryNotFoundException
            string outputDirectory = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDirectory) && !Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Load the existing presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Determine which slide to insert the chart into (use second slide if available)
                int slideIndex = (pres.Slides.Count > 1) ? 1 : 0;
                ISlide slide = pres.Slides[slideIndex];

                // Insert a clustered column chart at specified position and size
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 400f, 300f);

                // Configure chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Sample Chart");
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}