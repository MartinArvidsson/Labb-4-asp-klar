<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gissa_hemliga_talet.Default" ViewStateMode ="disabled"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="~/Style/Style.css" />
    <script src="Model/Script.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Ange ett tal mellan 1-100:<asp:TextBox ID="Guessarea" runat="server"></asp:TextBox><asp:Button ID="GuessButton" runat="server" Text="Button" OnClick="GuessButton_Click" /><br />

            <asp:RequiredFieldValidator ID="Noemptytextbox" 
            runat="server" 
            ErrorMessage="Fältet kan inte vara tomt"
            ControlToValidate="Guessarea" 
            Display="Dynamic" CssClass="ErrorMessage">
            </asp:RequiredFieldValidator>

                <asp:RangeValidator ID="ValidationOfRangeTempStep" 
                runat="server" 
                ErrorMessage="Måste vara inom intervallet 1-100" 
                Display="Dynamic" 
                ControlToValidate="Guessarea" 
                MaximumValue="100" 
                MinimumValue="1" 
                Type="Integer" 
                CssClass="ErrorMessage">
                </asp:RangeValidator>
    <br /><asp:Label ID="PresentationArea" runat="server" Text="" Visible="false"></asp:Label>
    </div>
    </form>
</body>
</html>
