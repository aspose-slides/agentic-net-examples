// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Generate XAML for slide transitions in a PowerPoint presentation using C#

//

// Description:

// This example demonstrates how to load a PPTX file, assign different slide

// transition effects to each slide, and export the presentation to XAML format

// using Aspose.Slides for .NET. It includes basic error handling and ensures

// proper disposal of resources. The generated XAML can be used for further

// processing or integration in XAML‑based applications.

//

// Keywords:

// C#, Aspose.Slides, PPTX, PowerPoint, XAML export, Slide transitions, 

// Presentation automation, .NET console application

//

// Use Cases:

// - Programmatically add or modify slide transitions before exporting to XAML.

// - Create tooling that converts PowerPoint presentations to XAML for UI frameworks.

// - Automate batch processing of PPTX files to generate XAML representations.

// - Validate and test slide transition settings in a CI pipeline.

// -----------------------------------------------------------------------------



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

