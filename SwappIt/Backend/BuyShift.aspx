<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="BuyShift.aspx.cs" Inherits="Backend.BuyShift" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <!-- BEGIN TABLE PORTLET-->
            <div class="portlet box blue">
                <div class="portlet-title">
							<div class="caption">
								<i class="fa fa-shopping-cart"></i>Køb vagt
							</div>
						</div>
                <div class="portlet-body">

                    <div class="table-responsive">
                        <table id="dataTable" class="table table-striped table-bordered table-hover dataTable">
                            <thead>
                                <tr>
                                    <th><i class="fa fa-user"></i>Sælges af</th>
                                    <th><i class="fa fa-calendar"></i>Vagtdato</th>
                                    <th><i class="fa fa-clock-o"></i>Tid</th>
                                    <th><i class="fa fa-shopping-cart"></i>Køb</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Literal ID="tableOut" runat="server"></asp:Literal>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <!-- END TABLE PORTLET-->
        </div>
    </div>
            
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderWithLinkButton" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="test" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="scripts" runat="server">
      <script>


        jQuery(document).ready(function () {

            var oTable = $('#dataTable').dataTable({
                "bPaginate": false,
                "bFilter": false,
                "bSort": true,
                "bInfo": false,
                "aoColumns": [
                                null,
                                { "sType": "datetime-eu" },
                                { "bSortable": false },
                                { "bSortable": false }
                ]
            });

            Helpers.init();

            <%= script %>
        });


    </script>
</asp:Content>
