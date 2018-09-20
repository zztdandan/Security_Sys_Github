<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RISKDETAIL.aspx.cs" Inherits="AppBox.HAZA.RISKDETAIL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <f:PageManager ID="PageManager2" runat="server" />
                        <f:Form ID="Formsubmit" CssClass="blockpanel" MessageTarget="Qtip" BodyPadding="10px" Title="风险添加与细节" ShowHeader="false" runat="server">
                            <Toolbars>
                                <f:Toolbar runat="server">
                                    <Items>
                                        <f:Button ID="RISK_Add" Text="添加风险" runat="server" ValidateForms="Formsubmit" OnClick="RISK_Add_Click" ConfirmText="点击确定将添加后关闭窗口"></f:Button>
                                        <f:Button ID="RISK_Save" Text="保存风险更改" runat="server" ValidateForms="Formsubmit" ConfirmText="此更改将作用于全部引用该风险的危险源" OnClick="RISK_Save_Click"></f:Button>
                                    </Items>
                                </f:Toolbar>
                            </Toolbars>
                            <Items>
                                <f:Panel runat="server" Layout="Column" CssClass="marginr" ShowBorder="false" ShowHeader="false" Margin="5 5 5 5">
                                    <Items>
                                        <f:TextBox ID="RISK_ID" runat="server" Hidden="true"></f:TextBox>
                                        <f:DatePicker runat="server" Required="true" DateFormatString="yyyy-MM-dd" Label="录入日期" EmptyText="默认录入日期"
                                            ID="REC_CREATE_TIME" ShowRedStar="True" EnableEdit="false">
                                        </f:DatePicker>
                                        <f:TextBox Label="录入人" ID="REC_CREATOR" runat="server" Enabled="false" Margin="0 5 0 20"></f:TextBox>
                                        <f:TextBox ID="RISK_DEPT" runat="server" Label="风险单位" Hidden="true"></f:TextBox>
                                    </Items>
                                </f:Panel>
                                <f:Panel runat="server" Layout="Column" CssClass="marginr" ShowBorder="false" ShowHeader="false" Margin="5 5 5 5">
                                    <Items>
                                        <f:DropDownList runat="server" ID="RISK_STATUS" EnableEdit="true" Label="风险状态" ShowLabel="true" Margin="5 5 5 0" Width="250px"></f:DropDownList>
                                         <f:TextBox runat="server" ID="RISK_MOD"  Label="风险事故模式" ShowLabel="true" Margin="5 5 5 0" Width="250px"></f:TextBox>

                                    </Items>
                                </f:Panel>
                                <f:Panel runat="server" Layout="Column" CssClass="marginr" ShowBorder="false" ShowHeader="false" Margin="5 5 5 5">
                                    <Items>
                                        <f:TextBox ID="RISK_L" runat="server" Label="风险评级L值" EmptyText="0" Required="true" Margin="5 5 5 0"  EnableBlurEvent="true"  OnBlur="RISKCalc"></f:TextBox>
                                        <f:TextBox ID="RISK_E" runat="server" Label="风险评级E值" EmptyText="0" Required="true" Margin="5 5 5 20"  EnableBlurEvent="true" OnBlur="RISKCalc"></f:TextBox>
                                        <f:TextBox ID="RISK_C" runat="server" Label="风险评级C值" EmptyText="0" Required="true" Margin="5 5 5 0"  EnableBlurEvent="true" OnBlur="RISKCalc"></f:TextBox>
                                        <f:TextBox ID="RISK_D" runat="server" Label="风险评级D值" EmptyText="0" Margin="5 5 5 20"  Readonly="true"></f:TextBox>
                                        <f:TextBox ID="FEATURE_CODE" runat="server" Label="风险数据特征码" Readonly="true" Margin="0 5 0 0" Hidden="true"></f:TextBox>
                                        <f:TextBox ID="RISK_LVL" runat="server" Label="风险评级"  Readonly="true" Margin="5 5 5 0"></f:TextBox>

                                    </Items>
                                </f:Panel>
                                <f:Panel runat="server" Layout="Column" CssClass="marginr" ShowBorder="false" ShowHeader="false" Margin="5 5 5 5">
                                    <Items>
                                        <f:Grid ID="RISK_SOL_Grid" CssClass="blockpanel" Title="处理措施" runat="server" EnableCollapse="false" EnableCheckBoxSelect="true"
                                            AllowPaging="False" IsDatabasePaging="false" Width="500px" ShowBorder="true" ShowHeader="true" ShowGridHeader="true"
                                            DataKeyNames="CODE">
                                            <Columns>
                                                <f:BoundField Width="30px" DataField="CODE" HeaderText="措施代码" />
                                                <f:BoundField Width="100px" DataField="CODE_DESC_1" HeaderText="措施信息" />
                                            </Columns>
                                        </f:Grid>
                                    </Items>
                                </f:Panel>
                                <f:Panel runat="server" Layout="Column" CssClass="marginr" ShowBorder="false" ShowHeader="false" Margin="5 5 5 5">
                                    <Items>
                                        <f:TextArea ID="RISK_DESC" runat="server" Label="风险描述" Required="true" Width="500px"></f:TextArea>
                                    </Items>
                                </f:Panel>
                            </Items>

                        </f:Form>

                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
