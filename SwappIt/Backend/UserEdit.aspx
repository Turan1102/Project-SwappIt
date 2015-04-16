<%@ Page Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="Backend.UserEdit" %>

<asp:Content ID="Content99" ContentPlaceHolderID="head" runat="server">

    <!-- BEGIN PAGE LEVEL STYLES -->
    <link rel="stylesheet" type="text/css" href="plugins/bootstrap-select/bootstrap-select.min.css" />
    <link rel="stylesheet" type="text/css" href="plugins/select2/select2.css" />
    <link rel="stylesheet" type="text/css" href="plugins/jquery-multi-select/css/multi-select.css" />
    <!-- BEGIN THEME STYLES -->
    <link href="css/components.css" id="style_components" rel="stylesheet" type="text/css" />
    <link href="css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <link id="style_color" href="css/themes/darkblue.css" rel="stylesheet" type="text/css" />
    <link href="css/custom.css" rel="stylesheet" type="text/css" />

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="pagetitle" runat="server">
    <h3 class="page-title"></h3>
    <asp:Literal runat="server" ID="TestText" Text=""></asp:Literal>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderWithLinkButton" runat="Server">

    <div class="row">
        <div class="col-md-12">
            <div class="portlet box blue ">
                <div class="portlet-title">
                    <div class="caption"></div>
                </div>
                <div class="portlet-body form">
                    <div class="form-horizontal form-bordered form-row-stripped">
                        <!-- BEGIN FORM-->
                        <div class="form-body">

                            <asp:Panel ID="ErrorPanel" Visible="false" runat="server">
                                <div class="alert alert-danger display-hide" style="display: block;">
                                    <button class="close" data-close="alert"></button>
                                    <span>
                                        <asp:Literal ID="ErrorText" runat="server"></asp:Literal></span>
                                </div>
                            </asp:Panel>

                            <div class="form-group">
                                <label class="control-label col-md-3">Personale nummer</label>
                                <div class="col-md-9">
                                    <input type="text" name="StaffNumber" id="StaffNumber" class="form-control" placeholder="" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">CPR nummer</label>
                                <div class="col-md-9">
                                    <input type="text" name="CPR" id="CPR" class="form-control" placeholder="" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">Navn</label>
                                <div class="col-md-9">
                                    <input type="text" name="Name" id="Name" class="form-control" placeholder="" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">Email</label>
                                <div class="col-md-9">
                                    <input type="text" name="Email" id="Email" class="form-control" placeholder="" runat="server" />
                                    <p class="help-block"></p>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">Afdeling</label>
                                <div class="col-md-9">
                                    <select data-container="body" class="bs-select form-control" name="Department" id="Department" runat="server" multiple="true"></select>
                                </div>
                            </div>
                            <!--Picture-->
                            <div class="form-group">
                                <label class="control-label col-md-3">Køn</label>
                                <div class="col-md-9">
                                    <select data-container="body" class="bs-select form-control" name="Gender" id="Gender" runat="server" multiple="false"></select>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">Leder</label>
                                <div class="col-md-9">
                                    <select data-container="body" class="bs-select form-control" name="Leader" id="Leader" runat="server" multiple="false"></select>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">Lukkeansvarlig</label>
                                <div class="col-md-9">
                                    <select data-container="body" class="bs-select form-control" name="CloseResponsible" id="CloseResponsible" runat="server" multiple="false"></select>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">Medarbejdertype</label>
                                <div class="col-md-9">
                                    <select data-container="body" class="bs-select form-control" name="EmployeeType" id="EmployeeType" runat="server" multiple="false"></select>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3">Roller</label>
                                <div class="col-md-9">
                                    <select data-container="body" class="bs-select form-control" name="Role" id="Role" runat="server" multiple="true"></select>
                                </div>
                            </div>

                            <div class="form-actions fluid">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-offset-3 col-md-9">
                                            <asp:LinkButton ID="LinkBtnSave" CssClass="btn green" runat="server" OnClick="SaveUserButton_Click"><i class="fa fa-check"></i> Gem</asp:LinkButton>
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

<asp:Content ID="scripts" ContentPlaceHolderID="scripts" runat="server">

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
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="scripts/metronic.js" type="text/javascript"></script>
    <script src="scripts/layout.js" type="text/javascript"></script>
    <script src="scripts/quick-sidebar.js" type="text/javascript"></script>
    <script src="scripts/demo.js" type="text/javascript"></script>
    <script src="scripts/components-dropdowns.js"></script>

    <script>
        jQuery(document).ready(function () {
            // initiate layout and plugins
            Metronic.init(); // init metronic core components
            Layout.init(); // init current layout
            QuickSidebar.init(); // init quick sidebar
            Demo.init(); // init demo features
            ComponentsDropdowns.init();
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
