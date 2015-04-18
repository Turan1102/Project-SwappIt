<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin.Master" CodeBehind="DepartmentList.aspx.cs" Inherits="Backend.DepartmentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagetitle" runat="server">
    <h3 class="page-title"> Afdelingsliste
    </h3>
    <asp:Literal runat="server" ID="TestText" Text=""></asp:Literal>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row">
        <div class="col-md-12">
            <!-- BEGIN TABLE PORTLET-->
            <div class="portlet">
                <div class="portlet-body">

                    <div class="portlet box yellow">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-search"></i>Søg
                                <asp:Literal ID="searchTotal" runat="server"></asp:Literal>
                            </div>
                            <div class="tools">
                                <a href="" class="collapse"></a>
                            </div>
                        </div>
                        <div class="portlet-body" style="">
                            <div class="row">
                                <div class="col-md-11">
                                    <label class="sr-only" for="SearchText">Søge tekst</label>
                                    <input type="text" class="form-control" id="searchText" name="searchText" placeholder="Søge tekst" runat="server">
                                </div>
                                <div class="col-md-1">
                                    <button type="submit" class="btn btn-default yellow">Søg <i class="m-icon-swapright m-icon-white"></i></button>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="table-responsive">
                        <table id="dataTable" class="table table-striped table-bordered table-hover dataTable">
                            <thead>
                                <tr>
                                    <th><i class="fa fa-user"></i>Kode</th>
                                    <th><i class="fa fa-user"></i>Navn</th>
                                    <th><i class="fa fa-edit"></i>Ret</th>
                                    <th><i class="fa fa-trash-o"></i>Slet</th>
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
