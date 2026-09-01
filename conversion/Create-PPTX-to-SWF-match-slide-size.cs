// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create PPTX to SWF match slide size using C#

//

// Description:

// Demonstrates how to convert a PPTX file to SWF while preserving the original

// slide dimensions using C# and Aspose.Slides for .NET. The example loads a

// presentation, explicitly sets the slide size to its current dimensions with

// no scaling, and saves the result as an SWF file. This pattern is useful for

// developers needing to generate SWF output that matches the source slide size

// for accurate rendering in legacy Flash environments.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Slide Size, Presentation Processing, Office Automation

//

// Use Cases:

// - Convert PPTX presentations to SWF while maintaining original slide dimensions.

// - Build C# utilities for PowerPoint to SWF conversion in .NET applications.

// - Automate batch processing of presentations for legacy Flash viewers.

// - Ensure size fidelity when integrating PowerPoint content into SWF-based workflows.

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

        string outputPath = "output.swf";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            float width = presentation.SlideSize.Size.Width;

            float height = presentation.SlideSize.Size.Height;

            presentation.SlideSize.SetSize(width, height, Aspose.Slides.SlideSizeScaleType.DoNotScale);



            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();



            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The file format is not supported for conversion.");

        }

        catch (Exception ex)

        {

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

