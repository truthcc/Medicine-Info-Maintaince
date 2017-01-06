<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UI-Medicine Info Maintaince.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>药品字典维护</title>
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

        .clearfix {
            height: 45px;
        }
    </style>
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <script src="js/jquery-3.1.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-group">
            <div class="col-md-4"></div>
            <h3>药品信息录入</h3>
        </div>
        <br />
        <br />
        <br />
        <br />
        <div class="row">
            <div class="form-group">
                <div class="col-md-3"></div>
                <div class="col-md-1" hidden="hidden">
                <input type="radio" name="medicinecategory" id="westernmedicine" value="A01" runat="server">
                <label for="westernmedicine" runat="server">西药</label>
                </div>
                <div class="col-md-1" hidden="hidden">
                <input type="radio" name="medicinecategory" id="Chinesetraditionalmedicine" value="A02" runat="server">
                <label for="Chinesetraditionalmedicine" runat="server">中成药</label>
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <div class="col-md-2"></div>
                <label for="name" class="col-md-2" runat="server"><span class="glyphicon glyphicon-phone"></span>药品编码:</label>
                <div class="col-md-2">
                    <input class="form-control" type="text" name="MedicineCode" id="medicinecode" runat="server" placeholder="药品编码" style="height: 30px; width: 267px">
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <div class="col-md-2"></div>
                <label for="name" class="col-md-2" runat="server"><span class="glyphicon glyphicon-camera"></span>药品名称:</label>
                <div class="col-md-2">
                    <input class="form-control" type="text" name="Name" id="medcinename" runat="server" placeholder="药品名称" autofocus="autofocus" style="height: 30px; width: 267px">
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <div class="col-md-2"></div>
                <label for="name" class="col-md-2" runat="server"><span class="glyphicon glyphicon-phone"></span>生产厂家编码:</label>
                <div class="col-md-2">
                    <input class="form-control" type="text" name="VendorCode" id="vendorcode" runat="server" placeholder="生产厂家" style="height: 30px; width: 267px">
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <div class="col-md-2"></div>
                <label for="name" class="col-md-2" runat="server"><span class="glyphicon glyphicon-phone"></span>生产厂家:</label>
                <div class="col-md-2">
                    <input class="form-control" type="text" name="Productor" id="productor" runat="server" placeholder="生产厂家" style="height: 30px; width: 267px">
                </div>
            </div>
            <div class="clearfix"></div>
            <div class="form-group">
                <div class="col-md-2"></div>
                <label for="name" class="col-md-2" runat="server"><span class="glyphicon glyphicon-calendar"></span>药品有效期:</label>
                <div class="col-md-2">
                    <input class="form-control" type="date" name="ExpireDate" id="expiredate" runat="server" value="31/12/2016" style="height: 30px; width: 267px">
                </div>
            </div>
            <div class="clearfix"></div>
        </div>
        <br />
        <br />
        <div class="col-md-6"></div>
        <div>
            <asp:Button ID="add" runat="server" Text="添加" OnClick="add_Click" />
            <asp:Button ID="update" runat="server" Text="修改" OnClick="update_Click" />
            <asp:Button ID="delete" runat="server" Text="删除" OnClick="delete_Click" />
            <asp:Button ID="search" runat="server" Text="查询" OnClick="search_Click" />
            <asp:Button ID="reset" runat="server" Text="清除" OnClick="reset_Click" />
            <%--<input type="reset" runat="server" name="清除" value="清除" />--%>
            <br />
            <br />
            <div class="col-md-2"></div>
            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="878px" AutoGenerateColumns="False" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" Visible="False"   />
                    <asp:BoundField DataField="MedicineCode" HeaderText="药品编码" />
                    <asp:BoundField DataField="Name" HeaderText="药品名称" />
                    <asp:BoundField DataField="vendor_name" HeaderText="供应商名称" />
                    <asp:BoundField DataField="ExpireDate" HeaderText="有效期" DataFormatString="{0:yyyy-MM-dd}" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
    </form>

</body>
</html>
