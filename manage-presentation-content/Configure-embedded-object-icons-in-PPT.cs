using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConfigureEmbeddedObjectIcons
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to the input and output presentations
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Iterate through all slides
                foreach (ISlide slide in presentation.Slides)
                {
                    // Iterate through all shapes on the slide
                    foreach (IShape shape in slide.Shapes)
                    {
                        // Check if the shape is an OLE object
                        OleObjectFrame oleObject = shape as OleObjectFrame;
                        if (oleObject != null)
                        {
                            // Display the OLE object as an icon
                            oleObject.IsObjectIcon = true;

                            // Set a custom title for the icon
                            oleObject.SubstitutePictureTitle = "Custom OLE Icon Title";
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}