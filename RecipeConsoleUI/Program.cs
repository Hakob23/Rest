using System;

/**** This is test of UserManagementAPI requests ****/

namespace RecipeConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("password".GetHashCode() == "password".GetHashCode());

            Console.Title = "RecipeConsoleUI";

            var client = new UmApiClient();

            Console.WriteLine("Enter register or sign in");

            var input = Console.ReadLine();

            if(input == "register")
            {
                var user = new user();
                Console.WriteLine("Username");
                user.UserName = Console.ReadLine();
                Console.WriteLine("Email");
                user.Email = Console.ReadLine();
                Console.WriteLine("Phone");
                user.Phone = Console.ReadLine();
                Console.WriteLine("Password");
                user.Password = Console.ReadLine();
                user.Role = "user";
                client.RegisterUser(user);
            }
            else
            {
                Console.WriteLine("Username");
                var username = Console.ReadLine();
                Console.WriteLine("Password");
                var password = Console.ReadLine();
                client.LogIn(username, password);
            }

            //var list = client.GetUserPublicInfos();
        }
    }
}
