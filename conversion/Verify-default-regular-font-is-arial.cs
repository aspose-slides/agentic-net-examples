// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Verify default regular font is arial using C#

//

// Description:

// Demonstrates how to verify that the default regular font used for SWF

// conversion is Arial using C# and Aspose.Slides for .NET. The example loads a

// PPTX file, checks the DefaultRegularFont property of SwfOptions, and then

// saves the presentation as an SWF file. This pattern can be used to ensure

// font settings before converting presentations to SWF format.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Verify, Default, Regular, Font, SwfOptions, Presentation Processing, Office Automation

//

// Use Cases:

// - Verify that the default regular font for SWF export is Arial.

// - Build C# utilities that validate font settings before converting PPTX to SWF.

// - Automate PowerPoint to SWF conversion with consistent font handling.

// - Integrate font verification into .NET presentation processing pipelines.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace TestSwfDefaultFont

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "sample.pptx";

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                Presentation presentation = new Presentation(inputPath);

                SwfOptions swfOptions = new SwfOptions();



                // Verify that DefaultRegularFont defaults to "Arial"

                string defaultFont = swfOptions.DefaultRegularFont;

                if (defaultFont == "Arial")

                {

                    Console.WriteLine("DefaultRegularFont defaults to Arial as expected.");

                }

                else

                {

                    Console.WriteLine("DefaultRegularFont default is not Arial. Actual: " + defaultFont);

                }



                string outputPath = "output.swf";

                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);



                // Save presentation before exit (already saved)

                presentation.Dispose();

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

