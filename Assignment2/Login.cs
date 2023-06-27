using System;
using System.Collections;
using System.IO;


namespace Assignment2
{
	public class Login
	{

		private string username; // This is to store the username for access in other classes
		private string userType; // This is to store the usertype for access in other classes
		private ArrayList loginDetails = new ArrayList(); // This coollection is used to store the login information of all users
		private ArrayList userNames = new ArrayList(); // This collection is used to store only the usernames of all users
		//have an arraylist of usernames only
		public Login()
		{
			this.loginDetails = loadData(); // The user infromation from the login text file is loaded into the loginDetails arraylist
			this.userNames = loaduserNames(); // The usernames from the login text file is loaded into the userNames arraylist 
		}

		public string Username //accessor for the username class variable
		{
			get { return username; }
			set { username = value; }
		}

		public string UserType //accessor for the usertype class variable 
		{
			get { return userType; }
			set { userType = value; }
		}

		public Boolean checkLogin(string username, string password)
		{ 
			// This method checks whether the username and password entered in teh login form is accurate 

			Boolean loginChecker = false;

			string[] userDetails;

			foreach (string loginDetail in loginDetails) // this loops through each user's information from the arraylist loginDetails
			{

				userDetails = loginDetail.Split(","); // This array storesd individual user information in an array 

				// This if clause checks whether the username and passwords match the data in the userDetails array 

				if ((username == userDetails[0]) && (password == userDetails[1])) // 
				{
					this.username = userDetails[0];
					this.userType = userDetails[2];
					loginChecker = true;
				}
			}

			return loginChecker;

		}

		public static void newUser(Array userInformation)
		{

			// This method is used to store the inforation of a new user into the login text file 

			string loginPath = @"C:\Users\vinay\OneDrive\Documents\Visual Studio 2019\UTS Code Files\Assignment2\Assignment2\login.txt";

			int loopchecker = 1;

			string userDetails = "";

			foreach (string item in userInformation) // This loops through each string in the userinformation array 
			{

				if (loopchecker == 6)
                {
					userDetails += item;
					break;
                }

				userDetails += item + ","; // This string is appended with individual user information

				loopchecker++;

			}

			StreamWriter sw = System.IO.File.AppendText(loginPath); // A streamwriter is opened to append text to the login text file 

			sw.WriteLine(userDetails);  // new userDetails string is appended to the login text file

			sw.Close(); // The stream writer is closed

		}

		public static ArrayList loadData()
        {
			// This method is used to load data from the login text file into the loginDetails arraylist 

			string[] userDetails = System.IO.File.ReadAllLines(@"C:\Users\vinay\OneDrive\Documents\Visual Studio 2019\UTS Code Files\Assignment2\Assignment2\login.txt");
			// The userDetails array stores the information lien by line from the login text file 
			
			ArrayList loginDetails = new ArrayList();

			foreach (string userDetail in userDetails) // The userDetails array is looped through 
			{
				loginDetails.Add(userDetail); // the method local arraylist is populated with user details 
			}

			return loginDetails;
		}

		public static ArrayList loaduserNames()
        {
			string[] userDetails = System.IO.File.ReadAllLines(@"C:\Users\vinay\OneDrive\Documents\Visual Studio 2019\UTS Code Files\Assignment2\Assignment2\login.txt");

			string[] singleUser;

			ArrayList userNames = new ArrayList();

			foreach (string userDetail in userDetails) 
			{
				singleUser = userDetail.Split(",");

				// Same as teh above method but the userDetail string is split to access the username only 

				foreach (string detail in singleUser)  // The singleUser array is looped through 
                {
					userNames.Add(detail);  // Only the username is added to the arraylist being returned
					break;
                }
			}

			return userNames;
		}

		public static Boolean checkUserName(string userName)
        {
			Boolean usernameChecker = false; 
			ArrayList userNames = new ArrayList();
			userNames = loaduserNames(); //A new arraylist is created and usernames are loaded into this arraylist 

			foreach (string Name in userNames) //Each username is looped through 
            {
				if (Name == userName) // If the parameter username matches any of the usernames in tghe arraylist this clause runs 
                {
					usernameChecker = true;
                }
            }

			return usernameChecker;
        }
	}

}
