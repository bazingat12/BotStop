
namespace BotStop.Core.CDS
{
    class CdsSettings : IParserSettings
    {
        public CdsSettings(int start)
        {
            StartPoint = start;
        }

        public string BaseUrl { get; set; } = "https://m.cdsvyatka.com";//ссылка на сайт

        public string Prefix { get; set; } = "prediction.php?busstop={CurrentId}";//

        public int StartPoint { get; set; }

    }
}

