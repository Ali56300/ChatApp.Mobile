using ChatApp.Mobile.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Input;
using ChatApp.Mobile.Models;

namespace ChatApp.Mobile.ViewModels
{
    public class ChatRoomPageViewModel : ViewModelBase
    {
        private readonly IChatService chatService;

        private string userName;
        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value); 
        }
        
        private string message;
        public string Message 
        {
            get => message;
            set => SetProperty(ref message, value); 
        }

        private IEnumerable<MessageModels> messageList;

        public IEnumerable<MessageModels> MessageList
        {
            get => messageList;
            set => SetProperty(ref messageList, value);  
        }

        public ChatRoomPageViewModel(
            INavigationService navigationService, 
            IChatService chatService) 
            : base(navigationService)
        {
            this.chatService = chatService;
            SendMsgCommand = new DelegateCommand(SendMsg); 
        }

        public ICommand SendMsgCommand { get; private set;  }

        public override async void Initialize(INavigationParameters parameters)
        {
            UserName = parameters.GetValue<string>("UserNameId");
            MessageList = new List<MessageModels>();
            try
            {
                chatService.ReceiveMessage(GetMessage);
                await chatService.Connect(); 

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }

        private void SendMsg()
        {
            chatService.SendMessage(UserName, Message);
            AddMsg(UserName, Message, true);
            
        }

        private void GetMessage(string userName, string message)
        {
            AddMsg(userName, message, false);
        }

        private void AddMsg(string userName, string message, bool isOwner)
        {
            var tempList = MessageList.ToList();
            tempList.Add(new MessageModels{IsOwnerMessage = true, Message = message, UseName = userName});
            MessageList = new List<MessageModels>(tempList);
            Message = string.Empty; 
        }
    }
}
