using RasArbitrCore.API;

namespace RasArbitrCore.Model
{
    public class ItemAnswerView
    {
        public Uri CaseId { get; set; } // url
        public Uri FileName { get; set; } //file url
        public string File { get; set; }
        public String Id { get; set; }

        public String Type { get; set; }

        public ItemAnswerView(PostResult.ItemData Data)
        {
            CaseId = new($"https://kad.arbitr.ru/Card/{Data.CaseId}");
            File = Data.FileName;
            FileName = new($"https://kad.arbitr.ru/Document/Pdf/{Data.CaseId}/{Data.Id}/{Data.FileName}");
            Id = Data.Id;

            Type = Data.Type;
        }

    }
}
