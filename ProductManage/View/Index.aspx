<%@ Page Title="" Language="C#" MasterPageFile="~/View/FMaster.Master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="ProductManage.Index" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/IndexStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLogin" runat="server">
    <asp:UpdatePanel ID="uplLogin" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <%--用户登录--%>
            <div style="width: 400px; height: 77px; float: left;border: solid 0px black;"></div>
            <div style="width: 600px; height: 20px; float: left;border: solid 0px black;"></div>
            <div style="width: 600px; height: 57px; float: left;border: solid 0px black;">
                <asp:Label ID="Label2" runat="server" Text=" &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;最强嘉宾百货，成立于1935年时战乱纷飞的上海滩。
                公司秉持“温暖服务，宾至如归”的理念， 积极承担社会责任，为顾客提供良好的购物体验。" 
                Font-Bold="true" Font-Size="15px"></asp:Label>
            </div>
            <div style="width: 275px; height: 30px; float: left;border: solid 0px black;">
            </div>a
            <div style="width: 430px; height: 30px; float: left;border: solid 0px black; padding-top: 3px;">
                <center>
                    <div id="ptop">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" Text="产品分类"></asp:Label>
                        &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="dwlProductCategory" runat="server">
                        </asp:DropDownList>
                        &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                    </div>
                </center>
            </div>
            <div style="width: 290px; height: 35px; border: solid 0px black;float: left;">
                <asp:ImageButton ID="imbSearch" runat="server" Width="78px" ImageUrl="~/Img/searchProduct.jpg"
                    OnClick="imbSearch_Click" />
            </div>
            <div style="width: 10px; height: 170px; float: left; border: solid 0px black;background-color: rgb(255,130,130)">
            </div>
            <div style="width: 265px; height: 170px; float: left; border: solid 0px black;background-color: rgb(255,130,130)">
                <table style="width: 260px; height: 170px; line-height: 35px;">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblUserIdTip" ForeColor="Black" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblUserId" runat="server" Text="帐号："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserId" runat="server" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblPwdTip" Text="" ForeColor="Black" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPwd" runat="server" Text="密码："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPwd" runat="server" MaxLength="15" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblmsg" Text="" ForeColor="Black" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <center>
                                <asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" />
                            </center>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--展示产品--%>
    <asp:UpdatePanel ID="uplProductlst" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div id="content_right">
                <%--展示产品内容--%>
                <div id="productviewcon" style="width: 700px; height: 400px;border: solid 0px green; ">
                
                    <div id="proviewcon">
                        <asp:Repeater ID="RepeaterByProduct" runat="server" OnItemCommand="RepeaterByProduct_ItemCommand">
                            <ItemTemplate>
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                     <td>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                        <td style="width: 90px">
                                            <%--产品图片--%>
                                            <img src="../ProductImg/<%# Eval("ProductId") %>/<%# Eval("ProductImgFile") %>" alt="<%# Eval("ProductName") %>"
                                                width="140px" height="90px" style="border: 0; padding: 0; margin: 0; vertical-align: middle;"
                                                title="<%# Eval("ProductName") %>" onerror="this.src='../Img/肥喵.jpg'" onclick="javascript:location.href='Product/ProductDetails.aspx?ProductId=<%# Eval("ProductId")%>'" />
                                        </td>
                                        <td>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                        <td style="padding-left: 10px; width: 150px;">
                                            <asp:Literal ID="litProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Literal>
                                        </td>
                                        <td>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                        <td colspan="2" style="padding-left: 10px; width: 200px;">
                                            价格：<asp:Label ID="lblPSalePrice" runat="server" Text='<%# Eval("SalePrice") %>' Font-Bold="true"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnBuy" runat="server" Text="购买" CommandName="buyly" CommandArgument='<%# Eval("ProductId") %>' />
                                        </td>
                                        <td>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                        <td>
                                            <asp:Label ID="yesBuy" runat="server" Text="购买成功!!!" Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                </table>
                            </ItemTemplate>
                            <SeparatorTemplate>
                                <hr style="border: 1px dashed #E0E0E0;" />
                            </SeparatorTemplate>
                        </asp:Repeater>
                    </div>
                    
                <%--<div id="Div1" style="width: 700px; height: 50px;border: solid 0px green; "></div>--%>
                    <div id="propager">
                        <%--分页控件--%>
                        <webdiyer:AspNetPager ID="AspNetPagerByProducts" runat="server" CssClass="paginator"
                            HorizontalAlign="Center" NumericButtonCount="10" PageSize="3" ShowBoxThreshold="2"
                            OnPageChanging="AspNetPagerByProducts_PageChanging" Width="595px" PageIndexBoxType="DropDownList"
                            ShowNavigationToolTip="True" SubmitButtonText="Go" TextAfterPageIndexBox="页"
                            TextBeforePageIndexBox="转到" AlwaysShow="True">
                        </webdiyer:AspNetPager>
                    </div>
                </div>


            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="width: 250px; height: 67px; float: left; border: solid 0px black;">
        <asp:ImageButton ID="imbManager" runat="server" ImageUrl="~/Img/人2.jpg" 
            onclick="imbManager_Click" />
    </div>
    <div style="width: 1002px; height: 10px; float: left; border: solid 0px black;">
    </div>
    <div style="width: 1002px; height: 35px; float: left; border: solid 0px yellow;">
        <center>
            <asp:Label ID="Label3" runat="server" Text="版权所有：最强嘉宾百货"   
                Font-Names="Microsoft Yahei" Font-Size="Medium">
                </asp:Label>
        </center>
    </div>
</asp:Content>
