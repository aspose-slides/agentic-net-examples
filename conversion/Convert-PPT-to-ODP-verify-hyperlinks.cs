using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptToOdp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.ppt";
            string outputPath = "output.odp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Count hyperlinks before conversion
                int beforeCount = 0;
                foreach (ISlide slide in presentation.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape.HyperlinkClick != null)
                        {
                            beforeCount++;
                        }

                        IAutoShape autoShape = shape as IAutoShape;
                        if (autoShape != null && autoShape.TextFrame != null)
                        {
                            foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
                            {
                                foreach (IPortion portion in paragraph.Portions)
                                {
                                    if (portion.PortionFormat.HyperlinkClick != null)
                                    {
                                        beforeCount++;
                                    }
                                }
                            }
                        }
                    }
                }

                // Save as ODP format
                presentation.Save(outputPath, SaveFormat.Odp);
                presentation.Dispose();

                // Reload the saved ODP file
                Presentation convertedPresentation = new Presentation(outputPath);

                // Count hyperlinks after conversion
                int afterCount = 0;
                foreach (ISlide slide in convertedPresentation.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape.HyperlinkClick != null)
                        {
                            afterCount++;
                        }

                        IAutoShape autoShape = shape as IAutoShape;
                        if (autoShape != null && autoShape.TextFrame != null)
                        {
                            foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
                            {
                                foreach (IPortion portion in paragraph.Portions)
                                {
                                    if (portion.PortionFormat.HyperlinkClick != null)
                                    {
                                        afterCount++;
                                    }
                                }
                            }
                        }
                    }
                }

                // Validate hyperlink counts
                if (beforeCount == afterCount)
                {
                    Console.WriteLine("All hyperlinks are preserved after conversion.");
                }
                else
                {
                    Console.WriteLine("Hyperlink count mismatch. Before: " + beforeCount + ", After: " + afterCount);
                }

                // Save presentation before exit (already saved as ODP)
                convertedPresentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}