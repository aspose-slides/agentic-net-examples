using System;
using Aspose.Slides.Export;

namespace TablePaddingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
                {
                    // Access the first slide
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Define column widths and row heights
                    double[] columnWidths = new double[] { 100, 100, 100 };
                    double[] rowHeights = new double[] { 50, 50, 50 };

                    // Add a table to the slide
                    Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                    // Set padding (margins) of each cell to 5 points
                    for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
                    {
                        for (int colIndex = 0; colIndex < table.Columns.Count; colIndex++)
                        {
                            Aspose.Slides.ICell cell = table[colIndex, rowIndex];
                            cell.MarginTop = 5;
                            cell.MarginBottom = 5;
                            cell.MarginLeft = 5;
                            cell.MarginRight = 5;
                        }
                    }

                    // Save the presentation
                    presentation.Save("TablePadding.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}