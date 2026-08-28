// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Configure viewer inclusion for SWF export based on deployment platform using C#

//

// Description:

// Demonstrates how to set the ViewerIncluded property of SwfOptions depending on

// the deployment platform (e.g., web or desktop) when converting a PowerPoint

// presentation (PPTX) to SWF format with Aspose.Slides for .NET. The example loads

// an input PPTX file, determines the platform from an environment variable, configures

// the export options accordingly, and saves the result as a SWF file.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, SWF, ViewerIncluded, Export Options,

// Deployment Platform, Environment Variable, Presentation Conversion

//

// Use Cases:

// - Export PPTX to SWF with or without the integrated viewer based on target platform.

// - Build automation scripts that adapt presentation export settings for web or desktop deployments.

// - Integrate conditional presentation export logic into .NET applications.

// - Validate and test platform‑specific export configurations.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Input and output file paths

        string inputPath = "input.pptx";

        string outputPath = "output.swf";



        // Check if the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            using (Presentation presentation = new Presentation(inputPath))

            {

                // Create SWF export options

                SwfOptions swfOptions = new SwfOptions();



                // Determine deployment platform (example: environment variable)

                string platform = Environment.GetEnvironmentVariable("DEPLOY_PLATFORM");

                if (string.Equals(platform, "Web", StringComparison.OrdinalIgnoreCase))

                {

                    // For web deployment, exclude the integrated viewer

                    swfOptions.ViewerIncluded = false;

                }

                else

                {

                    // For other platforms, include the viewer

                    swfOptions.ViewerIncluded = true;

                }



                // Save the presentation as SWF with the configured options

                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

            }

        }

        // Handle unsupported file format exceptions

        catch (Aspose.Slides.PptxUnsupportedFormatException)

        {

            // Format not supported

            Console.WriteLine("The presentation format is not supported.");

        }

        // General exception handling

        catch (Exception ex)

        {

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

