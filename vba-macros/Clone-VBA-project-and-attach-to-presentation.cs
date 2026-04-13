using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

namespace CloneVbaProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string sourcePath = "source.pptx";
            string destinationPath = "destination.pptx";
            string outputPath = "output.pptx";

            // Verify that source and destination files exist
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist: " + sourcePath);
                return;
            }

            if (!File.Exists(destinationPath))
            {
                Console.WriteLine("Destination file does not exist: " + destinationPath);
                return;
            }

            try
            {
                // Load source presentation
                using (Presentation sourcePres = new Presentation(sourcePath))
                {
                    // Load destination presentation
                    using (Presentation destPres = new Presentation(destinationPath))
                    {
                        // Get VBA project from source presentation
                        IVbaProject sourceVba = sourcePres.VbaProject;

                        if (sourceVba != null)
                        {
                            // Export VBA project to binary representation
                            byte[] vbaBinary = sourceVba.ToBinary();

                            // Create a new VBA project from binary data
                            VbaProject newVba = new VbaProject(vbaBinary);

                            // Attach the cloned VBA project to the destination presentation
                            destPres.VbaProject = newVba;
                        }

                        // Save the destination presentation with the cloned VBA project
                        destPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}