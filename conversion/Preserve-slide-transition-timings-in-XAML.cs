// -----------------------------------------------------------------------------
// Example: Preserve slide transition timings in XAML using C#
//
// Description:
// Demonstrates how to preserve slide transition timings when exporting a
// PowerPoint presentation to XAML using C# and Aspose.Slides for .NET. The
// example sets transition types, click advance options, and timing values for
// the first three slides, then saves the presentation as XAML (retaining the
// timings) and as PPTX for verification.
//
// Keywords:
// C#, PowerPoint, PPTX, XAML, Aspose.Slides for .NET, Preserve, Slide, Transition,
// Timings, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate preservation of slide transition timings in XAML exports.
// - Build C# tools for PowerPoint presentation processing and conversion.
// - Generate or transform PPTX files to XAML while keeping animation data.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;
using Aspose.Slides.Export.Xaml;

namespace PreserveSlideTransitionTimings
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output directory for saved files
            string outputDir = "output";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Ensure the output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Presentation(inputPath);

                // Apply transition type, click advance and timing to the first slide (if it exists)
                if (presentation.Slides.Count > 0)
                {
                    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Fade;
                    presentation.Slides[0].SlideShowTransition.AdvanceOnClick = true;
                    presentation.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000; // 3 seconds
                }

                // Apply transition to the second slide (if it exists)
                if (presentation.Slides.Count > 1)
                {
                    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Wipe;
                    presentation.Slides[1].SlideShowTransition.AdvanceOnClick = true;
                    presentation.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000; // 5 seconds
                }

                // Apply transition to the third slide (if it exists)
                if (presentation.Slides.Count > 2)
                {
                    presentation.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;
                    presentation.Slides[2].SlideShowTransition.AdvanceOnClick = true;
                    presentation.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000; // 7 seconds
                }

                // Save the presentation as XAML preserving transition timings
                XamlOptions xamlOptions = new XamlOptions
                {
                    ExportHiddenSlides = true
                };
                string xamlOutputPath = Path.Combine(outputDir, "output.xaml");
                presentation.Save(xamlOutputPath, SaveFormat.Xaml, xamlOptions);

                // Additionally save as PPTX to verify the changes
                string pptxOutputPath = Path.Combine(outputDir, "output.pptx");
                presentation.Save(pptxOutputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., network errors if loading from a URL)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                // Ensure the presentation is properly disposed
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}
