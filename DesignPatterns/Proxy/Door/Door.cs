using System;

namespace Proxy
{
    interface IDoor
    {
        void Open();
        void Close();
    }

    class LabDoor : IDoor
    {
        public void Open()
        {
            Console.WriteLine("Opening lab door");
        }

        public void Close()
        {
            Console.WriteLine("Closing the lab door");
        }
    }

    class Security // a proxy to door
    {
        protected IDoor Door;

        public Security(IDoor door)
        {
            Door = door;
        }

        public void Open(string password)
        {
            if (Authenticate(password))
            {
                Door.Open();
            }
            else
            {
                Console.WriteLine("Big no! It ain't possible.");
            }
        }

        public bool Authenticate(string password)
        {
            return password == "$ecr@t";
        }

        public void Close()
        {
            Door.Close();
        }
    }
}
