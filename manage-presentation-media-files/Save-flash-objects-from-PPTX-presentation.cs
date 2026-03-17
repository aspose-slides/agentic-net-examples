using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractFlashObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source PPTX file
                string sourcePath = "input.pptx";

                // Load the presentation
                using (Presentation presentation = new Presentation(sourcePath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        // Get the current slide
                        ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            // Attempt to cast the shape to OleObjectFrame
                            OleObjectFrame oleObjectFrame = slide.Shapes[shapeIndex] as OleObjectFrame;

                            if (oleObjectFrame != null && oleObjectFrame.EmbeddedData != null)
                            {
                                // Retrieve the embedded file data and its extension
                                byte[] fileData = oleObjectFrame.EmbeddedData.EmbeddedFileData;
                                string fileExtension = oleObjectFrame.EmbeddedData.EmbeddedFileExtension;

                                // Build a unique file name for the extracted object
                                string extractedFileName = $"Slide{slideIndex + 1}_Shape{shapeIndex + 1}{fileExtension}";

                                // Save the extracted data to disk
                                using (FileStream fileStream = new FileStream(extractedFileName, FileMode.Create, FileAccess.Write))
                                {
                                    fileStream.Write(fileData, 0, fileData.Length);
                                }

                                Console.WriteLine($"Extracted: {extractedFileName}");
                            }
                        }
                    }

                    // Save the presentation before exiting
                    string outputPath = "output.pptx";
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    Console.WriteLine($"Presentation saved as {outputPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}