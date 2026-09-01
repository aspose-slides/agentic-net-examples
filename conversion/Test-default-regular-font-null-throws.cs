// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Test default regular font null throws using C#

//

// Description:

// Demonstrates how to test that setting DefaultRegularFont to null throws an

// ArgumentNullException using Aspose.Slides for .NET. The example creates a

// presentation, attempts to assign a null default regular font, handles the

// expected exception, then sets a valid font and saves the presentation as a

// SWF file.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, SWF, DefaultRegularFont, ArgumentNullException,

// Presentation processing, Office automation

//

// Use Cases:

// - Verify that DefaultRegularFont property validates null values.

// - Build automated tests for font handling in Aspose.Slides.

// - Generate SWF output from presentations with a specified default font.

// - Integrate font validation logic into .NET PowerPoint processing tools.

// -----------------------------------------------------------------------------

using System;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace Example

{

    class Program

    {

        static void Main()

        {

            // Create a new presentation

            using (Presentation presentation = new Presentation())

            {

                SwfOptions options = new SwfOptions();



                try

                {

                    // Attempt to set DefaultRegularFont to null, expecting an exception

                    options.DefaultRegularFont = null;

                    Console.WriteLine("No exception thrown when setting null.");

                }

                catch (ArgumentNullException)

                {

                    Console.WriteLine("ArgumentNullException caught as expected.");

                }

                catch (Exception ex)

                {

                    Console.WriteLine("Unexpected exception: " + ex.GetType().Name);

                }



                // Set a valid font and save the presentation as SWF

                options.DefaultRegularFont = "Arial";

                presentation.Save("output.swf", SaveFormat.Swf, options);

            }

        }

    }

}

