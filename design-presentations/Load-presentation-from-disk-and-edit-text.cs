// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load presentation from disk and replace text using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation from disk, find and replace

// specific text strings using Aspose.Slides for .NET, and save the modified

// presentation. The example shows the essential steps for reading, editing,

// and writing PPTX files in a console application. Developers can adapt this

// pattern to automate text updates across slides.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Presentation, Disk, Replace Text,

// Text Editing, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate batch text replacement in PowerPoint files.

// - Build C# utilities for updating slide content programmatically.

// - Integrate text editing into .NET applications that generate or modify PPTX.

// - Validate and transform presentations before distribution.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using Aspose.Slides.Util;



class Program

{

    static void Main()

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

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Replace all occurrences of "Hello" with "Hi"

            Aspose.Slides.Util.SlideUtil.FindAndReplaceText(presentation, true, "Hello", "Hi", null);

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            presentation.Dispose();

        }

        catch (Exception ex)

        {

            // If the format is not supported, an exception will be thrown

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

