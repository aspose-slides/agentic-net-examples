using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.swf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Create SWF export options
                SwfOptions swfOptions = new SwfOptions();

                // Configure custom notes layout (speaker annotations)
                NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
                notesOptions.NotesPosition = NotesPositions.BottomFull;

                // Assign notes layout to SWF options
                swfOptions.SlidesLayoutOptions = notesOptions;

                // Save presentation as SWF with the specified options
                pres.Save(outputPath, SaveFormat.Swf, swfOptions);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (System.Net.WebException)
        {
            // Handle external URL or web service exception
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}