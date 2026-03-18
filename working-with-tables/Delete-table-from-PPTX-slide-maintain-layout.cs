using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    var slide = presentation.Slides[i];
                    // Iterate through shapes in reverse to safely remove items
                    for (int j = slide.Shapes.Count - 1; j >= 0; j--)
                    {
                        var shape = slide.Shapes[j];
                        if (shape is Aspose.Slides.ITable)
                        {
                            // Remove the table shape from the slide
                            slide.Shapes.RemoveAt(j);
                        }
                    }
                }

                // Clean up any unused layout slides
                presentation.LayoutSlides.RemoveUnused();

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}