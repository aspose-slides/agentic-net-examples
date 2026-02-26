class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a rectangle auto shape and cast it to GeometryShape
        Aspose.Slides.GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100) as Aspose.Slides.GeometryShape;

        // Create a custom geometry path (example: triangle)
        Aspose.Slides.GeometryPath geometryPath = new Aspose.Slides.GeometryPath();
        geometryPath.MoveTo(0, 0);
        geometryPath.LineTo(shape.Width, 0);
        geometryPath.LineTo(shape.Width / 2, shape.Height);
        geometryPath.CloseFigure();

        // Apply the custom geometry to the shape
        shape.SetGeometryPath(geometryPath);

        // Save the presentation
        pres.Save("CustomShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}