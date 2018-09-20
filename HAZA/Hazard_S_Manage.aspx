<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hazard_S_Manage.aspx.cs" Inherits="AppBox.HAZA.Hazard_S_Manage" %>

<%@ Register Assembly="FineUIPro" Namespace="FineUIPro" TagPrefix="fui" %>
<%@ Register Src="~/HAZA/interfaceNModel/HAZASearchForm.ascx" TagName="HAZASearchForm" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../res/css/bootstrap.min.css" rel="stylesheet" />
    <script src="res/js/jquery-1.8.0.min.js"></script>
    <script src="res/js/bootstrap.min.js"></script>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>危险源管理界面</title>
</head>
<body>

    <form id="form2" runat="server">

        <f:PageManager ID="PageManager2" runat="server" />
        <div class="container">
            <div class="row">
              
                  
            </div>
            <div class="row" style="padding:8px">
                  <f:FileUpload runat="server" ID="File_Upload" CssStyle="display:inline-block"></f:FileUpload>
                 <f:Button runat="server" ID="Btn_AddInRISK" OnClick="Btn_AddInRISK_Click" Text="导入风险及危险源" CssStyle="display:inline-block"></f:Button>
                <a href="../res/危险源风险录入.xls" style="display:inline-block">实例表格下载</a>
            </div>
            </div>


        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <uc1:HAZASearchForm ID="HAZASearchForm" runat="server"></uc1:HAZASearchForm>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <f:Grid ID="HAZAGrid" CssClass="blockpanel" ShowBorder="true" ShowHeader="true" Title="危险源表格" runat="server" EnableCollapse="false" EnableCheckBoxSelect="true"
                        AllowPaging="true"  OnPageIndexChange="HAZAGrid_PageIndexChange" PageSize="40"   IsDatabasePaging="true"
                      
                        DataKeyNames="ID">
                        <Toolbars>
                            <f:Toolbar runat="server">
                                <Items>
                                    <f:Button runat="server" ID="Btn_AddHAZA"  Text="添加危险源" OnClientClick="openAddHAZA()" EnablePostBack="false" Icon="Add"></f:Button>
                                    <f:Button runat="server" ID="Btn_DelHAZA" OnClick="Btn_DelHAZA_Click" Text="删除危险源" ConfirmText="点击确认确认删除，点击取消返回"></f:Button>
                                    <f:Button runat="server" ID="Btn_EditHAZA" OnClick="Btn_EditHAZA_Click" Text="修改危险源(单选)"></f:Button>
                                    <f:Button runat="server" ID="Btn_VerifyHAZA" OnClick="Btn_VerifyHAZA_Click" Text="危险源详细审核(单选)"></f:Button>
                                    <f:Button runat="server" ID="Btn_ViewHAZA" OnClick="Btn_ViewHAZA_Click" Text="危险源详情查看(单选)"></f:Button>
                                    <f:ToolbarFill ID="ToolbarFill1" runat="server"></f:ToolbarFill>
                                </Items>
                            </f:Toolbar>
                            <%-- <f:Toolbar runat="server" >
                                <Items>
                                    <f:Button runat="server" ID="Click1" OnClick="Btn_AddHAZA_Click" Text="添加危险源"></f:Button>
                                <f:Button runat="server" ID="Click2" OnClick="Btn_DelHAZA_Click" Text="删除危险源"></f:Button>

                                </Items>
                                
                            </f:Toolbar>--%>
                        </Toolbars>
                        <Columns>
                            <f:BoundField Width="30px" DataField="ID" DataFormatString="{0}" HeaderText="ID" />

                            <f:BoundField Width="30px" DataField="HAZA_ID" DataFormatString="{0}" HeaderText="序号" />
                            <f:BoundField Width="100px" DataField="HAZA_NAME" HeaderText="危险源名称" />
                            <f:BoundField Width="70px" DataField="HAZA_LOCA_G" HeaderText="区域" />
                            <f:BoundField Width="100px" DataField="HAZA_DEPT_G" HeaderText="单位" />
                            <f:BoundField Width="30px" DataField="HAZA_LVL_G" HeaderText="评级" />
                            <f:BoundField Width="100px" DataField="REC_CREATOR_G" HeaderText="录入人" />
                            <f:BoundField Width="100px" DataField="REC_CREATETIME_G" HeaderText="录入时间" />
                            <f:BoundField Width="100px" DataField="HAZA_CATEGORY_G" HeaderText="状态" />


                        </Columns>
                    </f:Grid>

                    <f:Window ID="Btn_HAZA_Window" runat="server" WindowPosition="Center" IsModal="true" EnableMaximize="true"
                        EnableResize="true" Target="Self" EnableIFrame="true" Hidden="true"
                        Height="700px" Width="960px" OnClose="Btn_HAZA_Window_Close" Title="危险源">
                    </f:Window>

                </div>
            </div>
        </div>



    </form>
    <script>
        function openAddHAZA() {

            parent.myFunction1('AddNewTab','~/HAZA/AddEditHAZA.aspx');
        }
        function openTab(a) {

            parent.myFunction1('AddNewTab', a);
        }
    </script>
</body>
</html>
