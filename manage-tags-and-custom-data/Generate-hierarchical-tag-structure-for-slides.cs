using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = args.Length > 0 ? args[0] : null;
        string outputPath = "HierarchicalTags.pptx";

        Aspose.Slides.Presentation pres = null;
        try
        {
            if (!string.IsNullOrEmpty(inputPath))
            {
                if (File.Exists(inputPath))
                {
                    pres = new Aspose.Slides.Presentation(inputPath);
                }
                else
                {
                    Console.WriteLine("Input file does not exist. Creating a new presentation.");
                    pres = new Aspose.Slides.Presentation();
                }
            }
            else
            {
                pres = new Aspose.Slides.Presentation();
            }
        }
        catch (Exception ex)
        {
            // Format not supported
            Console.WriteLine("Error loading presentation: " + ex.Message);
            return;
        }

        // Ensure at least three slides exist
        while (pres.Slides.Count < 3)
        {
            Aspose.Slides.ILayoutSlide layout = pres.LayoutSlides[0];
            pres.Slides.AddEmptySlide(layout);
        }

        // Assign hierarchical tags to slides
        // Group 1: Intro (slides 0 and 1)
        pres.Slides[0].CustomData.Tags.Add("Section", "Intro");
        pres.Slides[0].CustomData.Tags.Add("Order", "1");
        pres.Slides[1].CustomData.Tags.Add("Section", "Intro");
        pres.Slides[1].CustomData.Tags.Add("Order", "2");
        // Group 2: Details (slide 2)
        pres.Slides[2].CustomData.Tags.Add("Section", "Details");
        pres.Slides[2].CustomData.Tags.Add("Order", "1");

        // Retrieve and display the hierarchy
        Console.WriteLine("Slide hierarchy:");
        for (int i = 0; i < pres.Slides.Count; i++)
        {
            Aspose.Slides.ISlide slide = pres.Slides[i];
            string section = slide.CustomData.Tags["Section"];
            string order = slide.CustomData.Tags["Order"];
            Console.WriteLine("Slide " + (i + 1) + ": Section = " + section + ", Order = " + order);
        }

        // Save the presentation
        try
        {
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
        finally
        {
            pres.Dispose();
        }
    }
}