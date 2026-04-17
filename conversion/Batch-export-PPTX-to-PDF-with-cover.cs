using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace BatchExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect input and output directories as arguments
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: BatchExport <input_folder> <output_folder>");
                return;
            }

            string inputFolder = args[0];
            string outputFolder = args[1];

            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine($"Input folder does not exist: {inputFolder}");
                return;
            }

            if (!Directory.Exists(outputFolder))
            {
                try
                {
                    Directory.CreateDirectory(outputFolder);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to create output folder: {ex.Message}");
                    return;
                }
            }

            string[] pptxFiles = Directory.GetFiles(inputFolder, "*.pptx");
            foreach (string pptxPath in pptxFiles)
            {
                try
                {
                    // Load presentation
                    using (Presentation presentation = new Presentation(pptxPath))
                    {
                        // Collect slide titles
                        List<string> slideTitles = new List<string>();
                        for (int i = 0; i < presentation.Slides.Count; i++)
                        {
                            ISlide slide = presentation.Slides[i];
                            ITextFrame[] textFrames = SlideUtil.GetAllTextBoxes(slide);
                            if (textFrames != null && textFrames.Length > 0)
                            {
                                // Assume first text frame contains the title
                                slideTitles.Add(textFrames[0].Text);
                            }
                            else
                            {
                                slideTitles.Add($"Slide {i + 1}");
                            }
                        }

                        // Add cover slide at the beginning
                        ILayoutSlide layout = presentation.LayoutSlides[0];
                        ISlide coverSlide = presentation.Slides.AddEmptySlide(layout);
                        // Add a rectangle shape to hold the list
                        IAutoShape shape = coverSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, presentation.SlideSize.Size.Width - 100, presentation.SlideSize.Size.Height - 100);
                        shape.FillFormat.FillType = FillType.NoFill;
                        shape.LineFormat.FillFormat.FillType = FillType.NoFill;

                        // Build cover text
                        string coverText = "Table of Contents\r\n\r\n";
                        for (int i = 0; i < slideTitles.Count; i++)
                        {
                            coverText += $"{i + 1}. {slideTitles[i]}\r\n";
                        }

                        shape.TextFrame.Text = coverText;

                        // Save as PDF
                        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(pptxPath);
                        string pdfPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");
                        presentation.Save(pdfPath, SaveFormat.Pdf);
                    }
                }
                catch (PptxUnsupportedFormatException)
                {
                    // Format not supported
                    Console.WriteLine($"Unsupported format for file: {pptxPath}");
                }
                catch (Exception ex)
                {
                    // General exception handling
                    Console.WriteLine($"Error processing file {pptxPath}: {ex.Message}");
                }
            }
        }
    }
}