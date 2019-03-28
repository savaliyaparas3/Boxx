<%@ Page Language="VB" AutoEventWireup="false" CodeFile="POSAddCustomerPopup.aspx.vb" Inherits="POSAddCustomerPopup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <base target="_self" />
    <link href="1style.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Mainstyle.css" rel="stylesheet" type="text/css" />
    <title></title>
    <script type="text/javascript" language="javascript">
        function SwipesizeIt() {
            window.dialogHeight = "195px";
            window.dialogWidth = "550px";
        }
        </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 550px; height: 220px;">
            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                <tr>
                    <td valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%" style="padding: 10px 10px 10px 10px">
                            <tr id="trMobile" runat="server">
                                <td align="left" valign="top" class="tab1" width="100%">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td height="7" align="left" valign="top">
                                                <img src="images/crnr1w.gif" style="vertical-align: top;" alt="" width="8" height="7" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblCustMobileNo" runat="server" Font-Size="X-Large" CssClass="labelall" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblNotFound" runat="server" Font-Size="X-Large" CssClass="labelall" Text="Mobile Number Not Found"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:LinkButton ID="lnkAddCustomer" Font-Size="X-Large" runat="server" CssClass="labelall" OnClientClick="window.returnValue = 'Y';window.close();">Add this customer to the system.</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:LinkButton ID="lnkCloseScreen" runat="server" Font-Size="X-Large" OnClientClick="window.returnValue = 'N';window.close();" CssClass="labelall">Close Screen</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td height="8" align="left" valign="bottom" class="tab1c">
                                                <img alt="" height="8" style="vertical-align: bottom" src="images/crnr3w.gif" width="8" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="trQsr" runat="server">
                                <td align="left" valign="top" class="tab1" width="100%">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td height="7" align="left" valign="top">
                                                <img src="images/crnr1w.gif" style="vertical-align: top;" alt="" width="8" height="7" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblQsrNotFound" runat="server" Font-Size="X-Large" CssClass="labelall" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:LinkButton ID="lnkbtnTryagain" Font-Size="X-Large" runat="server" CssClass="labelall" OnClientClick="window.returnValue = 'YT';window.close();">Try Again</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:LinkButton ID="lnkbtnTryclose" runat="server" Font-Size="X-Large" OnClientClick="window.returnValue = 'N';window.close();" CssClass="labelall">Close Screen</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td height="8" align="left" valign="bottom" class="tab1c">
                                                <img alt="" height="8" style="vertical-align: bottom" src="images/crnr3w.gif" width="8" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
