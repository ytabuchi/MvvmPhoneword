using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmPhoneword.Models
{
    public class Number
    {
        public string RawNumber { get; }
        public string TranslatedNumber { get; }
        public DateTime CalledDate { get; }

        public Number(string rawNumber, string translatedNumber, DateTime calledDate)
        {
            this.RawNumber = rawNumber;
            this.TranslatedNumber = translatedNumber;
            this.CalledDate = calledDate;
        }
    }
}
