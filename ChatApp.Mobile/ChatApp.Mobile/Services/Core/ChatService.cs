using ChatApp.Mobile.Services.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Mobile.Services.Core
{
    public class ChatService: IChatService
    {
        private readonly HubConnection hubConnection;

        public ChatService()
        {
            hubConnection = new HubConnectionBuilder().WithUrl("http://192.168.1.127/ChatHub").Build(); 

        }
        public async Task Connect()
        {
            await hubConnection.StartAsync();
        }
        public async Task Disconnect()
        {
            await hubConnection.StopAsync(); 
        }
        public async Task SendMessage(string userId, string message)
        {
            await hubConnection.InvokeAsync("SendMessage", userId, message); 
        }

        public void ReceiveMessage(Action<string, string> getMessageAndUser)
        {
            throw new NotImplementedException();
        }

        public void ReceivedMessage(Action<string, string> getMessageAndUser)
        {
            hubConnection.On("ReceiveMessage", getMessageAndUser); 
        }


    }
}
