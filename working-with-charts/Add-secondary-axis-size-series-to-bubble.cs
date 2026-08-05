// -----------------------------------------------------------------------------
// Example: Add secondary axis size series to bubble using C#
//
// Description:
// Demonstrates how to add a secondary axis size series to a bubble chart using
// C# and Aspose.Slides for .NET. The example creates a presentation, inserts a
// bubble chart, configures primary and secondary series, sets bubble size
// representation and scaling, and saves the result as a PPTX file. This pattern
// can be used to automate PowerPoint chart creation and manipulation in .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Bubble Chart, Secondary Axis,
// Size Series, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of bubble charts with secondary axis size series.
// - Build .NET tools for PowerPoint chart generation and customization.
// - Generate or transform PPTX files with advanced chart configurations.
// - Validate chart workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;

using Aspose.Slides.Export;

using Aspose.Slides.Charts;



class Program

{

    static void Main()

    {

        // Create a new presentation

        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())

        {

            // Add a bubble chart to the first slide

            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(

                Aspose.Slides.Charts.ChartType.Bubble, 0f, 0f, 500f, 400f);



            // Set bubble size representation and scaling for the chart

            chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Width;

            chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150; // 150%



            // Get the workbook to create cells

            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            int defaultWorksheetIndex = 0;



            // Clear default series and categories

            chart.ChartData.Series.Clear();

            chart.ChartData.Categories.Clear();



            // Add categories

            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));

            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));

            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));



            // Add primary series (plotted on primary axis)

            Aspose.Slides.Charts.IChartSeries primarySeries = chart.ChartData.Series.Add(

                workbook.GetCell(defaultWorksheetIndex, 0, 1, "Primary Series"),

                Aspose.Slides.Charts.ChartType.Bubble);

            primarySeries.DataPoints.AddDataPointForBubbleSeries(

                workbook.GetCell(defaultWorksheetIndex, 1, 1, 10),

                workbook.GetCell(defaultWorksheetIndex, 1, 2, 20),

                workbook.GetCell(defaultWorksheetIndex, 1, 3, 30));

            primarySeries.DataPoints.AddDataPointForBubbleSeries(

                workbook.GetCell(defaultWorksheetIndex, 2, 1, 15),

                workbook.GetCell(defaultWorksheetIndex, 2, 2, 25),

                workbook.GetCell(defaultWorksheetIndex, 2, 3, 35));

            primarySeries.DataPoints.AddDataPointForBubbleSeries(

                workbook.GetCell(defaultWorksheetIndex, 3, 1, 20),

                workbook.GetCell(defaultWorksheetIndex, 3, 2, 30),

                workbook.GetCell(defaultWorksheetIndex, 3, 3, 40));



            // Add secondary series for size scaling and map it to the secondary axis

            Aspose.Slides.Charts.IChartSeries secondarySeries = chart.ChartData.Series.Add(

                workbook.GetCell(defaultWorksheetIndex, 0, 4, "Size Series"),

                Aspose.Slides.Charts.ChartType.Bubble);

            secondarySeries.PlotOnSecondAxis = true;

            secondarySeries.DataPoints.AddDataPointForBubbleSeries(

                workbook.GetCell(defaultWorksheetIndex, 1, 1, 10),

                workbook.GetCell(defaultWorksheetIndex, 1, 2, 20),

                workbook.GetCell(defaultWorksheetIndex, 1, 4, 5));

            secondarySeries.DataPoints.AddDataPointForBubbleSeries(

                workbook.GetCell(defaultWorksheetIndex, 2, 1, 15),

                workbook.GetCell(defaultWorksheetIndex, 2, 2, 25),

                workbook.GetCell(defaultWorksheetIndex, 2, 4, 7));

            secondarySeries.DataPoints.AddDataPointForBubbleSeries(

                workbook.GetCell(defaultWorksheetIndex, 3, 1, 20),

                workbook.GetCell(defaultWorksheetIndex, 3, 2, 30),

                workbook.GetCell(defaultWorksheetIndex, 3, 4, 9));



            // Save the presentation

            presentation.Save("BubbleChartWithSecondaryAxis.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        }

    }

}
