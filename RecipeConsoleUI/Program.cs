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
                var table = new table();
                table.restaurant = "asg";
                table.tableID = 1234;
                client.addd(table);
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
