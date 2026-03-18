using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing presentation
            using (Presentation pres = new Presentation("input.pptx"))
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Assume the first shape on the slide is a table
                ITable table = (ITable)slide.Shapes[0];

                // Index at which the new row should be inserted
                int insertIndex = 1; // example index

                // Use the first existing row as a template for the new row
                Row templateRow = (Row)table.Rows[0];

                // Insert a cloned row at the specified index
                table.Rows.InsertClone(insertIndex, templateRow, false);

                // Save the modified presentation
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}