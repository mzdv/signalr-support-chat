using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using ChatApp.Model;
using System.Threading.Tasks;

namespace ChatApp
{
    public class MainHub : Hub
    {
        public static List<User> users = new List<User>();

        public void CreateUser(string name)
        {

            User user = new User();
            user.Id = 0;
            user.Name = name;
            user.AccountType = AccTypeEnum.DOCTOR;
            user.Active = true;
            user.Created_at = DateTime.Now;
            user.Last_accessed = DateTime.Now;
            user.ConnectionId = Context.ConnectionId;   // this DOES NOT go into the database

            users.Add(user);

            Clients.All.userCreationCallback(user);                         
        }

        public void ListUsers()
        {
            Clients.All.generateActiveUsers(users);
        }

        public void Send(string name, string message)
        {
            Clients.All.broadcastMessage(name, message);
        }

        //public void UserDisconnected(string name)   // stub for disconnection event
        //{
        //    users.Remove(users.Find(x => x.Name == name));

        //    Clients.All.generateActiveUsers(users);
        //}

        public override Task OnDisconnected(bool stopCalled)
        {
            users.Remove(users.Find(x => x.ConnectionId == Context.ConnectionId));
            Clients.All.generateActiveUsers(users);

            return base.OnDisconnected(stopCalled);
        }
    }
}