﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="StudentInfo.NewsList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新闻管理</title>
    <meta name="renderer" content="webkit" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="viewport" content="width=device-width,user-scalable=yes, minimum-scale=0.4, initial-scale=0.8,target-densitydpi=low-dpi" />
    <link rel="stylesheet" href="./css/font.css" />
    <link rel="stylesheet" href="./css/xadmin.css" />
    <script src="./lib/layui/layui.js" charset="utf-8"></script>
    <script type="text/javascript" src="./js/xadmin.js"></script>
</head>
<body>
    <div class="x-nav">
        <span class="layui-breadcrumb">
            <a href="#">首页</a>
            <a href="#">演示</a>
            <a>
                <cite>导航元素</cite></a>
        </span>
        <a class="layui-btn layui-btn-small" style="line-height: 1.6em; margin-top: 3px; float: right" onclick="location.reload()" title="刷新">
            <i class="layui-icon layui-icon-refresh" style="line-height: 30px"></i></a>
    </div>
    <div class="layui-fluid">
        <div class="layui-row layui-col-space15">
            <div class="layui-col-md12">
                <div class="layui-card">
                    <form class="layui-form layui-col-space5" runat="server">
                        <div class="layui-card-body ">
                            <asp:GridView ID="grdnews" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" CssClass="layui-table layui-form" PageSize="3" DataSourceID="Sqlnews" OnRowCommand="grdnews_RowCommand" OnRowCreated="grdnews_RowCreated">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="新闻标号" SortExpression="Id" InsertVisible="False" ReadOnly="True" />
                                    <asp:BoundField DataField="Title" HeaderText="新闻标题" SortExpression="Title" />
                                    <asp:BoundField DataField="Author" HeaderText="作者" SortExpression="Author" />
                                    <asp:BoundField DataField="ReleaseTime" HeaderText="发布时间" SortExpression="ReleaseTime" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="Sqlnews" runat="server" ConnectionString="<%$ ConnectionStrings:SMDB %>" SelectCommand="SELECT [Id], [Title], [Author], [ReleaseTime] FROM [news]"></asp:SqlDataSource>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
