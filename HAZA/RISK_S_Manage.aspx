<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RISK_S_Manage.aspx.cs" Inherits="AppBox.HAZA.RISK_S_Manage" %>
<%@ Register Src="~/HAZA/interfaceNModel/RISKSearchForm.ascx" TagName="RISKSearchForm" TagPrefix="uc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../res/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../res/js/jquery.min.js"></script>
    <script src="../res/js/bootstrap.min.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>风险管理界面</title>
</head>
<body>
     <f:PageManager ID="PageManager2" runat="server" />
        <h2>风险管理界面</h2>


        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <uc2:RISKSearchForm ID="RISKSearchForm" runat="server"></uc2:RISKSearchForm>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <f:Grid ID="RISKGrid" CssClass="blockpanel" ShowBorder="true" ShowHeader="true" Title="风险表格" runat="server" EnableCollapse="false" EnableCheckBoxSelect="true"
                        AllowPaging="true" IsDatabasePaging="false" OnPageIndexChange="RISKGrid_PageIndexChange" PageSize="10"
                        DataKeyNames="ID">
                        <Toolbars>
                            <f:Toolbar runat="server">
                                <Items>
                                    <f:Button runat="server" ID="Btn_AddRISK" OnClick="Btn_AddRISK_Click" Text="添加风险"></f:Button>
                                    <f:Button runat="server" ID="Btn_DelRISK" OnClick="Btn_DelRISK_Click" Text="删除风险" ConfirmText="点击确认确认删除，点击取消返回"></f:Button>
                                    <f:Button runat="server" ID="Btn_EditRISK" OnClick="Btn_EditRISK_Click" Text="修改危险源(单选)"></f:Button>
                                    <f:Button runat="server" ID="Btn_VerifyRISK" OnClick="Btn_VerifyRISK_Click" Text="危险源详细审核(单选)"></f:Button>
                                    <f:Button runat="server" ID="Btn_ViewRISK" OnClick="Btn_ViewRISK_Click" Text="危险源详情查看(单选)"></f:Button>
                          

                                </Items>
                            </f:Toolbar>

                        </Toolbars>
                        <Columns>
                            <f:BoundField Width="30px" DataField="ID" DataFormatString="{0}" HeaderText="ID" />

                            <f:BoundField Width="30px" DataField="RISK_ID" HeaderText="风险主键" />
                            <f:BoundField Width="100px" DataField="REC_CREATE_TIME" HeaderText="风险录入时间" />
                            <f:BoundField Width="70px" DataField="RISK_NAME" HeaderText="风险名称" />
                            <f:BoundField Width="100px" DataField="RISK_DEPT" HeaderText="风险单位" />
                            <f:BoundField Width="30px" DataField="RISK_LVL" HeaderText="风险评级" />

                            <f:BoundField Width="100px" DataField="RISK_CATEGORY" HeaderText="风险数据属性" />
                        </Columns>
                    </f:Grid>

                   <%-- <f:Window ID="Btn_AddHAZA_Window" runat="server" WindowPosition="Center" IsModal="true" EnableMaximize="true"
                        EnableResize="true" Target="Self" EnableIFrame="true" IFrameUrl="~/HAZA/selectWindow/DeptSelect.aspx" Hidden="true"
                        Height="550px" Width="850px" OnClose="Window1_Close" Title="新建危险源">
                    </f:Window>--%>

                </div>
            </div>
        </div>



    
</body>
</html>
