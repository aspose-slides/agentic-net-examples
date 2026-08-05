// -----------------------------------------------------------------------------
// Example: Convert slide to animated GIF 200ms delay using C#
//
// Description:
// Demonstrates how to convert a slide from a PowerPoint presentation to an
// animated GIF with a 200 ms frame delay using C# and Aspose.Slides for .NET.
// The example loads a PPTX file, configures GIF export options, and saves the
// result as an animated GIF. This pattern can be used to automate PPTX
// workflows, validate results, or integrate presentation logic into .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Convert, Slide, Animated, GIF,
// 200Ms, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate conversion of a slide to an animated GIF with a 200 ms delay.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
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
            Presentation presentation = new Presentation(inputPath);
            GifOptions gifOptions = new GifOptions
            {
                FrameSize = new Size(960, 720),
                DefaultDelay = 200, // 200 ms frame delay
                TransitionFps = 25
            };
            presentation.Save(outputPath, SaveFormat.Gif, gifOptions);
            presentation.Dispose();
        }
        catch (Exception ex) when (ex.Message.Contains("format"))
        {
            // Format not supported.
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
