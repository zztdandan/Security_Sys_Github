<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEditHAZA.aspx.cs" Inherits="AppBox.HAZA.AddHAZA" %>

<%@ Register Src="~/Verify/SafeVerify.ascx" TagPrefix="uc1" TagName="SafeVerify" %>
<%@ Register Src="~/Verify/HAZA02Verify.ascx" TagPrefix="uc1" TagName="HAZA02Verify" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


    <link href="../res/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../res/js/jquery.min.js"></script>
    <script src="../res/js/bootstrap.min.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>添加危险源</title>

</head>
<body>
    <form id="form2" runat="server">
        <f:PageManager ID="PageManager2" runat="server" />

       
                <div class="col-md-12">
                    <uc1:HAZA02Verify runat="server" ID="SafeVerify" Visible="false"  />
                 
                </div>
          
        
                <div class="col-md-12">
                    <f:Form ID="Formsubmit" CssClass="blockpanel" MessageTarget="Qtip" BodyPadding="10px" Title="危险源" runat="server" ShowHeader="false">
                        <Toolbars>
                            <f:Toolbar runat="server">
                                <Items>
                                    <f:Button ID="HAZA_Add" Text="添加危险源" runat="server" ValidateForms="Formsubmit" OnClick="HAZA_Add_Click"></f:Button>
                                    <f:Button ID="HAZA_Edit" Text="保存危险源（危险源将进入审核中)" runat="server" ValidateForms="Formsubmit" OnClick="HAZA_Edit_Click"></f:Button>
                                </Items>
                            </f:Toolbar>
                        </Toolbars>
                        <Items>
                            <f:Panel runat="server" Layout="Column" CssClass="marginr" ShowBorder="false" ShowHeader="false" BodyPadding="5px">
                                <Items>
                                     <f:TextBox ID="ID_HAZA" runat="server" Hidden="true"></f:TextBox>
                                    <f:TextBox ID="HAZA_ID" runat="server" Hidden="true"></f:TextBox>
                                    <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="录入日期" EmptyText="默认录入日期"
                                        ID="HAZA_DATE" ShowRedStar="True" EnableEdit="false">
                                    </f:DatePicker>
                                    <f:TextBox Label="录入人" ID="HAZA_CREATOR" Width="250" Margin="0 5 0 20" runat="server" Enabled="false"></f:TextBox>
                                </Items>
                            </f:Panel>
                            <f:Panel runat="server" Layout="Column" CssClass="marginr" ShowBorder="false" ShowHeader="false" BodyPadding="5px">
                                <Items>
                                    <f:TextBox ID="HAZA_NAME" runat="server" Label="危险源名称" EmptyText="填入危险源名称（必填）" Required="true"></f:TextBox>
                                    <f:TriggerBox ID="hazaloca_tbxMyBox1" ShowLabel="true" Label="危险源区域" Readonly="false" TriggerIcon="Search"
                                        OnTriggerClick="hazaloca_tbxMyBox1_TriggerClick" EmptyText="点搜索按钮选择（默认全部）" runat="server" Width="250px" Margin="0 5 0 20" EnableEdit="true">
                                    </f:TriggerBox>
                                </Items>
                            </f:Panel>
                            <f:Grid ID="HAZA_RISKGrid" runat="server" EnableCheckBoxSelect="true" CssClass="blockpanel"
                                Title="危险源包含风险表格" AllowPaging="true" IsDatabasePaging="true" PageSize="20" OnPageIndexChange="HAZA_RISKGrid_PageIndexChange"
                                DataKeyNames="RISK_ID" OnRowCommand="HAZA_RISKGrid_RowCommand" ShowBorder="false" ShowHeader="false" Width="900" BodyPadding="5px">
                                <Toolbars>
                                    <f:Toolbar runat="server">
                                        <Items>
                                            <f:Button runat="server" ID="Btn_AddRISK" OnClick="Btn_AddRISK_Click" Text="添加风险"></f:Button>
                                            <f:Button runat="server" ID="Btn_DelRISK" OnClick="Btn_DelRISK_Click" Text="删除风险" ConfirmText="点击确认确认删除，点击取消返回"></f:Button>
                                            <f:Button runat="server" ID="Btn_EditRISK" OnClick="Btn_EditRISK_Click" Text="修改风险(单选)"></f:Button>

                                        </Items>
                                    </f:Toolbar>
                                </Toolbars>
                                <Columns>
                                    <f:BoundField Width="30px" DataField="RISK_ID" DataFormatString="{0}" HeaderText="ID" ID="ctl07" ColumnID="Formsubmit_HAZA_RISKGrid_ctl07"  Hidden="true"/>
                                    <f:BoundField Width="80px" DataField="RISK_STATUS_G" DataFormatString="{0}" HeaderText="风险状态" ID="ctl08" ColumnID="Formsubmit_HAZA_RISKGrid_ctl08" />
                                    <f:BoundField Width="500px" DataField="RISK_DECONTENT" HeaderText="风险详情" ID="ctl09" ColumnID="Formsubmit_HAZA_RISKGrid_ctl09" />
                                    <f:BoundField Width="100px" DataField="RISK_D" HeaderText="风险评级" ID="ctl10" ColumnID="Formsubmit_HAZA_RISKGrid_ctl10" />
                                    <f:LinkButtonField Width="80px" TextAlign="Center" HeaderText="操作" Text="详情" CommandName="ActionDetail" ID="ctl11" ColumnID="Formsubmit_HAZA_RISKGrid_ctl11" />
                                </Columns>
                            </f:Grid>
                            <f:Panel runat="server" Layout="Column" CssClass="marginr" ShowBorder="false" ShowHeader="false" BodyPadding="5px">
                                <Items>
                                    <f:DropDownList ID="HAZALVL_DList" runat="server" Label="危险源危险等级" EnableEdit="true" ShowLabel="true" Margin="0 5 0 20" LabelWidth="150px" Width="300px" Required="true" OnSelectedIndexChanged="HAZALVL_DList_SelectedIndexChanged"></f:DropDownList>
                                    <f:TextBox ID="HAZALVLEdit" runat="server" Hidden="true"></f:TextBox>
                                    <f:TextBox ID="HAZA_D_TEXT" runat="server" Label="风险总值"  LabelWidth="150px" Width="300px" EmptyText="该自动生成" Required="true"></f:TextBox>

                                </Items>
                            </f:Panel>
                        </Items>

                    </f:Form>
                    <f:Window ID="RISK_DETAIL_Window" runat="server" WindowPosition="Center" IsModal="true" EnableMaximize="true"
                        EnableResize="true" Target="Self" EnableIFrame="true" Hidden="true"
                        Height="550px" Width="850px" OnClose="RISK_DETAIL_Window_Close" Title="风险细节">
                    </f:Window>
                    <f:Window ID="hazaloca_tbxMyBox1_Window" runat="server" WindowPosition="Center" IsModal="true" EnableMaximize="true"
                        EnableResize="true" Target="Self" EnableIFrame="true" IFrameUrl="~/HAZA/selectWindow/HAZALOCA_Select.aspx" Hidden="true"
                        Height="550px" Width="850px" OnClose="hazaloca_tbxMyBox1_Window_Close" Title="危险区域选择">
                    </f:Window>
                </div>
  

    </form>


</body>
</html>
