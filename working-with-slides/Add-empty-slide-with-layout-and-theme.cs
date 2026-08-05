// -----------------------------------------------------------------------------
// Example: Add empty slide with layout and theme using C#
//
// Description:
// Demonstrates how to add an empty slide with a specific layout and apply a
// background color (theme) using C# and Aspose.Slides for .NET. The example
// loads a template presentation, selects an appropriate layout slide, inserts
// a new empty slide at the beginning, sets its background to a corporate color,
// and saves the result. This pattern can be used to automate PPTX workflows,
// enforce branding, or integrate slide creation into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Empty Slide, Layout, Theme,
// Background Color, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of branded empty slides into existing presentations.
// - Build .NET tools for PowerPoint presentation processing with custom themes.
// - Generate or transform PPTX files with specific layouts and background colors.
// - Validate and enforce corporate branding in slide decks before publishing.
// -----------------------------------------------------------------------------

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
            ILayoutSlide layoutSlide = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??
                                      presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Title);

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
                layoutSlide = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
            }

            if (layoutSlide == null)
            {
                layoutSlide = presentation.Masters[0].LayoutSlides.Add(SlideLayoutType.TitleAndObject, "TitleAndObject");
            }

            // Insert an empty slide at the beginning using the selected layout
            presentation.Slides.InsertEmptySlide(0, layoutSlide);

            // Apply corporate branding: set background color of the new slide
            ISlide newSlide = presentation.Slides[0];
            newSlide.Background.Type = BackgroundType.OwnBackground;
            newSlide.Background.FillFormat.FillType = FillType.Solid;
            newSlide.Background.FillFormat.SolidFillColor.Color = Color.Blue; // corporate color

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
