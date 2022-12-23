using RasArbitrCore.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasArbitrCore.Model {
    public class ItemAnswerView {
        public Uri CaseId { get; set; } // url
        public Uri FileName { get; set; } //file url
        public ItemAnswerView(PostResult.ItemData Data) {
            CaseId= new($"https://kad.arbitr.ru/Card/{Data.CaseId}");
            FileName = new($"https://kad.arbitr.ru/Document/Pdf/{Data.CaseId}/{Data.Id}/{Data.FileName}");
        }

    }
}
