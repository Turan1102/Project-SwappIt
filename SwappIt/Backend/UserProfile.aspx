<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="Backend.UserProfile" %>

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
    <link href="plugins/bootstrap-fileinput/bootstrap-fileinput.css" rel="stylesheet" type="text/css" />
    <link href="pages/css/profile.css" rel="stylesheet" type="text/css" />
    <link href="pages/css/tasks.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" type="text/css" href="plugins/bootstrap-fileinput/bootstrap-fileinput.css"/>
<link rel="stylesheet" type="text/css" href="plugins/bootstrap-switch/css/bootstrap-switch.min.css"/>
<link rel="stylesheet" type="text/css" href="plugins/jquery-tags-input/jquery.tagsinput.css"/>
<link rel="stylesheet" type="text/css" href="plugins/bootstrap-markdown/css/bootstrap-markdown.min.css">
<link rel="stylesheet" type="text/css" href="plugins/typeahead/typeahead.css">

    <!-- END PAGE LEVEL STYLES -->
    <!-- BEGIN THEME STYLES -->
    <link href="css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <link href="css/custom.css" rel="stylesheet" type="text/css" />
    <link href="css/components.css" id="style_components" rel="stylesheet" type="text/css" />
    <link href="css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <link id="style_color" href="css/themes/darkblue.css" rel="stylesheet" type="text/css" />
    <link href="css/custom.css" rel="stylesheet" type="text/css" />

<link href="css/plugins.css" rel="stylesheet" type="text/css"/>
<link href="css/layout.css" rel="stylesheet" type="text/css"/>
<link href="css/custom.css" rel="stylesheet" type="text/css"/>


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
                <i class="fa fa-gift"></i>Min Profil
            </div>
            <ul class="nav nav-tabs">
                <li class="active">
                    <a href="#portlet_tab1" data-toggle="tab"><i class="fa fa-users"></i>Personlige informationer</a>
                </li>
                <li class="">
                    <a href="#portlet_tab2" data-toggle="tab"><i class="fa fa-user"></i>Ændre adgangskode</a>
                </li>
            </ul>
        </div>
        <div class="portlet-body form">
            <div class="tab-content">

                <div class="tab-pane active" id="portlet_tab1">

                    <asp:Panel ID="Panel1" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>

                                <div class="form-horizontal form-bordered form-row-stripped">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <div class="alert alert-success">
                                                Alle the below dropdown menu. It will be opened as usual since there is enough space at the bottom.
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label col-md-3">Mobilnummer</label>
                                            <div class="col-md-4">
                                                <input type="text" name="phoneNumber" id="phoneNumber" placeholder="ex 12345678" class="form-control" runat="server" />
                                                <asp:CustomValidator ID="validatePhoneNumber" runat="server" ErrorMessage="Mobilnummer skal udfyldes og må kun bestå af numre" ValidateEmptyText="True" ControlToValidate="phoneNumber" OnServerValidate="validatePhoneNumber_ServerValidate" ForeColor="Red"></asp:CustomValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Email</label>
                                            <div class="col-md-9">
                                                <input type="text" name="email" id="email" class="form-control" placeholder="ex MinMail@mail.com" runat="server" />
                                                <asp:CustomValidator ID="validateEmail" runat="server" ErrorMessage="Email skal udfyldes i korrekt vis" ValidateEmptyText="True" ControlToValidate="email" OnServerValidate="validateEmail_ServerValidate" ForeColor="Red"></asp:CustomValidator>

                                            </div>
                                        </div>
                                        <div class="form-actions fluid">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-md-offset-3 col-md-9">
                                                        <asp:LinkButton ID="btnSavePersonal" CssClass="btn green" runat="server" OnClick="btnSavePersonal_Click"><i class="fa fa-check"></i> Gem personlige ændringer</asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                    </div>
                                </div>


                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>


                </div>

                <div class="tab-pane" id="portlet_tab2">

                    <asp:Panel ID="Panel" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>

                                <div class="form-horizontal form-bordered form-row-stripped">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <div class="alert alert-success">
                                                Alle the below dropdown menu. It will be opened as usual since there is enough space at the bottom.
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="control-label col-md-3">Gammelt Adgangskode</label>
                                            <div class="col-md-9">
                                                <input type="password" name="oldPsw" id="oldPsw" class="form-control" placeholder="" runat="server" />
                                                <asp:CustomValidator ID="validateOldPsw" runat="server" ErrorMessage="Forkert adgangskode. Der skelnes mellem store og små bogstaver" ValidateEmptyText="True" ControlToValidate="oldPsw" OnServerValidate="validateOldPsw_ServerValidate" ForeColor="Red"></asp:CustomValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Ny Adgangskode</label>
                                            <div class="col-md-9">
                                                <input type="password" name="newPsw" id="newPsw" class="form-control" placeholder="" runat="server" />
                                                <asp:CustomValidator ID="validateNewPsw" runat="server" ErrorMessage="Adgangskode skal udfyldes og skal være ens" ValidateEmptyText="True" ControlToValidate="newPsw" OnServerValidate="validateNewPsw_ServerValidate" ForeColor="Red"></asp:CustomValidator>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-md-3">Gentag Ny Adgangskode</label>
                                            <div class="col-md-9">
                                                <input type="password" name="repNewPsw" id="repNewPsw" class="form-control" placeholder="" runat="server" />
                                                <asp:CustomValidator ID="validateRepNewPsw" runat="server" ErrorMessage="Adgangskode skal udfyldes og skal være ens" ValidateEmptyText="True" ControlToValidate="repNewPsw" OnServerValidate="validateRepNewPsw_ServerValidate" ForeColor="Red"></asp:CustomValidator>
                                            </div>
                                        </div>

                                        <div class="form-actions fluid">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="col-md-offset-3 col-md-9">
                                                        <asp:LinkButton ID="btnSave2" CssClass="btn green" runat="server" OnClick="btnSavePassword_Click"><i class="fa fa-check"></i> Gem ny adgangskode</asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>

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
    <script src="plugins/bootstrap-fileinput/bootstrap-fileinput.js" type="text/javascript"></script>
    <script src="plugins/jquery.sparkline.min.js" type="text/javascript"></script>
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

<script type="text/javascript" src="plugins/fuelux/js/spinner.min.js"></script>
<script type="text/javascript" src="plugins/bootstrap-fileinput/bootstrap-fileinput.js"></script>
<script type="text/javascript" src="plugins/jquery-inputmask/jquery.inputmask.bundle.min.js"></script>
<script type="text/javascript" src="plugins/jquery.input-ip-address-control-1.0.min.js"></script>
<script src="plugins/bootstrap-pwstrength/pwstrength-bootstrap.min.js" type="text/javascript"></script>
<script src="plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>
<script src="plugins/jquery-tags-input/jquery.tagsinput.min.js" type="text/javascript"></script>
<script src="plugins/bootstrap-maxlength/bootstrap-maxlength.min.js" type="text/javascript"></script>
<script src="plugins/bootstrap-touchspin/bootstrap.touchspin.js" type="text/javascript"></script>
<script src="plugins/typeahead/handlebars.min.js" type="text/javascript"></script>
<script src="plugins/typeahead/typeahead.bundle.min.js" type="text/javascript"></script>
<script type="text/javascript" src="plugins/ckeditor/ckeditor.js"></script>

    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="scripts/metronic.js" type="text/javascript"></script>
    <script src="scripts/layout.js" type="text/javascript"></script>
    <script src="scripts/quick-sidebar.js" type="text/javascript"></script>
    <script src="scripts/demo.js" type="text/javascript"></script>
    <script src="scripts/components-dropdowns.js"></script>
    <script src="scripts/components-pickers.js"></script>
    <script src="scripts/metronic.js" type="text/javascript"></script>
    <script src="scripts/layout.js" type="text/javascript"></script>
    <script src="scripts/quick-sidebar.js" type="text/javascript"></script>
    <script src="scripts/demo.js" type="text/javascript"></script>
    <script src="pages/scripts/profile.js" type="text/javascript"></script>

    <script src="scripts/metronic.js" type="text/javascript"></script>
<script src="scripts/layout.js" type="text/javascript"></script>
<script src="scripts/demo.js" type="text/javascript"></script>
<script src="pages/scripts/components-form-tools.js"></script>


    <script>
        jQuery(document).ready(function () {
            // initiate layout and pluging
            Metronic.init(); // init metronic core components
            Layout.init(); // init current layout
            QuickSidebar.init(); // init quick sidebar
            Demo.init(); // init demo features
            ComponentsDropdowns.init();
            ComponentsPickers.init();
            Profile.init(); // init page demo
            ComponentsFormTools.init();

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

