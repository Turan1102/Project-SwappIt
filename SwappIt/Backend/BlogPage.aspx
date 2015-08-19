<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostBack="true" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="BlogPage.aspx.cs" Inherits="Backend.BlogPage" %>

<asp:Content ID="Content99" ContentPlaceHolderID="head" runat="server">

    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
    <link href="plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
    <link href="plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <link href="plugins/bootstrap-switch/css/bootstrap-switch.min.css" rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL STYLES -->
    <link href="css/blog.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL STYLES -->
    <!-- BEGIN THEME STYLES -->
    <link href="css/components.css" id="style_components" rel="stylesheet" type="text/css" />
    <link href="css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <link id="style_color" href="css/themes/darkblue.css" rel="stylesheet" type="text/css" />
    <link href="css/custom.css" rel="stylesheet" type="text/css" />

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="pagetitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderWithLinkButton" runat="server">
 <div class="portlet box blue">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-cogs"></i>Blogvæg
							</div>
							<div class="tools">
								<a href="javascript:;" class="collapse" data-original-title="" title="">
								</a>
								<a href="#portlet-config" data-toggle="modal" class="config" data-original-title="" title="">
								</a>
							</div>
						</div>
						<div class="portlet-body">
							<div class="">
								            <asp:LinkButton ID="LinkBtnScrollDown" CssClass="btn green" runat="server" OnClientClick="scrollDownToBottomOfPage()"><i class="fa fa-comment-o"></i> Skriv på væg</asp:LinkButton>
							</div><hr />
							<div class="clearfix">
								<ul class="media-list">
									<li class="media">
                                     <asp:Literal ID="tableOut" runat="server"></asp:Literal>
									</li>
								</ul>
							</div>
						</div>
					</div>

    <hr>
    <div class="post-comment">
        <h3>Skriv på væggen</h3>
             <div class="portlet-body form">
                <!-- BEGIN FORM-->
                    <div class="form-body">
               <div class="form-group">
                                <label class="control-label col-md-3">Titel</label>
                                    <input type="text" name="Titel" id="Titel" class="form-control" placeholder="" runat="server"/>
                            </div>
                        <div class="form-group">
                            <label class="control-label col-md-3">Tekst</label>
                            <textarea rows="4" id="Text" name="Text" cols="50" class="form-control" runat="server"></textarea>
                        </div>
                    </div>
                                           <asp:LinkButton ID="LinkButtonSave" CssClass="btn green" runat="server" OnClick="CreateBlogButton_Click"><i class="fa fa-check"></i> Opret</asp:LinkButton>
                                        </div>
                <!-- END FORM-->
    </div>
</asp:Content>

<asp:Content ID="scripts" ContentPlaceHolderID="scripts" runat="server">

    <script src="plugins/jquery.min.js" type="text/javascript"></script>
    <script src="plugins/jquery-migrate.min.js" type="text/javascript"></script>
    <!-- IMPORTANT! Load jquery-ui-1.10.3.custom.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->
    <script src="../../assets/global/plugins/jquery-ui/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
    <script src="plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <script src="plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="plugins/jquery.cokie.min.js" type="text/javascript"></script>
    <script src="plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
    <script src="plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>
    <!-- END CORE PLUGINS -->
    <script src="scripts/metronic.js" type="text/javascript"></script>
    <script src="scripts/layout.js" type="text/javascript"></script>
    <script src="scripts/quick-sidebar.js" type="text/javascript"></script>
    <script src="scripts/demo.js" type="text/javascript"></script>

    <script>
        jQuery(document).ready(function () {
            // initiate layout and plugins
            Metronic.init(); // init metronic core components
            Layout.init(); // init current layout
            QuickSidebar.init(); // init quick sidebar
            Demo.init(); // init demo features
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
        function scrollDownToBottomOfPage() {
            window.scrollTo(0, document.body.scrollHeight);
        }
</script>

</asp:Content>


