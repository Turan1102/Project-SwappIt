<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="SellShift.aspx.cs" Inherits="Backend.SellShift" %>

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
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-gift"></i>Sælg vagt
            </div>
            <ul class="nav nav-tabs">
                <li class="active">
                    <a href="#portlet_tab2_1" data-toggle="tab"><i class="fa fa-users"></i>Alle</a>
                </li>
                <li class="">
                    <a href="#portlet_tab2_2" data-toggle="tab"><i class="fa fa-user"></i>Enkelte</a>
                </li>
                <li class="">
                    <a href="#portlet_tab2_3" data-toggle="tab"><i class="fa fa-key"></i>Lukkevagter</a>
                </li>
            </ul>
        </div>
        <div class="portlet-body form">
            <div class="tab-content">
                <div class="tab-pane active" id="portlet_tab2_1">
                    <div class="form-horizontal form-bordered form-row-stripped">
                        <div class="form-body">
                            <div class="form-group">
                                <div class="alert alert-success">
                                    Alle the below dropdown menu. It will be opened as usual since there is enough space at the bottom.
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">Dato</label>
                                <div class="col-md-3">
                                    <div class="input-group input-medium date date-picker" data-date-format="yyyy-mm-dd" data-date-start-date="+0d">
                                        <input type="text" name="shiftDate0" id="shiftDate0" runat="server" class="form-control" readonly="">
                                        <span class="input-group-btn">
                                            <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                        </span>
                                    </div>
                                    <!-- /input-group -->
                                    <span class="help-block">Vælg dato </span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">Startid</label>
                                <div class="col-md-3">
                                    <div class="input-group">
                                        <input type="text" name="startTime0" id="startTime0" runat="server" class="form-control timepicker timepicker-24">
                                        <span class="input-group-btn">
                                            <button class="btn default" type="button"><i class="fa fa-clock-o"></i></button>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">Sluttid</label>
                                <div class="col-md-3">
                                    <div class="input-group">
                                        <input type="text" name="endTime0" id="endTime0" runat="server" class="form-control timepicker timepicker-24">
                                        <span class="input-group-btn">
                                            <button class="btn default" type="button"><i class="fa fa-clock-o"></i></button>
                                        </span>
                                    </div>
                                </div>
                            </div>

                            <div class="form-actions fluid">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-offset-3 col-md-9">
                                            <asp:LinkButton ID="LinkBtnSaveToAll" CssClass="btn green" runat="server" OnClick="SellShiftToAllButton_Click"><i class="fa fa-check"></i> Sælg til alle</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>

                </div>
                <div class="tab-pane" id="portlet_tab2_2">

                    <div class="form-horizontal form-bordered form-row-stripped">
                        <div class="form-body">
                            <div class="form-group">
                                <div class="alert alert-success">
                                    Enkelte the below dropdown menu. It will be opened as usual since there is enough space at the bottom.
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">Dato</label>
                                <div class="col-md-3">
                                    <div class="input-group input-medium date date-picker" data-date-format="yyyy-mm-dd" data-date-start-date="+0d">
                                        <input type="text" name="shiftDate1" id="shiftDate1" runat="server" class="form-control" readonly="">
                                        <span class="input-group-btn">
                                            <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                        </span>
                                    </div>
                                    <!-- /input-group -->
                                    <span class="help-block">Vælg dato </span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">Startid</label>
                                <div class="col-md-3">
                                    <div class="input-group">
                                        <input type="text" name="startTime1" id="startTime1" runat="server" class="form-control timepicker timepicker-24">
                                        <span class="input-group-btn">
                                            <button class="btn default" type="button"><i class="fa fa-clock-o"></i></button>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">Sluttid</label>
                                <div class="col-md-3">
                                    <div class="input-group">
                                        <input type="text" name="endTime1" id="endTime1" runat="server" class="form-control timepicker timepicker-24">
                                        <span class="input-group-btn">
                                            <button class="btn default" type="button"><i class="fa fa-clock-o"></i></button>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">Tilbyd vagt til</label>
                                <div class="col-md-9">
                                    <select data-container="body" class="bs-select form-control" name="individualDD" id="individualDD" runat="server" multiple="true"></select>
                                </div>
                            </div>

                            <div class="form-actions fluid">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-offset-3 col-md-9">
                                            <asp:LinkButton ID="LinkBtnSaveToIndividual" CssClass="btn green" runat="server" OnClick="SellShiftToIndividualButton_Click"><i class="fa fa-check"></i> Sælg til valgte</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>

                </div>
                <div class="tab-pane" id="portlet_tab2_3">
        <div class="form-horizontal form-bordered form-row-stripped">
                        <div class="form-body">
                            <div class="form-group">
                                <div class="alert alert-success">
                                    Lukkevagt the below dropdown menu. It will be opened as usual since there is enough space at the bottom.
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3">Dato</label>
                                <div class="col-md-3">
                                    <div class="input-group input-medium date date-picker" data-date-format="yyyy-mm-dd" data-date-start-date="+0d">
                                        <input type="text" name="shiftDate2" id="shiftDate2" runat="server" class="form-control" readonly="">
                                        <span class="input-group-btn">
                                            <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                        </span>
                                    </div>
                                    <!-- /input-group -->
                                    <span class="help-block">Vælg dato </span>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">Startid</label>
                                <div class="col-md-3">
                                    <div class="input-group">
                                        <input type="text" name="startTime2" id="startTime2" runat="server" class="form-control timepicker timepicker-24">
                                        <span class="input-group-btn">
                                            <button class="btn default" type="button"><i class="fa fa-clock-o"></i></button>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">Sluttid</label>
                                <div class="col-md-3">
                                    <div class="input-group">
                                        <input type="text" name="endTime2" id="endTime2" runat="server" class="form-control timepicker timepicker-24">
                                        <span class="input-group-btn">
                                            <button class="btn default" type="button"><i class="fa fa-clock-o"></i></button>
                                        </span>
                                    </div>
                                </div>
                            </div>

                            <div class="form-actions fluid">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-offset-3 col-md-9">
                                            <asp:LinkButton ID="LinkBtnSaveToCloseResponsible" CssClass="btn green" runat="server" OnClick="SellShiftToCloseResponsibleButton_Click"><i class="fa fa-check"></i> Sælg til alle lukkeansvarlige</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
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
</asp:Content>
