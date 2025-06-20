public class ExcelFactory : DocumentFactory
{
    public override Document CreateDocument() => new ExcelDocument();
}