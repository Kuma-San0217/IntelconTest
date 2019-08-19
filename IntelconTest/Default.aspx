<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IntelconTest.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Тестовое задание</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager EnablePartialRendering="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel UpdateMode="Conditional" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="textbox" runat="server" placeholder="Enter your message">
                </asp:TextBox>
                <asp:SqlDataSource runat="server" 
                                   id="UserSource" 
                                   DataSourceMode="DataReader" 
                                   ConnectionString="<%$ ConnectionStrings:dbConnectionString %>"
                                   SelectCommand="SELECT UserID, FullName
                                                  FROM Users">
                </asp:SqlDataSource>
                <asp:DropDownList ID="dropdownlist" runat="server" DataValueField="UserID" DataTextField="FullName" DataSourceID="UserSource">
            
                </asp:DropDownList>
                <asp:Button ID="Button" runat="server" Text="Send message" OnClick="Button_Click" />
                <div id="literalBox">
                    <asp:Literal id="literal" runat="server">

                    </asp:Literal>
                </div>
             </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button" EventName="Click"/>
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
