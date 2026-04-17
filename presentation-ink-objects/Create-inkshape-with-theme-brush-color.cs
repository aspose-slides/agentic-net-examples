using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Theme;

namespace AsposeSlidesInkFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            string presentationPath = "input.pptx";
            Presentation pres = null;

            try
            {
                if (File.Exists(presentationPath))
                {
                    pres = new Presentation(presentationPath);
                }
                else
                {
                    pres = new Presentation();
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Example usage of the factory method
            IAutoShape inkShape = CreateInkShape(pres, 0, 50f, 50f, 400f, 2f, "Accent3");
            if (inkShape != null)
            {
                Console.WriteLine("Ink shape created on slide 0.");
            }

            try
            {
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle save errors (e.g., unsupported format)
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
        }

        // Factory method to create an Ink-like shape with brush color based on a theme accent
        static IAutoShape CreateInkShape(Presentation pres, int slideIndex, float x, float y, float width, float height, string themeAccent)
        {
            if (pres == null || slideIndex < 0 || slideIndex >= pres.Slides.Count)
            {
                return null;
            }

            ISlide slide = pres.Slides[slideIndex];

            // Add a line shape to emulate ink
            IAutoShape lineShape = slide.Shapes.AddAutoShape(ShapeType.Line, x, y, width, height);

            // Apply scribble sketch effect to mimic ink strokes
            lineShape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;

            // Determine the scheme color based on user input
            SchemeColor schemeColor;
            switch (themeAccent)
            {
                case "Accent1":
                    schemeColor = SchemeColor.Accent1;
                    break;
                case "Accent2":
                    schemeColor = SchemeColor.Accent2;
                    break;
                case "Accent3":
                    schemeColor = SchemeColor.Accent3;
                    break;
                case "Accent4":
                    schemeColor = SchemeColor.Accent4;
                    break;
                case "Accent5":
                    schemeColor = SchemeColor.Accent5;
                    break;
                case "Accent6":
                    schemeColor = SchemeColor.Accent6;
                    break;
                default:
                    // Default to Accent1 if unrecognized
                    schemeColor = SchemeColor.Accent1;
                    break;
            }

            // Set the line color using the selected theme accent
            lineShape.LineFormat.FillFormat.SolidFillColor.SchemeColor = schemeColor;

            return lineShape;
        }
    }
}