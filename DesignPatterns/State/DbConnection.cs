using System;
using System.Collections.Generic;
using System.Text;

namespace State
{
    interface IDbConnectionState
    {
        void Open();

        void Close();

        void ExecuteQuery(string sql);
    }

    class DbConnection
    {
        private IDbConnectionState CurrentState { get; set; }

        private readonly IDbConnectionState created;
        private readonly IDbConnectionState opened;
        private readonly IDbConnectionState closed;

        public DbConnection()
        {
            created = new DbConnectionCreated(this);
            opened = new DbConnectionOpened(this);
            closed = new DbConnectionClosed(this);

            CurrentState = created;
        }

        public void Open()
        {
            CurrentState.Open();
        }

        public void Close()
        {
            CurrentState.Close();
        }

        public void ExecuteQuery(string sql)
        {
            CurrentState.ExecuteQuery(sql);
        }

        internal void SetState(State state)
        {
            switch (state)
            {
                case State.Created:
                    CurrentState = created;
                    break;
                case State.Open:
                    CurrentState = opened;
                    break;
                case State.Closed:
                    CurrentState = closed;
                    break;
                default:
                    throw new ArgumentException($"Unsupported {nameof(state)}: {state}");
            }
        }

        public enum State { Created, Open, Closed }
    }

    class DbConnectionCreated : IDbConnectionState
    {
        private readonly DbConnection dbConnection;

        public DbConnectionCreated(DbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public void Close()
        {
            throw new InvalidOperationException("Cannot close a not-opened connection.");
        }

        public void ExecuteQuery(string sql)
        {
            throw new InvalidOperationException("Cannot execute query on a not-opened connection. Open connection first!");
        }

        public void Open()
        {
            Console.WriteLine("Open connection.");
            dbConnection.SetState(DbConnection.State.Open);
        }
    }

    class DbConnectionOpened : IDbConnectionState
    {
        private readonly DbConnection dbConnection;

        public DbConnectionOpened(DbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public void Close()
        {
            Console.WriteLine("Close connection.");
            dbConnection.SetState(DbConnection.State.Closed);
        }

        public void ExecuteQuery(string sql)
        {
            Console.WriteLine($"Execute query: {sql}");
        }

        public void Open()
        {
            Console.WriteLine("Ignore method call: connection is in opened state.");
        }
    }

    class DbConnectionClosed : IDbConnectionState
    {
        private readonly DbConnection dbConnection;

        public DbConnectionClosed(DbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public void Close()
        {
            Console.WriteLine("Ignore method call: connection is in closed state.");
        }

        public void ExecuteQuery(string sql)
        {
            throw new InvalidOperationException("Cannot execute a query on a closed connection.");
        }

        public void Open()
        {
            throw new InvalidOperationException("Cannot re-open a closed connection.");
        }
    }
}
