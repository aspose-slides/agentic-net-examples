using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Get the layout slides collection from the first master
        Aspose.Slides.IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;

        // Try to find a suitable layout for the FAQ slide
        Aspose.Slides.ILayoutSlide faqLayout = layoutSlides.GetByType(Aspose.Slides.SlideLayoutType.TitleAndObject);
        if (faqLayout == null)
        {
            faqLayout = layoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Title);
        }
        if (faqLayout == null)
        {
            // Add a new layout if none suitable is found
            faqLayout = layoutSlides.Add(Aspose.Slides.SlideLayoutType.TitleAndObject, "FAQ Layout");
        }

        // Insert a new empty slide using the selected layout at the end of the presentation
        Aspose.Slides.ISlideCollection slides = presentation.Slides;
        int insertIndex = slides.Count;
        slides.InsertEmptySlide(insertIndex, faqLayout);

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}