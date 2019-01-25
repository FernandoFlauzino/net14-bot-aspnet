﻿using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.Logic
{
    public class SimpleBotUser
    {
        public string Reply(SimpleMessage message)
        {
           
            SaveMessage(message);

           // GetProfile(message.Id);

            return $"{message.User} disse '{message.Text}";
        }


        UserProfile GetProfile(string userId)
        {
            var client = new MongoClient();

            var db = client.GetDatabase("dbBot");

            var col = db.GetCollection<BsonDocument>("MessageSend");

            var result = col.Find(Builders<BsonDocument>.Filter.Eq("Id", userId)).ToList();

            return new UserProfile();
        }

        UserProfile SetProfile(string userId, int contador)
        {
            return new UserProfile();
        }

        private void SaveMessage(SimpleMessage message)
        {
            var client = new MongoClient();

            var db = client.GetDatabase("dbBot");

            var col = db.GetCollection<BsonDocument>("MessageSend");

            var doc = new BsonDocument() {
                { "UserName", message.User },
                { "TextMessage",message.Text }
            };

            col.InsertOne(doc);
        }


        

    }

    internal class UserProfile
    {
        public string Id { get; set; }
        public int Contador { get; set; }
    }
}