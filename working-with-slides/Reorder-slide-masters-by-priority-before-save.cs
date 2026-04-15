using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReorderSlideMasters
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Define the desired master slide order by name (priority list)
            string[] masterPriority = new string[] { "Master1", "Master2", "Master3" };

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Get the master slide collection
                    IMasterSlideCollection masters = pres.Masters;

                    // Reorder masters according to the priority list
                    for (int targetIndex = 0; targetIndex < masterPriority.Length; targetIndex++)
                    {
                        string masterName = masterPriority[targetIndex];
                        IMasterSlide foundMaster = null;
                        int currentIndex = -1;

                        // Search for the master slide with the specified name
                        for (int i = 0; i < masters.Count; i++)
                        {
                            if (masters[i].Name == masterName)
                            {
                                foundMaster = masters[i];
                                currentIndex = i;
                                break;
                            }
                        }

                        // If the master slide is not found, skip to the next name
                        if (foundMaster == null || currentIndex == -1)
                        {
                            continue;
                        }

                        // If the master is already at the desired position, continue
                        if (currentIndex == targetIndex)
                        {
                            continue;
                        }

                        // Insert a clone of the master at the target position
                        IMasterSlide clonedMaster = masters.InsertClone(targetIndex, foundMaster);

                        // Remove the original master slide (adjust index if needed)
                        if (currentIndex > targetIndex)
                        {
                            // Insertion shifts indices to the right
                            masters.RemoveAt(currentIndex + 1);
                        }
                        else
                        {
                            masters.RemoveAt(currentIndex);
                        }
                    }

                    // Optionally remove any unused master slides
                    masters.RemoveUnused(false);

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle generic exceptions (e.g., unsupported format, I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
                // Comment: format not supported
            }
        }
    }
}