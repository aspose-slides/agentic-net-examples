// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set default font to Arial before converting to SWF using C#

//

// Description:

// Demonstrates how to set the default regular font to Arial before saving a

// PowerPoint presentation as an SWF file using Aspose.Slides for .NET. The

// example loads a PPTX file, configures SwfOptions with the desired font, and

// saves the result as an SWF document. This pattern can be used in console

// applications or automated workflows that require font consistency during

// conversion.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Default Font, Arial, 

// Presentation Conversion, Office Automation

//

// Use Cases:

// - Ensure Arial is used as the fallback font when converting PPTX to SWF.

// - Build command‑line tools for batch conversion of presentations to SWF.

// - Integrate font‑consistent conversion into .NET services or applications.

// - Automate validation of presentation rendering before publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace Example

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.swf";



            // Check if the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



                // Create SWF save options and set default regular font to Arial

                Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();

                swfOptions.DefaultRegularFont = "Arial";



                // Save the presentation as SWF

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);



                // Dispose the presentation

                presentation.Dispose();



                Console.WriteLine("Presentation saved to SWF successfully.");

            }

            catch (Exception ex)

            {

                // Handle format not supported or other errors

                // Format not supported

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

