// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create GIF from PPT with looping using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation to an animated GIF

// with looping enabled using C# and Aspose.Slides for .NET. The example shows

// the required presentation-processing steps and produces a GIF file that

// repeats the slide show. Developers can use this pattern to automate PPTX

// to GIF conversion, integrate presentation logic into .NET applications, or

// validate results.

//

// Keywords:

// C#, PowerPoint, PPTX, GIF, Loop, Aspose.Slides for .NET, Presentation Processing,

// Office Automation

//

// Use Cases:

// - Automate conversion of PPTX files to looping animated GIFs.

// - Build C# utilities for PowerPoint presentation processing.

// - Generate GIF previews of slide decks in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string inputPath = "input.pptx";

        string outputPath = "output.gif";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            using (Presentation pres = new Presentation(inputPath))

            {

                // Enable looping for the slide show (preview will repeat)

                pres.SlideShowSettings.Loop = true;

                // Note: Aspose.Slides does not provide a direct loop count for GIF; looping is enabled.



                GifOptions gifOptions = new GifOptions();

                gifOptions.DefaultDelay = 1000; // 1 second per slide



                // Save the presentation as an animated GIF

                pres.Save(outputPath, SaveFormat.Gif, gifOptions);

            }

        }

        catch (Aspose.Slides.PptUnsupportedFormatException ex)

        {

            // Format not supported (PPT)

            Console.WriteLine("Unsupported PPT format: " + ex.Message);

        }

        catch (Aspose.Slides.PptxUnsupportedFormatException ex)

        {

            // Format not supported (PPTX)

            Console.WriteLine("Unsupported PPTX format: " + ex.Message);

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

