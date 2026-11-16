// -----------------------------------------------------------------------------
// Example: Adjust Slide Margins After Resizing Presentation
//
// Description:
// This console program loads a PPTX file, changes the slide size without automatic scaling, recalculates scaling factors, updates all shapes to preserve margins, and saves the modified presentation. It demonstrates slide resizing and margin adjustment using Aspose.Slides for .NET.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, slide size, margin adjustment, shape scaling
//
// Use Cases:
// - Reformatting existing presentations to new page dimensions while keeping layout intact.
// - Preparing slides for printing on different paper sizes without distorting content.
// - Automating batch processing of presentations to standardize slide margins.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

class Program
{
    static int Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        try
        {
            // Ensure input file exists; create a sample if missing
            if (!File.Exists(inputPath))
            {
                Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide sampleSlide = samplePres.Slides[0];
                // Add a rectangle shape as a sample content
                sampleSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 200);
                samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                samplePres.Dispose();
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Capture current slide dimensions
            float currentWidth = presentation.SlideSize.Size.Width;
            float currentHeight = presentation.SlideSize.Size.Height;

            // Set new slide size without automatic scaling
            float newWidth = 800f;
            float newHeight = 600f;
            presentation.SlideSize.SetSize(newWidth, newHeight, Aspose.Slides.SlideSizeScaleType.DoNotScale);

            // Compute scaling ratios
            float ratioWidth = presentation.SlideSize.Size.Width / currentWidth;
            float ratioHeight = presentation.SlideSize.Size.Height / currentHeight;

            // Scale shapes in master slides
            foreach (Aspose.Slides.IMasterSlide master in presentation.Masters)
            {
                foreach (Aspose.Slides.IShape shape in master.Shapes)
                {
                    shape.Width *= ratioWidth;
                    shape.Height *= ratioHeight;
                    shape.X *= ratioWidth;
                    shape.Y *= ratioHeight;

                    if (shape is Aspose.Slides.ITable)
                    {
                        Aspose.Slides.ITable table = (Aspose.Slides.ITable)shape;
                        foreach (Aspose.Slides.IRow row in table.Rows)
                        {
                            row.MinimalHeight *= ratioHeight;
                        }
                        foreach (Aspose.Slides.IColumn column in table.Columns)
                        {
                            column.Width *= ratioWidth;
                        }
                    }
                }

                // Scale shapes in layout slides
                foreach (Aspose.Slides.ILayoutSlide layout in master.LayoutSlides)
                {
                    foreach (Aspose.Slides.IShape shape in layout.Shapes)
                    {
                        shape.Width *= ratioWidth;
                        shape.Height *= ratioHeight;
                        shape.X *= ratioWidth;
                        shape.Y *= ratioHeight;

                        if (shape is Aspose.Slides.ITable)
                        {
                            Aspose.Slides.ITable table = (Aspose.Slides.ITable)shape;
                            foreach (Aspose.Slides.IRow row in table.Rows)
                            {
                                row.MinimalHeight *= ratioHeight;
                            }
                            foreach (Aspose.Slides.IColumn column in table.Columns)
                            {
                                column.Width *= ratioWidth;
                            }
                        }
                    }
                }
            }

            // Scale shapes in regular slides
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    shape.Width *= ratioWidth;
                    shape.Height *= ratioHeight;
                    shape.X *= ratioWidth;
                    shape.Y *= ratioHeight;

                    if (shape is Aspose.Slides.ITable)
                    {
                        Aspose.Slides.ITable table = (Aspose.Slides.ITable)shape;
                        foreach (Aspose.Slides.IRow row in table.Rows)
                        {
                            row.MinimalHeight *= ratioHeight;
                        }
                        foreach (Aspose.Slides.IColumn column in table.Columns)
                        {
                            column.Width *= ratioWidth;
                        }
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();

            Console.WriteLine("Presentation resized and margins adjusted successfully.");
            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
            return 1;
        }
    }
}
