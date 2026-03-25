using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace TableStylingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "styled_table.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Define column widths and row heights for the table
            double[] cols = new double[] { 150, 150, 150 };
            double[] rows = new double[] { 50, 40, 40, 40 };

            // Add a table to the slide
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, cols, rows);

            // Apply solid borders to each cell
            foreach (Aspose.Slides.IRow rowItem in table.Rows)
            {
                foreach (Aspose.Slides.ICell cellItem in rowItem)
                {
                    cellItem.CellFormat.BorderTop.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cellItem.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Blue;
                    cellItem.CellFormat.BorderTop.Width = 2;

                    cellItem.CellFormat.BorderBottom.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cellItem.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Blue;
                    cellItem.CellFormat.BorderBottom.Width = 2;

                    cellItem.CellFormat.BorderLeft.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cellItem.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Blue;
                    cellItem.CellFormat.BorderLeft.Width = 2;

                    cellItem.CellFormat.BorderRight.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cellItem.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Blue;
                    cellItem.CellFormat.BorderRight.Width = 2;
                }
            }

            // Merge the first two cells of the first row
            table.MergeCells(table[0, 0], table[0, 1], false);
            table[0, 0].TextFrame.Text = "Merged Header";

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}