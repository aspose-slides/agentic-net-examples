using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddColumnExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Get the first master slide
                    IMasterSlide masterSlide = presentation.Masters[0];

                    // Add a new layout slide (e.g., TitleAndObject) to act as a two‑column layout
                    ILayoutSlide newLayout = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.TitleAndObject, "TwoColumnLayout");

                    // Add a new empty slide using the newly created layout
                    ISlide newSlide = presentation.Slides.AddEmptySlide(newLayout);

                    // Add a rectangle shape to represent a column (optional)
                    newSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 300, 400);

                    // Save the updated presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}