using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace OleObjectLockExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_fixed.pptx";

            // Load existing presentation if it exists; otherwise create a new one
            Presentation presentation;
            if (File.Exists(inputPath))
            {
                presentation = new Presentation(inputPath);
            }
            else
            {
                presentation = new Presentation();
            }

            // Iterate through all slides and lock OLE object frames
            foreach (ISlide slide in presentation.Slides)
            {
                foreach (IShape shape in slide.Shapes)
                {
                    OleObjectFrame oleObject = shape as OleObjectFrame;
                    if (oleObject != null)
                    {
                        // Prevent resizing and repositioning
                        oleObject.GraphicalObjectLock.PositionLocked = true;
                        oleObject.GraphicalObjectLock.SizeLocked = true;
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}