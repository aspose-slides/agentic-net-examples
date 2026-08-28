// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create GIF from PPTX 256 colors using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation (PPTX) to an animated

// GIF with a 256‑color palette using C# and Aspose.Slides for .NET. The example

// loads a PPTX file, applies default GIF options (which limit the output to

// 256 colors), and saves the result as an animated GIF. This pattern can be

// used to automate PPTX‑to‑GIF conversions in .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, GIF, 256 colors, Aspose.Slides for .NET, Presentation

// Conversion, Office Automation

//

// Use Cases:

// - Convert PPTX presentations to animated GIFs with a limited color palette.

// - Integrate PPTX‑to‑GIF conversion into C# tools or services.

// - Automate generation of lightweight GIF previews for PowerPoint files.

// - Validate visual output of presentations in automated pipelines.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        // Define input and output file paths

        string inputPath = "input.pptx";

        string outputPath = "output.gif";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            Presentation pres = new Presentation(inputPath);



            // Configure GIF options (GIF format uses a 256‑color palette by default)

            GifOptions gifOptions = new GifOptions();



            // Save the presentation as an animated GIF

            pres.Save(outputPath, SaveFormat.Gif, gifOptions);

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

