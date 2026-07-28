// -----------------------------------------------------------------------------
// Example: Tag PPTX slide comments with keywords using C#
//
// Description:
// Demonstrates how to tag PPTX slide comments with keywords using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Pptx, Slide, Comments, 
// Keywords, Tagging, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate tagging PPTX slide comments with keywords.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TagCommentKeywords
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Define keywords to tag each comment with
            List<string> keywords = new List<string> { "Finance", "HR", "Marketing" };

            Presentation presentation = null;
            try
            {
                // Load presentation
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation. Details: " + ex.Message);
                return;
            }

            // Iterate through comment authors and their comments
            foreach (ICommentAuthor commentAuthor in presentation.CommentAuthors)
            {
                foreach (IComment comment in commentAuthor.Comments)
                {
                    // Add each keyword as a tag to the comment
                    foreach (string kw in keywords)
                    {
                        comment.Tags.Add(kw);
                    }
                }
            }

            try
            {
                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle save errors (e.g., unsupported format)
                Console.WriteLine("Failed to save presentation. Details: " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                presentation?.Dispose();
            }
        }
    }
}
