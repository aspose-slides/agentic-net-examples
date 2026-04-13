using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace UpdateCustomDataExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Get the first slide (adjust index as needed)
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Get the first shape on the slide (adjust index as needed)
                    Aspose.Slides.IShape shape = slide.Shapes[0];

                    // Access the shape's custom data tags collection
                    Aspose.Slides.ITagCollection tags = shape.CustomData.Tags;

                    // Update an existing tag or add a new one
                    tags["MyTag"] = "UpdatedValue";

                    // Save the presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., network errors, I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}