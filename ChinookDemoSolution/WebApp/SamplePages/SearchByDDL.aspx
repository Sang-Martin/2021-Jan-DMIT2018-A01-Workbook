﻿<%@ Page Title="Filter Search Demo" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="SearchByDDL.aspx.cs" 
    Inherits="WebApp.SamplePages.SearchByDDL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Search Albums by Artist</h1>
    <div class="row">
        <div class="offset-3">
            <asp:Label ID="Label1" runat="server" Text="Select an artist"></asp:Label>
            <asp:DropDownList ID="ArtistList" runat="server"></asp:DropDownList>
            <asp:Button ID="SearchAlbums" runat="server" Text="Search" OnClick="SearchAlbums_Click" />
        </div>
    </div>
    <br />
    <div class="row">
        <div class="offset-3 alert-danger">
            <asp:Label ID="MessegaLabel" runat="server" ></asp:Label>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="offset-3">
            <asp:GridView ID="ArtistAlbumList" runat="server" AutoGenerateColumns="False"
                CssClass="table table-striped" GridLines="Horizontal" AllowPaging="true" BorderStyle="None">

                <Columns>
                    <asp:TemplateField HeaderText="Album">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Title") %>'></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Released">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("ReleaseYear") %>'></asp:Label>

                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center">
                        </ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Artist">
                        <ItemTemplate>
                            <asp:DropDownList ID="ArtistNameList" runat="server" 
                                DataSourceID="ArtistAlbumListODS" 
                                DataTextField="DisplayField" 
                                DataValueField="ValueField" Width="250px"
                                SelectedValue='<%# Eval("ArtistId") %>'>

                            </asp:DropDownList>

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <EmptyDataTemplate>
                    No albums for selected artist
                </EmptyDataTemplate>

            </asp:GridView>
            <asp:ObjectDataSource ID="ArtistAlbumListODS" runat="server" 
                OldValuesParameterFormatString="original_{0}" 
                SelectMethod="Artists_DDLList" 
                TypeName="ChinookSystem.BLL.ArtistController">
            </asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>
