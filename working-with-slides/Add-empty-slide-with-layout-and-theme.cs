using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine(Environment.CurrentDirectory, "template.pptx");
        string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation presentation = new Presentation(inputPath);

            // Find a suitable layout slide (TitleAndObject, Title, or Blank)
            ILayoutSlide layoutSlide = presentation.Masters[0].LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.TitleAndObject) ??
                                      presentation.Masters[0].LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Title);

            if (layoutSlide == null)
            {
                foreach (ILayoutSlide ls in presentation.Masters[0].LayoutSlides)
                {
                    if (ls.Name == "Title and Content")
                    {
                        layoutSlide = ls;
                        break;
                    }
                }
            }

            if (layoutSlide == null)
            {
                foreach (ILayoutSlide ls in presentation.Masters[0].LayoutSlides)
                {
                    if (ls.Name == "Title")
                    {
                        layoutSlide = ls;
                        break;
                    }
                }
            }

            if (layoutSlide == null)
            {
                layoutSlide = presentation.Masters[0].LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
            }

            if (layoutSlide == null)
            {
                layoutSlide = presentation.Masters[0].LayoutSlides.Add(Aspose.Slides.SlideLayoutType.TitleAndObject, "TitleAndObject");
            }

            // Insert an empty slide at the beginning using the selected layout
            presentation.Slides.InsertEmptySlide(0, layoutSlide);

            // Apply corporate branding: set background color of the new slide
            ISlide newSlide = presentation.Slides[0];
            newSlide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            newSlide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            newSlide.Background.FillFormat.SolidFillColor.Color = Color.Blue; // corporate color

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}