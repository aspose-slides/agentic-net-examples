using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentationPath = "input.pptx";
            var outputPath = "output.pptx";

            using (var presentation = new Aspose.Slides.Presentation(presentationPath))
            {
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    var slide = presentation.Slides[i];
                    for (int j = 0; j < slide.Shapes.Count; j++)
                    {
                        var shape = slide.Shapes[j];
                        if (shape is Aspose.Slides.ITable table)
                        {
                            for (int rowIdx = 0; rowIdx < table.Rows.Count; rowIdx++)
                            {
                                var row = table.Rows[rowIdx];
                                for (int cellIdx = 0; cellIdx < row.Count; cellIdx++)
                                {
                                    var cell = row[cellIdx];
                                    cell.MarginTop = 5;
                                    cell.MarginBottom = 5;
                                    cell.MarginLeft = 5;
                                    cell.MarginRight = 5;
                                }
                            }
                        }
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}