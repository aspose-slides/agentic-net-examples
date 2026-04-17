using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Get or create the master notes slide
                IMasterNotesSlide masterNotes = presentation.MasterNotesSlideManager.MasterNotesSlide;
                if (masterNotes == null)
                {
                    masterNotes = presentation.MasterNotesSlideManager.SetDefaultMasterNotesSlide();
                }

                // Apply a custom solid background color to the notes master
                masterNotes.Background.Type = BackgroundType.OwnBackground;
                masterNotes.Background.FillFormat.FillType = FillType.Solid;
                masterNotes.Background.FillFormat.SolidFillColor.Color = Color.LightBlue;

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}