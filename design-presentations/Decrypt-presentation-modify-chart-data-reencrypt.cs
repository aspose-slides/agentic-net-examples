// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Decrypt presentation modify chart data reencrypt using C#

//

// Description:

// Demonstrates how to open a password‑protected PowerPoint presentation, modify

// chart data, and re‑encrypt the file with a new password using C# and

// Aspose.Slides for .NET. The example loads the presentation, updates the first

// series of the first chart, applies a new encryption password, and saves the

// result as a new PPTX file.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Decrypt, Encrypt, Presentation,

// Modify, Chart, Presentation Processing, Office Automation

//

// Use Cases:

// - Decrypt a protected PPTX, edit its content, and protect it again.

// - Automate chart data updates in secured presentations.

// - Build .NET tools for secure PowerPoint workflow automation.

// - Validate and transform encrypted PPTX files in enterprise environments.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Input and output paths

        string inputPath = "protected.pptx";

        string outputPath = "modified_encrypted.pptx";

        string password = "oldPassword";

        string newPassword = "newPassword";



        // Verify input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        try

        {

            // Load the password‑protected presentation

            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();

            loadOptions.Password = password;

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions))

            {

                // Locate the first chart on the first slide

                Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes[0] as Aspose.Slides.Charts.IChart;

                if (chart == null)

                {

                    Console.WriteLine("No chart found on the first slide.");

                }

                else

                {

                    // Modify the first series by adding a new data point

                    Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

                    Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                    // Add a data point with value 200 at row 1, column 1 of the default worksheet (index 0)

                    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 200));

                }



                // Re‑encrypt the presentation with a new password

                presentation.ProtectionManager.Encrypt(newPassword);



                // Save the modified and re‑encrypted presentation

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            }

        }

        catch (Aspose.Slides.InvalidPasswordException)

        {

            Console.WriteLine("The provided password is incorrect.");

        }

        catch (Aspose.Slides.PptReadException)

        {

            Console.WriteLine("Error reading the presentation file.");

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The presentation format is not supported.");

        }

        catch (Exception ex)

        {

            // General exception handling (e.g., I/O errors)

            Console.WriteLine("An unexpected error occurred: " + ex.Message);

        }

    }

}

