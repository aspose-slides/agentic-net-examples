// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load PPTX from bytes modify master background using C#

//

// Description:

// Demonstrates how to load a PPTX from a byte array, modify the master slide

// background color, and save the result using Aspose.Slides for .NET. The

// example shows the required presentation‑processing steps for PowerPoint files

// and produces the requested output in a standalone console application.

// Developers can use this pattern to automate PPTX workflows, validate results,

// or integrate presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Bytes, Modify, Master

// Background, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate loading a PPTX from bytes and changing the master slide background.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

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

        // Expect input and output file paths as arguments

        if (args.Length < 2)

        {

            Console.WriteLine("Usage: Program <input.pptx> <output.pptx>");

            return;

        }



        string inputPath = args[0];

        string outputPath = args[1];



        // Check if input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Read presentation bytes from file

            byte[] inputBytes = File.ReadAllBytes(inputPath);



            // Load presentation from byte array

            PresentationFactory factory = new PresentationFactory();

            IPresentation pres = factory.ReadPresentation(inputBytes);



            // Update master slide background

            pres.Masters[0].Background.Type = BackgroundType.OwnBackground;

            pres.Masters[0].Background.FillFormat.FillType = FillType.Solid;

            pres.Masters[0].Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;



            // Save modified presentation to a memory stream

            using (MemoryStream ms = new MemoryStream())

            {

                pres.Save(ms, SaveFormat.Pptx);

                byte[] outputBytes = ms.ToArray();



                // Write the modified bytes to the output file

                File.WriteAllBytes(outputPath, outputBytes);

            }



            // Dispose presentation

            pres.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

