<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="MyShifts.aspx.cs" Inherits="Backend.MyShifts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- BEGIN PAGE LEVEL STYLES -->
    <link rel="stylesheet" type="text/css" href="plugins/bootstrap-select/bootstrap-select.min.css" />
    <link rel="stylesheet" type="text/css" href="plugins/select2/select2.css" />
    <link rel="stylesheet" type="text/css" href="plugins/jquery-multi-select/css/multi-select.css" />
    <link rel="stylesheet" type="text/css" href="plugins/clockface/css/clockface.css" />
    <link rel="stylesheet" type="text/css" href="plugins/bootstrap-datepicker/css/datepicker3.css" />
    <link rel="stylesheet" type="text/css" href="plugins/bootstrap-timepicker/css/bootstrap-timepicker.min.css" />
    <link rel="stylesheet" type="text/css" href="plugins/bootstrap-daterangepicker/daterangepicker-bs3.css" />
    <link rel="stylesheet" type="text/css" href="plugins/bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css" />
    <!-- END PAGE LEVEL STYLES -->
    <!-- BEGIN THEME STYLES -->
    <link href="css/components.css" id="style_components" rel="stylesheet" type="text/css" />
    <link href="css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <link id="style_color" href="css/themes/darkblue.css" rel="stylesheet" type="text/css" />
    <link href="css/custom.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderWithLinkButton" runat="server">
    <div class="portlet box blue">

                <% if (Request.QueryString["command"] == null)
           {%>

        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-gift"></i>Mine vagter
            </div>
            <ul class="nav nav-tabs">
                <li class="active">
                    <a href="#portlet_tab1" data-toggle="tab"><i class="fa fa-users"></i>Mine købte vagter</a>
                </li>
                <li class="">
                    <a href="#portlet_tab2" data-toggle="tab"><i class="fa fa-user"></i>Mine solgte vagter</a>
                </li>
                <li class="">
                    <a href="#portlet_tab3" data-toggle="tab"><i class="fa fa-user"></i>Mine vagter til salg</a>
                </li>
            </ul>
        </div>

        <div class="portlet-body form">
            <div class="tab-content">

                <div class="tab-pane active" id="portlet_tab1">
                    <div class="form-horizontal form-bordered form-row-stripped">
                        <div class="form-body">
                            <div class="form-group">
                                <div class="alert alert-success">
                                    Alle the below dropdown menu. It will be opened as usual since there is enough space at the bottom. 1
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="table-responsive">
                                    <table id="dataTable1" class="table table-striped table-bordered table-hover dataTable">
                                        <thead>
                                            <tr>
                                                <th><i class="fa fa-user"></i>Købt af</th>
                                                <th><i class="fa fa-calendar"></i>Vagtdato</th>
                                                <th><i class="fa fa-shopping-cart"></i>Købsdato</th>
                                                <th><i class="fa fa-user"></i>Handlinger</th>

                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Literal ID="tableOut1" runat="server"></asp:Literal>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="tab-pane" id="portlet_tab2">
                    <div class="form-horizontal form-bordered form-row-stripped">
                        <div class="form-body">
                            <div class="form-group">
                                <div class="alert alert-success">
                                    Alle the below dropdown menu. It will be opened as usual since there is enough space at the bottom. 2
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="table-responsive">
                                    <table id="dataTable2" class="table table-striped table-bordered table-hover dataTable">
                                        <thead>
                                            <tr>
                                                <th><i class="fa fa-user"></i>Solgt til</th>
                                                <th><i class="fa fa-clock-o"></i>Vagttid</th>
                                                <th><i class="fa fa-shopping-cart"></i>Salgsdato</th>
                                                <th><i class="fa fa-user"></i>Handlinger</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Literal ID="tableOut2" runat="server"></asp:Literal>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="tab-pane" id="portlet_tab3">
                    <div class="form-horizontal form-bordered form-row-stripped">
                        <div class="form-body">
                            <div class="form-group">
                                <div class="alert alert-success">
                                    Alle the below dropdown menu. It will be opened as usual since there is enough space at the bottom. 1
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="table-responsive">
                                    <table id="dataTable3" class="table table-striped table-bordered table-hover dataTable">
                                        <thead>
                                            <tr>
                                                <th><i class="fa fa-user"></i>Vagtens type</th>
                                                <th><i class="fa fa-calendar"></i>Dato for oprettelse</th>
                                                <th><i class="fa fa-calendar"></i>Vagtdato</th>
                                                <th><i class="fa fa-user"></i>Handlinger</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Literal ID="tableOut3" runat="server"></asp:Literal>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


        </div>

        <%  } else { %>

        <% if (Request.QueryString["command"] == "shiftDetails")
           { %>

                <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-gift"></i> Vagtdetaljer
            </div>
        </div>
        <div class="portlet-body form">
            <div class="form-horizontal form-bordered form-row-stripped">

                <div class="form-body">
                    <div class="form-group">
                        <div class="alert alert-success">
                            Detaljer om vagt
                        </div>
                    </div>




                    <table class="table table-bordered table-striped">
                        <tbody>

                            <%--                            <tr>
                                <td>Repeating Pulsate
                                </td>
                                <td>
                                    <div>
                                        Repeating Pulsate
                                    </div>
                                </td>
                            </tr>--%>

                            <asp:Literal ID="tableOut4" runat="server"></asp:Literal>


                        </tbody>
                    </table>



                    <div class="form-actions fluid">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-offset-3 col-md-9">
                                    <asp:LinkButton ID="LinkButton1" CssClass="btn red" runat="server" OnClick="Return_Click"><i class="fa fa-reply"></i> Tilbage</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>

        <% } %>


        <% } %>

    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="test" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="scripts" runat="server">
    <script src="plugins/jquery.min.js" type="text/javascript"></script>
    <script src="plugins/jquery-migrate.min.js" type="text/javascript"></script>
    <!-- IMPORTANT! Load jquery-ui.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->
    <script src="plugins/jquery-ui/jquery-ui.min.js" type="text/javascript"></script>
    <script src="plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
    <script src="plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <script src="plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="plugins/jquery.cokie.min.js" type="text/javascript"></script>
    <script src="plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
    <script src="plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>
    <!-- END CORE PLUGINS -->
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <script type="text/javascript" src="plugins/bootstrap-select/bootstrap-select.min.js"></script>
    <script type="text/javascript" src="plugins/select2/select2.min.js"></script>
    <script type="text/javascript" src="plugins/jquery-multi-select/js/jquery.multi-select.js"></script>
    <script type="text/javascript" src="plugins/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="plugins/bootstrap-timepicker/js/bootstrap-timepicker.min.js"></script>
    <script type="text/javascript" src="plugins/clockface/js/clockface.js"></script>
    <script type="text/javascript" src="plugins/bootstrap-daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="plugins/bootstrap-daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="plugins/bootstrap-colorpicker/js/bootstrap-colorpicker.js"></script>
    <script type="text/javascript" src="plugins/bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js"></script>
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="scripts/metronic.js" type="text/javascript"></script>
    <script src="scripts/layout.js" type="text/javascript"></script>
    <script src="scripts/quick-sidebar.js" type="text/javascript"></script>
    <script src="scripts/demo.js" type="text/javascript"></script>
    <script src="scripts/components-dropdowns.js"></script>
    <script src="scripts/components-pickers.js"></script>
    <script>
        jQuery(document).ready(function () {
            // initiate layout and plugins
            Metronic.init(); // init metronic core components
            Layout.init(); // init current layout
            QuickSidebar.init(); // init quick sidebar
            Demo.init(); // init demo features
            ComponentsDropdowns.init();
            ComponentsPickers.init();
        });
    </script>
    <!-- END GOOGLE RECAPTCHA -->
    <!-- END JAVASCRIPTS -->
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');
        ga('create', 'UA-37564768-1', 'keenthemes.com');
        ga('send', 'pageview');
    </script>
    <script>



    </script>
</asp:Content>
