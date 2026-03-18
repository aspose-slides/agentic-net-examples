using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
                {
                    // Access the first slide
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Assume the first shape is a table
                    Aspose.Slides.ITable table = slide.Shapes[0] as Aspose.Slides.ITable;

                    if (table != null)
                    {
                        // Retrieve the cell at row 0, column 0 (adjust indices as needed)
                        Aspose.Slides.ICell cell = table[0, 0];

                        // Get the text frame of the cell
                        Aspose.Slides.ITextFrame textFrame = cell.TextFrame;

                        if (textFrame != null)
                        {
                            // Output the cell text
                            Console.WriteLine(textFrame.Text);
                        }
                        else
                        {
                            Console.WriteLine("The cell does not contain a text frame.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No table found on the first slide.");
                    }

                    // Save the presentation before exiting
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}