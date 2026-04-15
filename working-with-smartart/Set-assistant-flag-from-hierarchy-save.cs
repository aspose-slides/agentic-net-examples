using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace AsposeSlidesAssistantNodeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string hierarchyPath = "hierarchy.txt";

            // Verify that the input presentation exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Verify that the hierarchy data file exists
            if (!File.Exists(hierarchyPath))
            {
                Console.WriteLine("Hierarchy data file does not exist: " + hierarchyPath);
                return;
            }

            // Load hierarchy data (nodeIndex,isAssistant) e.g., "0,true"
            Dictionary<int, bool> assistantMap = new Dictionary<int, bool>();
            try
            {
                string[] lines = File.ReadAllLines(hierarchyPath);
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] parts = line.Split(',');
                    if (parts.Length != 2)
                        continue;

                    int nodeIndex = int.Parse(parts[0].Trim());
                    bool isAssistant = bool.Parse(parts[1].Trim());
                    assistantMap[nodeIndex] = isAssistant;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading hierarchy data: " + ex.Message);
                return;
            }

            // Load the presentation
            Presentation pres = null;
            try
            {
                pres = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load presentation. Possibly unsupported format.");
                Console.WriteLine("Exception: " + ex.Message);
                return;
            }

            try
            {
                // Process the first slide (adjust as needed)
                ISlide slide = pres.Slides[0];

                // Iterate through all shapes on the slide
                foreach (IShape shape in slide.Shapes)
                {
                    // Identify SmartArt shapes
                    if (shape is ISmartArt)
                    {
                        ISmartArt smartArt = (ISmartArt)shape;

                        // Iterate through all nodes in the SmartArt diagram
                        int nodeIdx = 0;
                        foreach (ISmartArtNode node in smartArt.AllNodes)
                        {
                            // Set IsAssistant based on external hierarchy data if available
                            if (assistantMap.ContainsKey(nodeIdx))
                            {
                                node.IsAssistant = assistantMap[nodeIdx];
                            }
                            else
                            {
                                // Default behavior: ensure node is not an assistant
                                node.IsAssistant = false;
                            }
                            nodeIdx++;
                        }
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while processing the presentation: " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                if (pres != null)
                {
                    pres.Dispose();
                }
            }
        }
    }
}