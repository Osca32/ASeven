using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [WebInvoke(Method = "POST", UriTemplate = "/signup")]
        [OperationContract]
        bool SignUp(User newUser);

        // Defines an operation for user login. This operation can be accessed via a POST request.
        [WebInvoke(Method = "POST", UriTemplate = "/login")]
        [OperationContract]
        bool Login(User user);

        // Defines an operation to generate a CAPTCHA image. Returns the image as a byte array.
        [OperationContract]
        byte[] GenerateCaptchaImage();

        // Defines an operation to retrieve the text associated with a CAPTCHA, often used for validation.
        [OperationContract]
        string GetText();
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class User
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}
