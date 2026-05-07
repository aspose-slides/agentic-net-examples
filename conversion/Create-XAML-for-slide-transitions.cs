using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Export.Xaml;

namespace SlideTransitionXamlGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;

            try
            {
                // Load the presentation
                presentation = new Aspose.Slides.Presentation(inputPath);

                // Apply different transitions to each slide
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[i];

                    // Choose a transition type based on slide index
                    if (i % 3 == 0)
                    {
                        slide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
                    }
                    else if (i % 3 == 1)
                    {
                        slide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Wipe;
                    }
                    else
                    {
                        slide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Zoom;
                    }

                    // Set common transition properties
                    slide.SlideShowTransition.AdvanceOnClick = true;
                    slide.SlideShowTransition.AdvanceAfterTime = 3000; // 3 seconds
                }

                // Configure XAML export options
                Aspose.Slides.Export.Xaml.XamlOptions xamlOptions = new Aspose.Slides.Export.Xaml.XamlOptions();
                xamlOptions.ExportHiddenSlides = true;

                // Save the presentation as XAML files
                presentation.Save(xamlOptions);
            }
            catch (System.NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested format is not supported.");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Ensure the presentation is disposed before exiting
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}