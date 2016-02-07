using System;

namespace UwpDiagnostics
{
    public abstract class BaseOutputWriter
    {
        public abstract IDisposable StartSection(string title);
        public abstract void WriteLine(string message);
    }
}