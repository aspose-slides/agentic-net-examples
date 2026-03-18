using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation from a file
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
                {
                    bool mergedFound = false;

                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                            // Check if the shape is a table
                            Aspose.Slides.Table table = shape as Aspose.Slides.Table;
                            if (table != null)
                            {
                                // Iterate through rows and columns of the table
                                for (int row = 0; row < table.Rows.Count; row++)
                                {
                                    for (int col = 0; col < table.Columns.Count; col++)
                                    {
                                        Aspose.Slides.ICell cell = table.Rows[row][col];
                                        if (cell.IsMergedCell)
                                        {
                                            mergedFound = true;
                                            Console.WriteLine("Merged cell detected at slide {0}, row {1}, column {2}.",
                                                slideIndex + 1, row + 1, col + 1);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (!mergedFound)
                    {
                        Console.WriteLine("No merged cells found in the presentation.");
                    }

                    // Save the (potentially unchanged) presentation
                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}