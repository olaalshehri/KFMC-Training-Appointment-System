<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Booking_appointments.aspx.cs" Inherits="KFCproject.demo2.Booking_appointments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<p>
        &nbsp;</p>
    <p>
        <table class="nav-justified">
                <tr>
        <td colspan="2">
            <asp:Label ID="lblOutput" runat="server"></asp:Label>
        </td>
               </tr>
                 <tr>
                <td class="modal-sm" style="width: 234px">BookingappointmentId : 
                 </td>
                <td>
                    <asp:TextBox ID="txtbookingappointmentId" runat="server" BorderColor="#333333"></asp:TextBox>
                </td>
            </tr>
                        <tr>
                <td class="modal-sm" style="width: 234px">File No : 
                            </td>
                <td>
                    <asp:TextBox ID="txtfileno" runat="server" BorderColor="#333333"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 234px">First Name :
                </td>
                <td>
                    <asp:TextBox ID="txtfirstname" runat="server" BorderColor="#333333"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 234px">Middle Name :
                </td>
                <td>
                    <asp:TextBox ID="txtmiddlename" runat="server" BorderColor="#333333"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 234px">Last Name :
                </td>
                <td>
                    <asp:TextBox ID="txtlastname" runat="server" BorderColor="#333333"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 234px">National ID :
                </td>
                <td>
                    <asp:TextBox ID="txtnationalID" runat="server" BorderColor="#333333"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 234px">Phone Number :
                </td>
                <td>
                    <asp:TextBox ID="txtphonenumber" runat="server" BorderColor="#333333"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 234px">Eamil :
                </td>
                <td>
                    <asp:TextBox ID="txtemail" runat="server" TextMode="Email" BorderColor="#333333"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 234px">Service Name :
                </td>
                <td>
                    <asp:DropDownList ID="ddlservicename" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlservicename_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 234px">Doctor Name :
                </td>
                <td>
                    <asp:DropDownList ID="ddldoctorname" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 234px">Date - Day :
                </td>
                <td>
                    <asp:TextBox ID="txtdateday" runat="server" TextMode="Date" BorderColor="#333333"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 234px">Time :</td>
                <td>
                    <asp:TextBox ID="txttime" runat="server" TextMode="Time" BorderColor="#333333"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 234px">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 234px">&nbsp;</td>
                <td>
                    <asp:Button ID="btnsend" runat="server" Text="Send" BorderColor="#333333" OnClick="btnsend_Click" />
                    <br />
                </td>
            </tr>
        </table>
    </p>

</asp:Content>
