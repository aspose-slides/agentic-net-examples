using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        var inputPath = "input.pptx";
        var outputPath = "output.swf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Configure SWF options with custom notes layout
                var swfOptions = new Aspose.Slides.Export.SwfOptions();
                var notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
                notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull; // speaker annotations
                swfOptions.SlidesLayoutOptions = notesOptions;

                // Save as SWF
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
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