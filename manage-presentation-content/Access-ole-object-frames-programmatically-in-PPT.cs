using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input and output presentations
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        using (Presentation pres = new Presentation(inputPath))
        {
            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                ISlide slide = pres.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    IShape shape = slide.Shapes[shapeIndex];

                    // Check if the shape is an OLE object frame
                    OleObjectFrame oleFrame = shape as OleObjectFrame;
                    if (oleFrame != null)
                    {
                        // Extract embedded OLE data if it exists
                        IOleEmbeddedDataInfo embeddedInfo = oleFrame.EmbeddedData;
                        if (embeddedInfo != null)
                        {
                            byte[] data = embeddedInfo.EmbeddedFileData;
                            string extension = embeddedInfo.EmbeddedFileExtension;
                            string extractedPath = "extracted_" + slideIndex + "_" + shapeIndex + extension;

                            using (FileStream fs = new FileStream(extractedPath, FileMode.Create, FileAccess.Write))
                            {
                                fs.Write(data, 0, data.Length);
                            }

                            Console.WriteLine("Extracted OLE object to: " + extractedPath);
                        }

                        // Example: replace the OLE object with a new PNG image
                        string newImagePath = "newImage.png";
                        if (File.Exists(newImagePath))
                        {
                            byte[] newData = File.ReadAllBytes(newImagePath);
                            IOleEmbeddedDataInfo newEmbeddedInfo = new OleEmbeddedDataInfo(newData, "png");
                            oleFrame.SetEmbeddedData(newEmbeddedInfo);
                            Console.WriteLine("Replaced OLE object on slide " + slideIndex);
                        }
                    }
                }
            }

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}