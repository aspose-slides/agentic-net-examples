using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace LayoutPlaceholderCsvExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input CSV and output PPTX paths
            string inputCsvPath = "data.csv";
            string outputPptxPath = "output.pptx";

            // Verify CSV file exists
            if (!File.Exists(inputCsvPath))
            {
                Console.WriteLine("CSV file not found: " + inputCsvPath);
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
                IAutoShape tablePlaceholder = placeholderManager.AddTablePlaceholder(10f, 10f, 500f, 300f);

                // Add a new slide based on the layout slide
                ISlide slide = presentation.Slides.AddEmptySlide(layoutSlide);

                // Read CSV data
                string[] csvLines = File.ReadAllLines(inputCsvPath);
                int rowCount = csvLines.Length;
                int columnCount = 0;
                foreach (string line in csvLines)
                {
                    string[] cells = line.Split(',');
                    if (cells.Length > columnCount)
                        columnCount = cells.Length;
                }

                // Prepare column widths and row heights
                double[] columnWidths = new double[columnCount];
                double[] rowHeights = new double[rowCount];
                for (int i = 0; i < columnCount; i++)
                    columnWidths[i] = 100; // uniform width
                for (int i = 0; i < rowCount; i++)
                    rowHeights[i] = 20; // uniform height

                // Add a table to the slide at the placeholder position
                ITable table = slide.Shapes.AddTable(10f, 10f, columnWidths, rowHeights);

                // Populate table cells with CSV data
                for (int r = 0; r < rowCount; r++)
                {
                    string[] cells = csvLines[r].Split(',');
                    for (int c = 0; c < cells.Length; c++)
                    {
                        table[r, c].TextFrame.Text = cells[c];
                    }
                }

                // Save the presentation
                presentation.Save(outputPptxPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}