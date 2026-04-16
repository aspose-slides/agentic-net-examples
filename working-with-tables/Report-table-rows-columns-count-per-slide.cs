using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesTableReport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine the presentation file path (use first argument or a default path)
            string presentationPath = args.Length > 0 ? args[0] : "input.pptx";

            // Verify that the file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(presentationPath))
                {
                    // Iterate through each slide
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        // Get the current slide
                        ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through each shape on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            // Attempt to cast the shape to a Table
                            Table table = slide.Shapes[shapeIndex] as Table;

                            // If the shape is a table, report its dimensions
                            if (table != null)
                            {
                                int rowCount = table.Rows.Count;
                                int columnCount = table.Columns.Count;
                                Console.WriteLine($"Slide {slideIndex + 1}, Table {shapeIndex + 1}: Rows = {rowCount}, Columns = {columnCount}");
                            }
                        }
                    }

                    // Save the presentation (optional – saves to a new file)
                    string outputPath = "output.pptx";
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // The presentation file format is not supported
                Console.WriteLine("The presentation file format is not supported.");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // The presentation file format is not supported (PPT version)
                Console.WriteLine("The presentation file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}