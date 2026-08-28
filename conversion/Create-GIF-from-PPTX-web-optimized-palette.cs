// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create GIF from PPTX web optimized palette using C#

//

// Description:

// Demonstrates how to convert a PPTX presentation to an animated GIF optimized

// for web usage using Aspose.Slides for .NET. The example sets a custom frame

// size, slide delay, and transition frame rate to produce a lightweight GIF

// suitable for embedding in web pages. It includes basic error handling for

// missing input files and unsupported formats.

//

// Keywords:

// C#, PowerPoint, PPTX, GIF, Aspose.Slides for .NET, Web Optimized, Palette,

// Presentation Conversion, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX presentations to web‑friendly GIFs.

// - Build .NET tools for generating animated previews of slides.

// - Integrate PPTX‑to‑GIF conversion into web services or desktop utilities.

// - Ensure consistent GIF output settings across multiple presentations.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using System.Drawing;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        string inputPath = "input.pptx";

        string outputPath = "output.gif";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            Presentation pres = new Presentation(inputPath);

            GifOptions gifOptions = new GifOptions();

            gifOptions.FrameSize = new Size(960, 720); // optimized size for web

            gifOptions.DefaultDelay = 2000; // 2 seconds per slide

            gifOptions.TransitionFps = 35; // smoother transitions



            pres.Save(outputPath, SaveFormat.Gif, gifOptions);

            pres.Dispose();



            Console.WriteLine("GIF saved to " + outputPath);

        }

        catch (NotSupportedException)

        {

            // format not supported

            Console.WriteLine("The file format is not supported for GIF conversion.");

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

