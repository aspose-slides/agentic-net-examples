using System;
using Aspose.Slides.Util;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Traverse all slides and shapes to find tables
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    Aspose.Slides.Table table = shape as Aspose.Slides.Table;
                    if (table != null)
                    {
                        Console.WriteLine("Found a table on slide number {0}", slide.SlideNumber);
                        Console.WriteLine("Rows: {0}, Columns: {1}", table.Rows.Count, table.Columns.Count);
                    }
                }
            }

            // Locate a specific table by alternative text using SlideUtil
            string targetAltText = "MyTable";
            Aspose.Slides.IShape targetShape = Aspose.Slides.Util.SlideUtil.FindShape(presentation, targetAltText);
            if (targetShape != null)
            {
                Aspose.Slides.Table targetTable = targetShape as Aspose.Slides.Table;
                if (targetTable != null)
                {
                    Console.WriteLine("Specific table found with alt text '{0}'", targetAltText);
                }
            }

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}