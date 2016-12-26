<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UI-Medicine Info Maintaince.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 99px;
            height: 35px;
        }

        .auto-style2 {
            width: 418px;
            height: 35px;
        }

        .auto-style3 {
            width: 99px;
            height: 51px;
        }

        .auto-style4 {
            width: 418px;
            height: 51px;
        }

        .auto-style5 {
            width: 99px;
            height: 43px;
        }

        .auto-style6 {
            width: 418px;
            height: 43px;
        }
    </style>
</head>
<body>
    <div class="row">
        <form id="form1" runat="server">
            <div class="form-group">
                <table class="width=400">
                    <tr>
                        <td class="auto-style1">
                            <label text="text" runat="server">药品名称:</label>
                        </td>
                        <td class="auto-style2">
                            <input type="text" name="Name" id="medcinename" runat="server" value="药品名称" style="height: 26px; width: 269px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            <label text="text" runat="server">生产厂家:</label>
                        </td>
                        <td class="auto-style6">
                            <input type="text" name="Productor" id="productor" runat="server" value="生产厂家" style="height: 23px; width: 267px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">
                            <label text="text" runat="server">药品有效期:</label>
                        </td>
                        <td class="auto-style4">
                            <input type="date" name="ExpireDate" id="expiredate" runat="server" value="药品有效期" style="height: 27px; width: 265px" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <asp:Button ID="add" runat="server" Text="添加" OnClick="add_Click" />
                <asp:Button ID="update" runat="server" Text="修改" OnClick="update_Click" />
                <asp:Button ID="delete" runat="server" Text="删除" OnClick="delete_Click" />
                <asp:Button ID="search" runat="server" Text="查询" OnClick="search_Click" Style="height: 21px" />
                <br />
                <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                </asp:GridView>
            </div>
        </form>
    </div>

</body>
</html>
