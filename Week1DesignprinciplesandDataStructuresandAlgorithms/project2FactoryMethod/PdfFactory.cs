
public class PdfFactory : DocumentFactory
{
    public override Document CreateDocument() => new PdfDocument();
}
