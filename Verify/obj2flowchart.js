function obj2flowchart(node, link,curr_node) {
    var retstr = "";
    for (var in_node in node) {
        var k_str = "";
        if (in_node.NODE_CATRGORY == '00') {
            kstr =in_node.NODE_ID +'=>start: ' + in_node.NODE_NAME;
        }
        else if (in_node.NODE_CATRGORY != '01')
        {
            kstr =in_node.NODE_ID + '=>end: ' + in_node.NODE_NAME;
        }
        else {
            kstr = in_node.NODE_ID + '=>end: ' + in_node.NODE_NAME;
        }
    }


}