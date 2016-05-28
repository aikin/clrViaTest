namespace BanKai.Basic.Common
{
    internal class GenericMethodDemoClass
    {
        public static string ResolvableGenericMethod<T>(T arg)
        {
            return $"ResolvableGenericMethod(T) called. T is {typeof (T).Name}";
        }

        public static string NotResolvableGenericMethod<T>()
        {
            return $"NotResolvableGenericMethod() called. T is {typeof (T).Name}";
        }
    }
}