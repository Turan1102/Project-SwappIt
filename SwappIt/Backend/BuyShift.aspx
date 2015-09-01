<%@ Page Title=""  Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="BuyShift.aspx.cs" Inherits="Backend.BuyShift" %>

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

    <!-- Popup kvittering start -->
    <div class="modal fade" id="receipt" tabindex="-1" role="receipt" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h2 class="modal-title">Kvittering for køb</h2>
                </div>
                <div class="modal-body">
                    <!-- Popup besked start -->
                    <h4>Dit køb af vagt er nu gennemført!</h4>
                </div>
                <div class="modal-footer">
                   <asp:LinkButton ID="LinkBtnClose" CssClass="btn red" runat="server" OnClick="RefreshPage_Click"><i class=""></i> Afslut</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
    <!-- Popup kvittering slut -->


    <!-- Popup bekræftelse start -->
    <div class="modal fade" id="ConfirmBuy" tabindex="-1" role="ConfirmBuy" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                    <h2 class="modal-title">Du vil købe en vagt</h2>
                </div>
                <div class="modal-body">
                    <!-- Popup besked start -->
                    <h4>Du er i færd med at købe en vagt. Er du sikker på dit valg?</h4>
                    <br />
                    <!-- Popup besked slut -->
                </div>
                <div class="modal-footer">
                    <!-- UpdatePanel, fordi vi ikke må miste data -->
                    <asp:Panel ID="Panel" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <button type="button" class="btn red" data-dismiss="modal"><i class="fa fa-times"></i>Fortryd</button>
                                <asp:HiddenField ID="CurrentShiftId" runat="server" Value="" />
                                <asp:LinkButton ID="LinkBtnBuy" CssClass="btn green" runat="server" OnClick="Buy_Click" OnClientClick="javascript:return SwitchToReceipt();"><i class="fa fa-check"></i> Bekræft</asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
    <!-- Popup bekræftelse slut -->

    <script type="text/javascript">

        function SetCurrentShiftId(shiftId) {
            document.getElementById('ContentPlaceHolder1_CurrentShiftId').value = shiftId;
            }

        function SwitchToReceipt() {
            $("#ConfirmBuy").hide();

            $(".modal-backdrop").hide();
            $("#receipt").modal('show');
        }

    </script>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderWithLinkButton" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="scripts" runat="server" ID="scripts">

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
