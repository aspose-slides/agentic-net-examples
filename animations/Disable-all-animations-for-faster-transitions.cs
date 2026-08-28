// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Disable all animations for faster transitions using C#

//

// Description:

// Demonstrates how to disable all animations for faster transitions using C# 

// and Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Disable, Animations, Faster, 

// Transitions, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate disable all animations for faster transitions.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using Aspose.Slides.Animation;



namespace DisableAnimationsExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.pptx";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation pres = new Presentation(inputPath))

                {

                    // Disable slide show animations globally

                    pres.SlideShowSettings.ShowAnimation = false;



                    // Remove all individual animation effects from each slide

                    for (int i = 0; i < pres.Slides.Count; i++)

                    {

                        ISlide slide = pres.Slides[i];

                        ISequence mainSequence = slide.Timeline.MainSequence;

                        mainSequence.Clear();

                    }



                    // Save the modified presentation

                    pres.Save(outputPath, SaveFormat.Pptx);

                }



                Console.WriteLine("Presentation saved without animations to: " + outputPath);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The file format is not supported for this operation.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., external URL issues)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

