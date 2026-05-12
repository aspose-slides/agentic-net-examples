using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MergePresentations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input presentation files
            string[] inputFiles = new string[]
            {
                "Presentation1.pptx",
                "Presentation2.pptx",
                "Presentation3.pptx"
            };

            // Define output file
            string outputFile = "MergedPresentation.pptx";

            // Create destination presentation
            Presentation destPres = new Presentation();

            try
            {
                foreach (string inputFile in inputFiles)
                {
                    // Check if the source file exists
                    if (!File.Exists(inputFile))
                    {
                        // Skip missing files
                        continue;
                    }

                    try
                    {
                        // Load source presentation
                        Presentation srcPres = new Presentation(inputFile);

                        // Clone each slide from source to destination
                        for (int i = 0; i < srcPres.Slides.Count; i++)
                        {
                            // AddClone adds a copy of the specified slide to the end of the collection
                            destPres.Slides.AddClone(srcPres.Slides[i]);
                        }

                        // Dispose source presentation
                        srcPres.Dispose();
                    }
                    catch (Exception ex)
                    {
                        // Handle unsupported format or other loading errors
                        // Comment: format not supported or loading failed
                        Console.WriteLine($"Error processing file '{inputFile}': {ex.Message}");
                    }
                }

                // Save the merged presentation
                destPres.Save(outputFile, SaveFormat.Pptx);
            }
            finally
            {
                // Ensure the destination presentation is disposed
                destPres.Dispose();
            }
        }
    }
}