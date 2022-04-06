using Prism.Commands;
using Prism.Navigation;
using System.Windows.Input;
using ChatApp.Mobile.Views; 

namespace ChatApp.Mobile.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private string email;

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value); 
        }
        public ICommand NavigateToChatPageCommand { get; private set; }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            NavigateToChatPageCommand = new DelegateCommand(NavigateToChatPage); 
        }

        private void NavigateToChatPage()
        {
            var param = new NavigationParameters {{"UserNameId", Email}}; 
            NavigationService.NavigateAsync($"NavigationPage/{nameof(ChatRoomPage)}", param); 
        }

        
    }
}
