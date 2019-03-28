Imports System.Data
Imports System.Data.SqlClient
Partial Class POSACHReport
    Inherits System.Web.UI.Page
    Dim Startdate As DateTime
    Dim Enddate As DateTime


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("emp_id") Is Nothing Then
            Session.Abandon()
            Response.Redirect("POSLogin.aspx")
        End If

        If Not IsPostBack Then
            Dim objTime As New VbGenralfunctions
            Dim objEmployee As New vbEmployee
            Dim dtemp As New DataTable
            dtemp = objEmployee.fnGetEmployee_information(Session("emp_id"), Session("storeno").ToString.Trim)
            If dtemp.Rows.Count > 0 Then
                lblProduceby.Text = dtemp.Rows(0)("lname").ToString().Trim + ", " + dtemp.Rows(0)("fname").ToString().Trim
            End If
            Startdate = Request.QueryString("startdate").ToString()
            Enddate = Request.QueryString("enddate").ToString()

            lblPrintdate.Text = objTime.CurrentDateTime(VbGenralfunctions.AllDateFormat.DateFormat11) + " @ " + objTime.CurrentDateTime(VbGenralfunctions.AllDateFormat.DateFormat15)
            lblTimeperiod.Text = Startdate.ToString("D") + " - " + Enddate.ToString("D")
            Call GetACHReportdata()
            Scriptmanager.RegisterStartupScript(Page, [GetType], "ACHReport", "window.print();", True)
        End If

    End Sub
    Private Sub GetACHReportdata()
        Dim ds As New DataSet
        Dim objInventory As New vbInventory
        objInventory.startdate = Startdate.ToString("MM/dd/yyyy")
        objInventory.enddate = Enddate.ToString("MM/dd/yyyy")
        objInventory.Storeno = Session("storeno").ToString.Trim
        objInventory.ServerDiffTime = (TimeZoneInfo.FindSystemTimeZoneById(TimeZoneInfo.Local.Id).GetUtcOffset(Now).TotalMinutes - TimeZoneInfo.FindSystemTimeZoneById(Session("TimeZone").ToString()).GetUtcOffset(Now).TotalMinutes).ToString
        Dim objEmp As New vbEmployee
        Dim dtstore As DataTable
        Dim Storeaccess As String = ""
        objEmp.Storeno = Session("storeno").ToString.Trim
        objEmp.EmployeeId = Convert.ToInt32(Session("emp_id"))
        dtstore = objEmp.fnGetEmployeeStoreAccess()
        If dtstore.Rows.Count > 0 Then
            If dtstore.Rows(0)("Storeaccess").ToString <> "" Then
                If dtstore.Rows(0)("Storeaccess").ToString.Trim = "allstores" Then

                Else
                    Storeaccess = dtstore.Rows(0)("Storeaccess").ToString.Trim
                End If
            End If
        End If
        objInventory.Storelist = Storeaccess.ToString.Trim
        If Not Request.QueryString("DaysClicked") Is Nothing And Request.QueryString("DaysClicked").ToString() <> "undefined" And Request.QueryString("DaysClicked").ToString() = "Y" Then
            ds = objInventory.fnGetWeklySnapShotPrint_WeekValChange(Session("stationno"))
        Else
            ds = objInventory.fnGetWeklySnapShotPrint()
        End If
        Dim dtStoreFilter As DataTable
        Dim makeStrSplit As String()
        Dim makeStr As String = String.Empty
        makeStrSplit = Request.QueryString("storeno").Split(",")
        For ij As Integer = 0 To makeStrSplit.Count - 1
            makeStr += ",'" + makeStrSplit(ij) + "'"
        Next
        makeStr = makeStr.Substring(1)
        dtStoreFilter = Nothing
        Dim dvstorefilter As DataView
        If ds.Tables.Count > 0 Then
            dtStoreFilter = ds.Tables(0).Select("storeno in (" & makeStr & ")").CopyToDataTable
            dvstorefilter = dtStoreFilter.DefaultView
            dvstorefilter.Sort = "storeno1"
            dtStoreFilter = Nothing
            dtStoreFilter = dvstorefilter.ToTable()
        End If

        'ds = objInventory.fnGetWeklySnapShotPrint()
        Dim strmaintable As String = "<br><br>"
        Dim Nosalecount As Integer = 0
        Dim Totalsalecount As Integer = 0
        If ds.Tables.Count > 0 Then
            If dtStoreFilter.Rows.Count > 0 Then
                strmaintable = "<table width = 98% align=center style=border-width:1px;>"
                strmaintable += "<tr><td width=1%></td><td colspan='2'><hr/></td></tr>"

                strmaintable += "<tr><td width=1%></td>"
                strmaintable += "<td width=98% ><table width=100% border=0 style=font-family:Arial;font-size:10pt cellspacing=0 cellpadding=0  bgcolor=silver >"

                strmaintable += "<tr>"
                strmaintable += "<td align=left width=30% style=padding-left:5px;><b>Store Data</b></td>"
                strmaintable += "<td align=right width=20%><b>Sub-Total</b></td>"
                strmaintable += "<td align=right width=15%><b>Fee%</b></td>"
                strmaintable += "<td align=right width=15%><b>Fees</td>"
                strmaintable += "<td align=left width=20% style=padding-left:15px;><b>Bank</b></td>"
                strmaintable += "</tr></table></td>"
                strmaintable += "<td width=1%></td></tr>"
                strmaintable += "<tr><td width=1% ></td><td colspan='6' ><hr/></td></tr>"
                strmaintable += "<tr><td width=1%></td>"
                strmaintable += " <td width=98%><table class=grd width=100% border=0 style=font-family:Arial;font-size:9pt cellpadding=0 cellspacing=0>"

                For i As Integer = 0 To dtStoreFilter.Rows.Count - 1
                    strmaintable += "<tr>"
                    Dim storedata As String = ""
                    storedata = dtStoreFilter.Rows(i)("storeno").ToString()
                    strmaintable += "<td align=left valign=top width=30% >" & dtStoreFilter.Rows(i)("storeno").ToString().Trim & "<br>" & dtStoreFilter.Rows(i)("address").ToString().Trim & "<br>" & dtStoreFilter.Rows(i)("city").ToString().Trim & ", " & dtStoreFilter.Rows(i)("st").ToString().Trim & "<br>" & dtStoreFilter.Rows(i)("lname").ToString().Trim & ", " & dtStoreFilter.Rows(i)("fname").ToString().Trim & "</td>"
                    strmaintable += "<td align=right valign=top width=20% >$" & IIf(dtStoreFilter.Rows(i)("totalSales").ToString() = "", "0.00", FormatNumber(Val(dtStoreFilter.Rows(i)("totalSales").ToString()), 2, TriState.True)) & "</td>"
                    strmaintable += "<td align=right valign=top width=15% >" & dtStoreFilter.Rows(i)("Standard_Perc").ToString() & "% <br>" & dtStoreFilter.Rows(i)("AdvtFee_Perc").ToString() & "% <br><b>Total:</b>" & "</td>"
                    strmaintable += "<td align=right valign=top width=15% >$" & IIf(dtStoreFilter.Rows(i)("StandardFees").ToString() = "", "0.00", dtStoreFilter.Rows(i)("StandardFees").ToString()) & "<br>$" & IIf(dtStoreFilter.Rows(i)("AdvtFees").ToString() = "", "0.00", dtStoreFilter.Rows(i)("AdvtFees").ToString()) & "<br>$" & IIf(dtStoreFilter.Rows(i)("Fees").ToString() = "", "0.00", dtStoreFilter.Rows(i)("Fees").ToString()) & "</td>"
                    strmaintable += "<td align=left valign=top width=20% style= padding-left:15px; >" & dtStoreFilter.Rows(i)("Bank_Name").ToString().Trim & "</td>"
                    strmaintable += "</tr>"
                    strmaintable += "<tr>"
                    strmaintable += "<td colspan='6' style=height:5px; ></td>"
                    strmaintable += "</tr>"

                    If dtStoreFilter.Rows(i)("totalSales").ToString() = "" Then
                        Nosalecount += 1
                    Else
                        Totalsalecount += 1
                    End If

                Next
                strmaintable += "<tr>"
                strmaintable += "<td colspan='6' style=height:10px; ></td>"
                strmaintable += "</tr>"
                strmaintable += "<tr><td colspan='6'><hr/></td></tr>"
                strmaintable += "<tr>"
                strmaintable += "<td colspan='6' style=height:5px; ></td>"
                strmaintable += "</tr>"
                strmaintable += "<tr>"
                strmaintable += "<td align=left valign=top width=30%  >Sub-Total:<br>Franchisee Fees:<br>NAF:<br>Total Fees:</td>"
                strmaintable += "<td align=right valign=top width=20% >$" & FormatNumber(Val(dtStoreFilter.Compute("Sum(totalsales)", "").ToString), 2, TriState.True) & "<br>$" & FormatNumber(Val(dtStoreFilter.Compute("Sum(StandardFees)", "").ToString), 2, TriState.True) & "<br>$" & FormatNumber(Val(dtStoreFilter.Compute("Sum(AdvtFees)", "").ToString), 2, TriState.True) & "<br>" & FormatNumber(Val(dtStoreFilter.Compute("Sum(Fees)", "").ToString), 2, TriState.True) & "</td>"
                strmaintable += "<td align=left valign=top width=1% ></td>"
                strmaintable += "<td align=left valign=top width=29% colspan='2'  >" & dtStoreFilter.Rows.Count.ToString() & " Stores Report" & "<br>" & Totalsalecount & " Stores Reporting Sales" & "<br>" & Nosalecount & " Stores showing no sales" & "</td>"
                strmaintable += "<td align=left valign=top width=20% ></td>"
                strmaintable += "</tr>"
                strmaintable += "</table>"
                strmaintable += "</td>"
                strmaintable += "</tr>"
                strmaintable += "</table>"
                strmaintable += "</td>"
                strmaintable += "</tr>"
                strmaintable += "</table>"

            End If
        End If
        ltrlstoredetail.Text = strmaintable


    End Sub
End Class
