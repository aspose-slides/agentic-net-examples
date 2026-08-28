// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Test show hidden slides default false using C#

//

// Description:

// Demonstrates how to test that SwfOptions.ShowHiddenSlides defaults to false 

// using C# and Aspose.Slides for .NET. The example creates a new presentation, 

// verifies the default value, attempts to save the presentation as SWF, handles 

// the case where the format is not supported, and cleans up any generated file.

// This pattern can be used to validate conversion option defaults in 

// Aspose.Slides.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Test, Show, Hidden, Slides, 

// SwfOptions, Presentation Processing, Office Automation

//

// Use Cases:

// - Verify default behavior of SwfOptions.ShowHiddenSlides.

// - Build C# tests for presentation conversion settings.

// - Ensure SWF conversion respects hidden slide settings.

// - Automate validation of Aspose.Slides conversion options.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SwfOptionsTests

{

    class Program

    {

        static void Main()

        {

            // Create a new presentation instance

            Presentation presentation = new Presentation();



            // Instantiate SwfOptions

            SwfOptions swfOptions = new SwfOptions();



            // Verify that ShowHiddenSlides defaults to false

            if (swfOptions.ShowHiddenSlides != false)

            {

                throw new Exception("SwfOptions.ShowHiddenSlides default value is not false.");

            }



            // Define output file path

            string outputPath = "test_output.swf";



            // Attempt to save the presentation using SwfOptions

            try

            {

                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                // Comment: format not supported

            }



            // Clean up the generated file if it exists

            if (File.Exists(outputPath))

            {

                File.Delete(outputPath);

            }

        }

    }

}

