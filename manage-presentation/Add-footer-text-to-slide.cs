// -----------------------------------------------------------------------------
// Example: Apply layout to all slides using C#
//
// Description:
// Demonstrates how to select or create a suitable layout slide (TitleAndObject,
// Title, or Blank) and apply it to every slide in a presentation using
// Aspose.Slides for .NET. The example loads an existing PPTX file, ensures the
// desired layout exists in the master slide, updates each slide's LayoutSlide
// property, and saves the modified presentation. This pattern can be used to
// enforce consistent slide layouts programmatically.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Layout, Slide, Presentation,
// Automation, Slide Master, Slide Layout
//
// Use Cases:
// - Enforce a uniform layout across all slides in a presentation.
// - Programmatically update slide layouts during batch processing.
// - Prepare presentations for corporate branding by applying a standard layout.
// - Integrate layout management into .NET applications that manipulate PPTX files.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string dataDir = Path.Combine(Environment.CurrentDirectory, "Data");
        string inputFile = "input.pptx";
        string inputPath = Path.Combine(dataDir, inputFile);
        string outputPath = Path.Combine(dataDir, "output.pptx");

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                // Get the first master slide
                IMasterSlide master = pres.Masters[0];

                // Get the layout slides collection of the master
                IMasterLayoutSlideCollection layoutSlides = master.LayoutSlides;

                // Try to obtain a TitleAndObject layout, fallback to Title, then Blank, or create new
                ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);
                if (layoutSlide == null)
                {
                    foreach (ILayoutSlide ls in layoutSlides)
                    {
                        if (ls.Name == "Title and Object")
                        {
                            layoutSlide = ls;
                            break;
                        }
                    }
                    if (layoutSlide == null)
                    {
                        foreach (ILayoutSlide ls in layoutSlides)
                        {
                            if (ls.Name == "Title")
                            {
                                layoutSlide = ls;
                                break;
                            }
                        }
                        if (layoutSlide == null)
                        {
                            layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
                            if (layoutSlide == null)
                            {
                                layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
                            }
                        }
                    }
                }

                // Apply the new layout to all existing slides
                foreach (ISlide slide in pres.Slides)
                {
                    slide.LayoutSlide = layoutSlide;
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
