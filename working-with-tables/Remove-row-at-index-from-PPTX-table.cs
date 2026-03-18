using System;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
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
                    int rowIndex = 1; // index of the row to remove (zero‑based)
                    bool withAttachedRows = false;
                    table.Rows.RemoveAt(rowIndex, withAttachedRows);
                }

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}