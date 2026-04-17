using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceFlashWithPlaceholder
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string placeholderImagePath = "placeholder.png";

            // Verify that input files exist
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file does not exist: " + inputPath);
                return;
            }

            if (!File.Exists(placeholderImagePath))
            {
                Console.WriteLine("Placeholder image file does not exist: " + placeholderImagePath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Load placeholder image bytes once
                byte[] placeholderBytes = File.ReadAllBytes(placeholderImagePath);
                Aspose.Slides.IPPImage placeholderImg = pres.Images.AddImage(placeholderBytes);

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                    // Get the collection of ActiveX controls on the slide
                    Aspose.Slides.IControlCollection controls = slide.Controls;

                    // Iterate through controls to find flash (ActiveX) objects
                    for (int ctrlIndex = 0; ctrlIndex < controls.Count; ctrlIndex++)
                    {
                        Aspose.Slides.IControl ctrl = controls[ctrlIndex];

                        // Identify flash objects by name or other criteria if needed
                        // Here we treat every control as a flash object to replace
                        Aspose.Slides.Control flashControl = ctrl as Aspose.Slides.Control;
                        if (flashControl != null)
                        {
                            // Retrieve the control's frame (position and size)
                            Aspose.Slides.IShapeFrame frame = flashControl.Frame;

                            // Add a picture placeholder at the same position
                            slide.Shapes.AddPictureFrame(
                                Aspose.Slides.ShapeType.Rectangle,
                                frame.X,
                                frame.Y,
                                frame.Width,
                                frame.Height,
                                placeholderImg);
                        }
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported for this operation.
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}