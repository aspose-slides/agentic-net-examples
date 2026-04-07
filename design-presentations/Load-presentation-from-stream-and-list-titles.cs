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
            // Path to the source presentation file
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Open a file stream for reading the presentation
            FileStream inputStream = null;
            Presentation presentation = null;
            try
            {
                inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
                // Load the presentation from the stream
                presentation = new Presentation(inputStream);
            }
            catch (PptxUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
                return;
            }
            catch (PptUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }
            finally
            {
                // Close the input stream if it was opened
                if (inputStream != null)
                {
                    inputStream.Close();
                }
            }

            // Enumerate slide titles
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                ISlide slide = presentation.Slides[i];
                string titleText = string.Empty;

                // Search for a shape that is a title placeholder
                for (int j = 0; j < slide.Shapes.Count; j++)
                {
                    IShape shape = slide.Shapes[j];
                    if (shape is IAutoShape && shape.Placeholder != null && shape.Placeholder.Type == PlaceholderType.Title)
                    {
                        IAutoShape autoShape = (IAutoShape)shape;
                        if (autoShape.TextFrame != null)
                        {
                            titleText = autoShape.TextFrame.Text;
                        }
                        break;
                    }
                }

                Console.WriteLine("Slide " + (i + 1) + " Title: " + (string.IsNullOrEmpty(titleText) ? "(No title)" : titleText));
            }

            // Save the presentation before exiting (optional: save to a new file)
            try
            {
                string outputPath = "output.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
            finally
            {
                // Dispose the presentation object
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}