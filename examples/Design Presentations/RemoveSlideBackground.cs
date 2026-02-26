using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace RemoveSlideBackground
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Iterate through all slides and remove their background
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                // Set the background to own background with a transparent solid fill
                presentation.Slides[slideIndex].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                presentation.Slides[slideIndex].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                presentation.Slides[slideIndex].Background.FillFormat.SolidFillColor.Color = Color.Transparent;
            }

            // Save the presentation
            string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "RemovedBackground.pptx");
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}