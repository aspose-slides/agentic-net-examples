using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TagLister
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "tags.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Access the tag collection
                    ITagCollection tagCollection = pres.CustomData.Tags;

                    // Retrieve all tag names
                    string[] tagNames = tagCollection.GetNamesOfTags();

                    // Write tag names to the output text file
                    using (StreamWriter writer = new StreamWriter(outputPath))
                    {
                        foreach (string tagName in tagNames)
                        {
                            writer.WriteLine(tagName);
                        }
                    }

                    // Save the presentation before exiting (no changes made)
                    pres.Save(inputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // If the format is not supported, comment accordingly
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}