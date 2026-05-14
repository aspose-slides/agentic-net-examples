using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace ExtractConclusionTitles
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "ConclusionTitles.txt";

            // Verify input file exists
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
                    // Find the section named "Conclusion"
                    ISection conclusionSection = null;
                    for (int i = 0; i < presentation.Sections.Count; i++)
                    {
                        ISection sec = presentation.Sections[i];
                        if (sec.Name == "Conclusion")
                        {
                            conclusionSection = sec;
                            break;
                        }
                    }

                    if (conclusionSection == null)
                    {
                        Console.WriteLine("Conclusion section not found.");
                        // Save presentation before exit as required
                        presentation.Save(inputPath, SaveFormat.Pptx);
                        return;
                    }

                    // Get slides belonging to the Conclusion section
                    ISectionSlideCollection sectionSlides = conclusionSection.GetSlidesListOfSection();

                    // Write titles to the output text file
                    using (StreamWriter writer = new StreamWriter(outputPath, false))
                    {
                        foreach (ISlide slide in sectionSlides)
                        {
                            string title = string.Empty;

                            // Attempt to locate a shape that contains the title text
                            foreach (IShape shape in slide.Shapes)
                            {
                                if (shape is AutoShape)
                                {
                                    AutoShape autoShape = (AutoShape)shape;
                                    if (autoShape.TextFrame != null && !string.IsNullOrEmpty(autoShape.TextFrame.Text))
                                    {
                                        title = autoShape.TextFrame.Text;
                                        break;
                                    }
                                }
                            }

                            writer.WriteLine(title);
                        }
                    }

                    // Save the presentation before exiting
                    presentation.Save(inputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported: PPTX
                Console.WriteLine("The file format is not supported (PPTX).");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Format not supported: PPT
                Console.WriteLine("The file format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}