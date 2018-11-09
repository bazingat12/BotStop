using AngleSharp.Dom.Html;

namespace BotStop.Core
{
    interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}
