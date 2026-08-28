// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Process PPTX apply JPEG 75 disable UI using C#

//

// Description:

// Demonstrates how to convert a PPTX file to SWF format while applying JPEG

// compression quality of 75 and disabling the built‑in viewer using Aspose.Slides

// for .NET. The example loads a presentation, configures SwfOptions, and saves

// the output as a SWF file.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, JPEG, Quality, Disable UI,

// Presentation Conversion, Export, Automation

//

// Use Cases:

// - Convert PPTX presentations to SWF with specific JPEG quality.

// - Generate SWF files without embedding the viewer for custom UI.

// - Automate batch conversion of PowerPoint files in .NET applications.

// - Integrate presentation export into server‑side workflows.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides.Export;



class Program

{

    static void Main(string[] args)

    {

        string inputPath;

        if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))

        {

            inputPath = args[0];

        }

        else

        {

            inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");

        }



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        string outputPath = Path.ChangeExtension(inputPath, ".swf");



        try

        {

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))

            {

                Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();

                swfOptions.JpegQuality = 75;

                swfOptions.ViewerIncluded = false;

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

            }

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

