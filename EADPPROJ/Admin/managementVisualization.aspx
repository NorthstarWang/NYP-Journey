<%@ Page Title="" Language="C#" MasterPageFile="./MasterPageAdminManagement.Master" AutoEventWireup="true" CodeBehind="managementVisualization.aspx.cs" Inherits="EADPPROJ.managementVisualization" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <script src="../Scripts/Chart.js"></script>
    <div class="kt-content  kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor" id="kt_content">

        <div class="row">
            <div class="col-xl-6">
                <div class="kt-portlet">
                    <div class="kt-portlet__head">
                        <div class="kt-portlet__head-label">
                            <h3 class="kt-portlet__head-title">Visitors On Recent 7 Days</h3>
                        </div>
                    </div>
                    <div class="kt-portlet__body">
                        <canvas id="View" style="height: 300px;"></canvas>
                        <asp:HiddenField ID="RecentDateTime" runat="server" />
                        <asp:HiddenField ID="Admin" runat="server" />
                        <asp:HiddenField ID="days" runat="server" />
                        <asp:HiddenField ID="Student" runat="server" />
                        <asp:HiddenField ID="Teacher" runat="server" />
                        <asp:HiddenField ID="Guest" runat="server" />
                    </div>
                </div>
            </div>
            <div class="col-xl-6">
                <div class="kt-portlet">
                    <div class="kt-portlet__head">
                        <div class="kt-portlet__head-label">
                            <h3 class="kt-portlet__head-title">OS Total Percentage</h3>
                        </div>
                    </div>
                    <div class="kt-portlet__body">
                        <canvas id="OS" style="height: 300px;"></canvas>
                        <asp:HiddenField ID="WinNT" runat="server" />
                        <asp:HiddenField ID="Linux" runat="server" />
                        <asp:HiddenField ID="MacOS" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        var ctxOS = document.getElementById("OS").getContext('2d');
        var myChart = new Chart(ctxOS, {
            type: 'pie',
            data: {
                labels: ['WinNT', 'Linux', 'Mac OS'],
                datasets: [{
                    label: 'Percentage of User Device Operating System',
                    data: [<%=Convert.ToInt32(WinNT.Value) %>, <%=Convert.ToInt32(Linux.Value) %>,<%=Convert.ToInt32(MacOS.Value) %>],
                    backgroundColor: [
                        'rgba(255, 99, 132, 0.5)',
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(255, 206, 86, 0.2)',
                    ],
                    borderColor: [
                        'rgba(255,99,132,1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                    ],
                    borderWidth: 1
                }]
            },
            options: {
                cutoutPercentage: 40,
                responsive: false,

            }
        });
    </script>
    <script>
        var dayDist = "<%=days.Value %>".split(",");
        var viewStud = "<%=Student.Value %>".split(",");
        var viewTeacher = "<%=Teacher.Value %>".split(",");
        var viewGuest = "<%=Guest.Value %>".split(",");
        var viewAdmin = "<%=Admin.Value %>".split(",");

        var dataFirst = {
            label: "Student",
            data: [parseInt(viewStud[6]), parseInt(viewStud[5]), parseInt(viewStud[4]), parseInt(viewStud[3]), parseInt(viewStud[2]), parseInt(viewStud[1]), parseInt(viewStud[0])],
            borderColor: '#2196f3',
            backgroundColor: '#2196f3',
            fill: false
        };

        var dataSecond = {
            label: "Teacher",
            data: [parseInt(viewTeacher[6]), parseInt(viewTeacher[5]), parseInt(viewTeacher[4]), parseInt(viewTeacher[3]), parseInt(viewTeacher[2]), parseInt(viewTeacher[1]), parseInt(viewTeacher[0])],
            backgroundColor: 'rgba(255,99,132,1)',
            borderColor: 'rgba(255,99,132,1)',
            fill: false
        };

        var dataThird = {
            label: "Admin",
            data: [parseInt(viewAdmin[6]), parseInt(viewAdmin[5]), parseInt(viewAdmin[4]), parseInt(viewAdmin[3]), parseInt(viewAdmin[2]), parseInt(viewAdmin[1]), parseInt(viewAdmin[0])],
            backgroundColor: '#FFC870',
            borderColor: '#FFC870',
            fill: false
        };

        var dataFourth = {
            label: "Guest",
            data: [parseInt(viewGuest[6]), parseInt(viewGuest[5]), parseInt(viewGuest[4]), parseInt(viewGuest[3]), parseInt(viewGuest[2]), parseInt(viewGuest[1]), parseInt(viewGuest[0])],
            backgroundColor: '#616774',
            borderColor: '#616774',
            fill: false
        };
        var dayData = {
            labels: [dayDist[6], dayDist[5], dayDist[4], dayDist[3], dayDist[2], dayDist[1], dayDist[0]],
            datasets: [dataFirst, dataSecond, dataThird, dataFourth]
        };

        var chartOptions = {
            scaleShowGridLines: true,
            scaleGridLineWidth: 1,
            scaleShowHorizontalLines: true,
            scaleShowVerticalLines: true,
            bezierCurve: true,
            bezierCurveTension: 0.4,
            pointDot: true,
            pointDotRadius: 4,
            pointDotStrokeWidth: 1,
            pointHitDetectionRadius: 20,
            datasetStroke: true,
            datasetStrokeWidth: 2,

            legend: {
                display: true,
                position: 'top'
            }
        };

        var lineChart = new Chart(View, {
            type: 'line',
            data: dayData,
            options: chartOptions
        });
    </script>
</asp:Content>
