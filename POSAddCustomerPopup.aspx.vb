Imports System.Data

Partial Class POSAddCustomerPopup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Call getGblsecuritysetting()
            If ViewState("isQSRCode") = True AndAlso ViewState("isPhyltyCard") = False Then
                trQsr.Style.Add("display", "")
                trMobile.Style.Add("display", "none")
                lblQsrNotFound.Text = "QSR: " & Request.QueryString("MobileNO").ToString.Replace("(", "").Replace(")", "").Replace("-", "") & " is not found"
                ScriptManager.RegisterStartupScript(Page, [GetType], "sizeit", "SwipesizeIt();", True)
            Else
                trQsr.Style.Add("display", "none")
                trMobile.Style.Add("display", "")
                lblCustMobileNo.Text = Request.QueryString("MobileNO")
            End If


        End If
    End Sub
    Private Sub getGblsecuritysetting()
        'Use to get customer type enable or not
        'frequent buyer enable or not
        Dim dt As New DataTable
        Dim objcustype As New vbStationSetup
        objcustype.StoreNo = Session("storeno")
        dt = objcustype.fnGetGlobalSetupValues()
        If dt.Rows.Count > 0 Then
            ViewState("customertype") = IIf(dt.Rows(0)("custype") = True, "Y", "N")
            ViewState("frequentbuyer") = IIf(IsDBNull(dt.Rows(0)("frequentbuyer")), "N", dt.Rows(0)("frequentbuyer").ToString())
            ViewState("isPhyltyCard") = IIf(ViewState("frequentbuyer").ToString.ToUpper = "Y", dt.Rows(0)("isPhyltyCard"), False)
            ViewState("promptclerkclub") = dt.Rows(0)("PromptClerkClub")
            ViewState("isQSRCode") = IIf(IsDBNull(dt.Rows(0)("isQSRorNot")), False, dt.Rows(0)("isQSRorNot"))
        Else
            ViewState("isPhyltyCard") = False
            ViewState("customertype") = "N"
            ViewState("frequentbuyer") = "N"
            ViewState("promptclerkclub") = False
            ViewState("isQSRCode") = False
        End If
        dt.Dispose()
    End Sub
End Class
