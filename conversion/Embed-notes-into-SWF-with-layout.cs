using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesSwfExport
{
    // Custom layout options to embed speaker notes
    public class MyNotesLayoutOptions : NotesCommentsLayoutingOptions
    {
        public MyNotesLayoutOptions()
        {
            this.NotesPosition = NotesPositions.BottomFull;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.swf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation pres = new Presentation(inputPath);

                // Configure SWF options with custom notes layout
                SwfOptions swfOptions = new SwfOptions();
                swfOptions.SlidesLayoutOptions = new MyNotesLayoutOptions();

                // Save as SWF with speaker notes embedded
                pres.Save(outputPath, SaveFormat.Swf, swfOptions);

                // Dispose presentation
                pres.Dispose();

                Console.WriteLine("Presentation saved as SWF with notes: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs, I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}