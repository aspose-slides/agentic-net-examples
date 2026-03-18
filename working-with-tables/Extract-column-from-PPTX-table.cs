using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Load the presentation
            var presentation = new Aspose.Slides.Presentation("input.pptx");

            // Get the first slide (adjust index as needed)
            var slide = presentation.Slides[0];

            // Define the column index to retrieve (0‑based)
            int columnIndex = 1; // example: second column

            // Iterate through shapes to find a table
            foreach (var shape in slide.Shapes)
            {
                var table = shape as Aspose.Slides.Table;
                if (table != null)
                {
                    // Ensure the column index is within bounds
                    if (columnIndex < table.Columns.Count)
                    {
                        // Iterate over each row and output the cell text from the designated column
                        for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
                        {
                            var cell = table[rowIndex, columnIndex];
                            var text = cell.TextFrame?.Text;
                            Console.WriteLine(text);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Column index out of range.");
                    }

                    // Table found, no need to continue searching
                    break;
                }
            }

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}