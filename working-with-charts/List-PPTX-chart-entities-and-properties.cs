using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartOverviewApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Presentation pres = new Presentation("input.pptx");

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    ISlide slide = pres.Slides[slideIndex];
                    Console.WriteLine($"Slide {slideIndex + 1}:");

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];

                        // Check if the shape is a chart
                        IChart chart = shape as IChart;
                        if (chart != null)
                        {
                            // Basic chart information
                            ChartType chartType = chart.Type;
                            bool is2D = ChartTypeCharacterizer.Is2DChart(chartType);
                            bool is3D = ChartTypeCharacterizer.Is3DChart(chartType);
                            bool hasTitle = chart.HasTitle;
                            bool hasLegend = chart.HasLegend;
                            bool hasDataTable = chart.HasDataTable;

                            // Chart title text (if any)
                            string titleText = string.Empty;
                            if (hasTitle && chart.ChartTitle != null && chart.ChartTitle.TextFrameForOverriding != null)
                            {
                                titleText = chart.ChartTitle.TextFrameForOverriding.Text;
                            }

                            // Output chart details
                            Console.WriteLine($"  Chart {shapeIndex + 1}:");
                            Console.WriteLine($"    Type          : {chartType}");
                            Console.WriteLine($"    2D/3D         : {(is2D ? "2D" : is3D ? "3D" : "Unknown")}");
                            Console.WriteLine($"    Has Title     : {hasTitle}");
                            if (hasTitle) Console.WriteLine($"    Title Text    : {titleText}");
                            Console.WriteLine($"    Has Legend    : {hasLegend}");
                            Console.WriteLine($"    Has DataTable : {hasDataTable}");
                        }
                    }
                }

                // Save the presentation (required before exit)
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}