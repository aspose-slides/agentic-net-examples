using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ApplyCustomNumericFormatToTable
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input and output files
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load existing presentation if it exists; otherwise create a new one
            Aspose.Slides.Presentation presentation;
            if (File.Exists(inputPath))
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();

                // Add a slide and a sample table
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                double[] columnWidths = new double[] { 100, 100, 100 };
                double[] rowHeights = new double[] { 50, 50 };
                Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                // Populate cells with numeric values as text
                Aspose.Slides.ICell cell00 = table.Rows[0][0];
                cell00.TextFrame.Text = "1234.567";
                Aspose.Slides.ICell cell01 = table.Rows[0][1];
                cell01.TextFrame.Text = "89.01";
                Aspose.Slides.ICell cell02 = table.Rows[0][2];
                cell02.TextFrame.Text = "456.78";

                Aspose.Slides.ICell cell10 = table.Rows[1][0];
                cell10.TextFrame.Text = "345.6";
                Aspose.Slides.ICell cell11 = table.Rows[1][1];
                cell11.TextFrame.Text = "78.9";
                Aspose.Slides.ICell cell12 = table.Rows[1][2];
                cell12.TextFrame.Text = "0.12";
            }

            // Iterate through all slides and shapes to find tables
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    if (slide.Shapes[shapeIndex] is Aspose.Slides.ITable)
                    {
                        Aspose.Slides.ITable table = (Aspose.Slides.ITable)slide.Shapes[shapeIndex];

                        // Apply custom numeric format to each cell
                        for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
                        {
                            for (int colIndex = 0; colIndex < table.Rows[rowIndex].Count; colIndex++)
                            {
                                Aspose.Slides.ICell cell = table.Rows[rowIndex][colIndex];
                                double numericValue;
                                // Parse the existing text as a number
                                if (double.TryParse(cell.TextFrame.Text, out numericValue))
                                {
                                    // Example custom format: currency with two decimal places
                                    cell.TextFrame.Text = numericValue.ToString("C2");
                                }
                            }
                        }
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            // Release resources
            presentation.Dispose();
        }
    }
}