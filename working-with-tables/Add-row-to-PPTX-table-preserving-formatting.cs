using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = "Data/";
            string inputFile = dataDir + "input.pptx";
            string outputFile = dataDir + "output.pptx";

            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputFile);
            Aspose.Slides.ISlide slide = pres.Slides[0];

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
                // Clone the first row as a template and add a new row at the bottom
                Aspose.Slides.IRow templateRow = table.Rows[0];
                Aspose.Slides.IRow[] addedRows = table.Rows.AddClone(templateRow, false);
                Aspose.Slides.IRow newRow = addedRows[0];

                // Set text for each cell in the new row (optional)
                for (int i = 0; i < newRow.Count; i++)
                {
                    newRow[i].TextFrame.Text = "New Cell " + (i + 1);
                }
            }

            pres.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}