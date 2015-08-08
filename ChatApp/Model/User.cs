using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatApp.Model
{
    public enum AccTypeEnum
    {
        USER,
        DOCTOR,
        ADMIN
    };

    public class User
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private AccTypeEnum accountType;

        public AccTypeEnum AccountType
        {
            get { return accountType; }
            set { accountType = value; }
        }

        private bool active;

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        private DateTime created_at;

        public DateTime Created_at
        {
            get { return created_at; }
            set { created_at = value; }
        }

        private DateTime last_accessed;

        public DateTime Last_accessed
        {
            get { return last_accessed; }
            set { last_accessed = value; }
        }

        private string connectionId;

        public string ConnectionId
        {
            get { return connectionId; }
            set { connectionId = value; }
        }

    }
}