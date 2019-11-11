using System;

namespace Mediator
{
    // Mediator
    interface IChatRoomMediator
    {
        void ShowMessage(User user, string message);
    }

    class ChatRoom : IChatRoomMediator
    {
        public void ShowMessage(User user, string message)
        {
            DateTime date = DateTime.Now;
            string sender = user.Name;
            Console.WriteLine($"{date} [{sender}] : {message}");  
        }
    }

    // Colleague
    class User
    {
        public string Name { get; }
        public IChatRoomMediator ChatMediator { get; }

        public User(string name, IChatRoomMediator chatMediator)
        {
            this.Name = name;
            this.ChatMediator = chatMediator;
        }

        public void Send(string message)
        {
            this.ChatMediator.ShowMessage(this, message);
        }
    }
}
