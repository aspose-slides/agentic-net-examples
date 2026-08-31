// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Modify master theme accent colors and save presentation using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation, modify the master theme's

// accent colors, and save the updated file using Aspose.Slides for .NET. The

// example illustrates the essential steps for presentation processing in a

// console application, enabling developers to programmatically adjust theme

// colors in PPTX files.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Theme, Accent Colors, Presentation

// Processing, Office Automation

//

// Use Cases:

// - Programmatically change accent colors of a presentation's master theme.

// - Build C# utilities for customizing PowerPoint theme colors.

// - Automate batch processing of PPTX files to apply corporate color schemes.

// - Validate and test theme modifications before distribution.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using System.Drawing;



class Program

{

    static void Main(string[] args)

    {

        string inputPath = "input.pptx";

        string outputPath = "output.pptx";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            Presentation pres = new Presentation(inputPath);



            // Modify accent colors of the master theme

            pres.MasterTheme.ColorScheme.Accent1.Color = Color.Red;

            pres.MasterTheme.ColorScheme.Accent2.Color = Color.Green;

            pres.MasterTheme.ColorScheme.Accent3.Color = Color.Blue;



            // Save the modified presentation

            pres.Save(outputPath, SaveFormat.Pptx);

        }

        catch (Aspose.Slides.PptxReadException ex)

        {

            Console.WriteLine("Failed to read the presentation: " + ex.Message);

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("File format not supported.");

        }

        catch (Exception ex)

        {

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

