// WordFactory.cs
public class WordFactory : DocumentFactory
{
    public override Document CreateDocument() => new WordDocument();
}
