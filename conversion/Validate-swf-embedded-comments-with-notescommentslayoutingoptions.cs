using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesSwfExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            var inputPath = "input.pptx";
            var outputPath = "output.swf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                var presentation = new Aspose.Slides.Presentation(inputPath);

                // Configure SWF options with notes and comments layout
                var swfOptions = new Aspose.Slides.Export.SwfOptions();
                var notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
                notesOptions.CommentsPosition = Aspose.Slides.Export.CommentsPositions.Right;
                notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;
                swfOptions.SlidesLayoutOptions = notesOptions;

                // Save the presentation as SWF
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

                // Simple validation: check that the SWF file was created
                if (File.Exists(outputPath) && new FileInfo(outputPath).Length > 0)
                {
                    Console.WriteLine("SWF file saved successfully with embedded comments.");
                }
                else
                {
                    Console.WriteLine("SWF file was not created correctly.");
                }

                // Save the presentation before exiting (as required)
                presentation.Save("saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // If the exception is due to an unsupported format, comment that format is not supported
                // Format not supported.
            }
        }
    }
}