using mongoapi.Models;
using mongoapi.SettingModels;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mongoapi.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> users;

        public UserService(IUsersDatabaseSettings settings)
        {
            // setup connection
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.UsersCollectionName) ;

            // get collection of users 
            users = database.GetCollection<User>(settings.UsersCollectionName);
        }

        // CRUD operations
        public List<User> Get() =>
            users.Find(u => true).ToList();

        public User Get(string id) =>
            users.Find<User>(u => u.Id == id).FirstOrDefault();

        public User Create(User user)
        {
            users.InsertOne(user);
            return user;
        }

        public void Update(string id, User user) =>
            users.ReplaceOne(u => u.Id == id, user);

        public void Remove(User user) =>
            users.DeleteOne(u => u.Id == user.Id);

        public void Remove(string id) =>
            users.DeleteOne(u => u.Id == id);
    }
}
