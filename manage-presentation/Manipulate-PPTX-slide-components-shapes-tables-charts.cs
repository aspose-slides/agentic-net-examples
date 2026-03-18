using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // -------------------- Add and format a table --------------------
                double[] columnWidths = new double[] { 100, 100, 100 };
                double[] rowHeights = new double[] { 50, 30, 30 };
                Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                // Apply border formatting to each cell
                for (int row = 0; row < table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        Aspose.Slides.ICell cell = table.Rows[row][col];

                        cell.CellFormat.BorderTop.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Blue;
                        cell.CellFormat.BorderTop.Width = 2;

                        cell.CellFormat.BorderBottom.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Blue;
                        cell.CellFormat.BorderBottom.Width = 2;

                        cell.CellFormat.BorderLeft.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Blue;
                        cell.CellFormat.BorderLeft.Width = 2;

                        cell.CellFormat.BorderRight.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Blue;
                        cell.CellFormat.BorderRight.Width = 2;
                    }
                }

                // Merge first two cells of the first row and add text
                table.MergeCells(table.Rows[0][0], table.Rows[0][1], false);
                table.Rows[0][0].TextFrame.Text = "Merged Cells";

                // -------------------- Add and populate a chart --------------------
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Pie, 300, 50, 400, 300);

                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Sample Pie Chart");

                // Remove default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add new series and categories
                int defaultWorksheetIndex = 0;
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                chart.ChartData.Series.Add(
                    workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);

                chart.ChartData.Categories.Add(
                    workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category A"));
                chart.ChartData.Categories.Add(
                    workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category B"));

                // Populate series data points
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];
                series.DataPoints.AddDataPointForPieSeries(
                    workbook.GetCell(defaultWorksheetIndex, 1, 1, 30));
                series.DataPoints.AddDataPointForPieSeries(
                    workbook.GetCell(defaultWorksheetIndex, 2, 1, 70));

                // Save the presentation
                presentation.Save("ManipulatedPresentation.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}