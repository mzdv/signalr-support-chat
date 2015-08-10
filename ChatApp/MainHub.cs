using System;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using ChatApp.Model;
using System.Threading.Tasks;

namespace ChatApp
{
    public class MainHub : Hub
    {
        public static List<User> users = new List<User>();
        public static List<Room> rooms = new List<Room>();

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

            JoinRoom("Lobby");

            users.Add(user);

            Clients.All.userCreationCallback(user);

        }

        public void CreateRoom(string name, int visibility, User admin, string description, int status, string passcode)
        {
            Room room = new Room();
            room.Id = 0;
            room.Name = name;
            room.Visibility = (VisibEnum)visibility;
            room.Admin = admin;
            room.Description = description;
            room.Passcode = passcode;

            rooms.Add(room);

            Clients.All.roomCreationCallback(room);

        }

        public void ListRooms()
        {
            List<Room> visibleRooms = rooms.FindAll(x => x.Visibility == VisibEnum.ALL);    // we don't want people to know about our hidden groups
            Clients.All.generateRooms(visibleRooms);
        }

        public void ListUsers()
        {
            Clients.All.generateActiveUsers(users);
        }

        public void Send(string name, string clientMessage)
        {
            Message message = new Message();
            message.Id = 0;
            message.User = users.Find(x => x.Name == name);
            message.Created_at = DateTime.Now;
            message.Content = clientMessage;
            message.Room = null;        // TO-DO

            Clients.All.broadcastMessage(name, clientMessage);
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            User user = users.Find(x => x.ConnectionId == Context.ConnectionId);
            users.Remove(user);

            Clients.All.generateActiveUsers(users);

            return base.OnDisconnected(stopCalled);
        }

        public Task JoinRoom(string roomName)
        {
            return Groups.Add(Context.ConnectionId, roomName);
        }

        public Task LeaveRoom(string roomName)
        {
            return Groups.Remove(Context.ConnectionId, roomName);
        }

        public void Announce()
        {
            Clients.Group("Lobby").addChatMessage("You are in the lobby right now.");
        }
    }
}