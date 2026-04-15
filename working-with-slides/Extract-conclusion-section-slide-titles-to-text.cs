using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "ConclusionTitles.txt";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Find the section named "Conclusion"
                    ISection conclusionSection = null;
                    for (int i = 0; i < pres.Sections.Count; i++)
                    {
                        ISection sec = pres.Sections[i];
                        if (sec.Name == "Conclusion")
                        {
                            conclusionSection = sec;
                            break;
                        }
                    }

                    if (conclusionSection == null)
                    {
                        Console.WriteLine("Section 'Conclusion' not found.");
                    }
                    else
                    {
                        // Get slides belonging to the Conclusion section
                        ISectionSlideCollection sectionSlides = conclusionSection.GetSlidesListOfSection();

                        // Write slide titles to the text file
                        using (StreamWriter writer = new StreamWriter(outputPath, false))
                        {
                            for (int i = 0; i < sectionSlides.Count; i++)
                            {
                                ISlide slide = sectionSlides[i];
                                // Use the slide's Name property as its title
                                string title = slide.Name;
                                writer.WriteLine(title);
                            }
                        }

                        Console.WriteLine("Titles extracted to: " + outputPath);
                    }

                    // Save the presentation before exiting (no changes made)
                    pres.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}