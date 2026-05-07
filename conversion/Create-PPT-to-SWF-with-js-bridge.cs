using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfConversionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect input and output file paths as arguments
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: SwfConversionExample <input-pptx> <output-swf>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file does not exist - " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Configure SWF options
                    SwfOptions swfOptions = new SwfOptions();
                    swfOptions.ViewerIncluded = true;               // Include the integrated viewer
                    swfOptions.ShowBottomPane = true;               // Show bottom pane (can be controlled via flashvars)
                    swfOptions.ShowTopPane = true;                  // Show top pane (can be controlled via flashvars)
                    swfOptions.SkipJavaScriptLinks = false;         // Preserve JavaScript hyperlinks for the bridge

                    // NOTE: To embed a custom JavaScript bridge, you can add JavaScript calls
                    // in the slide hyperlinks (e.g., "javascript:myBridgeFunction('slideChanged');").
                    // The SWF viewer will invoke these links, allowing communication with the host page.

                    // Save the presentation as SWF
                    presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                }

                // Presentation saved successfully
                Console.WriteLine("SWF file created at: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported comment
                // The requested format (SWF) is not supported by the current Aspose.Slides version or license.
                Console.WriteLine("Error: The SWF format is not supported in this environment.");
            }
            catch (Exception ex)
            {
                // Handle any other exceptions (e.g., I/O errors, licensing issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}