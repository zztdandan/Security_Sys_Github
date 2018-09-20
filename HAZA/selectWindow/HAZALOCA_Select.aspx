<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HAZALOCA_Select.aspx.cs" Inherits="AppBox.HAZA.selectWindow.HAZALOCA_Select" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>危险源、风险地点选择</title>
    <script src="../../res/js/jquery-1.8.0.min.js"></script>

</head>
<body>
    <form id="form2" runat="server">
        <f:PageManager ID="PageManager2" runat="server" />
        <div class="container">
            <div class="row" style="padding:8px">
                <f:FileUpload runat="server" ID="File_Upload"  CssStyle="display:inline-block"></f:FileUpload>
                   <f:Button runat="server" ID="Btn_AddIn" OnClick="Btn_AddIn_Click" Text="导入危险源区域"  CssStyle="display:inline-block"></f:Button>
                <a href="../../res/危险源区域.xls"  style="display:inline-block">危险源区域样表</a>
            </div>
            <div class="row">
                
            </div>
            <div class="row">
                <div class="col-md-12">
                    <f:Grid ID="HAZALOCAGrid" CssClass="blockpanel" ShowBorder="true" ShowHeader="true" Title="危险源区域" runat="server" EnableCollapse="false" EnableCheckBoxSelect="true"
                        AllowPaging="true" IsDatabasePaging="true" Width="800" OnPageIndexChange="HAZALOCAGrid_PageIndexChange" PageSize="10"
                        DataKeyNames="ID">
                        <Toolbars>
                            <f:Toolbar runat="server">
                                <Items>
                                    <f:TriggerBox ShowTrigger="false" OnTriggerClick="SearchButton_Click" ID="HAZALOCA_NAMEText" runat="server" EmptyText="按名称搜索" Margin="0 5 0 0"></f:TriggerBox>
                                    <f:TriggerBox ID="dept_tbxMyBox1" ShowLabel="true" Label="部门选择" Readonly="false" TriggerIcon="Search"
                                        OnTriggerClick="dept_tbxMyBox1_TriggerClick" EmptyText="点搜索图标选择（默认全部）" runat="server" Width="250px" Margin="0 5 0 20" EnableEdit="true">
                                    </f:TriggerBox>
                                    <f:Button ID="SearchButton" ValidateForms="SimpleFormTree" runat="server" OnClick="SearchButton_Click" Text="搜索" Margin="0 5 0 0"></f:Button>

                                    <f:Button runat="server" ID="Btn_AddLOCA" OnClick="Btn_AddLOCA_Click" Text="添加新的危险源区域"></f:Button>
                                    <f:Button runat="server" ID="Btn_DelLOCA" OnClick="Btn_DelLOCA_Click" Text="删除危险区域" ConfirmText="点击确认确认删除，点击取消返回"></f:Button>                                                              
                                    <f:Button runat="server" ID="Btn_SelectLOCA" OnClick="Btn_SelectLOCA_Click" Text="选择并关闭窗口"></f:Button>
                                    <f:ToolbarFill ID="ToolbarFill1" runat="server"></f:ToolbarFill>

                                </Items>
                            </f:Toolbar>
                          
                        </Toolbars>
                        <Columns>
                            <f:BoundField Width="30px" DataField="ID" DataFormatString="{0}" HeaderText="危险源区域ID" />
                            <f:BoundField Width="100px" DataField="DEPT" HeaderText="危险源区域所属单位" />
                            <f:BoundField Width="150px" DataField="C_NAME" HeaderText="危险源区域名称" />
                            <f:BoundField Width="100px" DataField="C_STATS" HeaderText="危险源区域状态" />
                            <f:BoundField Width="100px" DataField="DEPT_C" HeaderText="危险源区域所属单位中文名称" />
                        </Columns>
                    </f:Grid>
                    <f:Window ID="dept_tbxMyBox1_Window" runat="server" WindowPosition="Center" IsModal="true" EnableMaximize="true"
                        EnableResize="true" Target="Self" EnableIFrame="true" IFrameUrl="~/HAZA/selectWindow/DeptSelect1.aspx" Hidden="true"
                       Height="600px" Width="800px" OnClose="dept_tbxMyBox1_Window_Close" Title="部门选择">
                    </f:Window>
                    <f:Window ID="AddLOCA_Window" runat="server" WindowPosition="Center" IsModal="true" EnableMaximize="true"
                        EnableResize="true" Target="Self" Hidden="true"
                        Height="400px" Width="600px" OnClose="AddLOCA_Window_Close" Title="添加新危险源区域">
                        <Items>
                            <f:SimpleForm ID="AddLOCAForm" runat="server" CssClass="blockpanel" BodyPadding="10px" Title="新增危险源地址" ShowBorder="true" >
                                <Items>
                                    <f:TextBox runat="server" ID="AddLOCA_NAMEText" Label="添加危险区域名称" Required="true"></f:TextBox>
                                    <f:TriggerBox ID="dept_tbxMyBox2" ShowLabel="true" Label="选择所属部门" Readonly="false" TriggerIcon="Search" Required="true"
                                        OnTriggerClick="dept_tbxMyBox2_TriggerClick" EmptyText="点搜索按钮选择（默认A1）" runat="server" Width="250px" Margin="0 5 0 20" EnableEdit="true">
                                    </f:TriggerBox>
                                    <f:Button Type="Submit" runat="server" ValidateForms="AddLOCAForm" ID="Btn_AddLOCA_Add" Text="添加" ConfirmText="点击确认添加，点击取消取消添加" OnClick="Btn_AddLOCA_Add_Click"></f:Button>
                                </Items>
                            </f:SimpleForm>

                        </Items>
                    </f:Window>
                    <f:Window ID="dept_tbxMyBox2_Window" runat="server" WindowPosition="Center" IsModal="true" EnableMaximize="true"
                        EnableResize="true" Target="Self" EnableIFrame="true" IFrameUrl="~/HAZA/selectWindow/DeptSelect1.aspx" Hidden="true"
                        Height="600px" Width="800px" OnClose="dept_tbxMyBox2_Window_Close" Title="部门选择">
                    </f:Window>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
