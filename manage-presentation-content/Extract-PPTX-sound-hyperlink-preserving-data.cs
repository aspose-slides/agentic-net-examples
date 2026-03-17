using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            using (var presentation = new Presentation(inputPath))
            {
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    var slide = presentation.Slides[slideIndex];
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        var shape = slide.Shapes[shapeIndex];
                        var hyperlink = shape.HyperlinkClick;
                        if (hyperlink != null && hyperlink.Sound != null)
                        {
                            // Extract the sound data
                            var audioData = hyperlink.Sound.BinaryData;
                            var audioFileName = $"Slide{slideIndex + 1}_Shape{shapeIndex + 1}_Sound.bin";
                            System.IO.File.WriteAllBytes(audioFileName, audioData);

                            // Preserve hyperlink reference information
                            var url = hyperlink.ExternalUrl ?? "InternalLink";
                            Console.WriteLine($"Slide {slideIndex + 1}, Shape {shapeIndex + 1}: Hyperlink URL = {url}, Sound saved to {audioFileName}");
                        }
                    }
                }

                // Save the presentation (even if unchanged)
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}