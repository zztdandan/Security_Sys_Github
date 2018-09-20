<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SafeVerify.ascx.cs" Inherits="AppBox.Verify.SafeVerify" %>

<f:PageManager ID="PageManager3" runat="server" />
<f:Form ID="FormVerify" MessageTarget="Qtip" BodyPadding="10px" Title="审核" runat="server">
    <Items>
        <f:Panel ID="Btn_ToolBar" runat="server" BodyPadding="5px" Margin="5px" ShowBorder="false" ShowHeader="false" Title="Panel" Layout="Column">
            <Items>
             
            </Items>
        </f:Panel>

        <f:Panel ID="Panel2" runat="server" BodyPadding="5px" Margin="5px" ShowBorder="false" ShowHeader="false" Title="Panel" Layout="Column">
            <Items>
           <f:TextArea ID="CONCLUSION" runat="server" Height="60px"></f:TextArea>
            </Items>
        </f:Panel>
     
    </Items>
</f:Form>


