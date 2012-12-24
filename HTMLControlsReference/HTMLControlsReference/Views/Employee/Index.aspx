<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<HTMLControlsReference.ViewModels.EmployeeVM>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<head>


</head>

<h2>List of Employees</h2>

<p>
    <%: Html.ActionLink("Create New", "Create") %>
</p>
<table>
    <tr>
       
        <th>
            FirstName
        </th>
        <th>
            LastName
        </th>
        <th>
            Address
        </th>
        <th>
            DateOfBirth
        </th>
        <th>
            HiredDate
        </th>
        <th>
            Zipcode
        </th>
        
        <th>
            Phone
        </th>
        <th>
            UserName
        </th>
        
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
 
            <%: Html.HiddenFor(modelItem => item.EmployeeID) %>
       
    <tr>
       
        <td>
            <%: Html.DisplayFor(modelItem => item.FirstName) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.LastName) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Address) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.DateOfBirth) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.HiredDate) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Zipcode) %>
        </td>
        
        <td>
            <%: Html.DisplayFor(modelItem => item.Phone) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.UserName) %>
        </td>
        
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { id=item.EmployeeID}) %> |
            <%: Html.ActionLink("Delete", "Delete", new { id = item.EmployeeID })%>
        </td>
    </tr>
<% } %>

</table>

</asp:Content>
