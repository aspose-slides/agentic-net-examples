using System;
using System.IO;
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
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Access the first shape on the slide and cast it to OleObjectFrame
        Aspose.Slides.IShape shape = slide.Shapes[0];
        Aspose.Slides.OleObjectFrame oleFrame = shape as Aspose.Slides.OleObjectFrame;

        if (oleFrame != null)
        {
            // Output some properties of the OLE object
            Console.WriteLine("IsObjectLink: " + oleFrame.IsObjectLink);
            Console.WriteLine("LinkPathRelative: " + oleFrame.LinkPathRelative);

            // If the OLE object is linked, enable automatic update
            if (oleFrame.IsObjectLink)
            {
                oleFrame.UpdateAutomatic = true;
            }
        }

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}