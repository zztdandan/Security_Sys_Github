using AppBox.CommonHelper;
using AppBox.Model;
using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;



namespace AppBox.HAZA.selectWindow
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTreeData();
            }

        }

        /// <summary>
        /// 树形加载，
        /// </summary>
        private void LoadTreeData()
        {
            var db = new SAFEDB();
            var res1 = (from x in db.ORG_JOBUNITRELATION_T
                        group x by new { x.C_CORPCODE } into gr1
                        select gr1).ToList();
            foreach (var gr in res1)
            {
                var node = new FineUI.TreeNode();
                node.Text = gr.First().C_CORPCODE+"_"+ gr.First().C_CORPNAME;
                node.Leaf = false;
                node.NodeID = gr.First().C_CORPCODE;
                TreeSelectDept.Nodes.Add(node);
            }

        }






        /// <summary>
        /// 延时加载函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void TreeSelectDept_NodeLazyLoad(object sender, FineUI.TreeNodeEventArgs e)
        {
            DynamicAppendNode(e.Node);
            e.Node.Expanded = true;
        }
        private void DynamicAppendNode(FineUI.TreeNode parentNode)
        {
            FineUI.TreeNode node = null;
            var parentNodeid = parentNode.NodeID;
            var db = new SAFEDB();
            var res1 = (from x in db.ORG_JOBUNITRELATION_T
                        where x.C_CORPCODE.CompareTo(parentNodeid) == 0
                        select x);
            //如果res1找到了，说明这个id是个一级父类，需要加载二级父类的东西。二级类不是叶子
            if (res1.Count() > 0)
            {
                //选出的项首先不能与前者相等
                var res2 = (from x in res1
                            where (x.C_KSCODE.CompareTo(x.C_CORPCODE) != 0)
                            group x by new { x.C_KSCODE } into gr1

                            select gr1);
                foreach (var gr in res2)
                {
                    node = new FineUI.TreeNode();
                    node.Text = gr.First().C_KSCODE + "_" + gr.First().C_KSNAME;
                    node.Leaf = false;
                    node.EnableClickEvent = true;
                    node.NodeID = gr.First().C_KSCODE;
                    parentNode.Nodes.Add(node);

                }
            }
            else
            {
                //如果res11找到了，说明这个id是个二级父类，需要加载三级类的东西。三级类属于叶子
                var res11 = (from x in db.ORG_JOBUNITRELATION_T
                             where x.C_KSCODE.CompareTo(parentNodeid) == 0
                             select x).ToList();
                if (res11.Count() > 0)
                {
                    //选出的项首先不能与前者相等
                    var res2 = (from x in res11
                                where (x.C_UNITCODE.CompareTo(x.C_KSCODE) != 0)
                                group x by new { x.C_UNITCODE } into gr1

                                select gr1);
                    foreach (var gr in res2)
                    {
                        node = new FineUI.TreeNode();
                        node.Text = gr.First().C_UNITCODE + "_" + gr.First().C_UNITNAME;
                        node.Leaf = true;
                        node.EnableClickEvent = true;
                        node.NodeID = gr.First().C_UNITCODE;
                        parentNode.Nodes.Add(node);

                    }
                }
            }
        }

        protected void btnDeptSelect_Click(object sender, EventArgs e)
        {
                var selectedid = this.TreeSelectDept.SelectedNodeID;
            
            var name = this.TreeSelectDept.SelectedNode.Text;
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference(name));
        }

        private void BuildSpecialDeptTree(List<IGrouping<string, ORG_JOBUNITRELATION_T>> res)
        {
            var res3 = res.Select(g => g.FirstOrDefault());
            //清空树


            //按前两级目录分组
            var res1 = res3.GroupBy(x => x.C_CORPCODE).Select(g => g.FirstOrDefault());
            var res2 = res3.GroupBy(x => x.C_SECCODE).Select(g => g.FirstOrDefault());
            foreach (var re1 in res1)
            {
                var newre1_node = new FineUI.TreeNode();
                newre1_node.Text = re1.C_CORPNAME;
                newre1_node.Leaf = false;
                newre1_node.NodeID = re1.C_CORPCODE;
                var secnodelist = res2.Where(x => (x.C_CORPCODE.CompareTo(re1.C_CORPCODE) == 0 && (x.C_CORPCODE.CompareTo(x.C_SECCODE) != 0)));
                foreach (var re2 in secnodelist)
                {
                    var newre2_node = new FineUI.TreeNode();
                    newre2_node.Text = re2.C_SECNAME;
                    newre2_node.Leaf = false;
                    newre2_node.NodeID = re2.C_SECCODE;
                    var unitnodelist = res3.Where(x => (x.C_SECCODE.CompareTo(re2.C_SECCODE) == 0 && (x.C_UNITCODE.CompareTo(x.C_SECCODE) != 0)));
                    foreach (var re3 in unitnodelist)
                    {
                        var newre3_node = new FineUI.TreeNode();
                        newre3_node.Text = re3.C_UNITNAME;
                        newre3_node.NodeID = re3.C_UNITCODE;
                        newre3_node.Leaf = true;
                        newre2_node.Nodes.Add(newre3_node);
                    }
                    newre1_node.Nodes.Add(newre2_node);
                }
                 this.TreeSelectDept.Nodes.Add(newre1_node);
               
            }
        }

      
        protected void SearchButton_Click(object sender, System.EventArgs e)
        {
            if (this.SearchText1.Text == "")
            {
                return;
            }
            var db = new SAFEDB();
            var res = (from x in db.ORG_JOBUNITRELATION_T
                       where x.C_UNITNAME.Contains(this.SearchText1.Text)
                       select x).GroupBy(x => x.C_UNITCODE);
            if (res.Count() > 200)
            {
                Notify.ShowMessage("搜索结果过多，请缩小搜索范围");
                return;
            }
            this.TreeSelectDept.Nodes.Clear();
           
  
            this.BuildSpecialDeptTree(res.ToList());

           
        }

        protected void TreeSelectDept_NodeCommand(object sender, TreeCommandEventArgs e)
        {

        }
    }
}