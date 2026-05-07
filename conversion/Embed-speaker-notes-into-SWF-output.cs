using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class CustomNotesLayoutOptions : NotesCommentsLayoutingOptions
{
    // Custom implementation can be extended here if needed.
}

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.swf";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Add speaker notes to the first slide
                INotesSlideManager notesManager = pres.Slides[0].NotesSlideManager;
                INotesSlide notesSlide = notesManager.AddNotesSlide();
                notesSlide.NotesTextFrame.Text = "Speaker notes for slide 1.";

                // Configure SWF export options with custom notes layout
                SwfOptions swfOptions = new SwfOptions();
                swfOptions.SlidesLayoutOptions = new CustomNotesLayoutOptions();
                ((NotesCommentsLayoutingOptions)swfOptions.SlidesLayoutOptions).NotesPosition = NotesPositions.BottomFull;

                // Save the presentation as SWF with embedded notes
                pres.Save(outputPath, SaveFormat.Swf, swfOptions);

                // Save the presentation before exiting (as PPTX)
                pres.Save("saved_before_exit.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
            // Format not supported comment
            // The provided file format may not be supported by Aspose.Slides.
        }
    }
}