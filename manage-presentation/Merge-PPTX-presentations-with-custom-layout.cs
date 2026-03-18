using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create destination presentation
            using (var dest = new Aspose.Slides.Presentation())
            {
                // Remove the default empty slide
                dest.Slides.RemoveAt(0);

                // List of source presentation files to merge
                var sourceFiles = new string[] { "Presentation1.pptx", "Presentation2.pptx" };

                foreach (var filePath in sourceFiles)
                {
                    using (var src = new Aspose.Slides.Presentation(filePath))
                    {
                        // Clone layout slides from source to destination to preserve custom layouts
                        foreach (var layoutSlide in src.LayoutSlides)
                        {
                            dest.LayoutSlides.AddClone(layoutSlide);
                        }

                        // Clone each slide from source to destination
                        foreach (var slide in src.Slides)
                        {
                            dest.Slides.AddClone(slide);
                        }
                    }
                }

                // Save the merged presentation
                dest.Save("MergedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}