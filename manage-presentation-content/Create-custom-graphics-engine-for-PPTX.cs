using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing presentation
            var presentationPath = "input.pptx";
            using (Presentation pres = new Presentation(presentationPath))
            {
                // Access the first slide
                var slide = pres.Slides[0];

                // Add a rectangle shape with some text
                var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
                shape.TextFrame.Text = "Hello Aspose.Slides";

                // Apply a Fly animation effect to the shape
                var effect = slide.Timeline.MainSequence.AddEffect(
                    shape,
                    EffectType.Fly,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);

                // Generate and save thumbnails for all slides
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    var sld = pres.Slides[i];
                    var image = sld.GetImage(1f, 1f);
                    var imagePath = $"slide_{i + 1}.png";
                    image.Save(imagePath, Aspose.Slides.ImageFormat.Png);
                }

                // Save the modified presentation
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}