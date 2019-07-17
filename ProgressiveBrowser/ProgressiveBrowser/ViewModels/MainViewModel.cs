using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using ProgressiveBrowser.Models;

namespace ProgressiveBrowser.ViewModels
{
    public class MainViewModel : BindableBase
    {
        #region DI
        private readonly ICommunicator _communicator;
        #endregion

        #region backing fields
        private DelegateCommand _sendGetCommand;
        private DelegateCommand _downloadCommand;
        private string _gotPayload;
        #endregion

        #region ctor
        public MainViewModel(ICommunicator communicator)
        {
            _communicator = communicator;
        }
        #endregion

        #region props
        public DelegateCommand SendGetCommand => _sendGetCommand ?? (_sendGetCommand = new DelegateCommand(async () => await SendGetAsync()) );
        public DelegateCommand DownloadCommand => _downloadCommand ?? (_downloadCommand = new DelegateCommand(async () => await DownloadImgAsync()));

        public string GotPayload
        {
            get => _gotPayload;
            private set
            {
                _gotPayload = value;
                RaisePropertyChanged(nameof(GotPayload));
            }
        }

        public string Url { get; set; } = "https://www.google.co.jp/";
        #endregion

        #region methods
        private async Task SendGetAsync()
        {
            GotPayload = await _communicator.GetAsync(Url);
        }

        private async Task DownloadImgAsync()
        {
            await _communicator.DownloadImgAsync();
        }
        #endregion
    }
}
