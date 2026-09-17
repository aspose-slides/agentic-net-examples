// -----------------------------------------------------------------------------
// Example: Extract Author and Creation Date from 3D PowerPoint Presentation using C#
// 
// Description:
// This console application loads a PowerPoint (PPTX) file, extracts metadata
// such as the author name and creation date using Aspose.Slides for .NET, and
// logs the information to the console. It verifies the input file exists,
// handles unsupported formats, and saves the presentation before exiting.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, metadata extraction, author, creation date
// 
// Use Cases:
// - Retrieve document properties for auditing or reporting purposes.
// - Validate author information before publishing a presentation.
// - Automate metadata collection from a batch of PowerPoint files.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesMetadataExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string presentationPath = args.Length > 0 ? args[0] : "input.pptx";

            if (!File.Exists(presentationPath))
            {
                Console.WriteLine($"Error: File not found - {presentationPath}");
                return;
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationPath);
                Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

                string author = docProps.Author;
                DateTime? createdTime = docProps.CreatedTime;

                Console.WriteLine($"Author: {(string.IsNullOrEmpty(author) ? "N/A" : author)}");
                Console.WriteLine($"Created: {(createdTime.HasValue ? createdTime.Value.ToString("u") : "N/A")}");

                // Save the presentation (no modifications made) to ensure proper closure.
                presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                Console.WriteLine($"Unsupported PPTX format: {ex.Message}");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                Console.WriteLine($"Unsupported PPT format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
