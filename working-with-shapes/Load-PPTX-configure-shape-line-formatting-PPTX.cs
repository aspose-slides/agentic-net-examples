using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create load options and set TextAsShapes via dynamic to avoid compile‑time errors
                Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
                dynamic dynLoadOptions = loadOptions;
                dynLoadOptions.TextAsShapes = true;

                // Load the presentation with the specified options
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx", loadOptions))
                {
                    // Access the first slide
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Iterate through all shapes on the slide
                    for (int i = 0; i < slide.Shapes.Count; i++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[i];

                        // Configure line formatting if the shape supports it
                        if (shape.LineFormat != null)
                        {
                            Aspose.Slides.ILineFormat lineFormat = shape.LineFormat;
                            lineFormat.Width = 5;
                            lineFormat.DashStyle = Aspose.Slides.LineDashStyle.Dash;

                            // Set solid line color
                            if (lineFormat.FillFormat != null)
                            {
                                lineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                                lineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}