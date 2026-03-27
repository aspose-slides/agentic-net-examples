using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace SmartArtCsvReport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path (first argument) or default name
            string presentationPath = args.Length > 0 ? args[0] : "InputPresentation.pptx";

            // Load existing presentation if it exists; otherwise create a new one with a SmartArt diagram
            Presentation presentation;
            if (File.Exists(presentationPath))
            {
                presentation = new Presentation(presentationPath);
            }
            else
            {
                presentation = new Presentation();
                ISlide slide = presentation.Slides[0];
                // Add a basic SmartArt diagram
                ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);
                // Add a sample node with text
                ISmartArtNode node = smartArt.AllNodes.AddNode();
                node.TextFrame.Text = "Sample Node";
                node.IsAssistant = false;
            }

            // Prepare CSV output
            string csvPath = "SmartArtReport.csv";
            using (StreamWriter writer = new StreamWriter(csvPath, false, Encoding.UTF8))
            {
                // Write CSV header
                writer.WriteLine("SlideIndex,NodeText,FillStyle,IsAssistant");

                // Iterate through slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through shapes to find SmartArt objects
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];
                        if (shape is ISmartArt)
                        {
                            ISmartArt smartArt = (ISmartArt)shape;

                            // Iterate through all nodes in the SmartArt diagram
                            ISmartArtNodeCollection nodeCollection = smartArt.AllNodes;
                            foreach (ISmartArtNode node in nodeCollection)
                            {
                                // Retrieve node text
                                string nodeText = node.TextFrame != null ? node.TextFrame.Text : string.Empty;

                                // Retrieve fill style (bullet fill format)
                                string fillStyle = node.BulletFillFormat != null ? node.BulletFillFormat.FillType.ToString() : "None";

                                // Retrieve assistant status
                                string isAssistant = node.IsAssistant.ToString();

                                // Write CSV line
                                writer.WriteLine($"{slideIndex},{EscapeCsv(nodeText)},{fillStyle},{isAssistant}");
                            }
                        }
                    }
                }
            }

            // Save the presentation (required by lifecycle rule)
            presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);

            // Dispose presentation
            presentation.Dispose();
        }

        // Helper method to escape CSV fields containing commas or quotes
        private static string EscapeCsv(string field)
        {
            if (field.Contains(",") || field.Contains("\"") || field.Contains("\n"))
            {
                string escaped = field.Replace("\"", "\"\"");
                return $"\"{escaped}\"";
            }
            return field;
        }
    }
}