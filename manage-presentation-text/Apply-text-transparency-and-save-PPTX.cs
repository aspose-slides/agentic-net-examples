using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        try
        {
            // Load the existing presentation
            Presentation presentation = new Presentation("input.pptx");

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Assume the first shape is an AutoShape containing text
            IAutoShape shape = (IAutoShape)slide.Shapes[0];

            // Add a transparency animation effect to the text shape
            slide.Timeline.MainSequence.AddEffect(
                shape,
                Aspose.Slides.Animation.EffectType.Transparency,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

            // Optionally set the text fill color with alpha for visual transparency
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(128, Color.Black);

            // Save the updated presentation
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}