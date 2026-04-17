using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the presentation file
            string presentationPath = "sample.pptx";

            // Check if the file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("File does not exist: " + presentationPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationPath))
                {
                    // Access document properties
                    Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

                    // Get the last saved time from the document properties (UTC)
                    DateTime lastSavedUtc = docProps.LastSavedTime;

                    // Get the file system last write time (UTC)
                    DateTime fileLastWriteUtc = File.GetLastWriteTimeUtc(presentationPath);

                    // Compare the two timestamps
                    if (lastSavedUtc == fileLastWriteUtc)
                    {
                        Console.WriteLine("Document property LastSavedTime matches the file system timestamp.");
                    }
                    else
                    {
                        Console.WriteLine("Document property LastSavedTime does NOT match the file system timestamp.");
                        Console.WriteLine("Document property: " + lastSavedUtc.ToString("o"));
                        Console.WriteLine("File system timestamp: " + fileLastWriteUtc.ToString("o"));
                    }

                    // Save the presentation before exiting (no changes made)
                    presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Handle unsupported PPTX format
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                // Handle unsupported PPT format
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}