using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddColumnToTable
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Paths to the input and output PPTX files
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Assume the first shape on the slide is a table
                Aspose.Slides.ITable table = slide.Shapes[0] as Aspose.Slides.ITable;
                if (table == null)
                {
                    Console.WriteLine("No table found on the first slide.");
                    return;
                }

                // Index at which the new column will be inserted
                int insertIndex = 1; // Insert after the first column

                // Use an existing column as a template for the new column
                Aspose.Slides.IColumn templateColumn = table.Columns[0];

                // Insert the new column
                Aspose.Slides.IColumn[] insertedColumns = table.Columns.InsertClone(insertIndex, templateColumn, false);

                // Optionally set the width of the newly inserted column
                if (insertedColumns.Length > 0)
                {
                    insertedColumns[0].Width = 50;
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}