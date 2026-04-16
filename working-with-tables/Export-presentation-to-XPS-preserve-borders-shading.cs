using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportToXps
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "output.xps";

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Define column widths and row heights
                double[] columnWidths = new double[] { 150, 150, 150 };
                double[] rowHeights = new double[] { 100, 100, 100 };

                // Add a table to the slide
                ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                // Apply borders and cell shading
                for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < table.Rows[rowIndex].Count; colIndex++)
                    {
                        ICell cell = table.Rows[rowIndex][colIndex];

                        // Top border
                        cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
                        cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Black;
                        cell.CellFormat.BorderTop.Width = 2;

                        // Bottom border
                        cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
                        cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Black;
                        cell.CellFormat.BorderBottom.Width = 2;

                        // Left border
                        cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
                        cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Black;
                        cell.CellFormat.BorderLeft.Width = 2;

                        // Right border
                        cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
                        cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Black;
                        cell.CellFormat.BorderRight.Width = 2;

                        // Cell shading
                        cell.CellFormat.FillFormat.FillType = FillType.Solid;
                        cell.CellFormat.FillFormat.SolidFillColor.Color = Color.LightGray;
                    }
                }

                // Set XPS export options
                XpsOptions options = new XpsOptions();
                options.DrawSlidesFrame = false;

                // Save the presentation as XPS
                presentation.Save(outputPath, SaveFormat.Xps, options);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}