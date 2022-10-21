<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="ExpenseTracker.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 164px;
        }
        .auto-style4 {
            width: 164px;
            height: 23px;
        }
        .auto-style5 {
            height: 23px;
        }
        .auto-style6 {
            width: 452px;
        }
        .auto-style7 {
            height: 23px;
            width: 452px;
        }
    </style>
</head>

<body>
    <h1>hey! welcome <%Response.Write(Session["User"]); %></h1>
    <form id="form1" runat="server">
        <asp:Button runat="server" Text="Back To Home" ID="Unnamed1" OnClick="Unnamed1_Click" />
        <div>
             <table class="auto-style2">
        <tr>
            <td class="auto-style3">
                <asp:Label ID="lblExpense" runat="server" Text="ExpenseType"></asp:Label>
            </td>
            <td class="auto-style6">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Selected="True" Value="0">Please Select</asp:ListItem>
                    <asp:ListItem>Food</asp:ListItem>
                    <asp:ListItem>Medical</asp:ListItem>
                    <asp:ListItem>Entertainment</asp:ListItem>
                    <asp:ListItem>Transportation</asp:ListItem>
                    <asp:ListItem>Academics</asp:ListItem>
                    <asp:ListItem>Housing</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="lbldesc" runat="server" Text="Description"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:TextBox ID="desc" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style5"></td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="lblamt" runat="server" Text="Amount"></asp:Label>
            </td>
            <td class="auto-style6">
                <asp:TextBox ID="amt" runat="server" TextMode="Number"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="lbldate" runat="server" Text="Date"></asp:Label>
            </td>
            <td class="auto-style6">
                <asp:TextBox ID="paymentdate" runat="server" TextMode="Date"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Button ID="btninsert" runat="server" OnClick="btninsert_Click" Text="Insert" />
            </td>
            <td class="auto-style6">
                <asp:Button ID="btnedit" runat="server" OnClick="btnedit_Click" Text="Edit" />
            </td>
            <td>
                <asp:Button ID="btndelete" runat="server" OnClick="btndlt_Click" Text="Delete" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:GridView ID="GridView1" runat="server"  AutoGenerateSelectButton="True" OnSelectedIndexChanged="ExpenseGV_SelectedIndexChanged">
                </asp:GridView>
            </td>
            <td class="auto-style6">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
        </div>
    </form>
</body>
</html>
