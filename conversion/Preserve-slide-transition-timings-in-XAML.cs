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
                    presentation.Slides[0].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
                    presentation.Slides[0].SlideShowTransition.AdvanceOnClick = true;
                    presentation.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000; // 3 seconds
                }

                // Apply transition to the second slide (if it exists)
                if (presentation.Slides.Count > 1)
                {
                    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Wipe;
                    presentation.Slides[1].SlideShowTransition.AdvanceOnClick = true;
                    presentation.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000; // 5 seconds
                }

                // Apply transition to the third slide (if it exists)
                if (presentation.Slides.Count > 2)
                {
                    presentation.Slides[2].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Zoom;
                    presentation.Slides[2].SlideShowTransition.AdvanceOnClick = true;
                    presentation.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000; // 7 seconds
                }

                // Save the presentation as XAML preserving transition timings
                XamlOptions xamlOptions = new XamlOptions();
                xamlOptions.ExportHiddenSlides = true;
                presentation.Save(xamlOptions);

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