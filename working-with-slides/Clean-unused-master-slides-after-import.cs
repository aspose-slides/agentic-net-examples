using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CleanUnusedMasters
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input file paths
            string sourcePath = "source.pptx";
            string targetPath = "target.pptx";
            string outputPath = "output.pptx";

            // Verify source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source presentation not found: " + sourcePath);
                return;
            }

            // Verify target file exists
            if (!File.Exists(targetPath))
            {
                Console.WriteLine("Target presentation not found: " + targetPath);
                return;
            }

            try
            {
                // Load source and target presentations
                using (Presentation sourcePres = new Presentation(sourcePath))
                using (Presentation targetPres = new Presentation(targetPath))
                {
                    // Import all master slides from source into target
                    for (int i = 0; i < sourcePres.Masters.Count; i++)
                    {
                        IMasterSlide sourceMaster = sourcePres.Masters[i];
                        targetPres.Masters.AddClone(sourceMaster);
                    }

                    // Remove duplicate master slides based on name
                    for (int i = 0; i < targetPres.Masters.Count; i++)
                    {
                        IMasterSlide masterI = targetPres.Masters[i];
                        int j = i + 1;
                        while (j < targetPres.Masters.Count)
                        {
                            IMasterSlide masterJ = targetPres.Masters[j];
                            if (masterI.Name == masterJ.Name)
                            {
                                // Duplicate found – remove it
                                targetPres.Masters.RemoveAt(j);
                            }
                            else
                            {
                                j++;
                            }
                        }
                    }

                    // Remove masters that are not used by any slide
                    targetPres.Masters.RemoveUnused(false);

                    // Save the modified presentation
                    targetPres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported – handle accordingly
                Console.WriteLine("The requested save format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., file I/O, Aspose errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}