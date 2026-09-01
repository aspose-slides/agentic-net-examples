// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Test SwfOptions JPEGQuality above 100 throws using C#

//

// Description:

// Demonstrates how setting SwfOptions.JpegQuality to a value greater than 100

// triggers an ArgumentOutOfRangeException when saving a presentation as SWF

// with Aspose.Slides for .NET. The example creates a minimal presentation,

// configures invalid JPEG quality, attempts to save, and verifies that the

// expected exception is thrown.

//

// Keywords:

// C#, Aspose.Slides for .NET, SwfOptions, JpegQuality, ArgumentOutOfRangeException,

// SWF, PowerPoint, Presentation conversion, Test, Validation

//

// Use Cases:

// - Verify that invalid JPEG quality values are correctly rejected.

// - Include exception‑handling tests in automated CI pipelines for presentation conversion.

// - Demonstrate proper error handling when configuring SwfOptions.

// - Provide a reference for developers implementing custom SWF export logic.

// -----------------------------------------------------------------------------



using System;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SwfOptionsTest

{

    class Program

    {

        static void Main(string[] args)

        {

            // Create a new presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();



            // Create SwfOptions

            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();



            bool exceptionThrown = false;

            try

            {

                // Set invalid JpegQuality (>100)

                swfOptions.JpegQuality = 101;



                // Attempt to save presentation (should throw)

                presentation.Save("output.swf", Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

            }

            catch (ArgumentOutOfRangeException)

            {

                exceptionThrown = true;

                Console.WriteLine("Expected exception caught: JpegQuality out of range.");

            }

            catch (Exception ex)

            {

                // Unexpected exception

                Console.WriteLine("Unexpected exception: " + ex.Message);

            }

            finally

            {

                // Ensure presentation is saved if no exception (fallback)

                if (!exceptionThrown)

                {

                    // Save with default options

                    presentation.Save("output_default.swf", Aspose.Slides.Export.SaveFormat.Swf);

                }

                presentation.Dispose();

            }



            // Indicate test result

            if (exceptionThrown)

            {

                Console.WriteLine("Test passed.");

            }

            else

            {

                Console.WriteLine("Test failed: exception not thrown.");

            }

        }

    }

}

