// -----------------------------------------------------------------------------
// Example: Add secondary plot order bar of pie using C#
//
// Description:
// Demonstrates how to add a secondary plot order bar of pie using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, BarOfPie, Secondary Plot, 
// Order, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate add secondary plot order bar of pie.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AddSecondaryPlotBarOfPie
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a BarOfPie chart
            IChart chart = slide.Shapes.AddChart(ChartType.BarOfPie, 50f, 50f, 500f, 400f);

            // Remove default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook factory
            IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;
            int defaultWorksheetIndex = 0;

            // Add categories
            chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Add primary series (pie)
            IChartSeries primarySeries = chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Primary"), ChartType.Pie);
            primarySeries.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 30));
            primarySeries.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 40));
            primarySeries.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

            // Add secondary series (bar) that will be plotted on the secondary axis
            IChartSeries secondarySeries = chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Secondary"), ChartType.ClusteredColumn);
            secondarySeries.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 20));
            secondarySeries.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 50));
            secondarySeries.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 30));

            // Enable secondary plot for the bar series
            secondarySeries.PlotOnSecondAxis = true;

            // Adjust series order: make secondary series appear before primary series
            primarySeries.Order = 1;
            secondarySeries.Order = 0;

            // Adjust the size of the secondary bar (second pie size) via the series group
            IChartSeriesGroup seriesGroup = secondarySeries.ParentSeriesGroup;
            seriesGroup.SecondPieSize = 150; // Size as a percentage of the primary pie (5-200)

            // Save the presentation
            try
            {
                pres.Save("BarOfPieSecondaryPlot.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other save errors
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}
