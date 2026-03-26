using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartOverviewApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation
            string inputPath = "input.pptx";

            // Verify that the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("The file '" + inputPath + "' does not exist.");
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                Console.WriteLine("Slide " + (slideIndex + 1) + ":");

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                    Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;

                    if (chart != null)
                    {
                        // Basic chart information
                        Console.WriteLine("  Chart found at shape index " + shapeIndex);
                        Console.WriteLine("    Type: " + chart.Type);
                        Console.WriteLine("    Has Title: " + chart.HasTitle);
                        Console.WriteLine("    Has Legend: " + chart.HasLegend);
                        Console.WriteLine("    Has Data Table: " + chart.HasDataTable);
                        Console.WriteLine("    Style: " + chart.Style);
                        Console.WriteLine("    Plot Visible Cells Only: " + chart.PlotVisibleCellsOnly);
                        Console.WriteLine("    Display Blanks As: " + chart.DisplayBlanksAs);

                        // Determine dimensionality using ChartTypeCharacterizer
                        bool is2D = Aspose.Slides.Charts.ChartTypeCharacterizer.Is2DChart(chart.Type);
                        bool is3D = Aspose.Slides.Charts.ChartTypeCharacterizer.Is3DChart(chart.Type);
                        Console.WriteLine("    Is 2D Chart: " + is2D);
                        Console.WriteLine("    Is 3D Chart: " + is3D);

                        // Additional characteristics
                        bool isBar = Aspose.Slides.Charts.ChartTypeCharacterizer.IsChartTypeBar(chart.Type);
                        bool isColumn = Aspose.Slides.Charts.ChartTypeCharacterizer.IsChartTypeColumn(chart.Type);
                        bool isLine = Aspose.Slides.Charts.ChartTypeCharacterizer.IsChartTypeLine(chart.Type);
                        bool isPie = Aspose.Slides.Charts.ChartTypeCharacterizer.IsChartTypePie(chart.Type);
                        Console.WriteLine("    Is Bar Chart: " + isBar);
                        Console.WriteLine("    Is Column Chart: " + isColumn);
                        Console.WriteLine("    Is Line Chart: " + isLine);
                        Console.WriteLine("    Is Pie Chart: " + isPie);
                    }
                }
            }

            // Save the presentation (even if unchanged) before exiting
            presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}