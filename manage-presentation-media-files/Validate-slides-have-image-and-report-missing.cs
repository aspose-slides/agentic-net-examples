// -----------------------------------------------------------------------------
// Example: Validate slides have image and report missing using C#
//
// Description:
// Demonstrates how to validate each slide in a PowerPoint presentation
// contains at least one picture (image) and reports slides that are missing
// images. The example loads a PPTX file, checks every slide for picture frames,
// writes missing‑slide information to the console, and saves the presentation.
// This pattern can be used in .NET console tools for PowerPoint validation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Slides, Image, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate validation of slides to ensure they contain images.
// - Build C# utilities for PowerPoint content quality checks.
// - Integrate slide‑image verification into .NET applications.
// - Generate reports of missing media before publishing presentations.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideImageValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load presentation
            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Validate each slide for at least one image element
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                bool hasImage = false;

                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.IPictureFrame)
                    {
                        hasImage = true;
                        break;
                    }
                }

                if (!hasImage)
                {
                    Console.WriteLine("Slide " + (slideIndex + 1) + " does not contain any image.");
                }
            }

            // Save presentation before exit
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The output file format is not supported.");
            }
            finally
            {
                presentation.Dispose();
            }
        }
    }
}
