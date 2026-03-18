using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            using (Presentation pres = new Presentation(inputPath))
            {
                const float margin = 50f; // uniform whitespace around content (points)

                // Adjust each shape on every slide to respect the margin
                foreach (ISlide slide in pres.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        // Shift position inward by margin
                        shape.X += margin;
                        shape.Y += margin;

                        // Reduce size to keep within margins
                        shape.Width -= 2 * margin;
                        shape.Height -= 2 * margin;

                        // If the shape is a table, also adjust its rows and columns
                        if (shape is ITable)
                        {
                            ITable table = (ITable)shape;

                            foreach (IRow row in table.Rows)
                            {
                                // Reduce row height proportionally
                                row.MinimalHeight -= 2 * margin;
                            }

                            foreach (IColumn column in table.Columns)
                            {
                                // Reduce column width proportionally
                                column.Width -= 2 * margin;
                            }
                        }
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}