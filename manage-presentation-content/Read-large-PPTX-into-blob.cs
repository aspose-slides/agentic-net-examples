using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesBlobExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation file
            string sourcePath = "input.pptx";
            // Path to the output presentation file (saved before exit)
            string outputPath = "output.pptx";

            try
            {
                // Open the source file as a FileStream
                using (FileStream fileStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
                {
                    // Load the presentation from the stream
                    using (Presentation presentation = new Presentation(fileStream))
                    {
                        // Save the presentation to a MemoryStream to obtain a binary BLOB
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            presentation.Save(memoryStream, SaveFormat.Pptx);
                            // Get the byte array representing the presentation
                            byte[] presentationBlob = memoryStream.ToArray();

                            // The BLOB can now be used for in‑memory processing
                            // Example: write the BLOB to another file (optional)
                            File.WriteAllBytes("presentation_blob.bin", presentationBlob);
                        }

                        // Ensure the presentation is saved to disk before exiting
                        presentation.Save(outputPath, SaveFormat.Pptx);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}