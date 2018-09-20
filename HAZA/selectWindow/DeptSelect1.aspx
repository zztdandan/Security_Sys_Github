<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeptSelect1.aspx.cs" Inherits="AppBox.HAZA.selectWindow.DeptSelect1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../res/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../res/js/jquery-1.8.0.js"></script>
    <script src="../res/js/bootstrap.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>部门选择</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="SimpleFormTree" runat="server"></f:PageManager>

                <f:Panel runat="server" BodyPadding="5px" Margin="10px" Width="400px" ShowBorder="false" ShowHeader="false" Title="Panel">
                    <Toolbars>
                        <f:Toolbar runat="server">
                            <Items>
                                <f:Button runat="server" ID="btnSelectUNIT" OnClick="btnSelectUNIT_Click" Text="选择并关闭"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Items>
                        <f:DropDownList ID="SECID_Select" runat="server" Label="二级单位" AutoPostBack="true"  Width="300px" Margin="10px"  OnSelectedIndexChanged="SECID_Select_SelectedIndexChanged"></f:DropDownList>
                        <f:DropDownList ID="KSID_Select" runat="server" Label="车间级" AutoPostBack="true"   Width="300px" Margin="10px" OnSelectedIndexChanged="KSID_Select_SelectedIndexChanged"></f:DropDownList>
                        <f:DropDownList ID="UNITID_Select" runat="server" Label="班组级" AutoPostBack="true"   Width="300px" Margin="10px" OnSelectedIndexChanged="UNITID_Select_SelectedIndexChanged"></f:DropDownList>
                    </Items>
                </f:Panel>

                <f:TextBox Readonly="true" ID="SelectedDept" runat="server" Width="300px" Label="选择的部门" Margin="10px"></f:TextBox>
 

    </form>

</body>
</html>
