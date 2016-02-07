using System;
using System.Text;

namespace UwpDiagnostics
{
    public class StringOutputWriter: BaseOutputWriter
    {
        private class SectionHelper: BaseSectionHelper
        {
            private readonly StringOutputWriter mParent;

            public SectionHelper(StringOutputWriter parent)
            {
                mParent = parent;
            }

            protected override void OnSectionEnd()
            {
                mParent.WriteLine(null);
                mParent.mSectionLevel--;
            }
        }

        private readonly StringBuilder mOutputBuilder = new StringBuilder();

        private int mSectionLevel = 0;

        private string GetPrefix()
        {
            return new String(' ', mSectionLevel * 4);
        }

        public override void WriteLine(string message)
        {
            if (String.IsNullOrWhiteSpace(message))
            {
                mOutputBuilder.AppendLine();
            }
            else
            {
                mOutputBuilder.Append(GetPrefix());
                mOutputBuilder.AppendLine(message);
            }
        }

        public override IDisposable StartSection(string title)
        {
            WriteLine(null);
            WriteLine(title + ":");
            mSectionLevel++;
            return new SectionHelper(this);
        }

        public override string ToString()
        {
            return mOutputBuilder.ToString();
        }
    }
}