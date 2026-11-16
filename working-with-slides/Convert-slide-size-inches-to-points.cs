// -----------------------------------------------------------------------------
// Example: Convert Slide Size from Inches to Points using Aspose.Slides
//
// Description:
// Demonstrates how to convert slide dimensions specified in inches to points
// (1 inch = 72 points) and apply the size to a PowerPoint presentation using
// Aspose.Slides for .NET. The program creates a new PPTX file with the updated
// slide size, suitable for automation or integration scenarios.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Slide Size, Inches to Points, Presentation Automation
//
// Use Cases:
// - Automate conversion of slide dimensions from inches to points.
// - Generate PPTX files with custom slide sizes in .NET applications.
// - Validate slide size settings before publishing presentations.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace SlideSizeConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "ConvertedSlideSize.pptx";

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Desired slide size in inches
                float widthInches = 10.0f;
                float heightInches = 7.5f;

                // Convert inches to points (1 inch = 72 points)
                float widthPoints = widthInches * 72f;
                float heightPoints = heightInches * 72f;

                // Apply the new slide size with scaling to ensure content fits
                presentation.SlideSize.SetSize(widthPoints, heightPoints, Aspose.Slides.SlideSizeScaleType.EnsureFit);

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation saved successfully to: " + Path.GetFullPath(outputPath));
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("Error: The specified file format is not supported.");
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Environment.Exit(1);
            }
        }
    }
}
