// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Test show hidden slides in SWF using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation to SWF while

// including hidden slides using Aspose.Slides for .NET. The example loads a

// PPTX file, marks the first slide as hidden, configures SWF export options

// to show hidden slides, and saves the result as an SWF file. It also

// includes basic validation and error handling suitable for console

// applications.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Hidden Slides, Conversion,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Convert PPTX files to SWF while preserving hidden slides.

// - Build C# utilities for PowerPoint to SWF conversion.

// - Automate presentation workflows that require hidden slide visibility.

// - Validate and test SWF export settings in .NET applications.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SwfHiddenSlidesTest

{

    class Program

    {

        static void Main()

        {

            // Path to the source presentation

            string sourcePath = "sample.pptx";

            // Path to the output SWF file

            string outputPath = "output.swf";



            // Verify that the source file exists

            if (!File.Exists(sourcePath))

            {

                Console.WriteLine("Source file does not exist: " + sourcePath);

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(sourcePath))

                {

                    // Hide the first slide (if there is at least one slide)

                    if (presentation.Slides.Count > 0)

                    {

                        presentation.Slides[0].Hidden = true;

                    }



                    // Create SWF options and enable inclusion of hidden slides

                    SwfOptions swfOptions = new SwfOptions();

                    swfOptions.ShowHiddenSlides = true;



                    // Save the presentation as SWF with the specified options

                    presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

                }



                // Verify that the SWF file was created

                if (File.Exists(outputPath))

                {

                    Console.WriteLine("SWF file created successfully: " + outputPath);

                }

                else

                {

                    Console.WriteLine("Failed to create SWF file.");

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Comment: format not supported

                Console.WriteLine("The requested format is not supported.");

            }

            catch (Exception ex)

            {

                // Handle any other exceptions (e.g., I/O errors)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

