using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Load the SVG file into an ISvgImage instance
                using (FileStream svgStream = new FileStream("graphic.svg", FileMode.Open, FileAccess.Read))
                {
                    ISvgImage svgImage = new Aspose.Slides.SvgImage(svgStream);

                    // Convert the SVG into individual shapes within a group shape placed in the slide heading area
                    IGroupShape headerGroup = slide.Shapes.AddGroupShape(svgImage, 50f, 20f, 400f, 100f);
                    headerGroup.Name = "HeaderSvgGroup";
                }

                // Save the presentation
                presentation.Save("OutputPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}