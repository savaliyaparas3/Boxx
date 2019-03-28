<%@ Page Language="VB" AutoEventWireup="false" CodeFile="POSACHReport.aspx.vb" Inherits="POSACHReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <base target="_self" />
    <link href="1style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .grd tbody tr th {
            border-top: solid 1px black;
            border-bottom: solid 1px black;
            border-left: none;
            border-right: none;
        }

        .altr {
            padding: 5px;
        }
        .altr {
            padding: 5px;
        }
        @media print {
            .pagestart {
                page-break-before: always;
            }

            .pageend {
                page-break-after: always;
            }

            .grd tr {
                page-break-inside: avoid;
                page-break-after: auto;
            }
        }

        @page {
            margin: 1cm;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <ajax:ScriptManager ID="Scriptmanager" runat="server">
        </ajax:ScriptManager>
        <table cellpadding="0" cellspacing="0" style="width: 100%;">
            <tr>
                <td style="width: 1%;"></td>
                <td style="width: 98%;">
                    <table cellpadding="0" cellspacing="0" style="width: 100%;">
                        <tr>
                            <td style="text-align: center; font-family: Arial; font-size: 10pt; font-weight: bold; white-space: nowrap; vertical-align: middle; width: 100%; padding-bottom: 10px;">Weekly ACH Report
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 100%;padding-left:10px;">
                                <asp:Label ID="lblProducebylabel" runat="server" CssClass="labelall" Font-Size="9pt" Font-Bold="true" Text="Produced by:"></asp:Label>&nbsp;
                                <asp:Label ID="lblProduceby" runat="server" CssClass="labelall" Font-Size="9pt"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; width: 50%;padding-left:10px;">
                                <asp:Label ID="lblTimeperiodlabel" runat="server" CssClass="labelall" Font-Size="9pt" Font-Bold="true" Text="Time Period:"></asp:Label>&nbsp;
                                <asp:Label ID="lblTimeperiod" runat="server" CssClass="labelall" Font-Size="9pt"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                             <td style="text-align: left; width: 50%;padding-left:10px;">
                                <asp:Label ID="lblPrintdatelabel" runat="server" CssClass="labelall" Font-Size="9pt" Font-Bold="true" Text="Print Date:"></asp:Label>&nbsp;
                                <asp:Label ID="lblPrintdate" runat="server" CssClass="labelall" Font-Size="9pt"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 1%;"></td>
            </tr>
        </table>
        <table cellpadding="2" width="100%" cellspacing="0">
            <tr>
                <td align="center">
                    <asp:Literal ID="ltrlstoredetail" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
