using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Locate the first table on the slide
            Aspose.Slides.ITable table = null;
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.ITable)
                {
                    table = (Aspose.Slides.ITable)shape;
                    break;
                }
            }

            if (table != null)
            {
                // ------------------------------
                // Modify an existing cell
                // ------------------------------
                // Change text of cell at row 0, column 1
                table[0, 1].TextFrame.Text = "Modified Cell";

                // ------------------------------
                // Delete a row and a column
                // ------------------------------
                // Remove the second row (index 1)
                table.Rows.RemoveAt(1, false);
                // Remove the first column (index 0)
                table.Columns.RemoveAt(0, false);

                // ------------------------------
                // Add a new row
                // ------------------------------
                // Clone the first row and add it at the end of the table
                Aspose.Slides.IRow rowToClone = table.Rows[0];
                table.Rows.AddClone(rowToClone, false);

                // ------------------------------
                // Add a new column
                // ------------------------------
                // Clone the first column and insert it at position 1
                // (Assuming IColumnCollection supports InsertClone similar to IRowCollection)
                Aspose.Slides.IColumn columnToClone = table.Columns[0];
                table.Columns.InsertClone(1, columnToClone, false);
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}