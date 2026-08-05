// -----------------------------------------------------------------------------
// Example: Add line shape dash color variation using C#
//
// Description:
// Demonstrates how to create a PowerPoint presentation, add multiple line
// shapes each with a distinct dash style and line color, and save the result
// using Aspose.Slides for .NET. The example iterates through predefined dash
// styles and colors, creates a slide per variation, configures the line's
// formatting, and writes the presentation to a PPTX file.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, LineShape, DashStyle, LineColor, 
// PresentationGeneration, OfficeAutomation
//
// Use Cases:
// - Generate presentations with visual line style variations.
// - Automate creation of diagrammatic slides with custom dash patterns.
// - Build .NET utilities for batch processing of PPTX files.
// - Test and validate line formatting features in Aspose.Slides.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Define dash styles and corresponding colors
            Aspose.Slides.LineDashStyle[] dashStyles = new Aspose.Slides.LineDashStyle[]
            {
                Aspose.Slides.LineDashStyle.Solid,
                Aspose.Slides.LineDashStyle.Dash,
                Aspose.Slides.LineDashStyle.Dot,
                Aspose.Slides.LineDashStyle.DashDot,
                Aspose.Slides.LineDashStyle.LargeDash,
                Aspose.Slides.LineDashStyle.SystemDash
            };

            Color[] lineColors = new Color[]
            {
                Color.Red,
                Color.Green,
                Color.Blue,
                Color.Orange,
                Color.Purple,
                Color.Brown
            };

            // Create a slide for each dash style with a unique line
            for (int i = 0; i < dashStyles.Length && i < lineColors.Length; i++)
            {
                Aspose.Slides.ISlide slide;
                if (i == 0)
                {
                    // Use the default first slide
                    slide = presentation.Slides[0];
                }
                else
                {
                    // Add a new empty slide based on the layout of the first slide
                    slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
                }

                // Add a plain line shape
                Aspose.Slides.IAutoShape line = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);

                // Set line dash style
                line.LineFormat.DashStyle = dashStyles[i];

                // Set line color
                line.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                line.LineFormat.FillFormat.SolidFillColor.Color = lineColors[i];

                // Set line width
                line.LineFormat.Width = 5;
            }

            // Save the presentation
            string outputPath = "LinesPresentation.pptx";
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception)
            {
                // Handle format not supported or other save errors
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
