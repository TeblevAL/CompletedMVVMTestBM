using MVVMTestBM.Core;

using System;

namespace MVVMTestBM.ViewModels
{
    public class BaseViewModel : ObservableObject, IDisposable
    {
        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) 
                return;

            if (disposing)
            {
                //dispose
            }

            _disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
    }
}
