using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation and external theme files
            string presentationPath = "input.pptx";
            string themePath = "custom.thmx";

            // Verify that the input files exist
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }
            if (!File.Exists(themePath))
            {
                Console.WriteLine("Theme file not found: " + themePath);
                return;
            }

            // Load the presentation
            using (Presentation pres = new Presentation(presentationPath))
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a SmartArt diagram to the slide
                ISmartArt smartArt = slide.Shapes.AddSmartArt(50f, 50f, 400f, 300f, SmartArtLayoutType.BasicBlockList);

                // Render the original slide (before cloning)
                IImage originalImage = slide.GetImage(1f, 1f);
                originalImage.Save("original.png", Aspose.Slides.ImageFormat.Png);
                originalImage.Dispose();

                // Clone the SmartArt shape and add it to the same slide
                IShape clonedShape = slide.Shapes.AddClone(smartArt);
                // Optionally cast to ISmartArt if further manipulation is needed
                ISmartArt clonedSmartArt = clonedShape as ISmartArt;

                // Apply an external theme to the master slide of the current slide
                IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
                masterSlide.ApplyExternalThemeToDependingSlides(themePath);

                // Render the slide after cloning and applying the theme
                IImage clonedImage = slide.GetImage(1f, 1f);
                clonedImage.Save("clone.png", Aspose.Slides.ImageFormat.Png);
                clonedImage.Dispose();

                // Save the modified presentation
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
    }
}