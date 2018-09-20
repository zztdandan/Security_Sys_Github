<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HAZA02Verify.ascx.cs" Inherits="AppBox.Verify.HAZA02Verify" %>

<f:PageManager ID="PageManager3" runat="server" />
<div id="canvas" style="width:300px;height=200px;display:block;"></div>
<f:Form ID="FormVerify" MessageTarget="Qtip" BodyPadding="10px" Title="审核" runat="server">
    <Items>
        <f:Panel  runat="server" BodyPadding="5px" Margin="5px" ShowBorder="false" ShowHeader="false" Title="Panel" Layout="Column">
            <Items>
               
                <f:ToolbarText runat="server"  Text="现在审核状态:  "></f:ToolbarText>
      
                <f:ToolbarText runat="server" CssClass="Veri_Status" ID="Veri_Status"></f:ToolbarText>

            </Items>
        </f:Panel>

       
        <f:Panel ID="Panel2" runat="server" BodyPadding="5px" Margin="5px" ShowBorder="false" ShowHeader="false" Title="Panel" Layout="Column">
            <Items>
                <f:TextArea ID="CONCLUSION" CssClass="conclusion"  runat="server" Height="60px" Width="500px" Label="填写审核意见"></f:TextArea>
            </Items>
        </f:Panel>
         <f:Panel ID="Btn_ToolBar" runat="server" BodyPadding="5px" Margin="5px" ShowBorder="false" ShowHeader="false" Title="Panel" Layout="Column">
            <Items>
                 <f:ToolbarText runat="server"  Text="选择审核操作:&nbsp;&nbsp"></f:ToolbarText>
            </Items>
        </f:Panel>

    </Items>
</f:Form>
<script src="../res/js/jquery.js"></script>
<script src="../res/js/raphael.js"></script>
<script src="../res/js/flowchart.js"></script>
<script>
    $(function () {

        $.ajax({
            type: "get",
            url: '/Verify/fcHandler.ashx',
            data: { "action":"flowchart","flow_id": "01" },
            dataType: "text",
            success: function (data) {
                var staustr = $('.Veri_Status').text();
                data = data.replace(staustr, staustr + '|approved');
                $('#canvas').html(data);

                $('#canvas').flowChart({
                    'flowstate':
                    {
                        'past': { 'fill': '#CCCCCC', 'font-size': 11 },
                        'current': { 'fill': 'yellow', 'font-size': 11 },
                        'future': { 'fill': '#FFFF99', 'font-size': 11 },
                        'request': { 'fill': 'blue', 'font-size': 11 },
                        'invalid': { 'fill': '#444444', 'font-size': 11 },
                        'approved': { 'fill': '#58C4A3', 'yes-text': '通过', 'no-text': '否决', 'font-size': 11 },
                        'rejected': { 'fill': '#FFFF99', 'yes-text': '通过', 'no-text': '否决', 'font-size': 11 }
                    }
                });
            },
            error: function (data) {
                alert("操作出现错误" + data);
            }
        });
        //setTimeout(function () {
        //    $('.btn_verify').on('click', function (e) {
        //        console.log(e);
        //    });
        //}
        //,100);
    });
    function VeriClick(oper_str,entity_key,workflow_id) {
        var conclusion = $('.conclusion').find('textarea').val();
        $.ajax({
            type: "post",
            url: '/Verify/fcHandler.ashx',
            data: { "action": "Verify", "oper_str": oper_str, "entity_key": entity_key, "workflow_id": workflow_id, "conclusion": conclusion },
            dataType: "text",
            success: function (data) {
                alert(data+"请手动关闭此标签");
                
            },
            error: function (data) {
                alert("操作出现错误:" + data);
            }
        });
    }
</script>