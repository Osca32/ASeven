<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="StaffLogin.aspx.cs" Inherits="ASeven.StaffLogin" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <title>Default Page</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.9.1/font/bootstrap-icons.css" />
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>
    <webopt:bundlereference runat="server" path="~/Content/css" />
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            color: #333;
        }

        .container {
            width: 80%;
            margin: auto;
            padding: 20px;
            background-color: #fff;
            box-shadow: 0 2px 5px rgba(0,0,0,0.1);
            border-radius: 8px;
            margin-top: 100px;
        }

        h1, h2, b {
            color: #007bff;
        }

        nav.navbar {
            background-color: #007bff;
        }

        .navbar-nav .nav-link {
            color: #fff;
        }

        .navbar-nav .nav-link:hover {
            background-color: #0056b3;
        }

        input[type="text"], input[type="password"], textarea {
            width: 100%;
            padding: 10px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }

        input[type="submit"], button {
            width: 100%;
            background-color: #007bff;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        input[type="submit"]:hover, button:hover {
            background-color: #0056b3;
        }

        .service-section {
            padding: 20px;
            margin-top: 20px;
            border-left: 5px solid #007bff;
        }

        .service-section:last-child {
            margin-bottom: 20px;
        }

        .label {
            font-weight: bold;
        }

    </style>
</head>
    <body>
        <form id="form1" runat="server">
            <!-- Navbar -->
            

            <br /><br /><br /><br />


            <br /><br />

            <!-- Login and Signup Service Section -->
            <div class="container mx-auto p-2" style="width: 600px;">
                <b>Staff Login</b>
                <br /><br />
                
                <!-- Input Field for Username -->
                <label>Username:</label>
                <asp:TextBox ID="txtUsername" runat="server" />
                <br />
                <!-- Input Field for Password -->
                <label>Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" />  
                <br />
                <label ID="status">Results Here</label>
                <asp:Panel ID="pnCaptcha" runat="server" Visible="true">

                    
                    
                    <!-- Display the CAPTCHA Image -->
                    <asp:Image ID="imgCaptcha" runat="server" />
                    <br />       
                    
                    <!-- Text Input for Entering CAPTCHA -->
                    <asp:TextBox ID="txtCaptchaInput" runat="server" placeholder="Enter CAPTCHA" />      
                    

                </asp:Panel>
                
                    
                    <!-- Button to Invoke Login Operation -->
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" Enabled="false" />
            </div>

        </form>
        <asp:PlaceHolder runat="server">
            <%: Scripts.Render("~/Scripts/bootstrap.js") %>
        </asp:PlaceHolder>
    </body>
</html>
