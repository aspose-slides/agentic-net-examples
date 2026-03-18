using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThumbnailExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                var presentationPath = "input.pptx";
                var outputImagePath = "shape_thumbnail.png";
                var outputPresentationPath = "output.pptx";

                using (var presentation = new Presentation(presentationPath))
                {
                    var slide = presentation.Slides[0];
                    var shape = slide.Shapes[0]; // assumes at least one shape on the slide

                    using (var image = shape.GetImage())
                    {
                        image.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);
                    }

                    presentation.Save(outputPresentationPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}