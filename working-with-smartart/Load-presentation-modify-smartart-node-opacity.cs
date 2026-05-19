using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation file path (optional)
            string inputPath = args.Length > 0 ? args[0] : string.Empty;
            byte[] presentationBytes;

            if (!string.IsNullOrEmpty(inputPath) && File.Exists(inputPath))
            {
                // Load file into memory
                presentationBytes = File.ReadAllBytes(inputPath);
            }
            else
            {
                // Create a new empty presentation if no valid file is provided
                using (Presentation emptyPres = new Presentation())
                {
                    using (MemoryStream tempStream = new MemoryStream())
                    {
                        emptyPres.Save(tempStream, SaveFormat.Pptx);
                        presentationBytes = tempStream.ToArray();
                    }
                }
            }

            // Load presentation from memory stream
            using (MemoryStream inputStream = new MemoryStream(presentationBytes))
            {
                try
                {
                    using (Presentation pres = new Presentation(inputStream))
                    {
                        // Find the first SmartArt shape on the first slide
                        ISmartArt smartArt = null;
                        foreach (IShape shape in pres.Slides[0].Shapes)
                        {
                            smartArt = shape as SmartArt;
                            if (smartArt != null)
                                break;
                        }

                        if (smartArt != null && smartArt.AllNodes.Count > 0)
                        {
                            // Get the first node
                            ISmartArtNode node = smartArt.AllNodes[0];

                            // Ensure the node has at least one shape
                            if (node.Shapes.Count > 0)
                            {
                                // Modify the fill of the first shape in the node
                                ISmartArtShape shapeInNode = node.Shapes[0];
                                shapeInNode.FillFormat.FillType = FillType.Solid;
                                // Set opacity to 50% (alpha = 128)
                                shapeInNode.FillFormat.SolidFillColor.Color = Color.FromArgb(128, 0, 0, 255);
                            }
                        }

                        // Save back to the same memory stream
                        inputStream.SetLength(0);
                        pres.Save(inputStream, SaveFormat.Pptx);
                    }
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
                catch (Exception)
                {
                    // Handle other exceptions as needed
                }
            }
        }
    }
}