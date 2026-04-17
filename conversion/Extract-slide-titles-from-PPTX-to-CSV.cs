using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;
using Aspose.Slides.Export;

namespace SlideTitleExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputCsv = "titles.csv";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Presentation presentation = null;
            try
            {
                // Load presentation
                presentation = new Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Format not supported
                Console.WriteLine("The file format is not supported.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Prepare CSV writer
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(outputCsv, false);
                writer.WriteLine("SlideIndex,Title");
                // Iterate through slides
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide slide = presentation.Slides[i];
                    // Get all text boxes on the slide
                    ITextFrame[] textFrames = SlideUtil.GetAllTextBoxes(slide);
                    string title = "";
                    if (textFrames != null && textFrames.Length > 0)
                    {
                        // Assume the first text box contains the title
                        title = textFrames[0].Text;
                        // Replace line breaks and commas to keep CSV format simple
                        title = title.Replace("\r", " ").Replace("\n", " ").Replace(",", " ");
                    }
                    writer.WriteLine($"{i + 1},{title}");
                }
            }
            finally
            {
                if (writer != null)
                {
                    writer.Flush();
                    writer.Dispose();
                }
            }

            // Save presentation before exit (no changes made)
            try
            {
                presentation.Save(inputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
            finally
            {
                presentation.Dispose();
            }

            Console.WriteLine("Slide titles have been extracted to " + outputCsv);
        }
    }
}