using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq;

namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private string UsersXmlPath
        {
            get
            {
                // Retrieves the base directory where the application's executable is running.
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                // Combines the base directory with the name of the XML file to form the full path.
                // The XML file named "Member.xml" is expected to contain user registration data.
                return Path.Combine(baseDirectory, "Member.xml");
            }
        }

        public bool SignUp(User newUser)
        {
            // Load existing users from the XML database.
            List<User> users = LoadUsersFromXml();

            // Check if a user with the same username already exists.
            if (users.Exists(u => u.Username == newUser.Username))
            {
                // If a user exists, return false to indicate signup failure.
                return false;
            }

            // If the username is new, add the user to the list.
            users.Add(newUser);

            // Save the updated user list back to the XML database.
            SaveUsersToXml(users);

            // Return true to indicate the signup was successful.
            return true;
        }

        public bool Login(User user)
        {
            // Load the list of users from the XML file into memory.
            List<User> users = LoadUsersFromXml();

            // Check if there exists a user with matching username and password.
            if (users.Exists(u => u.Username == user.Username && u.Password == user.Password))
            {
                // If a matching user is found, return true indicating a successful login.
                return true;
            }

            // If no matching user is found, return false indicating login failure.
            return false;
        }

        private List<User> LoadUsersFromXml()
        {
            // Initialize a new list to hold the users.
            List<User> users = new List<User>();

            // Check if the XML file with user data exists.
            if (File.Exists(UsersXmlPath))
            {
                // Load the XML document from the file path.
                XDocument doc = XDocument.Load(UsersXmlPath);

                // Iterate through all 'User' elements within the XML document.
                foreach (XElement userElement in doc.Descendants("User"))
                {
                    // Create a new User object and set its properties based on the XML element data.
                    User user = new User
                    {
                        Username = userElement.Element("Username").Value, // Get the username from the 'Username' element.
                        Password = userElement.Element("Password").Value  // Get the password from the 'Password' element.
                    };

                    // Add the newly created User object to the list of users.
                    users.Add(user);
                }
            }

            // Return the populated or empty list of users.
            return users;
        }

        private void SaveUsersToXml(List<User> users)
        {
            // Create a new XDocument (part of System.Xml.Linq) which is an in-memory XML document representation.
            XDocument doc = new XDocument(
                // Add a root element named "Users".
                new XElement("Users",
                    // For each User object in the 'users' list, create a new "User" element.
                    users.Select(u =>
                        new XElement("User",
                            // For the current User object 'u', create a "Username" element with the user's username as content.
                            new XElement("Username", u.Username),
                            // Similarly, create a "Password" element with the user's password as content.
                            // NOTE: Storing passwords in plain text is a security risk.
                            new XElement("Password", u.Password)
                        )
                    )
                )
            );

            // Save the XDocument to a file at the location specified by the UsersXmlPath variable.
            // UsersXmlPath should be a string containing the file path where the XML document will be saved.
            doc.Save(UsersXmlPath);
        }

        public byte[] GenerateCaptchaImage()
        {
            // Generate a random text for the CAPTCHA by calling the GenerateRandomCaptchaText method
            // and assign it to the GeneratedText property of the CaptchaClass.
            CaptchaClass.GeneratedText = GenerateRandomCaptchaText();

            // Create a Bitmap image of the CAPTCHA using the generated text with specific dimensions (200x100 pixels)
            // by calling the GenerateCaptcha method of the CaptchaGenerator.
            Bitmap captchaImage = CaptchaGenerator.GenerateCaptcha(CaptchaClass.GeneratedText, 200, 100);

            // Using a using-statement to ensure proper disposal of the MemoryStream after its use.
            using (MemoryStream stream = new MemoryStream())
            {
                // Save the generated Bitmap image into the MemoryStream in PNG format.
                captchaImage.Save(stream, ImageFormat.Png);

                // Convert the MemoryStream to a byte array and return it.
                // This byte array represents the PNG image of the CAPTCHA.
                return stream.ToArray();
            }
            // After the using block, the MemoryStream is automatically disposed, releasing the resources.
        }

        private static string GenerateRandomCaptchaText()
        {
            // Define a constant string of uppercase letters and digits that will be used to generate the CAPTCHA text.
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            // Instantiate a new Random object to generate random numbers.
            Random random = new Random();

            // Create an array of characters to hold the CAPTCHA text, initializing it to have 5 characters.
            char[] captchaText = new char[5];

            // Loop 5 times to generate a 5-character CAPTCHA text.
            for (int i = 0; i < 5; i++)
            {
                // Assign a random character from 'chars' to each position in the 'captchaText' array.
                // The random.Next(chars.Length) call generates a random index to select a character from 'chars'.
                captchaText[i] = chars[random.Next(chars.Length)];
            }

            // Construct a new string from the characters in the 'captchaText' array.
            string text = new string(captchaText);

            // Return the generated string which will serve as the CAPTCHA text.
            return text;
        }


        // Method to retrieve the generated CAPTCHA text from the CaptchaClass.
        public string GetText()
        {
            // Return the value of GeneratedText property from CaptchaClass.
            return CaptchaClass.GeneratedText;
        }

        public class CaptchaClass
        {
            // Static field to hold the generated CAPTCHA text.
            public static string GeneratedText = "";

            // Property to get or set the CAPTCHA text.
            // The value of GeneratedText is returned and set through this property.
            public string GenCaptcha
            {
                get { return GeneratedText; }
                set { GeneratedText = value; }
            }
        }

        // Class responsible for generating the CAPTCHA image.
        public class CaptchaGenerator
        {
            // Static method that creates a CAPTCHA image with the specified text, width, and height.
            public static Bitmap GenerateCaptcha(string text, int width, int height)
            {
                // Create a new bitmap image with the given dimensions.
                Bitmap captchaImage = new Bitmap(width, height);

                // Use the Graphics object to draw on the bitmap.
                using (Graphics graphics = Graphics.FromImage(captchaImage))
                {
                    // Create a new font and brush for drawing text.
                    Font font = new Font("Arial", 12, FontStyle.Bold);
                    SolidBrush brush = new SolidBrush(Color.Black);

                    // Draw the specified text onto the image at position (10, 10).
                    graphics.DrawString(text, font, brush, new PointF(10, 10));

                    // Call a private method to add noise to the image, making the CAPTCHA harder to read by bots.
                    AddNoise(graphics, width, height);
                }
                // Return the CAPTCHA image.
                return captchaImage;
            }

            // Private static method that adds noise (lines and dots) to the graphics object (the CAPTCHA image).
            private static void AddNoise(Graphics graphics, int width, int height)
            {
                // Instantiate a Random object for generating random numbers.
                Random random = new Random();

                // Draw 5 random lines on the image.
                for (int i = 0; i < 5; i++)
                {
                    // Create a new pen with a random color.
                    Pen pen = new Pen(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)));
                    // Generate random start and end points for the line.
                    int x1 = random.Next(0, width);
                    int y1 = random.Next(0, height);
                    int x2 = random.Next(0, width);
                    int y2 = random.Next(0, height);
                    // Draw the line on the image.
                    graphics.DrawLine(pen, x1, y1, x2, y2);
                }

                // Draw 100 random dots on the image.
                for (int i = 0; i < 100; i++)
                {
                    // Generate a random position for the dot.
                    int x = random.Next(0, width);
                    int y = random.Next(0, height);
                    // Create a brush with a random color.
                    SolidBrush brush = new SolidBrush(Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)));
                    // Draw the dot as a small ellipse.
                    graphics.FillEllipse(brush, x, y, 2, 2);
                }
            }
        }

    }
}
