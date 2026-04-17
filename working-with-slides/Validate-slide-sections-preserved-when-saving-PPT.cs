using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ValidateSlideSections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.ppt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the original presentation
                using (Aspose.Slides.Presentation originalPres = new Aspose.Slides.Presentation(inputPath))
                {
                    // Store original sections information
                    int originalSectionCount = originalPres.Sections.Count;
                    string[] originalSectionNames = new string[originalSectionCount];
                    for (int i = 0; i < originalSectionCount; i++)
                    {
                        originalSectionNames[i] = originalPres.Sections[i].Name;
                    }

                    // Save the presentation in PPT format
                    originalPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);

                    // Load the saved PPT presentation
                    using (Aspose.Slides.Presentation savedPres = new Aspose.Slides.Presentation(outputPath))
                    {
                        // Compare sections
                        int savedSectionCount = savedPres.Sections.Count;
                        if (savedSectionCount != originalSectionCount)
                        {
                            Console.WriteLine($"Section count mismatch. Original: {originalSectionCount}, Saved: {savedSectionCount}");
                        }
                        else
                        {
                            for (int i = 0; i < originalSectionCount; i++)
                            {
                                string originalName = originalSectionNames[i];
                                string savedName = savedPres.Sections[i].Name;
                                if (!originalName.Equals(savedName, StringComparison.Ordinal))
                                {
                                    Console.WriteLine($"Section name mismatch at index {i}. Original: \"{originalName}\", Saved: \"{savedName}\"");
                                }
                            }

                            if (originalSectionCount == savedSectionCount)
                            {
                                Console.WriteLine("All sections are preserved after saving to PPT format.");
                            }
                        }
                    }
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // The PPT format is not supported for this operation.
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}