using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using QuizApp.Model;

namespace QuizApp.Tools
{
    public class FirebaseHelper
    {
        public FirebaseHelper()
        {
        }

        FirebaseClient firebase = new FirebaseClient("https://xamarindatabase-ad351.firebaseio.com/");

        public async Task<List<User>> GetAllPersons()
        {

            return (await firebase
              .Child("Persons")
              .OnceAsync<User>()).Select(item => new User
              {
                  Name = item.Object.Name,
                  UserId = item.Object.UserId,
                  OfOwner = item.Object.OfOwner
              })
              .ToList();
        }


        public async Task AddPerson(int personId, string name, string owner)
        {

            await firebase
              .Child("Persons")
              .PostAsync(new User() { UserId = personId, Name = name, OfOwner = owner });


        }
        //leaderboar
        public async Task AddScoreForLeaderboard(string user, string score )
        {

            await firebase
              .Child("Leaderboard")
              .PostAsync(new Leaderboard() { Username = user, AverageScore = score });
        }

        public async Task<List<Leaderboard>> GetLeaderboardScores()
        {

            return (await firebase
              .Child("Leaderboard")
              .OnceAsync<Leaderboard>()).Select(item => new Leaderboard
              {
                  Username = item.Object.Username,
                  AverageScore = item.Object.AverageScore
              })
              .ToList();
        }

        public async Task UpdateLeaderboard(string  username, string score)
        {
            var updateLeaderboard = (await firebase
              .Child("Leaderboard")
              .OnceAsync<Leaderboard>()).Where(a => a.Object.AverageScore == score).FirstOrDefault();

            await firebase
              .Child("Leaderboard")
              .Child(updateLeaderboard.Key)
              .PutAsync(new Leaderboard() { Username = username, AverageScore = score });
        }

        public async Task DeleteLeaderboard(string username)
        {
            var toDeletePerson = (await firebase
              .Child("Leaderboard")
              .OnceAsync<Leaderboard>()).Where(a => a.Object.Username == username).FirstOrDefault();
            await firebase.Child("Leaderboard").Child(toDeletePerson.Key).DeleteAsync();


        }

        //leaderboard finish


        public async Task<User> GetPerson(int personId)
        {
            var allPersons = await GetAllPersons();
            await firebase
              .Child("Persons")
              .OnceAsync<User>();
            return allPersons.Where(a => a.UserId == personId).FirstOrDefault();
        }
            
        public async Task UpdatePerson(int personId, string name, string owner)
        {
            var toUpdatePerson = (await firebase
              .Child("Persons")
              .OnceAsync<User>()).Where(a => a.Object.UserId == personId).FirstOrDefault();

            await firebase
              .Child("Persons")
              .Child(toUpdatePerson.Key)
              .PutAsync(new User() { UserId = personId, Name = name, OfOwner = owner });
        }

        public async Task DeletePerson(int personId)
        {
            var toDeletePerson = (await firebase
              .Child("Persons")
              .OnceAsync<User>()).Where(a => a.Object.UserId == personId).FirstOrDefault();
            await firebase.Child("Persons").Child(toDeletePerson.Key).DeleteAsync();

        }

        public async Task<List<Scores>> GetAllScores()
        {

            return (await firebase
              .Child("Scores")
              .OnceAsync<Scores>()).Select(item => new Scores
              {
                  Username = item.Object.Username,
                  Score = item.Object.Score,
                  Date = item.Object.Date,
                  Category = item.Object.Category
              })
              .ToList();
        }

    }
}
