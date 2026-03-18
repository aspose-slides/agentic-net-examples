using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableColumnRemoval
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to the input and output presentations
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Index of the column to remove (zero‑based)
            int columnIndex = 1; // example: remove the second column

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Assume the table is on the first slide
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Find the first table shape on the slide
                    Aspose.Slides.ITable table = null;
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.ITable)
                        {
                            table = (Aspose.Slides.ITable)shape;
                            break;
                        }
                    }

                    if (table == null)
                    {
                        Console.WriteLine("No table found on the first slide.");
                    }
                    else
                    {
                        // Remove the specified column; true indicates attached rows are also removed
                        table.Columns.RemoveAt(columnIndex, true);
                        Console.WriteLine($"Column at index {columnIndex} removed.");
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}