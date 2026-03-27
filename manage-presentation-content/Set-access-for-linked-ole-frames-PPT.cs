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
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Iterate through all slides
            for (int slideIdx = 0; slideIdx < presentation.Slides.Count; slideIdx++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIdx];

                // Iterate through all shapes on the slide
                for (int shapeIdx = 0; shapeIdx < slide.Shapes.Count; shapeIdx++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIdx];
                    Aspose.Slides.IOleObjectFrame oleFrame = shape as Aspose.Slides.IOleObjectFrame;

                    if (oleFrame != null)
                    {
                        // Enable automatic update for linked OLE objects
                        oleFrame.UpdateAutomatic = true;

                        // If the OLE object is linked, modify its absolute link path
                        if (oleFrame.IsObjectLink)
                        {
                            // Example new path; adjust as needed
                            oleFrame.LinkPathLong = @"C:\NewLinkedFile.xlsx";
                        }

                        // Output the relative link path for verification
                        Console.WriteLine("Relative link path: " + oleFrame.LinkPathRelative);
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}