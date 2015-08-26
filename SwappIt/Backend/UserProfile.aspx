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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderWithLinkButton" runat="server">
    <div class="row margin-top-20">
				<div class="col-md-12">
					<!-- BEGIN PROFILE CONTENT -->
					<div class="profile-content">
						<div class="row">
							<div class="col-md-12">
								<div class="portlet light">
									<div class="portlet-title tabbable-line">
										<div class="caption caption-md">
											<i class="icon-globe theme-font hide"></i>
											<span class="caption-subject font-blue-madison bold uppercase">Profile Account</span>
										</div>
										<ul class="nav nav-tabs">
											<li class="active">
												<a href="#tab_1_1" data-toggle="tab">Personlige Informationer</a>
											</li>
											<li>
												<a href="#tab_1_3" data-toggle="tab">Ændre Adgangskode</a>
											</li>
										</ul>
									</div>
									<div class="portlet-body">
										<div class="tab-content">
											<!-- PERSONAL INFO TAB -->
											<div class="tab-pane active" id="tab_1_1">
												<form role="form" action="#">
													<div class="form-group">
														<label class="control-label">Fornavn</label>
														<input type="text" placeholder="John Jonahan" class="form-control"/>
													</div>
													<div class="form-group">
														<label class="control-label">Efternavn</label>
														<input type="text" placeholder="Johnson" class="form-control"/>
													</div>
													<div class="form-group">
														<label class="control-label">Mobil Nummer</label>
														<input type="text" placeholder="+4512345678" class="form-control"/>
													</div>
													<div class="form-group">
														<label class="control-label">Email</label>
														<input type="text" placeholder="John@Mail.dk" class="form-control"/>
													</div>
													<div class="margiv-top-10">
														<a href="javascript:;" class="btn green-haze">
														Gem ændringer </a>
														<a href="javascript:;" class="btn default">
														Fortryd </a>
													</div>
												</form>
											</div>
											<!-- END PERSONAL INFO TAB -->

											<!-- CHANGE PASSWORD TAB -->
											<div class="tab-pane" id="tab_1_3">
												<form action="#">
													<div class="form-group">
														<label class="control-label">Nuværende Adgangskode</label>
														<input type="password" class="form-control"/>
													</div>
													<div class="form-group">
														<label class="control-label">Ny Adgangskode</label>
														<input type="password" class="form-control"/>
													</div>
													<div class="form-group">
														<label class="control-label">Gentag Ny Adgangskode</label>
														<input type="password" class="form-control"/>
													</div>
													<div class="margin-top-10">
														<a href="javascript:;" class="btn green-haze">
														Ændre Adgangskode </a>
														<a href="javascript:;" class="btn default">
														Fortryd </a>
													</div>
												</form>
											</div>
											<!-- END CHANGE PASSWORD TAB -->
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
					<!-- END PROFILE CONTENT -->
				</div>
			</div>
			<!-- END PAGE CONTENT-->

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

