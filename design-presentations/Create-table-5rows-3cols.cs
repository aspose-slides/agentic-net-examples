using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Define column widths and row heights
            double[] cols = new double[] { 100, 100, 100 };
            double[] rows = new double[] { 50, 50, 50, 50, 50 };

            // Add a table with 5 rows and 3 columns
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, cols, rows);

            // Optional: Populate cells with sample text
            foreach (Aspose.Slides.IRow row in table.Rows)
            {
                foreach (Aspose.Slides.ICell cell in row)
                {
                    Aspose.Slides.ITextFrame tf = cell.TextFrame;
                    tf.Text = "R" + cell.FirstRowIndex.ToString() + "C" + cell.FirstColumnIndex.ToString();
                    tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 12;
                }
            }

            // Save the presentation
            presentation.Save("TablePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}