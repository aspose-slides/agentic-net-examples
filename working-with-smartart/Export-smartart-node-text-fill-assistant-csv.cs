using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace SmartArtCsvReport
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputCsv = "SmartArtReport.csv";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    List<string> csvLines = new List<string>();
                    // Header for CSV
                    csvLines.Add("SlideIndex,NodeText,FillStyle,IsAssistant");

                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        foreach (IShape shape in slide.Shapes)
                        {
                            // Identify SmartArt shapes
                            ISmartArt smartArt = shape as ISmartArt;
                            if (smartArt != null)
                            {
                                // Process all nodes recursively
                                ProcessSmartArtNodes(smartArt.AllNodes, slideIndex, csvLines);
                            }
                        }
                    }

                    // Write CSV file
                    File.WriteAllLines(outputCsv, csvLines);

                    // Save the presentation before exit
                    presentation.Save("ProcessedPresentation.pptx", SaveFormat.Pptx);
                }

                Console.WriteLine("CSV report generated: " + outputCsv);
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (PptUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        // Recursive method to process SmartArt nodes
        private static void ProcessSmartArtNodes(ISmartArtNodeCollection nodes, int slideIndex, List<string> csvLines)
        {
            foreach (ISmartArtNode node in nodes)
            {
                // Get node text
                string nodeText = string.Empty;
                if (node.TextFrame != null && node.TextFrame.Text != null)
                {
                    nodeText = node.TextFrame.Text;
                }

                // Get fill style (using bullet fill format if available)
                string fillStyle = "None";
                if (node.BulletFillFormat != null && node.BulletFillFormat.FillType != FillType.NoFill)
                {
                    fillStyle = node.BulletFillFormat.FillType.ToString();
                }

                // Assistant status
                string isAssistant = node.IsAssistant.ToString();

                // Add CSV line
                csvLines.Add(string.Format("{0},\"{1}\",{2},{3}", slideIndex, nodeText.Replace("\"", "\"\""), fillStyle, isAssistant));

                // Recursively process child nodes
                if (node.ChildNodes != null && node.ChildNodes.Count > 0)
                {
                    ProcessSmartArtNodes(node.ChildNodes, slideIndex, csvLines);
                }
            }
        }
    }
}