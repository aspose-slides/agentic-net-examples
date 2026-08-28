// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Verify that SwfOptions.ViewerIncluded defaults to true using C#

//

// Description:

// Demonstrates how to verify the default value of the ViewerIncluded property

// in Aspose.Slides.Export.SwfOptions. The console application creates a

// SwfOptions instance, reads the ViewerIncluded flag, and reports whether it

// defaults to true. This pattern can be used for quick sanity checks or

// automated tests of Aspose.Slides for .NET configuration defaults.

//

// Keywords:

// C#, Aspose.Slides, SwfOptions, ViewerIncluded, Default Value, Test, .NET,

// Presentation Export, SWF Export

//

// Use Cases:

// - Confirm that ViewerIncluded defaults to true in a given Aspose.Slides version.

// - Include default‑value verification in automated test suites.

// - Provide developers with a minimal example for checking export option defaults.

// - Ensure consistent behavior when generating SWF files from presentations.

// -----------------------------------------------------------------------------



using System;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        try

        {

            // Create a new SwfOptions instance

            SwfOptions swfOptions = new SwfOptions();



            // Check the default value of ViewerIncluded

            bool viewerIncludedDefault = swfOptions.ViewerIncluded;



            if (viewerIncludedDefault)

            {

                Console.WriteLine("Test Passed: ViewerIncluded defaults to true.");

            }

            else

            {

                Console.WriteLine("Test Failed: ViewerIncluded default is not true.");

            }

        }

        catch (Exception ex)

        {

            // Handle any unexpected exceptions

            Console.WriteLine("Exception occurred: " + ex.Message);

        }

    }

}

