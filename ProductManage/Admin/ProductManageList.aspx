<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductManageList.aspx.cs" Inherits="ProductManage.ProductManageList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
    <title>产品列表页面</title>
     <%--引用外部样式表--%>
    <link href="../CSS/ProductStyle.css" rel="stylesheet" type="text/css" />


  

</head>
<body>
      <form id="form1" runat="server">
    <div>
        <h3 style="color: Blue;">
            产品列表页面</h3>
        <table width="1200px" style="text-align: left; font-size: 12px;">
            <tr>
                <td>
                    <center>
                        <asp:Label ID="Label1" runat="server" Text="产品分类"></asp:Label>
                        <asp:DropDownList ID="dwlProductCategory" runat="server"> 
          
                        </asp:DropDownList>
                        &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:Button ID="btnSearch" runat="server" Text="查询产品" OnClick="btnSearch_Click" />
                        &nbsp;
                        <asp:Button ID="btnDelete" runat="server" Text="删除产品" OnClick="btnDelete_Click" 
                            style="height: 21px" />
                        &nbsp;
                        <asp:Button ID="btnLook" runat="server" Text="查看订单信息" onclick="btnLook_Click" />
                    </center>
                </td>
            </tr>
            <tr>
                <td>
                    当前选中的产品编号：<asp:Label ID="lblStedProductId" runat="server" Text="" ForeColor="Red"
                        Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="overflow: scroll">
                    <asp:GridView ID="gdvProduct" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" Width="100%" AllowPaging="True" PageSize="5" ShowFooter="True"
                        OnPageIndexChanging="gdvProduct_PageIndexChanging" OnRowDataBound="gdvProduct_RowDataBound"
                        OnSelectedIndexChanged="gdvProduct_SelectedIndexChanged">
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
                            <asp:HyperLinkField HeaderText="详细" Text="详细" DataNavigateUrlFormatString="UpdateProduct.aspx?ProductId={0}"
                                DataNavigateUrlFields="ProductId">
                                <ItemStyle Width="50px" />
                            </asp:HyperLinkField>
                            <asp:CommandField ShowSelectButton="True">
                                <ItemStyle ForeColor="Blue" Width="50px" />
                            </asp:CommandField>
                            <asp:BoundField DataField="ProductId" HeaderText="产品编号">
                                <ItemStyle Width="125px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ProductName" HeaderText="产品名称">
                                <ItemStyle Width="275px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ProductCategoryName" HeaderText="所属分类">
                                <ItemStyle Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ProductCost" HeaderText="成本价">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SalePrice" HeaderText="销售价">
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="图片">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkpimg" runat="server" ToolTip="" OnClientClick='showimg(this)'>                                        
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="ProductUnits" HeaderText="单位">
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="StockNotifyStatus" HeaderText="库存提醒">
                                <ItemStyle Width="80px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Inputer" HeaderText="录入人">
                                <ItemStyle Width="80px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="InputDate" HeaderText="录入日期">
                                <ItemStyle Width="200px" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
    <asp:HyperLink ID="hnkBack" runat="server" Font-Size="12pt" 
                ForeColor="Blue" NavigateUrl="~/View/Index.aspx">返回首页</asp:HyperLink>
</body>
</html>
