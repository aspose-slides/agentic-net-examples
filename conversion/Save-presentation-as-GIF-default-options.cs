// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Save presentation as GIF default options using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation to a GIF image using

// default conversion options with Aspose.Slides for .NET. The example loads a

// PPTX file, applies the built‑in GifOptions, and saves the result as a GIF file.

// This pattern can be used in console applications, automation scripts, or

// larger .NET solutions that need to transform presentations into GIF format.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Save, Presentation, GIF,

// Default Options, Conversion, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX files to GIF images.

// - Build C# utilities for PowerPoint presentation processing.

// - Generate GIF previews of slides in .NET applications.

// - Validate presentation conversion workflows before deployment.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



public static class GifConverter

{

    // Wraps Presentation.Save for GIF conversion with default options

    public static void ConvertToGif(string inputPath, string outputPath)

    {

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

            // Use default GIF options

            Aspose.Slides.Export.GifOptions options = new Aspose.Slides.Export.GifOptions();

            // Save as GIF

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, options);

            // Dispose the presentation

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The specified format is not supported for conversion.");

        }

        catch (Exception ex)

        {

            // General error handling

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}



public class Program

{

    public static void Main(string[] args)

    {

        // Expect input and output file paths as arguments

        if (args.Length < 2)

        {

            Console.WriteLine("Usage: <inputPath> <outputPath>");

            return;

        }



        string inputPath = args[0];

        string outputPath = args[1];



        GifConverter.ConvertToGif(inputPath, outputPath);

    }

}

