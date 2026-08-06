// -----------------------------------------------------------------------------
// Example: Clone SmartArt shape, apply external theme, and compare PNG using C#
//
// Description:
// Demonstrates how to load a PowerPoint presentation, locate the first SmartArt
// shape, clone it, apply an external theme to the master slide, render the slide
// to PNG before and after the modifications, and save the updated presentation.
// This example uses Aspose.Slides for .NET in a console application.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, SmartArt, Clone, Theme, PNG, Presentation Processing, Office Automation
//
// Use Cases:
// - Clone SmartArt shapes programmatically.
// - Apply custom themes to presentations.
// - Generate before/after PNG snapshots for visual comparison.
// - Automate PowerPoint manipulation in .NET applications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace CloneSmartArtWithTheme
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation and theme files
            string inputPath = "input.pptx";
            string themePath = "custom.thmx";

            // Output folder and files
            string outputFolder = "output";
            string outputPresentationPath = Path.Combine(outputFolder, "result.pptx");
            string originalImagePath = Path.Combine(outputFolder, "original.png");
            string clonedImagePath = Path.Combine(outputFolder, "clone.png");

            // Verify input files exist
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file does not exist: " + inputPath);
                return;
            }

            if (!File.Exists(themePath))
            {
                Console.WriteLine("Theme file does not exist: " + themePath);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Get first slide
                ISlide slide = presentation.Slides[0];

                // Find the first SmartArt shape on the slide
                ISmartArt originalSmartArt = null;
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape is ISmartArt)
                    {
                        originalSmartArt = (ISmartArt)shape;
                        break;
                    }
                }

                if (originalSmartArt == null)
                {
                    Console.WriteLine("No SmartArt shape found on the first slide.");
                    presentation.Dispose();
                    return;
                }

                // Render original slide (before cloning) to PNG
                IImage originalSlideImage = slide.GetImage();
                originalSlideImage.Save(originalImagePath, Aspose.Slides.ImageFormat.Png);

                // Clone the SmartArt shape using AddClone
                IShape clonedShape = slide.Shapes.AddClone((IShape)originalSmartArt);
                ISmartArt clonedSmartArt = (ISmartArt)clonedShape;

                // Apply external theme to the master slide (custom theme)
                IMasterSlide masterSlide = presentation.Masters[0];
                try
                {
                    masterSlide.ApplyExternalThemeToDependingSlides(themePath);
                }
                catch (Exception themeEx)
                {
                    Console.WriteLine("Failed to apply external theme: " + themeEx.Message);
                }

                // Render slide after cloning and theme application to PNG
                IImage clonedSlideImage = slide.GetImage();
                clonedSlideImage.Save(clonedImagePath, Aspose.Slides.ImageFormat.Png);

                // Save the modified presentation
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);

                // Dispose resources
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
