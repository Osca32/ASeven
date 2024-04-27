<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASeven._Default" %>
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

        .form-control {
            margin-bottom: 10px;
        }
    </style>
</head>
    <body>
        <form id="form1" runat="server">
            <asp:Button ID="MemberPage" runat="server" Text="Member" OnClick="MemberBtn_Click" />
            <asp:Button ID="StaffPage" runat="server" Text="Staff" OnClick="StaffBtn_Click" />

        </form>
        <asp:PlaceHolder runat="server">
            <%: Scripts.Render("~/Scripts/bootstrap.js") %>
        </asp:PlaceHolder>
    </body>
</html>