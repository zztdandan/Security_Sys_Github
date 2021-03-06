﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HAZASearchForm.ascx.cs" Inherits="AppBox.HAZA.HAZASearchForm" %>
<%@ Register Assembly="FineUIPro" Namespace="FineUIPro" TagPrefix="fui" %>
<f:PageManager ID="PageManager2" runat="server" />

<f:Form ID="FormsubmitSearch" CssClass="blockpanel" MessageTarget="Qtip" BodyPadding="10px" Title="危险源搜索选项" runat="server">
    <Items>
        <f:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false" Title="Panel" Layout="Column">
            <Items>
                <f:DatePicker runat="server" Required="true" AutoPostBack="true" OnTextChanged="start_time_picker_1_TextChanged"
                    Label="开始日期" EmptyText="请选择开始日期" ID="start_time_picker_1" ShowRedStar="True" Width="250px">
                </f:DatePicker>
                <f:DatePicker ID="end_time_picker_2" Required="true" Readonly="false" CompareControl="start_time_picker_1"
                    DateFormatString="yyyy-MM-dd" CompareOperator="GreaterThan" CompareMessage="结束日期应该大于开始日期"
                    Label="结束日期" runat="server" ShowRedStar="True" Margin="0 5 0 20" Width="250px">
                </f:DatePicker>

                <f:TriggerBox ID="dept_tbxMyBox1" ShowLabel="true" Label="部门选择" Readonly="false" TriggerIcon="Search"
                    OnTriggerClick="dept_tbxMyBox1_TriggerClick" EmptyText="点搜索按钮选择（默认全部）" runat="server" Width="250px" Margin="0 5 0 20" EnableEdit="true">
                </f:TriggerBox>
            </Items>
        </f:Panel>

        <f:Panel ID="Panel2" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false" Title="Panel" Layout="Column">
            <Items>
                <f:TextBox ID="HAZA_name" runat="server" Label="危险源名称" ShowLabel="true" Width="250px"></f:TextBox>
                <f:DropDownList ID="HAZA_lvl_droplist" EnableEdit="true" Label="危险源等级" ShowLabel="true" Margin="0 5 0 20" Width="250px" runat="server"></f:DropDownList>

            </Items>
        </f:Panel>
        <f:Panel ID="Panel3" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false" Title="Panel" Layout="Column">
            <Items>
                <f:DropDownList ID="HAZA_cate_droplist" EnableEdit="true" Label="危险源数据状态" ShowLabel="true" Width="250px" runat="server"></f:DropDownList>
                <f:TriggerBox ID="hazaloca_tbxMyBox1" ShowLabel="true" Label="危险源区域" Readonly="false" TriggerIcon="Search"
                    OnTriggerClick="hazaloca_tbxMyBox1_TriggerClick" EmptyText="点搜索按钮选择（默认全部）" runat="server" Width="250px" Margin="0 5 0 20" EnableEdit="true">
                </f:TriggerBox>
                <f:Button ID="btnSubmitForm" runat="server" CssClass="marginr" Margin="8 5 0 20" Text="搜索" OnClick="Btn_Search_Click" ValidateForms="FormsubmitSearch"></f:Button>
            </Items>
        </f:Panel>
    </Items>
</f:Form>
<f:Window ID="dept_tbxMyBox1_Window" runat="server" WindowPosition="Center" IsModal="true" EnableMaximize="true"
    EnableResize="true" Target="Self" EnableIFrame="true" IFrameUrl="~/HAZA/selectWindow/DeptSelect1.aspx" Hidden="true"
    Height="400px" Width="800px" OnClose="dept_tbxMyBox1_Window_Close" Title="部门选择">
</f:Window>
<f:Window ID="hazaloca_tbxMyBox1_Window" runat="server" WindowPosition="Center" IsModal="true" EnableMaximize="true"
    EnableResize="true" Target="Self" EnableIFrame="true" IFrameUrl="~/HAZA/selectWindow/HAZALOCA_Select.aspx" Hidden="true"
    Height="550px" Width="850px" OnClose="hazaloca_tbxMyBox1_Window_Close" Title="危险区域选择">
</f:Window>

