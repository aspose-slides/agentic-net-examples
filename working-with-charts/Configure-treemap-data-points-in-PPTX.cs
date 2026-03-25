using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Check for optional input file argument
        string inputPath = args.Length > 0 ? args[0] : null;
        if (inputPath != null && !File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Access the first slide
            ISlide slide = pres.Slides[0];

            // -------------------- Treemap Chart --------------------
            IChart treemapChart = slide.Shapes.AddChart(ChartType.Treemap, 50, 50, 500, 400);
            IChartDataWorkbook treemapWb = treemapChart.ChartData.ChartDataWorkbook;

            // Remove default series and categories
            treemapChart.ChartData.Series.Clear();
            treemapChart.ChartData.Categories.Clear();

            // Add a single series for the treemap
            IChartSeries treemapSeries = treemapChart.ChartData.Series.Add(treemapWb.GetCell(0, 0, 1, "Series 1"), ChartType.Treemap);

            // Add categories with grouping levels
            IChartCategory catA = treemapChart.ChartData.Categories.Add(treemapWb.GetCell(0, 1, 0, "A"));
            catA.GroupingLevels.SetGroupingItem(0, "A1");

            IChartCategory catB = treemapChart.ChartData.Categories.Add(treemapWb.GetCell(0, 2, 0, "B"));
            catB.GroupingLevels.SetGroupingItem(0, "B1");

            IChartCategory catC = treemapChart.ChartData.Categories.Add(treemapWb.GetCell(0, 3, 0, "C"));
            catC.GroupingLevels.SetGroupingItem(0, "C1");

            // Add data points (size values) for each category
            treemapSeries.DataPoints.AddDataPointForTreemapSeries(treemapWb.GetCell(0, 1, 1, 30));
            treemapSeries.DataPoints.AddDataPointForTreemapSeries(treemapWb.GetCell(0, 2, 1, 50));
            treemapSeries.DataPoints.AddDataPointForTreemapSeries(treemapWb.GetCell(0, 3, 1, 20));

            // -------------------- Sunburst Chart --------------------
            IChart sunburstChart = slide.Shapes.AddChart(ChartType.Sunburst, 50, 500, 500, 400);
            IChartDataWorkbook sunburstWb = sunburstChart.ChartData.ChartDataWorkbook;

            // Remove default series and categories
            sunburstChart.ChartData.Series.Clear();
            sunburstChart.ChartData.Categories.Clear();

            // Add a single series for the sunburst
            IChartSeries sunburstSeries = sunburstChart.ChartData.Series.Add(sunburstWb.GetCell(0, 0, 1, "Series 1"), ChartType.Sunburst);

            // Root category
            IChartCategory rootCat = sunburstChart.ChartData.Categories.Add(sunburstWb.GetCell(0, 1, 0, "Root"));

            // Child categories with grouping to the root
            IChartCategory child1 = sunburstChart.ChartData.Categories.Add(sunburstWb.GetCell(0, 2, 0, "Child1"));
            child1.GroupingLevels.SetGroupingItem(0, "Root");

            IChartCategory child2 = sunburstChart.ChartData.Categories.Add(sunburstWb.GetCell(0, 3, 0, "Child2"));
            child2.GroupingLevels.SetGroupingItem(0, "Root");

            // Add data points (size values) for each category
            sunburstSeries.DataPoints.AddDataPointForSunburstSeries(sunburstWb.GetCell(0, 1, 1, 40));
            sunburstSeries.DataPoints.AddDataPointForSunburstSeries(sunburstWb.GetCell(0, 2, 1, 30));
            sunburstSeries.DataPoints.AddDataPointForSunburstSeries(sunburstWb.GetCell(0, 3, 1, 30));

            // Save the presentation
            pres.Save("ConfiguredCharts.pptx", SaveFormat.Pptx);
        }
    }
}