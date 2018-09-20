<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeptSelect.aspx.cs" Inherits="AppBox.HAZA.selectWindow.WebForm1" %>


<!DOCTYPE html>
<html>
<head runat="server">
    <title>部门选择页面</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="SimpleFormTree" runat="server"></f:PageManager>
        <f:SimpleForm ID="SimpleFormTree" LabelAlign="Top" ShowBorder="false" ShowHeader="false" Title="SimpleForm"
            BodyPadding="10px" runat="server" EnableCollapse="false" AutoScroll="true">
            <Toolbars>
                <f:Toolbar runat="server">
                    <Items>
                      
                        <f:TriggerBox ShowTrigger="false" OnTriggerClick="SearchButton_Click"    ID="SearchText1" runat="server"  EmptyText="如需搜索请输入搜索项" Margin="0 5 0 0" ></f:TriggerBox>
                        <f:Button ID="SearchButton"  ValidateForms="SimpleFormTree" runat="server" OnClick="SearchButton_Click" Text="搜索" Margin="0 5 0 0"></f:Button>
                        <f:Button ID="btnDeptSelect" runat="server" CssClass="marginr" Margin="0 5 0 0" Text="选择单位并关闭窗口" OnClick="btnDeptSelect_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <%--树形控件--%>
            <Items>
                <f:Tree ID="TreeSelectDept" CssClass="blockpanel" EnableSingleClickExpand="true" ShowHeader="true" EnableCollapse="false" Collapsed="false" OnNodeLazyLoad="TreeSelectDept_NodeLazyLoad" AutoLeafIdentification="false"
                    Title="树_选择单位" runat="server">
                    <Nodes>
                    </Nodes>
                </f:Tree>
              
            </Items>
        </f:SimpleForm>

    </form>
</body>
</html>
