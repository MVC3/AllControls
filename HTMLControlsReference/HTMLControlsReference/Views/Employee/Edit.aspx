<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HTMLControlsReference.ViewModels.EmployeeVM>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Edit</h2>

<script src="<%: Url.Content("~/Scripts/jquery-1.5.1.min.js") %>" type="text/javascript"></script>
<script type="text/javascript">

    $(document).ready(function () {
        $("#DtofBirth").datepicker();
        $("#DtofHire").datepicker();
        $("#state").change(function () {
            var stateID = $(this).val();
            //alert(stateID);
            var url = '<%: Url.Action("Getstate","Employee")%>';
            $.getJSON(url + "?stateID=" + stateID, function (data) {
                //return data;
                //  alert(data);
                $("#cityDDL").empty();
                var selectList = $("#cityDDL");

                $.each(data, function (index, optionData) {

                    var option = new Option(optionData.Text, optionData.Value);
                    //    alert(optionData.Text);
                    // selectList.add(option, null);
                    selectList.append(option);
                    //  alert(option);

                    //                    $("#cityDDL").click(function () {
                    //                        alert("some");
                    //                        $(this).add(optionData.Text);
                    //                    });
                });


            });

            

            // $("#cityDDL").html(data.join(""));

            // alert(data);
        });
    });

    $(document).ready(function () {
        $("#Cpwd").change(function () {
            var confirmPwd = $(this).val();
            //alert(confirmPwd);
            var pwd = $("#pwd").val();
            //alert(pwd);
            if (confirmPwd != pwd) {
                alert("Password and confirmation password should be same");
                $("#Cpwd").val("");
            }
        });
    });
</script>
<head>
<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>
<link href="../../Content/themes/base/jquery.ui.core.css" rel="stylesheet" type="text/css" />
<link href="../../Content/themes/base/jquery.ui.theme.css" rel="stylesheet" type="text/css" />
<link href="../../Content/themes/base/jquery.ui.datepicker.css" rel="stylesheet" type="text/css" />
<script src="<%: Url.Content("~/Scripts/jquery.ui.core.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.ui.datepicker.min.js") %>" type="text/javascript"></script>
</head>

<table>
<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Employee Details</legend>
        <td>
        <div class="editor-field">
            <%: Html.HiddenFor(model => model.EmployeeID) %>
            <%: Html.ValidationMessageFor(model => model.EmployeeID) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.FirstName) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.FirstName) %>
            <%: Html.ValidationMessageFor(model => model.FirstName) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.LastName) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.LastName) %>
            <%: Html.ValidationMessageFor(model => model.LastName) %>
        </div>

       
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Gender) %>
        </div>
        <div class="editor-field">
            <%: Html.RadioButtonFor(model => model.Gender,"Male",true) %>Male<%:Html.RadioButtonFor(model =>model.Gender,"Female",false) %>Female
            <%: Html.ValidationMessageFor(model => model.SelectedDeptID) %>
        </div>
      

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Address) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Address) %>
            <%: Html.ValidationMessageFor(model => model.Address) %>
        </div>
        
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Addressline) %>
            <%: Html.ValidationMessageFor(model => model.Addressline) %>
        </div>
                          
        <div class="editor-label">
            <%: Html.LabelFor(model => model.AllState) %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownListFor(model => model.SelectedStateID, Model.AllState, new { id = "state"})%>
            <%: Html.ValidationMessageFor(model => model.SelectedStateID) %>
        </div>
                
         <div class="editor-label">
            <%: Html.LabelFor(model => model.AllCity) %>
        </div>
        
        <div class="editor-field">
            <%:Html.DropDownListFor(model => Model.SelectedCityID, Model.AllCity, new { id = "cityDDL" })%>
            <%: Html.ValidationMessageFor(model => model.SelectedCityID) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Zipcode) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Zipcode) %>
            <%: Html.ValidationMessageFor(model => model.Zipcode) %>
        </div>
        </td>
        <td>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.DateOfBirth) %>
        </div>
        <div class= "editor-fieldDOB"  id = "DOB">
            <%: Html.TextBoxFor(model => model.DateOfBirth, new { id="DtofBirth"})%>
            <%: Html.ValidationMessageFor(model => model.DateOfBirth) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.HiredDate) %>
        </div>
        <div class="editor-field"id="DOH">
            <%: Html.TextBoxFor(model => model.HiredDate, new { id = "DtofHire" })%>
            <%: Html.ValidationMessageFor(model => model.HiredDate) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Email) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Email) %>
            <%: Html.ValidationMessageFor(model => model.Email) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Phone) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Phone) %>
            <%: Html.ValidationMessageFor(model => model.Phone) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.UserName) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.UserName) %>
            <%: Html.ValidationMessageFor(model => model.UserName) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Password) %>
        </div>
        <div class="editor-field">
            <%: Html.PasswordFor(model => model.Password, new { value = Model.Password, id ="pwd" })%>
            <%: Html.ValidationMessageFor(model => model.Password) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.ConfirmPassword) %>
        </div>
        <div class="editor-field">
            <%: Html.PasswordFor(model => model.ConfirmPassword, new {value = Model.ConfirmPassword, id="Cpwd"}) %>
            <%: Html.ValidationMessageFor(model => model.ConfirmPassword)%>

        </div>

         </td>

        <td>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.AllJobs) %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownListFor(model => model.SelectedJobID, Model.AllJobs) %>
            <%: Html.ValidationMessageFor(model => model.SelectedJobID) %>
        </div>
       
        <div class="editor-label">
            <%: Html.LabelFor(model => model.AllDepartment) %>
        </div>
        <div class="editor-field">
            <%: Html.DropDownListFor(model => model.SelectedDeptID, Model.AllDepartment) %>
            <%: Html.ValidationMessageFor(model => model.SelectedDeptID) %>
        </div>

        
        <div class="editor-label">
            <%: Html.LabelFor(model => model.AllWorkingDays) %>
        </div>
        <div class="editor-field">
            <%: Html.ListBoxFor(model => model.SelectedWorkingDayIDs, Model.AllWorkingDays) %>
            <%: Html.ValidationMessageFor(model => model.SelectedWorkingDayIDs)%>
        </div>
        
        
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Shifts) %>
        </div>
        <%for(int i=0; i<Model.Shifts.Count();i++)
          { %>
        <div class="editor-field">
            <%: Html.HiddenFor(model => model.Shifts[i].ID) %>
            <%: Html.HiddenFor(model => model.Shifts[i].Name ) %>
            <%: Html.CheckBoxFor(model => model.Shifts[i].Checked,new {id = Model.Shifts[i].ID})%> <%:Model.Shifts[i].Name %>
            <%: Html.ValidationMessageFor(model => model.Shifts) %>
        </div>
        <%} %>
        </td>
</table>
        

        
            <input type="submit" value="Save" />
            <input type="reset" value ="Reset" />   
        
      
    </fieldset>
     
<% } %>


<div>
    <%: Html.ActionLink("Back to List", "Index") %>
</div>

</asp:Content>
