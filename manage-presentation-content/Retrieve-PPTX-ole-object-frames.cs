using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace OleObjectExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string sourcePath = "input.pptx";
            // Path to the output presentation (saved after processing)
            string outputPath = "output.pptx";

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(sourcePath))
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
                                // Retrieve embedded data if the OLE object is embedded
                                if (!oleFrame.IsObjectLink)
                                {
                                    byte[] embeddedData = oleFrame.EmbeddedData.EmbeddedFileData;
                                    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
                                    string extractedFileName = $"OleObject_{slideIndex}_{shapeIndex}{fileExtension}";

                                    // Save the embedded file to disk
                                    using (FileStream fileStream = new FileStream(extractedFileName, FileMode.Create, FileAccess.Write))
                                    {
                                        fileStream.Write(embeddedData, 0, embeddedData.Length);
                                    }

                                    Console.WriteLine($"Extracted embedded OLE object to: {extractedFileName}");
                                }
                                else
                                {
                                    // For linked OLE objects, display the relative path
                                    string relativePath = oleFrame.LinkPathRelative;
                                    Console.WriteLine($"Linked OLE object found on slide {slideIndex}, shape {shapeIndex}. Relative path: {relativePath}");
                                }
                            }
                        }
                    }

                    // Save the (potentially modified) presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}