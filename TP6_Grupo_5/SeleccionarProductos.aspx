<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarProductos.aspx.cs" Inherits="TP6_Grupo_5.SeleccionarProductos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style5 {
            width: 2%;
        }
        .auto-style8 {
            width: 232px;
        }
        .auto-style9 {
            width: 52%;
        }
        .auto-style10 {
            width: 9%;
        }
        .auto-style11 {
            width: 232px;
            height: 23px;
        }
        .auto-style12 {
            width: 52%;
            height: 23px;
        }
        .auto-style13 {
            width: 9%;
            height: 23px;
        }
        .auto-style14 {
            width: 2%;
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="7">
                    <asp:GridView ID="GVProductos" runat="server" AllowPaging="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="GVProductos_PageIndexChanging" PageSize="14" AutoGenerateSelectButton="True" AutoGenerateColumns="False" OnSelectedIndexChanging="GVProductos_SelectedIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Id Producto">
                                <ItemTemplate>
                                    <asp:Label ID="Lbl_it_idProducto" runat="server" Text='<%# Bind("IdProducto") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre Producto">
                                <ItemTemplate>
                                    <asp:Label ID="Lbl_it_nombreProducto" runat="server" Text='<%# Bind("NombreProducto") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id Proveedor">
                                <ItemTemplate>
                                    <asp:Label ID="Lbl_it_idProveedor" runat="server" Text='<%# Bind("IdProveedor") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Precio Unitario">
                                <ItemTemplate>
                                    <asp:Label ID="Lbl_it_precioUnidad" runat="server" Text='<%# Bind("PrecioUnidad") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                        <SortedDescendingHeaderStyle BackColor="#002876" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="LblProductoSeleccionado" runat="server"></asp:Label>
                </td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style10">
                    <asp:HyperLink ID="hlInicio" runat="server" NavigateUrl="~/Ejercicio2.aspx">Volver al inicio</asp:HyperLink>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style11"></td>
                <td class="auto-style12"></td>
                <td class="auto-style13"></td>
                <td class="auto-style14"></td>
                <td class="auto-style14"></td>
                <td class="auto-style14"></td>
                <td class="auto-style14"></td>
            </tr>
            <tr>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
