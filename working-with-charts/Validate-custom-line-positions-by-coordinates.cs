using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "CustomLineValidation_out.pptx";

        try
        {
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a line shape (start at 100,100 with width 200 and height 0)
                IAutoShape line = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 100f, 100f, 200f, 0f);

                // Retrieve start and end coordinates
                float startX = line.X;
                float startY = line.Y;
                float endX = line.X + line.Width;
                float endY = line.Y + line.Height;

                // Validate that the start point is not after the end point
                if (startX <= endX && startY <= endY)
                {
                    Console.WriteLine("Line coordinates are valid.");
                }
                else
                {
                    Console.WriteLine("Line coordinates are invalid.");
                }

                // Save the presentation before exiting
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            Console.WriteLine("Unsupported PPTX format: " + ex.Message);
        }
        catch (Aspose.Slides.PptUnsupportedFormatException ex)
        {
            Console.WriteLine("Unsupported PPT format: " + ex.Message);
        }
        catch (Aspose.Slides.PptCorruptFileException ex)
        {
            Console.WriteLine("Corrupt file: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}