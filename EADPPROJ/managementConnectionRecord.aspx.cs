using System;

namespace EADPPROJ
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“managementStatistic”的 XML 注释
    public partial class managementStatistic : System.Web.UI.Page
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“managementStatistic”的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员“managementStatistic.Page_Load(object, EventArgs)”的 XML 注释
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员“managementStatistic.Page_Load(object, EventArgs)”的 XML 注释
        {
            if (IsPostBack)
            {
                if (search.Text != "")
                {
                    if (daterange.Text != "")
                    {
                        try
                        {
                            string[] ArrayDR = daterange.Text.ToString().Split('-');
                            DateTime startFrom = Convert.ToDateTime(ArrayDR[0]);
                            DateTime endBy = Convert.ToDateTime(ArrayDR[1]);
                            conRecord.SelectCommand = "SELECT * FROM [tb_ConnectionRecord] WHERE ([LeaveTime] BETWEEN '" + startFrom.ToString("yyyy/MM/dd") + "' AND '" + endBy.ToString("yyyy/MM/dd") + "') AND ([Id] LIKE '% " + search.Text + " %' OR [OS] LIKE '%" + search.Text + "%' OR [Browser] LIKE '%" + search.Text + "%' OR [Username] LIKE '%" + search.Text + "%' OR [IP] LIKE '%" + search.Text + "%') ORDER BY [LeaveTime] DESC, [Id] DESC";
                            conRecord.DataBind();
                            connectionRecord.DataBind();
                        }
                        catch (Exception)
                        {
                            NoData.Visible = true;
                            connectionRecord.Visible = false;
                        }

                    }
                    else
                    {
                        try
                        {
                            conRecord.SelectCommand = "SELECT * FROM [tb_ConnectionRecord] WHERE [Id] LIKE '% " + search.Text + " %' OR [OS] LIKE '%" + search.Text + "%' OR [Browser] LIKE '%" + search.Text + "%' OR [Username] LIKE '%" + search.Text + "%' OR [IP] LIKE '%" + search.Text + "%' ORDER BY [LeaveTime] DESC, [Id] DESC";
                            conRecord.DataBind();
                            connectionRecord.DataBind();
                        }
                        catch (Exception)
                        {
                            NoData.Visible = true;
                            connectionRecord.Visible = false;
                        }
                    }

                }
                else
                {
                    if (daterange.Text != "")
                    {
                        try
                        {
                            string[] ArrayDR = daterange.Text.ToString().Split('-');
                            DateTime startFrom = Convert.ToDateTime(ArrayDR[0]);
                            DateTime endBy = Convert.ToDateTime(ArrayDR[1]);
                            conRecord.SelectCommand = "SELECT * FROM [tb_ConnectionRecord] WHERE [LeaveTime] BETWEEN '" + startFrom.ToString("yyyy/MM/dd") + "' AND '" + endBy.ToString("yyyy/MM/dd") + "' ORDER BY [LeaveTime] DESC, [Id] DESC";
                            conRecord.DataBind();
                            connectionRecord.DataBind();
                        }
                        catch (Exception)
                        {
                            NoData.Visible = true;
                            connectionRecord.Visible = false;
                        }

                    }
                    else
                    {
                        try
                        {
                            conRecord.SelectCommand = "SELECT * FROM [tb_ConnectionRecord] ORDER BY [LeaveTime] DESC, [Id] DESC";
                            conRecord.DataBind();
                            connectionRecord.DataBind();
                        }
                        catch (Exception)
                        {
                            NoData.Visible = true;
                            connectionRecord.Visible = false;
                        }

                    }

                }
                if (connectionRecord.Rows.Count == 0)
                {
                    NoData.Visible = true;
                    connectionRecord.Visible = false;
                }
            }
        }

    }
}