namespace BanKai.Basic.Common
{
    public class IndexerDemoClass
    {
        public string this[int integerArgument] => "You are accessing indexer " + integerArgument;

        public string this[string stringArgument] => "You are accessing indexer " + stringArgument;

        public string this[int firstArgument, string secondArgument] => $"You are accessing indexer with first argument {firstArgument} and second argument {secondArgument}";
    }
}