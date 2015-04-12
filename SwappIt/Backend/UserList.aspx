<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="Backend.UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagetitle" runat="server">
    <h3 class="page-title">
        --
			</h3>   
    <asp:Literal runat="server" ID="TestText" Text=""></asp:Literal>

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <!-- BEGIN TABLE PORTLET-->
            <div class="portlet">
                <div class="portlet-body">                      
                    <div class="table-responsive">
                        <table id="dataTable" class="table table-striped table-bordered table-hover dataTable">
                            <thead>
                                <tr>
                                    <th><i class="fa fa-user"></i> Personale nummer</th>
                                    <th><i class="fa fa-user"></i> Navn</th>
                                    <th><i class="fa fa-user"></i> CPR</th>
                                    <th><i class="fa fa-edit"></i> Ret</th>
                                    <th><i class="fa fa-unlock-alt"></i> Aktiv</th>
                                    <th><i class="fa fa-trash-o"></i> Slet</th>
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