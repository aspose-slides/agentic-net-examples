using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddIso8601TimestampWatermark
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = args.Length > 0 ? args[0] : string.Empty;
            string outputPath = args.Length > 1 ? args[1] : "WatermarkedPresentation.pptx";

            // Create or load presentation
            Presentation pres;
            if (!string.IsNullOrEmpty(inputPath) && File.Exists(inputPath))
            {
                try
                {
                    pres = new Presentation(inputPath);
                }
                catch (Exception ex)
                {
                    // If the file format is not supported, exit with a comment
                    Console.WriteLine("Error: The input file format is not supported. " + ex.Message);
                    return;
                }
            }
            else
            {
                // Create a new presentation if no valid input file is provided
                pres = new Presentation();
            }

            // Generate ISO 8601 timestamp
            string timestamp = DateTime.UtcNow.ToString("o");

            // Add watermark shape to each master slide (appears on all slides)
            for (int i = 0; i < pres.Masters.Count; i++)
            {
                IMasterSlide master = pres.Masters[i];
                // Add a rectangle shape that will hold the watermark text
                IAutoShape watermarkShape = master.Shapes.AddAutoShape(
                    ShapeType.Rectangle,
                    0f,          // X position
                    0f,          // Y position
                    500f,        // Width
                    50f);        // Height

                // Add the timestamp text
                watermarkShape.AddTextFrame(timestamp);
                // Center the text within the shape
                watermarkShape.TextFrame.TextFrameFormat.CenterText = NullableBool.True;
                // Make shape background and border transparent
                watermarkShape.FillFormat.FillType = FillType.NoFill;
                watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
            }

            // Save the presentation
            try
            {
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any saving errors (e.g., unsupported format)
                Console.WriteLine("Error: Unable to save the presentation. " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                pres.Dispose();
            }
        }
    }
}