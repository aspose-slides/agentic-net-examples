using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceCommentPlaceholders
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

            // Configuration dictionary with placeholder values
            Dictionary<string, string> config = new Dictionary<string, string>()
            {
                { "{CompanyName}", "Contoso Ltd." },
                { "{Year}", DateTime.Now.Year.ToString() },
                { "{Author}", "John Doe" }
            };

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation. Possible unsupported format. Details: " + ex.Message);
                return;
            }

            // Iterate through comment authors and their comments
            foreach (Aspose.Slides.ICommentAuthor commentAuthor in presentation.CommentAuthors)
            {
                foreach (Aspose.Slides.IComment comment in commentAuthor.Comments)
                {
                    string originalText = comment.Text;
                    string replacedText = originalText;

                    foreach (KeyValuePair<string, string> kvp in config)
                    {
                        replacedText = replacedText.Replace(kvp.Key, kvp.Value);
                    }

                    // Update comment text if changes were made
                    if (!originalText.Equals(replacedText))
                    {
                        comment.Text = replacedText;
                    }
                }
            }

            try
            {
                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle save errors (e.g., unsupported format)
                Console.WriteLine("Failed to save presentation. Details: " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}