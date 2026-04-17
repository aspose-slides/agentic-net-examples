using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideReorderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string inputPath = "input.pptx";
            string configPath = "order.txt";
            string outputPath = "output.pptx";

            // Verify input presentation exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file not found: " + inputPath);
                return;
            }

            // Verify configuration file exists
            if (!File.Exists(configPath))
            {
                Console.WriteLine("Configuration file not found: " + configPath);
                return;
            }

            try
            {
                // Read custom slide order from configuration file (comma or whitespace separated indices)
                string configContent = File.ReadAllText(configPath);
                string[] tokens = configContent.Split(new char[] { ',', ';', ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                List<int> newOrder = new List<int>();
                foreach (string token in tokens)
                {
                    int index;
                    if (int.TryParse(token, out index))
                    {
                        newOrder.Add(index);
                    }
                }

                // Load the presentation
                Presentation pres = new Presentation(inputPath);
                ISlideCollection slides = pres.Slides;

                // Reorder slides according to the custom sequence
                for (int targetIndex = 0; targetIndex < newOrder.Count && targetIndex < slides.Count; targetIndex++)
                {
                    int originalIndex = newOrder[targetIndex];
                    if (originalIndex < 0 || originalIndex >= slides.Count)
                    {
                        // Skip invalid indices
                        continue;
                    }

                    ISlide slideToMove = slides[originalIndex];
                    slides.Reorder(targetIndex, slideToMove);
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}