<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderInfo.aspx.cs" Inherits="ProductManage.Admin.OrderInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>订单信息查看</title>
</head>
<body>
    <form id="form1" runat="server">

    <div>
        <asp:GridView ID="OrderInformation" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" Width="100%" AllowPaging="True" PageSize="10" ShowFooter="True">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" CssClass="pages"
                Font-Bold="True" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Height="20px" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            <Columns>
                <asp:CommandField ShowSelectButton="True">
                    <ItemStyle ForeColor="Blue" Width="50px" />
                </asp:CommandField>
                <asp:BoundField DataField="OrderId" HeaderText="订单编号">
                    <ItemStyle Width="125px" />
                </asp:BoundField>
                <asp:BoundField DataField="ProductId" HeaderText="商品编号">
                    <ItemStyle Width="275px" />
                </asp:BoundField>
                <asp:BoundField DataField="ProductName" HeaderText="商品名称">
                    <ItemStyle Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="CustomerName" HeaderText="客户名">
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="SalePrice" HeaderText="销售价">
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="Inputer" HeaderText="录入人">
                    <ItemStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="InputDate" HeaderText="录入日期">
                    <ItemStyle Width="200px" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
            <div>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="BtnBack" runat="server" Text="返回" onclick="BtnBack_Click" />
       
    </div>
    </form>

</body>
</html>
