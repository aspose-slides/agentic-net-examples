using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var inputPath = "input.pptx";
            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                var slideIndex = 0; // index of the slide to inspect
                var slide = presentation.Slides[slideIndex];
                var mainSequence = slide.Timeline.MainSequence;

                foreach (var effect in mainSequence)
                {
                    var shapeName = effect.TargetShape?.Name ?? "None";
                    Console.WriteLine($"Effect Type: {effect.Type}, Subtype: {effect.Subtype}, Target Shape: {shapeName}");
                }

                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}