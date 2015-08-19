<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master"  AutoEventWireup="true" CodeBehind="CreateNewsPage.aspx.cs" Inherits="Backend.CreateNewsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pagetitle" runat="server">
    <h3 class="page-title">SwappIt <small>ændret fra testmasterpage!</small>
    </h3>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderWithLinkButton" runat="server">
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
                    <div class="form-body">
               <div class="form-group">
                                <label class="control-label col-md-3">Titel</label>
                                    <input type="text" name="Titel" id="Titel" class="form-control" placeholder="" runat="server" />
                            </div>
                        <div class="form-group">
                            <label class="control-label col-md-3">Tekst</label>
                            <textarea rows="4" id="Text" name="Text" cols="50" class="form-control" runat="server"></textarea>
                        </div>
                    </div>
                    <div class="form-actions fluid">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-offset-3 col-md-9">
                                            <asp:LinkButton ID="LinkBtnSave" CssClass="btn green" runat="server" OnClick="CreateNewsButton_Click"><i class="fa fa-check"></i> Opret</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                </div>
                <!-- END FORM-->
        </div>
    </div>
    <!-- END PORTLET-->
</asp:Content>

