﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HTMLControlsReference.ViewModels.EmployeeVM>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>EmployeeVM</legend>

    <div class="display-label">EmployeeID</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.EmployeeID) %>
    </div>

    <div class="display-label">FirstName</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.FirstName) %>
    </div>

    <div class="display-label">LastName</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.LastName) %>
    </div>

    
    <div class="display-label">DateOfBirth</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.DateOfBirth) %>
    </div>

    <div class="display-label">HiredDate</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.HiredDate) %>
    </div>

    <div class="display-label">Gender</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Gender) %>
    </div>

</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Delete" /> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
<% } %>

</asp:Content>
