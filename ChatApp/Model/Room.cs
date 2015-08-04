using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatApp.Model
{
    public enum VisibEnum
    {
        ALL,
        CALL
    };

    public class Room
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

        private VisibEnum visibility;

        public VisibEnum Visibility
        {
            get { return visibility; }
            set { visibility = value; }
        }

        private User admin;

        public User Admin
        {
            get { return admin; }
            set { admin = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private bool status;

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

    }
}