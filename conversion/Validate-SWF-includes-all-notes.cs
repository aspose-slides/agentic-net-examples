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
            var presentation = new Aspose.Slides.Presentation(inputPath);
            var swfOptions = new Aspose.Slides.Export.SwfOptions();

            // Enable notes and comments layouting
            var notesOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
            notesOptions.NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull;
            notesOptions.CommentsPosition = Aspose.Slides.Export.CommentsPositions.Right;
            swfOptions.SlidesLayoutOptions = notesOptions;

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

            // Simple validation to ensure the SWF file was created and is not empty
            if (File.Exists(outputPath) && new FileInfo(outputPath).Length > 0)
            {
                Console.WriteLine("SWF file generated successfully with notes and comments.");
            }
            else
            {
                Console.WriteLine("SWF file generation failed or file is empty.");
            }

            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}