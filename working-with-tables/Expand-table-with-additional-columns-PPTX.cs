using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExpandTableColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths to the input and output PPTX files
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                // Load the presentation containing the table
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Access the first slide (adjust index if needed)
                    ISlide slide = presentation.Slides[0];

                    // Assume the first shape on the slide is the table
                    ITable table = slide.Shapes[0] as ITable;
                    if (table == null)
                    {
                        Console.WriteLine("No table found on the first slide.");
                        return;
                    }

                    // Number of columns to add
                    int columnsToAdd = 2;
                    // Desired width for each new column (in points)
                    double newColumnWidth = 50.0;

                    // Use an existing column as a template for cloning
                    IColumn templateColumn = table.Columns[table.Columns.Count - 1];

                    for (int i = 0; i < columnsToAdd; i++)
                    {
                        // Clone the template column and add it to the end of the collection
                        table.Columns.AddClone(templateColumn, false);
                        // Set the width of the newly added column
                        table.Columns[table.Columns.Count - 1].Width = newColumnWidth;
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Table expanded and presentation saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}