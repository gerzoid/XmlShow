using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLViewer2.Classes
{
    public class RtfHelper
    {
        StringBuilder _rtf;
        RichTextBox _rtb;
        public RtfHelper(RichTextBox rtb)
        {
            _rtb = rtb;
            _rtf = new StringBuilder();
            _rtf.Append(@"{\rtf1\ansi\deff0 }");
        }

        public void AddString(string text, bool bold = false)
        {
            int endOfDocumentIndex = _rtf.ToString().LastIndexOf('}');
            _rtf.Remove(endOfDocumentIndex, 1);
            if (bold) _rtf.Append("\\b ");
            _rtf.Append(text);
            if (bold) _rtf.Append("\\b0 ");
            _rtf.Append("\\par");
            _rtf.Append('}');
            _rtb.Rtf = _rtf.ToString();
        }

        public void AddTable(Dictionary<string, int> dic)
        {
            int endOfDocumentIndex = _rtf.ToString().LastIndexOf('}');
            _rtf.Remove(endOfDocumentIndex, 1);
            _rtf.Append('{');
            foreach (var item in dic)
                _rtf.Append($"\\trowd \\cellx2000 \\cellx4000\\intbl {item.Key}\\cell {item.Value}\\cell\\row");
            _rtf.Append("}}");
            _rtb.Rtf = _rtf.ToString();
        }

        public string GetString()
        {
            var res = _rtf.ToString();
            return res;
        }

    }
}
