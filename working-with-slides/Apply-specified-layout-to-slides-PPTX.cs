using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the source presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the layout collection of the first master slide
            Aspose.Slides.IMasterLayoutSlideCollection masterLayouts = presentation.Masters[0].LayoutSlides;

            // Try to get a Title and Object layout; if not present, fall back to Title layout
            Aspose.Slides.ILayoutSlide layoutSlide = masterLayouts.GetByType(Aspose.Slides.SlideLayoutType.TitleAndObject);
            if (layoutSlide == null)
            {
                layoutSlide = masterLayouts.GetByType(Aspose.Slides.SlideLayoutType.Title);
            }

            // If still not found, add a Title layout to the master
            if (layoutSlide == null)
            {
                layoutSlide = masterLayouts.Add(Aspose.Slides.SlideLayoutType.Title, "Title");
            }

            // Apply the selected layout to all existing slides
            Aspose.Slides.ISlideCollection slides = presentation.Slides;
            for (int i = 0; i < slides.Count; i++)
            {
                slides[i].LayoutSlide = layoutSlide;
            }

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}