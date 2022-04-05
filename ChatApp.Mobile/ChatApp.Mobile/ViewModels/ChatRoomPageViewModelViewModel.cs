using ChatApp.Mobile.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatApp.Mobile.ViewModels
{
    public class ChatRoomPageViewModelViewModel : ViewModelBase
    {
        private readonly IChatService chatService;

        public ChatRoomPageViewModelViewModel(INavigationService navigationService, 
            IChatService chatService) 
            : base(navigationService)
        {
            this.chatService = chatService;
        }

        public override async void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
           await chatService.Connect(); 
        }
    }
}
