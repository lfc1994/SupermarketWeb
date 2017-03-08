<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProduct.aspx.cs" Inherits="ProductManage.UpdateProduct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="ZLTextBox" Namespace="BaseText" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
    <div style="float: left; border: 0; margin-left: 10px; font-size: 12px;">
    <br />
        <p style="font-size: 25px; font-weight: bold; color: Red;">
            修改产品信息
            <asp:HyperLink ID="hnkProductLst" runat="server" Font-Size="12pt" 
                ForeColor="Blue" NavigateUrl="~/Admin/ProductManageList.aspx">产品列表页</asp:HyperLink>
            </p>
        <p>
            提示：以下打 <span style="color: Red">*</span> 项为必填内容
        </p>
        <table width="100%" cellpadding="2px" cellspacing="2px" border="0" style="line-height: 30px;">
            <tr>
                <td style="width: 85px">
                    原产品编号
                </td>
                <td>
                    <asp:TextBox ID="txtProductId" runat="server" MaxLength="20" ToolTip="最长20位" Enabled="false"
                        BackColor="Lavender"></asp:TextBox>
                    <span style="color: Red">*</span>
                </td>
            </tr>         
            <tr>
                <td>
                    产品名称
                </td>
                <td>
                    <asp:TextBox ID="txtProductName" runat="server" MaxLength="200" ToolTip="最长200字符或100汉字"></asp:TextBox>
                    <span style="color: Red">*</span>
                </td>
            </tr>
            <tr>
                <td>
                    产品分类编号
                </td>
                <td>
                      <asp:TextBox ID="txtProductCategoryId" runat="server" Enabled="false" BackColor="Lavender"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    产品分类名称
                </td>
                <td>
                    <asp:TextBox ID="txtProductCategoryName" runat="server" Enabled="false" BackColor="Lavender"></asp:TextBox>
                    <span style="color: Red">*</span>
                </td>
            </tr>
            <tr>
                <td style="color: Red">
                    上传文件说明：
                </td>
                <td style="color: Red">
                    文件格式：jpg、png、gif、bmp (文件最大4M)
                </td>
            </tr>
            <tr>
                <td>
                    产品图片
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan="3">
                                <asp:ImageButton ID="imgProductImgFilebtn" runat="server" OnClientClick="showimg(this)"
                                    ToolTip="" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 200px">
                                <asp:FileUpload ID="fuProductImgFile" runat="server" ToolTip="选择产品图片" />
                            </td>
                            <td style="width: 200px">
                                <asp:ImageButton ID="uploadbtn" runat="server" ImageUrl="~/Img/bkimg/upload.png"
                                    OnClick="uploadbtn_Click" ToolTip="上传产品图片" />&nbsp;
                                <asp:ImageButton ID="imgdelbfbtn" runat="server" ImageUrl="~/Img/bkimg/delete.png"
                                    ToolTip="删除产品图片" OnClick="imgdelbfbtn_Click" OnClientClick="javascript:return confirm('确定要删除？');" />
                            </td>
                            <td>
                                <asp:Label ID="uplblmsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    产品参数
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    产品成本价
                </td>
                <td>
                    <cc1:ZLTextBox ID="txtProductCost" runat="server" FloatLength="3" InputType="number"
                        IsDisplayTime="False" MaxLength="10" textValue="">0</cc1:ZLTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    产品销售价
                </td>
                <td>
                    <cc1:ZLTextBox ID="txtSalePrice" runat="server" FloatLength="3" InputType="number"
                        IsDisplayTime="False" MaxLength="10">0</cc1:ZLTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    产品单位
                </td>
                <td>
                    <asp:TextBox ID="txtProductUnits" runat="server" Width="75px" MaxLength="15"></asp:TextBox>
                    <span style="color: Red">*</span>
                </td>
            </tr>
            <tr>
                <td>
                   当前库存量
                </td>
                <td>
                    <cc1:ZLTextBox ID="txtCurrentstock" runat="server" FloatLength="3" InputType="number"
                        IsDisplayTime="False" MaxLength="100">0</cc1:ZLTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    库存量提醒
                </td>
                <td>
                    <asp:DropDownList ID="dwlStockNotifyStatus" runat="server">
                        <asp:ListItem Value="1">要提醒</asp:ListItem>
                        <asp:ListItem Value="0" Selected="True">不提醒</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
          
            </tr>
            <tr>
                <td>
                    备注
                </td>
                <td>
                    <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" MaxLength="500"
                        ToolTip="最长500字符或250汉字" Height="80px" Width="550px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:ImageButton ID="imgUpdatebtn" runat="server" ImageUrl="~/Img/bkimg/update.png"
                        ToolTip="修改产品" OnClick="imgUpdatebtn_Click" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Label ID="lblmsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
