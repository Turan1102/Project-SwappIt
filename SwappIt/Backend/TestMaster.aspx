<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="TestMaster.aspx.cs" Inherits="Backend.TestMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagetitle" runat="server">
    <h3 class="page-title">SwappIt <small>ændret fra testmasterpage!</small>
    </h3>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="test" runat="server">
    <div class="col-md-6 col-sm-6">
        <!-- BEGIN PORTLET NEWS READER-->
        <div class="portlet">
            <div class="portlet-title line">
                <div class="caption"><i class="fa fa-newspaper-o"></i>Nyheder</div>
                <div class="tools" style="display: none;">
                    <a href="" class="collapse"></a>
                    <a href="#portlet-config" data-toggle="modal" class="config"></a>
                    <a href="" class="reload"></a>
                    <a href="" class="remove"></a>
                </div>
            </div>
            <div class="portlet-body" id="chats">
                <div class="scroller" style="height: 440px;" data-always-visible="1" data-rail-visible1="1">
                    <ul class="chats">
                        <asp:Literal ID="tableOut" runat="server"></asp:Literal>
                    </ul>
                </div>
            </div>
        </div>
        <!-- END PORTLET-->
    </div>
    <!-- BEGIN PORTLET NEWS CREATE-->
    <div class="col-md-6">
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption">
                    <i class="fa fa-envelope"></i>Opret nyhed
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                    <a href="#portlet-config" data-toggle="modal" class="config" data-original-title="" title=""></a>
                    <a href="javascript:;" class="reload" data-original-title="" title=""></a>
                    <a href="javascript:;" class="remove" data-original-title="" title=""></a>
                </div>
            </div>
            <div class="portlet-body form">
                <!-- BEGIN FORM-->
                <form action="#">
                    <div class="form-body">
                        <div class="form-group">
                            <label class="control-label">Titel</label>
                            <input type="text" class="form-control" placeholder="">
                        </div>
                        <div class="form-group">
                            <label class="control-label">Tekst</label>
                            <textarea rows="4" cols="50" class="form-control"></textarea>
                        </div>
                    </div>
                    <div class="form-actions right">
                        <button type="submit" class="btn green">Opret</button>

                    </div>
                </form>
                <!-- END FORM-->
            </div>
        </div>
    </div>
    <!-- END PORTLET-->
</asp:Content>
