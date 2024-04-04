using System;
using System.Threading;

namespace LegacyApp
{
   
    public static class UserDataAccess
    {
       
        public static void AddUser(User user)
        {
            int randomWaitTime = new Random().Next(1000);
            Thread.Sleep(randomWaitTime);
            Console.WriteLine($"Added the user {user} successfully");
        }
    }
}
