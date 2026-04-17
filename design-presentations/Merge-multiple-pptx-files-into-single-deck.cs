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
            // Input presentation files to merge
            string[] inputFiles = new string[] { "Presentation1.pptx", "Presentation2.pptx", "Presentation3.pptx" };
            // Output merged presentation
            string outputFile = "MergedPresentation.pptx";

            // Create destination presentation (empty with one slide)
            Presentation destPres = new Presentation();

            try
            {
                foreach (string inputPath in inputFiles)
                {
                    // Verify source file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    // Load source presentation
                    Presentation srcPres = null;
                    try
                    {
                        srcPres = new Presentation(inputPath);
                    }
                    catch (Exception ex)
                    {
                        // Handle unsupported format or loading errors
                        Console.WriteLine($"Failed to load {inputPath}: {ex.Message}");
                        continue;
                    }

                    // Clone each slide from source to destination preserving order
                    for (int i = 0; i < srcPres.Slides.Count; i++)
                    {
                        // AddClone adds a copy of the specified slide to the end of the collection
                        destPres.Slides.AddClone(srcPres.Slides[i]);
                    }

                    // Dispose source presentation
                    srcPres.Dispose();
                }

                // Save merged presentation
                destPres.Save(outputFile, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., unsupported format during save)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                // Ensure destination presentation is disposed
                destPres.Dispose();
            }
        }
    }
}