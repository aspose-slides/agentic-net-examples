using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TitleSlideExample
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Define output file path
            string outputPath = "TitleSlide.pptx";

            // Try to get a Title layout; fallback to TitleAndObject or Blank if not found
            Aspose.Slides.ILayoutSlide layoutSlide = presentation.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Title);
            if (layoutSlide == null)
            {
                layoutSlide = presentation.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.TitleAndObject);
            }
            if (layoutSlide == null)
            {
                layoutSlide = presentation.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
            }

            // Insert a new empty slide using the selected layout at the beginning of the presentation
            Aspose.Slides.ISlide slide = presentation.Slides.InsertEmptySlide(0, layoutSlide);

            // Set the title placeholder text programmatically
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape.Placeholder != null && shape is Aspose.Slides.IAutoShape)
                {
                    if (shape.Placeholder.Type == Aspose.Slides.PlaceholderType.CenteredTitle)
                    {
                        ((Aspose.Slides.IAutoShape)shape).TextFrame.Text = "My Presentation Title";
                    }
                }
            }

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}