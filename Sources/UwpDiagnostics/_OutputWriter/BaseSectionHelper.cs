using System;

namespace UwpDiagnostics
{
    public abstract class BaseSectionHelper: IDisposable
    {
        public void Dispose()
        {
            OnSectionEnd();
        }

        protected abstract void OnSectionEnd();
    }
}