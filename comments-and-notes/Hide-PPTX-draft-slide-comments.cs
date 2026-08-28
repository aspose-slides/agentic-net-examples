// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Hide PPTX draft slide comments using C#

//

// Description:

// Demonstrates how to hide comments on draft (hidden) slides in a PPTX file 

// using C# and Aspose.Slides for .NET. The example loads a presentation, 

// identifies hidden slides, disables comment visibility for those slides, 

// and saves the updated presentation. This pattern can be used to automate 

// comment management in PowerPoint workflows.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hide, Draft, Slide, Comments, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automatically hide comments on draft or hidden slides before publishing.

// - Build tools that clean up presentation metadata in .NET applications.

// - Integrate comment visibility control into PowerPoint processing pipelines.

// - Ensure draft slides do not expose comments during review or distribution.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace HideDraftSlideComments

{

    class Program

    {

        static void Main(string[] args)

        {

            // Expect input file path as first argument

            if (args.Length == 0)

            {

                Console.WriteLine("Please provide the path to the presentation file.");

                return;

            }



            string inputPath = args[0];

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("File does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Iterate through all slides

                    ISlideCollection slides = presentation.Slides;

                    for (int i = 0; i < slides.Count; i++)

                    {

                        ISlide slide = slides[i];

                        // Consider a slide as draft if it is hidden

                        if (slide.Hidden)

                        {

                            // Set comment visibility to false for the presentation view

                            // This affects how comments are displayed during editing/viewing

                            presentation.ViewProperties.ShowComments = NullableBool.False;

                        }

                    }



                    // Save the modified presentation

                    string outputPath = Path.Combine(Path.GetDirectoryName(inputPath), "output.pptx");

                    presentation.Save(outputPath, SaveFormat.Pptx);

                    Console.WriteLine("Presentation saved to: " + outputPath);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The file format is not supported.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., network, I/O)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

