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

            using (Presentation presentation = new Presentation(inputPath))
            {
                // Access the first slide (index 0)
                ISlide slide = presentation.Slides[0];

                // Add a line shape to the slide
                slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50f, 150f, 300f, 0f);

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}