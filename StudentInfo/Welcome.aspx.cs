﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts; 
using System.Web.UI;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using Model;
using SQLDAL;
namespace StudentInfo
{
    public partial class Welcome : System.Web.UI.Page
    {
        public static string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Git\\DATA\\StudentInfo.mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Session["uName"].ToString());
                GetData(id);//获取数据
            }
        }
        public void GetData(int id)
        {
            DALstudent_info dal = new DALstudent_info();
            student_infoEntity student = dal.Getstudent_info(id);
            ViewState["student"] = student;
            select.Value= student.StudentId;
            //将取回的数据在页面进行展示，可以修改的数据使用TextBox来展示，并提供修改。
            //通过按钮触发，实现将数据编辑保存的功能
        }
        //创建一张二维数据表
        /// <summary>
        /// 创建一张二维数据表
        /// </summary>
        /// <returns>Datatable类型的数据表</returns>
        DataTable CreatData()
        {
            DataTable dt = new DataTable();
            //实例化SqlConnection对象
            SqlConnection sqlCon = new SqlConnection();
            //实例化SqlConnection对象连接数据库的字符串
            sqlCon.ConnectionString = conn;
            //定义SQL语句
            //sql公用部分
            string sqlQ = "select StudentId,CourseId,CourseScore from student_course where StudentId=" + select.Value;
            dt = GetDataTable(sqlQ);

            return dt;
        }

        //数据库查询返回datatable
        public static DataTable GetDataTable(string Sqlstr)
        {
            DataTable dt;
            SqlDataAdapter sda;
            SqlConnection sqlCon = new SqlConnection();
            //实例化SqlConnection对象连接数据库的字符串
            sqlCon.ConnectionString = conn;
            sqlCon.Open();
            sda = new SqlDataAdapter(Sqlstr, conn);
            dt = new DataTable();
            sda.Fill(dt);
            sqlCon.Close();
            return dt;
        }

        protected void btnselect_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(conn);
            // 折线图
            DataTable dt = CreatData();

            // #region 折线图
            Chart1.DataSource = dt;//绑定数据
            Chart1.Series["Series1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;//设置图表类型
            Chart1.Series[0].XValueMember = "CourseId";//X轴数据成员列
            Chart1.Series[0].YValueMembers = "CourseScore";//Y轴数据成员列
            Chart1.ChartAreas["ChartArea1"].AxisX.Title = "科目";//X轴标题
            Chart1.ChartAreas["ChartArea1"].AxisX.TitleAlignment = StringAlignment.Far;//设置Y轴标题的名称所在位置位远
            Chart1.ChartAreas["ChartArea1"].AxisY.Title = "成绩";//Y轴标题
            Chart1.ChartAreas["ChartArea1"].AxisY.TitleAlignment = StringAlignment.Far;//设置Y轴标题的名称所在位置位远
            Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;//X轴数据的间距
            Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;//不显示竖着的分割线
            Chart1.Series[0].IsValueShownAsLabel = true;//显示坐标值
                                                        // #endregion
        }
    }
}