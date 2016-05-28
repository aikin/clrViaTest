namespace BanKai.Basic.Common
{
    // ReSharper disable RedundantBaseQualifier

    internal abstract class BaseKeywordDemoClassBase
    {
        protected string Ending => ".";

        public virtual string Name => "BaseClass";
    }

    internal class BaseKeywordDemoClass : BaseKeywordDemoClassBase
    {
        public override string Name => base.Name + "'s derived class" + base.Ending;
    }

    // ReSharper restore RedundantBaseQualifier
}