using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatApp.Model
{
    public class Message
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private User user;
                
        public User User
        {
            get { return user; }
            set { user = value; }
        }

        private DateTime created_at;

        public DateTime Created_at
        {
            get { return created_at; }
            set { created_at = value; }
        }

        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private Room room;

        public Room Room
        {
            get { return room; }
            set { room = value; }
        }

    }
}