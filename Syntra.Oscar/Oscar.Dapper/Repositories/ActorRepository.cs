﻿using Dapper;
using Oscar.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Oscar.Dapper.Repositories
{
    public class ActorRepository
    {
        /////////////////////////////////////////
        // Functions.

        // This function gets all the properties that belong to all the Actors objects form the database.
        // It places these properties in an Actors object.
        // It places these objects into an IEnumerable "list".
        public IEnumerable<Actors> GetActors()
        {
            using (var connection = new SqlConnection(Connection.Instance.ConnectionString))
            {
                return connection.Query<Actors>
                    (@" 
                        SELECT ActorId, FirstName, LastName
                        FROM Actors
                    ");
            }
        }

        // This function inserts the properties of the parameter (Actors object) 
        // Into the database as a new entry in the Actors table.
        public void InsertActor(Actors actor)
        {
            using (SqlConnection connection = new SqlConnection(Connection.Instance.ConnectionString))
            {
                connection.Execute(@"
                    INSERT INTO Actors(ActorId, FirstName, LastName)
                    VALUES (@ActorId, @FirstName, @LastName)
                ", new
                {
                    ActorId = actor.ActorId,
                    FirstName = actor.ActorFirstName,
                    LastName = actor.ActorLastName
                });
            }
        }
    }
}