using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate over all slides
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    // Iterate over all shapes on the slide
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        // Find group shapes with AltText containing 'Header'
                        if (shape is Aspose.Slides.IGroupShape groupShape && shape.AlternativeText != null && shape.AlternativeText.Contains("Header"))
                        {
                            // Change fill to solid gray
                            if (groupShape.FillFormat != null)
                            {
                                groupShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                                groupShape.FillFormat.SolidFillColor.Color = Color.Gray;
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}