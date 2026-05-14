using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceTablePlaceholder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string csvPath = "data.csv";
            string outputPath = "output.pptx";

            // Verify CSV file exists
            if (!File.Exists(csvPath))
            {
                Console.WriteLine("CSV file not found: " + csvPath);
                return;
            }

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get a blank layout slide
                ILayoutSlide layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

                // Add a table placeholder to the layout slide
                ILayoutPlaceholderManager placeholderManager = layoutSlide.PlaceholderManager;
                IAutoShape placeholder = placeholderManager.AddTablePlaceholder(10, 10, 500, 300);

                // Add a new slide based on the layout slide
                ISlide slide = presentation.Slides.AddEmptySlide(layoutSlide);

                // Locate the placeholder shape on the new slide
                IShape placeholderShape = null;
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape.Placeholder != null && shape.Placeholder.Type == PlaceholderType.Table)
                    {
                        placeholderShape = shape;
                        break;
                    }
                }

                // If placeholder not found, exit
                if (placeholderShape == null)
                {
                    Console.WriteLine("Table placeholder not found on the slide.");
                    presentation.Save(outputPath, SaveFormat.Pptx);
                    return;
                }

                // Read CSV data
                string[] csvLines = File.ReadAllLines(csvPath);
                int rowCount = csvLines.Length;
                int columnCount = 0;
                if (rowCount > 0)
                {
                    string[] firstRow = csvLines[0].Split(',');
                    columnCount = firstRow.Length;
                }

                // Prepare column widths and row heights
                double[] columnWidths = new double[columnCount];
                double[] rowHeights = new double[rowCount];
                for (int i = 0; i < columnCount; i++) columnWidths[i] = 100; // uniform width
                for (int i = 0; i < rowCount; i++) rowHeights[i] = 20; // uniform height

                // Add a table to the slide at the placeholder position
                Table table = (Table)slide.Shapes.AddTable(placeholderShape.X, placeholderShape.Y, columnWidths, rowHeights);

                // Populate table cells with CSV data
                for (int r = 0; r < rowCount; r++)
                {
                    string[] cells = csvLines[r].Split(',');
                    for (int c = 0; c < columnCount; c++)
                    {
                        if (c < cells.Length)
                        {
                            table[r, c].TextFrame.Text = cells[c];
                        }
                    }
                }

                // Remove the original placeholder shape
                slide.Shapes.Remove(placeholderShape);

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The specified file format is not supported.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}