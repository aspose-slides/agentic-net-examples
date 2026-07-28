// -----------------------------------------------------------------------------
// Example: Read modification date and compare timestamp using C#
//
// Description:
// Demonstrates how to read the modification date from a PowerPoint presentation's
// document properties and compare it with the file system's last write timestamp
// using Aspose.Slides for .NET. The example loads a PPTX file, retrieves the
// LastSavedTime property, obtains the file's last write time in UTC, compares the
// two values, and outputs the result. It also shows basic error handling for
// unsupported formats and general exceptions.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Read, Modification, Date,
// Compare, Timestamp, DocumentProperties, Presentation Processing, Office Automation
//
// Use Cases:
// - Verify that a presentation's internal LastSavedTime matches the file system timestamp.
// - Build validation tools for PowerPoint files in .NET applications.
// - Automate consistency checks during document management workflows.
// - Integrate presentation metadata verification into CI/CD pipelines.
// -----------------------------------------------------------------------------
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
