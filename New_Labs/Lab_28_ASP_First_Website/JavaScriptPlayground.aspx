<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JavaScriptPlayground.aspx.cs" Inherits="Lab_28_ASP_First_Website.JavaScriptPlayground" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        var x = 0;
        function runSomeTestData() {
            alert('The value of x is ' + x);
            var genius = confirm('Are you a computer genius?');
            var name = prompt('DeyTkErJerbs');
            if (genius) {
                alert('Thanks, ' + name + ', i will come to you for advice now!')
            }
            else {
                alert('ite fam, no problem');
            }
            console.log(genius);
            console.log(name);
        }
    </script>
    <button onclick="runSomeTestData()">Run Some Test Data</button>
    <div id="test-data"></div>

</asp:Content>
