@Code
    ViewBag.Title = "Home Page"
End Code

<style type="text/css">
    .highlight
    {
        background-color: #99FF66;
    }
</style>

<script type="text/javascript">
    var currentNode;
    function OnClick(s, e) {
        var nodeName = TextBox.GetValue();
        var node = TreeView.GetNodeByName(nodeName);

        HighLightNode(node);
        ExpandNode(node);
    }
    function HighLightNode(node) {
        if (currentNode)
            $(currentNode.GetHtmlElement()).removeClass('highlight');
        currentNode = node;
        $(currentNode.GetHtmlElement()).addClass('highlight');
    }
    function ExpandNode(node) {
        TreeView.CollapseAll();
        setTimeout(function () {
            ExpandParents(node);
        }, 200);
        
    }
    function ExpandParents(node) {
        if (node.parent && node.parent.GetExpanded() == false) {
            node.parent.SetExpanded(true);
            ExpandParents(node.parent);
        }
    }
</script>

@Html.DevExpress().TextBox(
    Sub(settings)
        settings.Name = "TextBox"
    End Sub).GetHtml()
@Html.DevExpress().Button(
    Sub(settings)
        settings.Name = "Button"
        settings.ClientSideEvents.Click = "OnClick"
    End Sub).GetHtml()


@Html.DevExpress().TreeView(
    Sub(settings)
        settings.Name = "TreeView"
        settings.AllowSelectNode = False
        settings.EnableClientSideAPI = True

        settings.Nodes.Add(
                Sub(node)
                    node.Text = "Node 0"
                    node.Name = "Node 0"
                    node.Nodes.Add(
                            Sub(subNode)
                                subNode.Text = "SubNode 0"
                                subNode.Name = "SubNode 0"
                                subNode.Nodes.Add("SubSubNode 0", "SubSubNode 0")
                                subNode.Nodes.Add("SubSubNode 1", "SubSubNode 1")
                            End Sub
                )
                    node.Nodes.Add("SubNode 1", "SubNode 1")
                End Sub)
        settings.Nodes.Add("Node 1", "Node 1")
    End Sub).GetHtml()