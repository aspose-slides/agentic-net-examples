using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation presentation = new Presentation())
        {
            // Create a MathBlock with a simple expression "x^2 + y"
            MathBlock mathBlock = new MathBlock();
            mathBlock.Add(new MathematicalText("x"));
            mathBlock.Add(new MathematicalText("^"));
            mathBlock.Add(new MathematicalText("2"));
            mathBlock.Add(new MathematicalText(" + "));
            mathBlock.Add(new MathematicalText("y"));

            // Export MathBlock to MathML using MemoryStream
            using (MemoryStream ms = new MemoryStream())
            {
                try
                {
                    mathBlock.WriteAsMathMl(ms);
                    ms.Position = 0;
                    using (StreamReader reader = new StreamReader(ms))
                    {
                        string mathMl = reader.ReadToEnd();
                        Console.WriteLine(mathMl);
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exception that may occur during MathML export
                    Console.WriteLine("Error exporting MathML: " + ex.Message);
                }
            }

            // Save the presentation before exit
            try
            {
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Format not supported
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}