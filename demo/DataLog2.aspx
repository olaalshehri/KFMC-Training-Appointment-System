<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DataLog2.aspx.cs" Inherits="KFCproject.demo.DataLog2" 
   EnableEventValidation="false" ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 
    <table class="nav-justified">

    <tr>
        <td style="width: 81px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 81px">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="lblOutput" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 81px; height: 37px;">LoginId</td>
        <td style="height: 37px"> 
            <asp:TextBox ID="txtId" runat="server" BorderColor="Gray"></asp:TextBox>
        &nbsp;</td>

        
    </tr>

    <tr>
        <td style="width: 81px; height: 37px;">The Name</td>
        <td style="height: 37px"> 
            <asp:TextBox ID="txtfname" runat="server" BorderColor="Gray"></asp:TextBox>
          
        </td>

        
    </tr>

    <tr>
        <td style="width: 81px; height: 6px;">The Age</td>
        <td style="height: 6px"> <br />
            <asp:TextBox ID="txtage" runat="server" BorderColor="Gray" ></asp:TextBox>
            <br />
        </td>
    </tr>
    <tr>
        <td style="width: 81px">Phone</td>
        <td> <br />
            <asp:TextBox ID="txtphone" runat="server" BorderColor="Gray"></asp:TextBox>
            </td> 
    </tr>
        
    <tr>
        <td style="width: 81px">&nbsp;</td>
        <td> &nbsp;</td> 
    </tr>
        
    <tr>
        <td style="width: 81px">The Gender</td>
        <td> 
            <asp:DropDownList ID="ddlgender" runat="server">
                
            </asp:DropDownList>
        </td> 
        
    </tr>
        
    <tr>
        <td style="width: 81px">&nbsp;</td>
        <td> 
            &nbsp;</td> 
        
    </tr>
        
    <tr>
        <td style="width: 81px">The country</td>
        <td> 
            <asp:DropDownList ID="ddlcountry" runat="server">
            </asp:DropDownList>
        </td> 
    </tr>
    <tr>
        <td style="width: 81px">&nbsp;</td>
        <td>
            <br />
            <asp:Button ID="btnsend" runat="server" Text="Send Data" OnClick="btnsend_Click" />
            <asp:Button ID="btnSelect" runat="server" OnClick="btnSelect_Click" Text="Select" />
            <asp:Button ID="btnupdate" runat="server" OnClick="btnupdate_Click" Text="Update" />
            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
        </td>
    </tr>
    <tr>
        <td style="width: 81px">&nbsp;</td>
        <td>
            <asp:Button ID="btnExportToExcel" runat="server" Text="ExportToExcel" OnClick="btnExportToExcel_Click" 
                EnableEventValidation="false" ValidateRequest="false"/>
        </td>
    </tr>
</table>
         <div>
          <asp:GridView ID="gvcontact" runat="server" AutoGenerateColumns="False" DataKeyNames="LoginId" 
               >
            <Columns>

                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="LoginId">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkupdate" runat="server"
                        CommandArgument='<%# Bind("LoginId") %>' OnClick="populateForm_Click"
                        Text='<%# Eval("LoginId")  %>'></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="left"></ItemStyle>
            </asp:TemplateField>

             
             
                <asp:BoundField DataField="fname" HeaderText="fname" SortExpression="fname" />
                 <asp:BoundField DataField="age" HeaderText="age" SortExpression="age" />
                 <asp:BoundField DataField="phone" HeaderText="phone" SortExpression="phone" />
                 <asp:BoundField DataField="gender" HeaderText="gender" SortExpression="gender" />
                 <asp:BoundField DataField="country" HeaderText="country" SortExpression="country" />
               
             
            </Columns>
        </asp:GridView>    
    
       

    </div>
</asp:Content>

