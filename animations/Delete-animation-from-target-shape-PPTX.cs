using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main()
    {
        try
        {
            // Load the existing presentation
            Presentation presentation = new Presentation("input.pptx");

            // Access the first slide (adjust index as needed)
            ISlide slide = presentation.Slides[0];

            // Locate the target shape by its name (replace "TargetShape" with actual name)
            IShape shape = SlideUtil.FindShape(slide, "TargetShape");

            if (shape != null)
            {
                // Remove any animation effect assigned to the shape
                slide.Timeline.MainSequence.RemoveByShape(shape);
            }

            // Save the modified presentation
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}