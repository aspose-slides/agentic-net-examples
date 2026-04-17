using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace AsposeSlidesSmartArtClone
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file paths
            string originalPath = "OriginalSmartArt.pptx";
            string themedPath = "ThemedSmartArt.pptx";
            // Path to external theme file
            string themeFile = "customTheme.thmx";

            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];
                // Add a SmartArt diagram
                Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);
                // Clone the SmartArt shape and position it beside the original
                Aspose.Slides.IShape clonedShape = slide.Shapes.AddClone(smartArt, 500, 50);

                // Save the presentation before applying the custom theme
                try
                {
                    pres.Save(originalPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (Aspose.Slides.PptxUnsupportedFormatException)
                {
                    // Format not supported
                }

                // Apply external theme if the file exists
                if (File.Exists(themeFile))
                {
                    try
                    {
                        // Apply the theme to the master slide and its dependent slides
                        Aspose.Slides.IMasterSlide newMaster = slide.LayoutSlide.MasterSlide.ApplyExternalThemeToDependingSlides(themeFile);
                    }
                    catch (Aspose.Slides.PptxReadException)
                    {
                        // Handle theme read errors (e.g., invalid or corrupted theme file)
                    }
                }

                // Save the presentation after applying the theme (contains both original and cloned SmartArt)
                try
                {
                    pres.Save(themedPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (Aspose.Slides.PptxUnsupportedFormatException)
                {
                    // Format not supported
                }
            }
        }
    }
}