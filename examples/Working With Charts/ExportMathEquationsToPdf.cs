using System;

class Program
{
    static void Main()
    {
        // Output directory and file
        System.String outputDir = "Output";
        if (!System.IO.Directory.Exists(outputDir))
            System.IO.Directory.CreateDirectory(outputDir);
        System.String outPath = System.IO.Path.Combine(outputDir, "MathEquation.pdf");

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a mathematical shape to the first slide
        Aspose.Slides.IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

        // Retrieve the math paragraph from the shape
        Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Build the equation a + b = c and add it to the paragraph
        mathParagraph.Add(new Aspose.Slides.MathText.MathematicalText("a")
            .Join("+")
            .Join(new Aspose.Slides.MathText.MathematicalText("b"))
            .Join("=")
            .Join(new Aspose.Slides.MathText.MathematicalText("c")));

        // Save the presentation as PDF
        pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pdf);

        // Clean up
        pres.Dispose();
    }
}