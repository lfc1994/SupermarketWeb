<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="ProductManage.AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>后台管理员登录</title>
</head>
<body>
    <center>
        <form id="form1" runat="server">
       <div style="width: 500px; height: 401px; background: url(../Img/wode/logo.png); background-repeat:no-repeat; background-position:center;">



            <table style="width: 450px; height: 160px; border: 0; line-height: 35px; margin-top:160px; margin-left:25px; margin-right:25px;">
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="lbltp" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblUserId" runat="server" Text="帐号：" Font-Bold="True" Font-Names="仿宋"
                            Font-Size="Medium"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:TextBox ID="txtUserId" runat="server">admin</asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPwd" runat="server" Text="密码：" Font-Bold="True" Font-Names="仿宋"
                            Font-Size="Medium"></asp:Label>
                    </td>
                    <td style="text-align: left">
                        <asp:TextBox ID="txtPwd" runat="server" MaxLength="15" TextMode="Password" BorderStyle="Inset"
                            Width="149px"></asp:TextBox>
                    </td>
                    <td style="text-align: left">
                        <asp:Image ID="imgValidateCode" runat="server" Width="120px" Height="35px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>验证码：</b>
                    </td>
                    <td style="text-align: left">
                        <asp:TextBox ID="txtVerifycode" runat="server" ToolTip="验证码要区分大小写" Width="72px" MaxLength="8"
                            onmouseover="this.style.borderColor='red'" onmouseout="this.style.borderColor='#808080 #cbdfca #cbdfca #808080'"
                            BorderStyle="Inset"></asp:TextBox>
                    </td>
                    <td>
                        <asp:LinkButton ID="lnkGetVerifyCode" runat="server" Font-Underline="False" OnClick="lnkGetVerifyCode_Click"
                            Font-Size="13px">看不清,换一张</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <center>
                            <asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" BackColor="#6699FF"
                                BorderStyle="None" Font-Bold="True" Font-Names="仿宋" Font-Size="Medium" Height="27px"
                                Width="57px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" OnClientClick="javascript:return confirm('确定要重置？')"
                                BackColor="#6699FF" BorderStyle="None" Font-Bold="True" Font-Names="仿宋" Font-Size="Medium"
                                Height="27px" Width="57px" />
                        </center>
                    </td>
                </tr>
            </table>
    
         </div>
        </form>
    </center>
       <asp:HyperLink ID="hnkBack" runat="server" Font-Size="12pt" 
                ForeColor="Blue" NavigateUrl="~/View/Index.aspx">返回首页</asp:HyperLink>
</body>
</html>
