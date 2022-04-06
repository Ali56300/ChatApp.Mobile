using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using ChatApp.Mobile.Views; 

namespace ChatApp.Mobile.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private string userName;

        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value); 
        }
        public ICommand NavigateToChatPageCommand { get; private set; }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            NavigateToChatPageCommand = new DelegateCommand(NavigateToChatPage); 
        }

        private void NavigateToChatPage()
        {
            var param = new NavigationParameters {{"UserNameId", UserName}}; 
            NavigationService.NavigateAsync($"NavigationPage/{nameof(ChatRoomPage)}", param); 
        }

        
    }
}
