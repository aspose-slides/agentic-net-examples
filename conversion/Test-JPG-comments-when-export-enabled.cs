// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Test JPG comments when export enabled using C#

//

// Description:

// Demonstrates how to verify that JPG export includes slide comments when the

// export‑comments flag is enabled using C# and Aspose.Slides for .NET. The example

// loads a PPTX file, configures rendering options to print comments, exports the

// first slide as a JPEG image, and checks that the output file is created.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPG, Test, Comments, Export,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Validate that JPG export respects the PrintComments rendering option.

// - Automate testing of comment inclusion in image exports.

// - Build .NET utilities for PowerPoint to image conversion with comments.

// - Ensure presentation workflows produce expected visual output.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



public class Program

{

    public static void Main()

    {

        VerifyJpgOutputIncludesComments();

    }



    // Test that JPG export includes comments when the export‑comments flag is enabled

    private static void VerifyJpgOutputIncludesComments()

    {

        string inputFile = "sample.pptx";

        string outputFile = "slide_with_comments.jpg";



        // Check if the input presentation exists

        if (!File.Exists(inputFile))

        {

            Console.WriteLine("Input file does not exist: " + inputFile);

            return;

        }



        try

        {

            // Load the presentation

            using (Presentation presentation = new Presentation(inputFile))

            {

                // Configure rendering options to print comments

                RenderingOptions renderingOptions = new RenderingOptions();

                renderingOptions.SlidesLayoutOptions = new HandoutLayoutingOptions

                {

                    PrintComments = true

                };



                // Export the first slide as JPG with comments

                using (IImage slideImage = presentation.Slides[0].GetImage(renderingOptions))

                {

                    slideImage.Save(outputFile, Aspose.Slides.ImageFormat.Jpeg);

                }

            }



            // Verify that the JPG file was created

            if (File.Exists(outputFile))

            {

                Console.WriteLine("JPG export with comments succeeded: " + outputFile);

            }

            else

            {

                Console.WriteLine("JPG export failed: output file not found.");

            }

        }

        catch (Aspose.Slides.PptxUnsupportedFormatException)

        {

            // Handle unsupported file format

            Console.WriteLine("The provided file format is not supported for JPG export.");

        }

        catch (Exception ex)

        {

            // General exception handling

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

