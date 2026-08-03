// -----------------------------------------------------------------------------
// Example: Batch replace picture frames using mapping dictionary using C#
//
// Description:
// Demonstrates how to batch replace picture frames in a PowerPoint presentation 
// using a mapping dictionary that associates image indices with new image files. 
// The example loads a PPTX file, iterates over the specified mappings, validates 
// each index and replacement image, substitutes the image data, and saves the 
// updated presentation. This pattern can be used to automate image updates in 
// existing slides.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Batch, Replace, Picture, 
// Frames, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate batch replacement of picture frames based on image index mapping.
// - Build tools for updating images in existing PPTX files programmatically.
// - Integrate image replacement logic into .NET applications handling presentations.
// - Validate and preprocess presentations before distribution or further processing.
// -----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchImageReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output presentation path
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file does not exist: " + inputPath);
                return;
            }

            // Mapping of image index to new image file path
            Dictionary<int, string> imageMap = new Dictionary<int, string>
            {
                { 0, "newImage0.png" },
                { 1, "newImage1.jpg" }
                // Add more mappings as needed
            };

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate over the mapping and replace images
                    foreach (KeyValuePair<int, string> kvp in imageMap)
                    {
                        int index = kvp.Key;
                        string newImagePath = kvp.Value;

                        // Validate index
                        if (index < 0 || index >= pres.Images.Count)
                        {
                            Console.WriteLine("Image index out of range: " + index);
                            continue;
                        }

                        // Validate new image file
                        if (!File.Exists(newImagePath))
                        {
                            Console.WriteLine("Replacement image file does not exist: " + newImagePath);
                            continue;
                        }

                        // Read new image data
                        byte[] newImageData = File.ReadAllBytes(newImagePath);

                        // Replace image data
                        IPPImage image = pres.Images[index];
                        image.ReplaceImage(newImageData);
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported format scenario
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
