using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
        string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");
        string themePath = Path.Combine(Environment.CurrentDirectory, "CorporateTheme.thmx");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load presentation
        Presentation presentation = null;
        try
        {
            presentation = new Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Retrieve a suitable layout slide (TitleAndObject, Title, or Blank)
        ILayoutSlide layoutSlide = null;
        IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
        layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);
        if (layoutSlide == null)
        {
            layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
        }
        if (layoutSlide == null)
        {
            // Create a blank layout if none exists
            layoutSlide = layoutSlides.Add(SlideLayoutType.Blank, "BlankLayout");
        }

        // Insert an empty slide based on the selected layout at the end of the presentation
        presentation.Slides.InsertEmptySlide(presentation.Slides.Count, layoutSlide);

        // Apply corporate branding theme if the theme file exists
        if (File.Exists(themePath))
        {
            try
            {
                // Apply external theme to the first master slide and propagate to dependent slides
                IMasterSlide newMaster = presentation.Masters[0].ApplyExternalThemeToDependingSlides(themePath);
                // newMaster can be used further if needed
            }
            catch (Exception ex)
            {
                // Handle errors such as PptxReadException
                Console.WriteLine("Failed to apply external theme: " + ex.Message);
            }
        }
        else
        {
            Console.WriteLine("Theme file not found, skipping theme application.");
        }

        // Save the modified presentation
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Format not supported or other save errors
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }
        finally
        {
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}