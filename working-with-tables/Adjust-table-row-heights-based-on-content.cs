using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace VariableRowHeightTable
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Get the first slide
                    ISlide slide = pres.Slides[0];

                    // Define column width (single column) and initial row heights
                    double[] columnWidths = new double[] { 400 };
                    double[] initialRowHeights = new double[] { 50, 50, 50 };

                    // Add a table to the slide using the correct overload
                    ITable table = slide.Shapes.AddTable(50, 50, columnWidths, initialRowHeights);

                    // Sample contents with varying lengths
                    string[] contents = new string[]
                    {
                        "Short",
                        "Medium length text for the second row.",
                        "A very long text that should increase the row height significantly because it contains many characters and needs more space."
                    };

                    // Populate cells and adjust row heights based on content length
                    for (int i = 0; i < contents.Length; i++)
                    {
                        // Set text for the cell at column 0, row i
                        table[i, 0].TextFrame.Text = contents[i];

                        // Simple heuristic: height = base height + (text length * factor)
                        double calculatedHeight = 30 + (contents[i].Length * 0.5);
                        // Ensure the height is at least the initial height
                        if (calculatedHeight < initialRowHeights[i])
                            calculatedHeight = initialRowHeights[i];

                        // Set the minimal height for the row
                        table.Rows[i].MinimalHeight = calculatedHeight;
                    }

                    // Save the presentation
                    pres.Save("VariableRowHeightTable.pptx", SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException ex)
            {
                // Handle unsupported PPTX format
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (PptUnsupportedFormatException ex)
            {
                // Handle unsupported PPT format
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}