Imports System.ComponentModel
Imports Microsoft.Research.DynamicDataDisplay.DataSources
Imports Microsoft.Research.DynamicDataDisplay
Imports Microsoft.Research.DynamicDataDisplay.PointMarkers
Imports System.Windows.Media.Animation

Public Structure DataPoint
    Public Sub New(ByVal Ydata As Double, ByVal Xdata As Double)
        _Ydata = Ydata
        _Xdata = Xdata
    End Sub

    Public Property Ydata As Double
    Public Property Xdata As Double
End Structure

Public Class DataSeries
    Inherits ObjectModel.ObservableCollection(Of DataPoint)
    Implements IEnumerable(Of DataPoint)

    Public Sub New()

    End Sub
End Class

Public Class DataSeries2
    Inherits ObjectModel.ObservableCollection(Of DataPoint)
    Implements IEnumerable(Of DataPoint)

    Public Sub New()

    End Sub
End Class

Public Class DataSeries3
    Inherits ObjectModel.ObservableCollection(Of DataPoint)
    Implements IEnumerable(Of DataPoint)

    Public Sub New()

    End Sub
End Class

Public Class DataSeries4
    Inherits ObjectModel.ObservableCollection(Of DataPoint)
    Implements IEnumerable(Of DataPoint)

    Public Sub New()

    End Sub
End Class

Public Class Cratedata
    Implements INotifyPropertyChanged
    Private cpressure As Double
    Private ccompress As Double
    Private cgiip As Double
    Private cgprod As Double
    Private crecovery As Double

    Sub New()
    End Sub

    Sub New(ByVal pressure As Double, ByVal compress As Double, ByVal giip As Double, ByVal gprod As Double, ByVal recovery As Double)
        Me.cpressure = pressure
        Me.ccompress = compress
        Me.cgiip = giip
        Me.cgprod = gprod
        Me.crecovery = recovery
    End Sub
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Property pressure() As Double
        Get
            Return cpressure
        End Get
        Set(value As Double)
            cpressure = value
            OnPropertyChanged("pressure")
        End Set
    End Property

    Public Property compress() As Double
        Get
            Return ccompress
        End Get
        Set(value As Double)
            ccompress = value
            OnPropertyChanged("compress")
        End Set
    End Property

    Public Property giip() As Double
        Get
            Return cgiip
        End Get
        Set(value As Double)
            cgiip = value
            OnPropertyChanged("cgiip")
        End Set
    End Property

    Public Property gprod() As Double
        Get
            Return cgprod
        End Get
        Set(value As Double)
            cgprod = value
            OnPropertyChanged("gprod")
        End Set
    End Property

    Public Property recovery() As Double
        Get
            Return crecovery
        End Get
        Set(value As Double)
            crecovery = value
            OnPropertyChanged("recovery")
        End Set
    End Property

    Private Sub OnPropertyChanged(ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

End Class

Public Class Cratedata2
    Implements INotifyPropertyChanged
    Private cpressure As Double
    Private ccompress As Double
    Private cpoverz As Double
    Private cgprod As Double
    Private crecovery As Double

    Sub New()
    End Sub

    Sub New(ByVal pressure As Double, ByVal compress As Double, ByVal poverz As Double, ByVal gprod As Double, ByVal recovery As Double)
        Me.cpressure = pressure
        Me.ccompress = compress
        Me.cpoverz = poverz
        Me.cgprod = gprod
        Me.crecovery = recovery
    End Sub
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Property pressure() As Double
        Get
            Return cpressure
        End Get
        Set(value As Double)
            cpressure = value
            OnPropertyChanged("pressure")
        End Set
    End Property

    Public Property compress() As Double
        Get
            Return ccompress
        End Get
        Set(value As Double)
            ccompress = value
            OnPropertyChanged("compress")
        End Set
    End Property

    Public Property poverz() As Double
        Get
            Return cpoverz
        End Get
        Set(value As Double)
            cpoverz = value
            OnPropertyChanged("poverz")
        End Set
    End Property

    Public Property gprod() As Double
        Get
            Return cgprod
        End Get
        Set(value As Double)
            cgprod = value
            OnPropertyChanged("gprod")
        End Set
    End Property

    Public Property recovery() As Double
        Get
            Return crecovery
        End Get
        Set(value As Double)
            crecovery = value
            OnPropertyChanged("recovery")
        End Set
    End Property

    Private Sub OnPropertyChanged(ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class
Class MainWindow

    Dim myseries As New DataSeries
    Dim myseries2 As New DataSeries2
    Dim myseries3 As New DataSeries3
    Dim myseries4 As New DataSeries4
    Dim blinkstory As Storyboard
    Dim blinkstory2 As Storyboard
    Dim blinkstory3 As Storyboard

    Dim mychartSeries1 As New EnumerableDataSource(Of DataPoint)(myseries)
    Dim mychartSeries2 As New EnumerableDataSource(Of DataPoint)(myseries2)
    Dim mychartSeries3 As New EnumerableDataSource(Of DataPoint)(myseries3)
    Dim mychartSeries4 As New EnumerableDataSource(Of DataPoint)(myseries4)



    Private Sub vm_btn_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles vm_btn.MouseDown
        My.Settings.Task = 1
        wwi_btn.Visibility = Windows.Visibility.Hidden
        wow_btn.Visibility = Windows.Visibility.Hidden
        vol_bg.Visibility = Windows.Visibility.Visible
        wwi_bg.Visibility = Windows.Visibility.Hidden
        wow_bg.Visibility = Windows.Visibility.Hidden
        errorlabel.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub mb_btn_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles mb_btn.MouseDown
        wwi_btn.Visibility = Windows.Visibility.Visible
        wow_btn.Visibility = Windows.Visibility.Visible
    End Sub

    Private Sub wwi_btn_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles wwi_btn.MouseDown
        My.Settings.Task = 2
        vol_bg.Visibility = Windows.Visibility.Hidden
        wwi_bg.Visibility = Windows.Visibility.Visible
        wow_bg.Visibility = Windows.Visibility.Hidden
        errorlabel.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub wow_btn_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles wow_btn.MouseDown
        My.Settings.Task = 3
        vol_bg.Visibility = Windows.Visibility.Hidden
        wwi_bg.Visibility = Windows.Visibility.Hidden
        wow_bg.Visibility = Windows.Visibility.Visible
        errorlabel.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub begincalc_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles begincalc.MouseDown
        My.Settings.Bgistatus = 0
        My.Settings.Bgastatus = 0
        If My.Settings.Task = 1 Then
            introgrid.Visibility = Windows.Visibility.Hidden
            softgrid.Visibility = Windows.Visibility.Visible
            volumegrid.Visibility = Windows.Visibility.Visible
            calmethod.Content = "The Volumetric Method"
            wwigrid.Visibility = Windows.Visibility.Hidden
            wowgrid.Visibility = Windows.Visibility.Hidden
        ElseIf My.Settings.Task = 2 Then
            introgrid.Visibility = Windows.Visibility.Hidden
            softgrid.Visibility = Windows.Visibility.Visible
            wwigrid.Visibility = Windows.Visibility.Visible
            calmethod.Content = "The Material Balance Method; With water influx"
            volumegrid.Visibility = Windows.Visibility.Hidden
            wowgrid.Visibility = Windows.Visibility.Hidden
        ElseIf My.Settings.Task = 3 Then
            introgrid.Visibility = Windows.Visibility.Hidden
            softgrid.Visibility = Windows.Visibility.Visible
            wowgrid.Visibility = Windows.Visibility.Visible
            calmethod.Content = "The Material Balance Method; Without water influx"
            wwigrid.Visibility = Windows.Visibility.Hidden
            volumegrid.Visibility = Windows.Visibility.Hidden
        ElseIf My.Settings.Task = 0 Then
            errorlabel.Visibility = Windows.Visibility.Visible
            blinkstory = DirectCast(FindResource("blinkanim"), Storyboard)
            blinkstory.Begin()

        End If
    End Sub

    Private Sub homebtn_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles homebtn.MouseDown
        My.Settings.Task = 0
        My.Settings.Bgistatus = 0
        My.Settings.Bgival = 0
        My.Settings.Bgastatus = 0
        My.Settings.Bgaval = 0
        My.Settings.Charterror = 0
        softgrid.Visibility = Windows.Visibility.Hidden
        introgrid.Visibility = Windows.Visibility.Visible
        wowgrid.Visibility = Windows.Visibility.Hidden
        wwigrid.Visibility = Windows.Visibility.Hidden
        volumegrid.Visibility = Windows.Visibility.Hidden
        errorlabel.Visibility = Windows.Visibility.Hidden
        statuslabel.Visibility = Windows.Visibility.Hidden
        footererrorlabel.Visibility = Windows.Visibility.Hidden
        vol_bg.Visibility = Windows.Visibility.Hidden
        wwi_bg.Visibility = Windows.Visibility.Hidden
        wow_bg.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub datainbtn_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles datainbtn.MouseDown
        volumegridcharts.Visibility = Windows.Visibility.Hidden
        volumegridwrap.Visibility = Windows.Visibility.Visible
        statuslabel.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub datainbtn1_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles datainbtn1.MouseDown
        wwigridcharts.Visibility = Windows.Visibility.Hidden
        wwigridwrap.Visibility = Windows.Visibility.Visible
        statuslabel.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub datainbtn2_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles datainbtn2.MouseDown
        wowgridcharts.Visibility = Windows.Visibility.Hidden
        wowgridwrap.Visibility = Windows.Visibility.Visible
        statuslabel.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        mychartSeries1.SetXYMapping(Function(dataPoint) New System.Windows.Point(dataPoint.Xdata, dataPoint.Ydata))
        mychartSeries2.SetXYMapping(Function(dataPoint) New System.Windows.Point(dataPoint.Xdata, dataPoint.Ydata))
        mychartSeries3.SetXYMapping(Function(dataPoint) New System.Windows.Point(dataPoint.Xdata, dataPoint.Ydata))
        mychartSeries4.SetXYMapping(Function(dataPoint) New System.Windows.Point(dataPoint.Xdata, dataPoint.Ydata))

        Dim pointMarker As New CircleElementPointMarker()
        With pointMarker
            .Size = 8
            .Brush = Brushes.DarkSlateGray
            .Fill = Brushes.DarkSlateGray
        End With

        myChartPlotter1.AddLineGraph(mychartSeries1, New Pen(Brushes.Chartreuse, 2), pointMarker, New PenDescription("Gas FVF (cuft/scf)"))
        myChartPlotter2.AddLineGraph(mychartSeries2, New Pen(Brushes.Purple, 2), pointMarker, New PenDescription("GP (SCF)"))
        myChartPlotter3.AddLineGraph(mychartSeries3, New Pen(Brushes.Tomato, 2), pointMarker, New PenDescription("GP (SCF)"))
        myChartPlotter4.AddLineGraph(mychartSeries4, New Pen(Brushes.Turquoise, 2), pointMarker, New PenDescription("GP (SCF)"))
    End Sub

    Private Sub A_KeyUp(sender As Object, e As KeyEventArgs) Handles A.KeyUp, H.KeyUp, Phi.KeyUp, Swi.KeyUp, Bgiin.KeyUp, Bgain.KeyUp, T.KeyUp, P.KeyUp, Tb.KeyUp, Pb.KeyUp, gg.KeyUp, ggb.KeyUp

        Try
            Dim Av As Double = A.Text
            Dim Hv As Double = H.Text
            Dim Phiv As Double = Phi.Text
            Dim Swiv As Double = Swi.Text
            Dim Bgiinv As Double = Bgiin.Text
            Dim Bgainv As Double = Bgain.Text
            Dim Tv As Double = T.Text
            Dim Pv As Double = P.Text
            Dim Tbv As Double = Tb.Text
            Dim Pbv As Double = Pb.Text
            Dim ggv As Double = gg.Text
            Dim ggbv As Double = ggb.Text
            Dim Gv As Double
            Dim Gpv As Double
            Dim Rfv As Double
            Dim zv As Double = z.Text
            Dim Zbv As Double = zb.Text

            Gv = callvolumetricG(Av, Hv, Phiv, Swiv, Tv, Pv, ggv, Bgiinv, zv)
            Gpv = callvolumetricGp(Av, Hv, Phiv, Swiv, Tv, Pv, ggv, Bgiinv, Bgainv, ggbv, Tbv, Pbv, zv, Zbv)
            Rfv = Math.Round((Gpv / Gv) * 100, 1)

            If (Gv < 1000) Then
                g_calc.Content = (Math.Round(Gv, 1)).ToString + " SCF"
            ElseIf (Gv > 1000 And Gv <= 999999) Then
                g_calc.Content = (Math.Round((Gv / 1000), 2)).ToString + " MSCF"
            ElseIf (Gv > 999999 And Gv <= 999999999) Then
                g_calc.Content = (Math.Round((Gv / 1000000), 2)).ToString + " MMSCF"
            ElseIf (Gv > 999999999 And Gv <= 999999999999) Then
                g_calc.Content = (Math.Round((Gv / 1000000000), 2)).ToString + " MMMSCF"
            ElseIf (Gv > 999999999999) Then
                g_calc.Content = (Math.Round(Gv, 2)).ToString + " SCF"
            End If
            If (Gpv < 1000) Then
                gp_calc.Content = (Math.Round(Gpv, 1)).ToString + " SCF"
            ElseIf (Gpv > 1000 And Gpv <= 999999) Then
                gp_calc.Content = (Math.Round((Gpv / 1000), 2)).ToString + " MSCF"
            ElseIf (Gpv > 999999 And Gpv <= 999999999) Then
                gp_calc.Content = (Math.Round((Gpv / 1000000), 2)).ToString + " MMSCF"
            ElseIf (Gpv > 999999999 And Gpv <= 999999999999) Then
                gp_calc.Content = (Math.Round((Gpv / 1000000000), 2)).ToString + " MMMSCF"
            ElseIf (Gpv > 999999999999) Then
                gp_calc.Content = (Math.Round(Gpv, 2)).ToString + " SCF"
            End If
            rf_calc.Content = Rfv.ToString + "%"
            bgi_calc.Content = My.Settings.Bgival.ToString + " cuft/scf"
            bga_calc.Content = My.Settings.Bgaval.ToString + " cuft/scf"
        Catch ex As Exception

        End Try


    End Sub
    Private Sub GP_KeyUp(sender As Object, e As KeyEventArgs) Handles GP.KeyUp, Bw.KeyUp, We.KeyUp, Wp.KeyUp, Bgiin1.KeyUp, Bgain1.KeyUp, gg1.KeyUp, ggb1.KeyUp, P1.KeyUp, Pb1.KeyUp, T1.KeyUp, Tb1.KeyUp, z1.KeyUp, zb1.KeyUp
        Try
            Dim Gpv As Double = GP.Text
            Dim Bwv As Double = Bw.Text
            Dim Wev As Double = We.Text
            Dim Wpv As Double = Wp.Text
            Dim z1v As Double = z1.Text
            Dim zb1v As Double = zb1.Text
            Dim Bgiinv As Double = Bgiin1.Text
            Dim Bgainv As Double = Bgain1.Text
            Dim T1v As Double = T1.Text
            Dim P1v As Double = P1.Text
            Dim Tb1v As Double = Tb1.Text
            Dim Pb1v As Double = Pb1.Text
            Dim gg1v As Double = gg1.Text
            Dim ggb1v As Double = ggb1.Text
            Dim Rav As Double = Ra.Text
            Dim Gv As Double
            Dim Rfv As Double

            Gv = callvolumetricG(Rav, Bwv, Wev, Wpv, Tb1v, Pb1v, ggb1v, Bgainv, zb1v)
            Rfv = Math.Round((Gpv / Gv) * 100, 1)

            If (Gv < 1000) Then
                g_calc1.Content = (Math.Round(Gv, 1)).ToString + " SCF"
            ElseIf (Gv > 1000 And Gv <= 999999) Then
                g_calc1.Content = (Math.Round((Gv / 1000), 2)).ToString + " MSCF"
            ElseIf (Gv > 999999 And Gv <= 999999999) Then
                g_calc1.Content = (Math.Round((Gv / 1000000), 2)).ToString + " MMSCF"
            ElseIf (Gv > 999999999 And Gv <= 999999999999) Then
                g_calc1.Content = (Math.Round((Gv / 1000000000), 2)).ToString + " MMMSCF"
            ElseIf (Gv > 999999999999) Then
                g_calc1.Content = (Math.Round(Gv, 2)).ToString + " SCF"
            End If
            gp_calc1.Content = Gpv.ToString + " SCF"
            rf_calc1.Content = Rfv.ToString + "%"
            bgi_calc1.Content = My.Settings.Bgaval.ToString + " cuft/scf"
            bga_calc1.Content = My.Settings.Bgival.ToString + " cuft/scf"

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Gp1_KeyUp(sender As Object, e As KeyEventArgs) Handles Gp1.KeyUp, z2.KeyUp, gg2.KeyUp, bgiin2.KeyUp, T2.KeyUp, P2.KeyUp, zb2.KeyUp, ggb2.KeyUp, Bgain2.KeyUp, Tb2.KeyUp, Pb2.KeyUp
        Try
            Dim Gpv As Double = Gp1.Text
            Dim z2v As Double = z2.Text
            Dim zb2v As Double = zb2.Text
            Dim Bgiinv As Double = bgiin2.Text
            Dim Bgainv As Double = Bgain2.Text
            Dim T2v As Double = T2.Text
            Dim P2v As Double = P2.Text
            Dim Tb2v As Double = Tb2.Text
            Dim Pb2v As Double = Pb2.Text
            Dim gg2v As Double = gg2.Text
            Dim ggb2v As Double = ggb2.Text
            Dim Gv As Double
            Dim Rfv As Double

            Gv = callwowG(Gpv, Bgiinv, Bgainv, gg2v, ggb2v, T2v, P2v, Tb2v, Pb2v, z2v, zb2v)
            Rfv = Math.Round((Gpv / Gv) * 100, 1)

            If (Gv < 1000) Then
                g_calc2.Content = (Math.Round(Gv, 1)).ToString + " SCF"
            ElseIf (Gv > 1000 And Gv <= 999999) Then
                g_calc2.Content = (Math.Round((Gv / 1000), 2)).ToString + " MSCF"
            ElseIf (Gv > 999999 And Gv <= 999999999) Then
                g_calc2.Content = (Math.Round((Gv / 1000000), 2)).ToString + " MMSCF"
            ElseIf (Gv > 999999999 And Gv <= 999999999999) Then
                g_calc2.Content = (Math.Round((Gv / 1000000000), 2)).ToString + " MMMSCF"
            ElseIf (Gv > 999999999999) Then
                g_calc2.Content = (Math.Round(Gv, 2)).ToString + " SCF"
            End If
            gp_calc2.Content = Gpv.ToString + " SCF"
            rf_calc2.Content = Rfv.ToString + "%"
            bgi_calc2.Content = My.Settings.Bgival.ToString + " cuft/scf"
            bga_calc2.Content = My.Settings.Bgaval.ToString + " cuft/scf"
        Catch ex As Exception

        End Try
    End Sub
    Function callz(ByVal ggv As Double, ByVal Tv As Double, ByVal Pv As Double)
        Dim ppc As Double = 709.604 - (58.718 * ggv)
        Dim tpc As Double = 170.491 + (307.344 * ggv)
        Dim tpr As Double = (Tv + 460) / tpc
        Dim ppr As Double = Pv / ppc
        Dim An As Double = 1.39 * (tpr - 0.92) ^ 0.5 - (0.36 * tpr) - 0.1
        Dim C As Double = 0.132 - (0.32 * (Math.Log10(tpr)))
        Dim F As Double = 0.3106 - (0.49 * tpr) + (0.1824 * tpr * tpr)
        Dim E As Double = 9 * (tpr - 1)
        Dim D As Double = 10 ^ F
        Dim B As Double = ppr * (0.62 - (0.23 * tpr)) + (ppr ^ 2) * ((0.066 / (tpr - 0.86)) - 0.037) + (0.32 * (ppr ^ 6)) / (10 ^ E)
        Dim Z As Double = An + ((1 - An) / (Math.Exp(B))) + (C * (ppr ^ D))
        Z = Math.Round(Z, 4)
        Return Z
    End Function

    Function callvolumetricG(ByVal Av As Double, ByVal Hv As Double, ByVal Phiv As Double, ByVal Swiv As Double, Tv As Double, Pv As Double, ggv As Double, Bgiinv As Double, ByVal Zv As Double)
        Dim Gv As Double
        If (My.Settings.Bgistatus = 1) Then
            Gv = (43560 * (Phiv / 100) * Av * Hv * (1 - Swiv)) / Bgiinv
            My.Settings.Bgival = Math.Round(Bgiinv, 6)
        ElseIf (My.Settings.Bgistatus = 2) Then
            Gv = (43560 * (Phiv / 100) * Av * Hv * (1 - Swiv)) / ((0.02827 * Zv * (Tv + 460)) / Pv)
            My.Settings.Bgival = Math.Round(((0.02827 * Zv * (Tv + 460)) / Pv), 6)
        ElseIf (My.Settings.Bgistatus = 3) Then
            Gv = (43560 * (Phiv / 100) * Av * Hv * (1 - Swiv)) / ((0.02827 * (callz(ggv, Tv, Pv)) * (Tv + 460)) / Pv)
            My.Settings.Bgival = Math.Round(((0.02827 * (callz(ggv, Tv, Pv)) * (Tv + 460)) / Pv), 6)
        End If
        Gv = Math.Round(Gv, 2)
        Return Gv
    End Function
    Function callmbeG(ByVal Gpv As Double, ByVal Bgiinv As Double, ByVal Bgainv As Double, ByVal Wev As Double, ByVal Wpv As Double, ByVal Bwv As Double, ByVal gg1v As Double, ByVal ggb1v As Double, ByVal T1v As Double, ByVal P1v As Double, ByVal Tb1v As Double, ByVal Pb1v As Double, z1v As Double, zb1v As Double)
        Dim Gv As Double
        Dim Bgiinf As Double
        Dim Bgainf As Double
        If (My.Settings.Bgistatus = 1) Then
            Bgiinf = Bgiinv
        ElseIf (My.Settings.Bgistatus = 2) Then
            Bgiinf = (0.02827 * z1v * (T1v + 460)) / P1v
        ElseIf (My.Settings.Bgistatus = 3) Then
            Bgiinf = (0.02827 * (callz(gg1v, T1v, P1v)) * (T1v + 460)) / P1v
        End If

        If (My.Settings.Bgastatus = 1) Then
            Bgainf = Bgainv
        ElseIf (My.Settings.Bgastatus = 2) Then
            Bgainf = (0.02827 * zb1v * (Tb1v + 460)) / Pb1v
        ElseIf (My.Settings.Bgastatus = 3) Then
            Bgainf = (0.02827 * (callz(ggb1v, Tb1v, Pb1v)) * (Tb1v + 460)) / Pb1v
        End If

        My.Settings.Bgival = Math.Round(Bgiinf, 6)
        My.Settings.Bgaval = Math.Round(Bgainf, 6)

        Gv = ((Gpv * Bgiinf) - (Wev - (Wpv * Bwv))) / (Bgiinf - Bgainf)
        Gv = Math.Round(Gv, 2)
        Return Gv
    End Function

    Function callwowG(ByVal Gpv As Double, ByVal Bgiinv As Double, ByVal Bgainv As Double, ByVal gg2v As Double, ByVal ggb2v As Double, ByVal T2v As Double, ByVal P2v As Double, ByVal Tb2v As Double, ByVal Pb2v As Double, z2v As Double, zb2v As Double)
        Dim Gv As Double
        Dim Bgiinf As Double
        Dim Bgainf As Double
        If (My.Settings.Bgistatus = 1) Then
            Bgiinf = Bgiinv
        ElseIf (My.Settings.Bgistatus = 2) Then
            Bgiinf = (0.02827 * z2v * (T2v + 460)) / P2v
        ElseIf (My.Settings.Bgistatus = 3) Then
            Bgiinf = (0.02827 * (callz(gg2v, T2v, P2v)) * (T2v + 460)) / P2v
        End If

        If (My.Settings.Bgastatus = 1) Then
            Bgainf = Bgainv
        ElseIf (My.Settings.Bgastatus = 2) Then
            Bgainf = (0.02827 * zb2v * (Tb2v + 460)) / Pb2v
        ElseIf (My.Settings.Bgastatus = 3) Then
            Bgainf = (0.02827 * (callz(ggb2v, Tb2v, Pb2v)) * (Tb2v + 460)) / Pb2v
        End If

        My.Settings.Bgival = Math.Round(Bgiinf, 6)
        My.Settings.Bgaval = Math.Round(Bgainf, 6)

        Gv = (Gpv * Bgiinf) / (Bgiinf - Bgainf)
        Gv = Math.Round(Gv, 2)
        Return Gv
    End Function

    Function callvolumetricGp(ByVal Av As Double, ByVal Hv As Double, ByVal Phiv As Double, ByVal Swiv As Double, Tv As Double, Pv As Double, ggv As Double, Bgiinv As Double, Bgainv As Double, ggbv As Double, Tbv As Double, Pbv As Double, Zv As Double, Zbv As Double)
        Dim Gpv As Double
        Dim Bgiinf As Double
        Dim Bgainf As Double
        If (My.Settings.Bgistatus = 1) Then
            Bgiinf = Bgiinv
        ElseIf (My.Settings.Bgistatus = 2) Then
            Bgiinf = (0.02827 * Zv * (Tv + 460)) / Pv
        ElseIf (My.Settings.Bgistatus = 3) Then
            Bgiinf = (0.02827 * (callz(ggv, Tv, Pv)) * (Tv + 460)) / Pv
        End If
        If (My.Settings.Bgastatus = 1) Then
            Bgainf = Bgainv
        ElseIf (My.Settings.Bgastatus = 2) Then
            Bgainf = (0.02827 * Zbv * (Tbv + 460)) / Pbv
        ElseIf (My.Settings.Bgastatus = 3) Then
            Bgainf = (0.02827 * (callz(ggbv, Tbv, Pbv)) * (Tbv + 460)) / Pbv
        End If
        My.Settings.Bgival = Math.Round(Bgiinf, 6)
        My.Settings.Bgaval = Math.Round(Bgainf, 6)

        Gpv = 43560 * Av * Hv * (Phiv / 100) * (1 - Swiv) * ((1 / Bgiinf) - (1 / Bgainf))
        Gpv = Math.Round(Gpv, 2)
        Return Gpv
    End Function

    Private Sub bgiinputbtn_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles bgiinputbtn.MouseDown
        My.Settings.Bgistatus = 1
        voldataimg_Copy27.Visibility = Windows.Visibility.Visible
        Bgiin.Visibility = Windows.Visibility.Visible
        voldataimg_Copy3.Visibility = Windows.Visibility.Hidden
        gg.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy5.Visibility = Windows.Visibility.Hidden
        T.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy7.Visibility = Windows.Visibility.Hidden
        P.Visibility = Windows.Visibility.Hidden
        z.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy35.Visibility = Windows.Visibility.Hidden

        zbgicalcbtn.Visibility = Windows.Visibility.Hidden
        ubgicalcbtn.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub bgainputbtn_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles bgainputbtn.MouseDown
        My.Settings.Bgastatus = 1
        voldataimg_Copy28.Visibility = Windows.Visibility.Visible
        Bgain.Visibility = Windows.Visibility.Visible
        voldataimg_Copy4.Visibility = Windows.Visibility.Hidden
        ggb.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy6.Visibility = Windows.Visibility.Hidden
        Tb.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy8.Visibility = Windows.Visibility.Hidden
        Pb.Visibility = Windows.Visibility.Hidden
        zb.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy36.Visibility = Windows.Visibility.Hidden
        zbgacalcbtn.Visibility = Windows.Visibility.Hidden
        ubgacalcbtn.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub bgicalcbtn_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles bgicalcbtn.MouseDown
        Bgiin.Text = "0"
        voldataimg_Copy27.Visibility = Windows.Visibility.Hidden
        Bgiin.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy3.Visibility = Windows.Visibility.Hidden
        gg.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy5.Visibility = Windows.Visibility.Hidden
        T.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy7.Visibility = Windows.Visibility.Hidden
        P.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy35.Visibility = Windows.Visibility.Hidden
        z.Visibility = Windows.Visibility.Hidden

        zbgicalcbtn.Visibility = Windows.Visibility.Visible
        ubgicalcbtn.Visibility = Windows.Visibility.Visible
    End Sub

    Private Sub bgacalcbtn_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles bgacalcbtn.MouseDown
        Bgain.Text = "0"
        voldataimg_Copy28.Visibility = Windows.Visibility.Hidden
        Bgain.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy4.Visibility = Windows.Visibility.Hidden
        ggb.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy6.Visibility = Windows.Visibility.Hidden
        Tb.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy8.Visibility = Windows.Visibility.Hidden
        Pb.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy36.Visibility = Windows.Visibility.Hidden
        zb.Visibility = Windows.Visibility.Hidden

        zbgacalcbtn.Visibility = Windows.Visibility.Visible
        ubgacalcbtn.Visibility = Windows.Visibility.Visible
    End Sub

    Private Sub zbgicalcbtn_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles zbgicalcbtn.MouseDown
        My.Settings.Bgistatus = 2
        voldataimg_Copy27.Visibility = Windows.Visibility.Hidden
        Bgiin.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy3.Visibility = Windows.Visibility.Hidden
        gg.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy35.Visibility = Windows.Visibility.Visible
        z.Visibility = Windows.Visibility.Visible
        voldataimg_Copy5.Visibility = Windows.Visibility.Visible
        T.Visibility = Windows.Visibility.Visible
        voldataimg_Copy7.Visibility = Windows.Visibility.Visible
        P.Visibility = Windows.Visibility.Visible
        zbgicalcbtn.Visibility = Windows.Visibility.Hidden
        ubgicalcbtn.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub zbgacalcbtn_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles zbgacalcbtn.MouseDown
        My.Settings.Bgastatus = 2
        voldataimg_Copy28.Visibility = Windows.Visibility.Hidden
        Bgain.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy4.Visibility = Windows.Visibility.Hidden
        ggb.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy6.Visibility = Windows.Visibility.Visible
        Tb.Visibility = Windows.Visibility.Visible
        voldataimg_Copy8.Visibility = Windows.Visibility.Visible
        Pb.Visibility = Windows.Visibility.Visible
        voldataimg_Copy36.Visibility = Windows.Visibility.Visible
        zb.Visibility = Windows.Visibility.Visible
        zbgacalcbtn.Visibility = Windows.Visibility.Hidden
        ubgacalcbtn.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub ubgicalcbtn_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles ubgicalcbtn.MouseDown
        My.Settings.Bgistatus = 3
        voldataimg_Copy27.Visibility = Windows.Visibility.Hidden
        Bgiin.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy3.Visibility = Windows.Visibility.Visible
        gg.Visibility = Windows.Visibility.Visible
        voldataimg_Copy35.Visibility = Windows.Visibility.Hidden
        z.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy5.Visibility = Windows.Visibility.Visible
        T.Visibility = Windows.Visibility.Visible
        voldataimg_Copy7.Visibility = Windows.Visibility.Visible
        P.Visibility = Windows.Visibility.Visible
        zbgicalcbtn.Visibility = Windows.Visibility.Hidden
        ubgicalcbtn.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub ubgacalcbtn_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles ubgacalcbtn.MouseDown
        My.Settings.Bgastatus = 3
        voldataimg_Copy28.Visibility = Windows.Visibility.Hidden
        Bgain.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy4.Visibility = Windows.Visibility.Visible
        ggb.Visibility = Windows.Visibility.Visible
        voldataimg_Copy6.Visibility = Windows.Visibility.Visible
        Tb.Visibility = Windows.Visibility.Visible
        voldataimg_Copy8.Visibility = Windows.Visibility.Visible
        Pb.Visibility = Windows.Visibility.Visible
        voldataimg_Copy36.Visibility = Windows.Visibility.Hidden
        zb.Visibility = Windows.Visibility.Hidden
        zbgacalcbtn.Visibility = Windows.Visibility.Hidden
        ubgacalcbtn.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub chart1btn_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles chart1btn.MouseDown
        My.Settings.Charterror = 0
        Dim Tv As Double
        Dim Pv As Double
        Dim ggv As Double
        Dim ggbv As Double
        Dim Tbv As Double
        Dim Pbv As Double
        Dim zv As Double
        Dim zbv As Double
        If (T.Text = "0" Or T.Text = "") Then
            Tv = 0
        Else
            Tv = T.Text
        End If
        If (P.Text = "0" Or P.Text = "") Then
            Pv = 0
        Else
            Pv = P.Text
        End If
        If (Tb.Text = "0" Or Tb.Text = "") Then
            Tbv = 0
        Else
            Tbv = Tb.Text
        End If
        If (Pb.Text = "0" Or Pb.Text = "") Then
            Pbv = 0
        Else
            Pbv = Pb.Text
        End If
        If (gg.Text = "0" Or gg.Text = "") Then
            ggv = 0
        Else
            ggv = gg.Text
        End If
        If (ggb.Text = "0" Or ggb.Text = "") Then
            ggbv = 0
        Else
            ggbv = ggb.Text
        End If
        If (z.Text = "0" Or z.Text = "") Then
            zv = 0
        Else
            zv = z.Text
        End If
        If (zb.Text = "0" Or zb.Text = "") Then
            zbv = 0
        Else
            zbv = zb.Text
        End If

        If (My.Settings.Bgistatus = 0 Or My.Settings.Bgastatus = 0 Or My.Settings.Bgistatus = 1 Or My.Settings.Bgastatus = 1) Then
            footererrorlabel.Visibility = Windows.Visibility.Visible
            footererrorlabel.Content = "Data Error 2711: For charts to be plotted, Bgi and Bga have to be calculated." & vbCrLf & "Hint : Click the 'Calculate value' Button."
            blinkstory2 = DirectCast(FindResource("blinkanim2"), Storyboard)
            blinkstory2.Begin()
            My.Settings.Charterror = 1
        Else
            If (My.Settings.Bgistatus = 2) Then
                If (Tv = 0 Or Pv = 0 Or zv = 0) Then
                    footererrorlabel.Content = "Data Error 2311: Data input error." & vbCrLf & "Hint : Click the 'Calculate value' Button."
                    footererrorlabel.Visibility = Windows.Visibility.Visible
                    blinkstory2 = DirectCast(FindResource("blinkanim2"), Storyboard)
                    blinkstory2.Begin()
                    My.Settings.Charterror = 1
                End If
            ElseIf (My.Settings.Bgistatus = 3) Then
                If (Tv = 0 Or Pv = 0 Or ggv = 0) Then
                    footererrorlabel.Content = "Data Error 2311: Data input error." & vbCrLf & "Hint : Click the 'Calculate value' Button."
                    footererrorlabel.Visibility = Windows.Visibility.Visible
                    blinkstory2 = DirectCast(FindResource("blinkanim2"), Storyboard)
                    blinkstory2.Begin()
                    My.Settings.Charterror = 1
                End If
            End If
            If (My.Settings.Bgastatus = 2) Then
                If (Tbv = 0 Or Pbv = 0 Or zbv = 0) Then
                    footererrorlabel.Content = "Data Error 2311: Data input error." & vbCrLf & "Hint : Click the 'Calculate value' Button."
                    footererrorlabel.Visibility = Windows.Visibility.Visible
                    blinkstory2 = DirectCast(FindResource("blinkanim2"), Storyboard)
                    blinkstory2.Begin()
                    My.Settings.Charterror = 1
                End If
            ElseIf (My.Settings.Bgastatus = 3) Then
                If (Tbv = 0 Or Pbv = 0 Or ggbv = 0) Then
                    footererrorlabel.Content = "Data Error 2311: Data input error." & vbCrLf & "Hint : Click the 'Calculate value' Button."
                    footererrorlabel.Visibility = Windows.Visibility.Visible
                    blinkstory2 = DirectCast(FindResource("blinkanim2"), Storyboard)
                    blinkstory2.Begin()
                    My.Settings.Charterror = 1
                End If
            End If
        End If
        If (A.Text = "" Or A.Text = "0") Then
            footererrorlabel.Content = "Data Error 2311: Data input error." & vbCrLf & "Hint : Check the Area, A, input box."
            footererrorlabel.Visibility = Windows.Visibility.Visible
            blinkstory2 = DirectCast(FindResource("blinkanim2"), Storyboard)
            blinkstory2.Begin()
            My.Settings.Charterror = 1
        End If
        If (H.Text = "" Or H.Text = "0") Then
            footererrorlabel.Content = "Data Error 2311: Data input error." & vbCrLf & "Hint : Check the Reservoir height, H, input box."
            footererrorlabel.Visibility = Windows.Visibility.Visible
            blinkstory2 = DirectCast(FindResource("blinkanim2"), Storyboard)
            blinkstory2.Begin()
            My.Settings.Charterror = 1
        End If
        If (Phi.Text = "" Or Phi.Text = "0") Then
            footererrorlabel.Content = "Data Error 2311: Data input error." & vbCrLf & "Hint : Check the Porosity, Φ, input box."
            footererrorlabel.Visibility = Windows.Visibility.Visible
            blinkstory2 = DirectCast(FindResource("blinkanim2"), Storyboard)
            blinkstory2.Begin()
            My.Settings.Charterror = 1
        End If
        If (Swi.Text = "" Or Swi.Text = "0") Then
            footererrorlabel.Content = "Data Error 2311: Data input error." & vbCrLf & "Hint : Check the Initial water saturation, Swi, input box."
            footererrorlabel.Visibility = Windows.Visibility.Visible
            blinkstory2 = DirectCast(FindResource("blinkanim2"), Storyboard)
            blinkstory2.Begin()
            My.Settings.Charterror = 1
        End If
        If (My.Settings.Charterror = 0) Then
            footererrorlabel.Visibility = Windows.Visibility.Hidden
            footererrorlabel.Content = "Error:"
            volumegridwrap.Visibility = Windows.Visibility.Hidden
            volumegridcharts.Visibility = Windows.Visibility.Visible

            myseries.Clear()
            myseries2.Clear()
            Try
                Dim Av As Double = A.Text
                Dim Hv As Double = H.Text
                Dim Phiv As Double = Phi.Text
                Dim Swiv As Double = Swi.Text

                Dim Bgiinv As Double = 0
                Dim Bgainv As Double = 0

                Dim Gv As Double
                Dim Gpv As Double
                Dim Rfv As Double
                Dim zo As Double
                Dim zvv As Double
                zo = zv

                voltable.Items.Clear()
                If (My.Settings.Bgistatus = 2 And My.Settings.Bgastatus = 2) Then
                    Dim Zcounter = (zbv - zv) / 10
                    For vP As Double = Pv To Pbv Step -((Pv - Pbv) / 10)
                        Gv = callvolumetricG(Av, Hv, Phiv, Swiv, Tv, Pv, ggv, Bgiinv, zo)
                        Gpv = callvolumetricGp(Av, Hv, Phiv, Swiv, Tv, Pv, ggv, Bgiinv, Bgainv, ggbv, Tbv, vP, zo, zv)
                        Rfv = Math.Round(((Gpv / Gv) * 100), 1)
                        voltable.Items.Add(New Cratedata(vP, (Math.Round((0.02827 * zv * (Tbv + 460) * (1 / vP)), 6)), Gv, Gpv, Rfv))
                        colpressure.Binding = New Binding("pressure")
                        colcompress.Binding = New Binding("compress")
                        colgiip.Binding = New Binding("giip")
                        colgprod.Binding = New Binding("gprod")
                        colrecovery.Binding = New Binding("recovery")

                        myseries.Add(New DataPoint((Math.Round((0.02827 * zv * (Tbv + 460) * (1 / vP)), 6)), vP))
                        myseries2.Add(New DataPoint(vP, Gpv))
                        zv = zv + Zcounter
                    Next
                Else
                    Gv = callvolumetricG(Av, Hv, Phiv, Swiv, Tv, Pv, ggv, Bgiinv, zv)
                    For vP As Double = Pv To Pbv Step -((Pv - Pbv) / 10)
                        Gpv = callvolumetricGp(Av, Hv, Phiv, Swiv, Tv, Pv, ggv, Bgiinv, Bgainv, ggbv, Tbv, vP, zv, zbv)
                        zvv = callz(ggv, Tv, vP)
                        Rfv = Math.Round(((Gpv / Gv) * 100), 1)

                        voltable.Items.Add(New Cratedata(vP, (Math.Round((0.02827 * zvv * (Tbv + 460) * (1 / vP)), 6)), Gv, Gpv, Rfv))
                        colpressure.Binding = New Binding("pressure")
                        colcompress.Binding = New Binding("compress")
                        colgiip.Binding = New Binding("giip")
                        colgprod.Binding = New Binding("gprod")
                        colrecovery.Binding = New Binding("recovery")

                        myseries.Add(New DataPoint((Math.Round((0.02827 * zvv * (Tbv + 460) * (1 / vP)), 6)), vP))
                        myseries2.Add(New DataPoint(vP, Gpv))

                    Next
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub chart2btn_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles chart2btn.MouseDown
        My.Settings.Charterror = 0
        Dim T1v As Double
        Dim P1v As Double
        Dim gg1v As Double
        Dim ggb1v As Double
        Dim Tb1v As Double
        Dim Pb1v As Double
        Dim z1v As Double
        Dim zb1v As Double
        If (T1.Text = "0" Or T1.Text = "") Then
            T1v = 0
        Else
            T1v = T1.Text
        End If
        If (P1.Text = "0" Or P1.Text = "") Then
            P1v = 0
        Else
            P1v = P1.Text
        End If
        If (Tb1.Text = "0" Or Tb1.Text = "") Then
            Tb1v = 0
        Else
            Tb1v = Tb1.Text
        End If
        If (Pb1.Text = "0" Or Pb1.Text = "") Then
            Pb1v = 0
        Else
            Pb1v = Pb1.Text
        End If
        If (gg1.Text = "0" Or gg1.Text = "") Then
            gg1v = 0
        Else
            gg1v = gg1.Text
        End If
        If (ggb1.Text = "0" Or ggb1.Text = "") Then
            ggb1v = 0
        Else
            ggb1v = ggb1.Text
        End If
        If (z1.Text = "0" Or z1.Text = "") Then
            z1v = 0
        Else
            z1v = z1.Text
        End If
        If (zb1.Text = "0" Or zb1.Text = "") Then
            zb1v = 0
        Else
            zb1v = zb1.Text
        End If

        If (My.Settings.Bgistatus = 0 Or My.Settings.Bgastatus = 0 Or My.Settings.Bgistatus = 1 Or My.Settings.Bgastatus = 1) Then
            footererrorlabel.Visibility = Windows.Visibility.Visible
            footererrorlabel.Content = "Data Error 2711: For charts to be plotted, Bg and Bgi have to be calculated." & vbCrLf & "Hint : Click the 'Calculate value' Button."
            blinkstory2 = DirectCast(FindResource("blinkanim2"), Storyboard)
            blinkstory2.Begin()
            My.Settings.Charterror = 1
        Else
            If (My.Settings.Bgistatus = 2) Then
                If (T1v = 0 Or P1v = 0 Or z1v = 0) Then
                    footererrorlabel.Content = "Data Error 2311: Data input error." & vbCrLf & "Hint : Click the 'Calculate value' Button."
                    footererrorlabel.Visibility = Windows.Visibility.Visible
                    blinkstory2 = DirectCast(FindResource("blinkanim2"), Storyboard)
                    blinkstory2.Begin()
                    My.Settings.Charterror = 1
                End If
            ElseIf (My.Settings.Bgistatus = 3) Then
                If (T1v = 0 Or P1v = 0 Or gg1v = 0) Then
                    footererrorlabel.Content = "Data Error 2311: Data input error." & vbCrLf & "Hint : Click the 'Calculate value' Button."
                    footererrorlabel.Visibility = Windows.Visibility.Visible
                    blinkstory2 = DirectCast(FindResource("blinkanim2"), Storyboard)
                    blinkstory2.Begin()
                    My.Settings.Charterror = 1
                End If
            End If
            If (My.Settings.Bgastatus = 2) Then
                If (Tb1v = 0 Or Pb1v = 0 Or zb1v = 0) Then
                    footererrorlabel.Content = "Data Error 2311: Data input error." & vbCrLf & "Hint : Click the 'Calculate value' Button."
                    blinkstory2 = DirectCast(FindResource("blinkanim2"), Storyboard)
                    blinkstory2.Begin()
                    My.Settings.Charterror = 1
                End If
            ElseIf (My.Settings.Bgastatus = 3) Then
                If (Tb1v = 0 Or Pb1v = 0 Or ggb1v = 0) Then
                    footererrorlabel.Content = "Data Error 2311: Data input error." & vbCrLf & "Hint : Click the 'Calculate value' Button."
                    footererrorlabel.Visibility = Windows.Visibility.Visible
                    blinkstory2 = DirectCast(FindResource("blinkanim2"), Storyboard)
                    blinkstory2.Begin()
                    My.Settings.Charterror = 1
                End If
            End If
        End If
        If (GP.Text = "" Or GP.Text = "0") Then
            footererrorlabel.Content = "Data Error 2311: Data input error." & vbCrLf & "Hint : Check the Gas produced, Gp, input box."
            footererrorlabel.Visibility = Windows.Visibility.Visible
            blinkstory2 = DirectCast(FindResource("blinkanim2"), Storyboard)
            blinkstory2.Begin()
            My.Settings.Charterror = 1
        End If
        If (Bw.Text = "" Or Bw.Text = "0") Then
            footererrorlabel.Content = "Data Error 2311: Data input error." & vbCrLf & "Hint : Check the Reservoir height, h, input box."
            footererrorlabel.Visibility = Windows.Visibility.Visible
            blinkstory2 = DirectCast(FindResource("blinkanim2"), Storyboard)
            blinkstory2.Begin()
            My.Settings.Charterror = 1
        End If
        If (We.Text = "" Or We.Text = "0") Then
            footererrorlabel.Content = "Data Error 2311: Data input error." & vbCrLf & "Hint : Check the Porosity input box."
            footererrorlabel.Visibility = Windows.Visibility.Visible
            blinkstory2 = DirectCast(FindResource("blinkanim2"), Storyboard)
            blinkstory2.Begin()
            My.Settings.Charterror = 1
        End If
        If (Wp.Text = "" Or Wp.Text = "0") Then
            footererrorlabel.Content = "Data Error 2311: Data input error." & vbCrLf & "Hint : Check the Initial water saturation input box."
            footererrorlabel.Visibility = Windows.Visibility.Visible
            blinkstory2 = DirectCast(FindResource("blinkanim2"), Storyboard)
            blinkstory2.Begin()
            My.Settings.Charterror = 1
        End If
        If (Ra.Text = "" Or Ra.Text = "0") Then
            footererrorlabel.Content = "Data Error 2311: Data input error." & vbCrLf & "Hint : Check the reservoir area input box."
            footererrorlabel.Visibility = Windows.Visibility.Visible
            blinkstory2 = DirectCast(FindResource("blinkanim2"), Storyboard)
            blinkstory2.Begin()
            My.Settings.Charterror = 1
        End If

        If (My.Settings.Charterror = 0) Then
            footererrorlabel.Visibility = Windows.Visibility.Hidden
            footererrorlabel.Content = "Error:"
            wwigridwrap.Visibility = Windows.Visibility.Hidden
            wwigridcharts.Visibility = Windows.Visibility.Visible

            myseries3.Clear()
            Try
                Dim Gpv As Double = GP.Text
                Dim Bwv As Double = Bw.Text
                Dim Wev As Double = We.Text
                Dim Wpv As Double = Wp.Text
                Dim Rav As Double = Ra.Text

                Dim Bgiinv As Double = 0
                Dim Bgainv As Double = 0

                Dim Gv As Double
                Dim Gpvv As Double
                Dim Rfv As Double
                Dim zo As Double
                Dim zvv As Double
                Dim poverz As Double
                Dim Bgiinf As Double
                Dim Bgainf As Double
                Dim Gp0 As Double
                Dim Gp1 As Double
                Dim poverz0 As Double
                Dim poverz1 As Double
                zo = zb1v

                wwitable.Items.Clear()
                If (My.Settings.Bgistatus = 2 And My.Settings.Bgastatus = 2) Then
                    Dim Zcounter = ((z1v - zb1v) / (Pb1v - P1v)) * 100
                    Gv = callvolumetricG(Rav, Bwv, Wev, Wpv, Tb1v, Pb1v, ggb1v, Bgainv, zo)
                    For vP As Double = Pb1v To (Pb1v - 900) Step -100
                        Bgiinv = (0.02827 * zb1v * (Tb1v + 460)) / vP
                        Bgainv = (0.02827 * zo * (Tb1v + 460)) / Pb1v
                        Gpvv = Math.Round(callvolumetricGp(Rav, Bwv, Wev, Wpv, Tb1v, Pb1v, ggb1v, Bgainv, Bgiinv, gg1v, T1v, vP, zo, z1v), 2)
                        poverz = Math.Round((vP / z1v), 1)
                        Rfv = Math.Round(((Gpvv * Bgiinv) - (Gv * (Bgiinv - Bgainv))), 2)

                        wwitable.Items.Add(New Cratedata2(vP, Math.Round(zb1v, 5), poverz, Rfv, Math.Round(Gpvv - (Rfv / Bgiinv), 2)))
                        colpressure1.Binding = New Binding("pressure")
                        colcompress1.Binding = New Binding("compress")
                        colpoverz1.Binding = New Binding("poverz")
                        colgprod1.Binding = New Binding("gprod")
                        colrecovery1.Binding = New Binding("recovery")

                        myseries3.Add(New DataPoint(poverz, Gpvv - (Rfv / Bgiinv)))
                        zb1v = zb1v + Zcounter

                        If (vP = Pb1v - 800) Then
                            poverz0 = poverz
                            Gp0 = Gpvv - (Rfv / Bgiinv)
                        End If
                        If (vP = Pb1v - 900) Then
                            poverz1 = poverz
                            Gp1 = Gpvv - (Rfv / Bgiinv)
                        End If
                    Next
                    myseries3.Add(New DataPoint(0, (Gp1 + ((Gp1 - Gp0) / (poverz0 - poverz1)) * poverz1)))
                    statuslabel.Visibility = Windows.Visibility.Visible
                    statuslabel.Content = "Extrapolating the plot of P/z against We to 0 shows G to be " + Math.Round((Gp1 + ((Gp1 - Gp0) / (poverz0 - poverz1)) * poverz1), 2).ToString + " SCF, as against " + Gv.ToString + " SCF gotten from using the formula."
                    blinkstory3 = DirectCast(FindResource("blinkanim3"), Storyboard)
                    blinkstory3.Begin()

                Else
                    Gv = callvolumetricG(Rav, Bwv, Wev, Wpv, Tb1v, Pb1v, ggb1v, Bgainv, zo)
                    For vP As Double = Pb1v To (Pb1v - 900) Step -100
                        If (My.Settings.Bgistatus = 2) Then
                            Bgiinf = (0.02827 * z1v * (T1v + 460)) / vP
                            zvv = z1v
                        ElseIf (My.Settings.Bgistatus = 3) Then
                            Bgiinf = (0.02827 * (callz(gg1v, T1v, vP)) * (T1v + 460)) / vP
                            zvv = callz(gg1v, T1v, vP)
                        End If
                        If (My.Settings.Bgastatus = 2) Then
                            Bgainf = (0.02827 * zb1v * (Tb1v + 460)) / Pb1v
                        ElseIf (My.Settings.Bgastatus = 3) Then
                            Bgainf = (0.02827 * (callz(ggb1v, Tb1v, Pb1v)) * (Tb1v + 460)) / Pb1v
                        End If

                        Gpvv = Math.Round(callvolumetricGp(Rav, Bwv, Wev, Wpv, Tb1v, Pb1v, ggb1v, Bgainv, Bgiinv, gg1v, T1v, vP, zo, z1v), 2)
                        Gpvv = Math.Round(callvolumetricGp(Rav, Bwv, Wev, Wpv, Tb1v, Pb1v, ggb1v, Bgainf, Bgiinf, gg1v, T1v, vP, zo, zb1v), 2)
                        poverz = Math.Round((vP / zvv), 1)
                        Rfv = Math.Round(((Gpvv * Bgiinf) - Gv * (Bgainf - Bgiinf)), 2)

                        wwitable.Items.Add(New Cratedata2(vP, Math.Round(zvv, 5), poverz, Rfv, Math.Round(Gpvv - (Rfv / Bgainf), 2)))
                        colpressure1.Binding = New Binding("pressure")
                        colcompress1.Binding = New Binding("compress")
                        colpoverz1.Binding = New Binding("poverz")
                        colgprod1.Binding = New Binding("gprod")
                        colrecovery1.Binding = New Binding("recovery")

                        myseries3.Add(New DataPoint(poverz, Gpvv - (Rfv / Bgiinf)))
                        If (vP = Pb1v - 800) Then
                            poverz0 = poverz
                            Gp0 = Gpvv - (Rfv / Bgiinf)
                        End If
                        If (vP = Pb1v - 900) Then
                            poverz1 = poverz
                            Gp1 = Gpvv - (Rfv / Bgiinf)
                        End If

                    Next
                    myseries3.Add(New DataPoint(0, (Gp1 + ((Gp1 - Gp0) / (poverz0 - poverz1)) * poverz1)))
                    statuslabel.Visibility = Windows.Visibility.Visible
                    statuslabel.Content = "Extrapolating the plot of P/z against We to 0 shows G to be " + Math.Round((Gp1 + ((Gp1 - Gp0) / (poverz0 - poverz1)) * poverz1), 2).ToString + " SCF, as against " + Gv.ToString + " SCF gotten from using the formula."
                    blinkstory3 = DirectCast(FindResource("blinkanim3"), Storyboard)
                    blinkstory3.Begin()
                End If

            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub chart3btn_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles chart3btn.MouseDown
        My.Settings.Charterror = 0
        Dim T2v As Double
        Dim P2v As Double
        Dim gg2v As Double
        Dim ggb2v As Double
        Dim Tb2v As Double
        Dim Pb2v As Double
        Dim z2v As Double
        Dim zb2v As Double
        If (T2.Text = "0" Or T2.Text = "") Then
            T2v = 0
        Else
            T2v = T2.Text
        End If
        If (P2.Text = "0" Or P2.Text = "") Then
            P2v = 0
        Else
            P2v = P2.Text
        End If
        If (Tb2.Text = "0" Or Tb2.Text = "") Then
            Tb2v = 0
        Else
            Tb2v = Tb2.Text
        End If
        If (Pb2.Text = "0" Or Pb2.Text = "") Then
            Pb2v = 0
        Else
            Pb2v = Pb2.Text
        End If
        If (gg2.Text = "0" Or gg2.Text = "") Then
            gg2v = 0
        Else
            gg2v = gg2.Text
        End If
        If (ggb2.Text = "0" Or ggb2.Text = "") Then
            ggb2v = 0
        Else
            ggb2v = ggb2.Text
        End If
        If (z2.Text = "0" Or z2.Text = "") Then
            z2v = 0
        Else
            z2v = z2.Text
        End If
        If (zb2.Text = "0" Or zb2.Text = "") Then
            zb2v = 0
        Else
            zb2v = zb2.Text
        End If

        If (My.Settings.Bgistatus = 0 Or My.Settings.Bgastatus = 0 Or My.Settings.Bgistatus = 1 Or My.Settings.Bgastatus = 1) Then
            footererrorlabel.Visibility = Windows.Visibility.Visible
            footererrorlabel.Content = "Data Error 2711: For charts to be plotted, Bg and Bgi have to be calculated." & vbCrLf & "Hint : Click the 'Calculate value' Button."
            blinkstory2 = DirectCast(FindResource("blinkanim2"), Storyboard)
            blinkstory2.Begin()
            My.Settings.Charterror = 1
        Else
            If (My.Settings.Bgistatus = 2) Then
                If (T2v = 0 Or P2v = 0 Or z2v = 0) Then
                    footererrorlabel.Content = "Data Error 2311: Data input error." & vbCrLf & "Hint : Click the 'Calculate value' Button."
                    footererrorlabel.Visibility = Windows.Visibility.Visible
                    blinkstory2 = DirectCast(FindResource("blinkanim2"), Storyboard)
                    blinkstory2.Begin()
                    My.Settings.Charterror = 1
                End If
            ElseIf (My.Settings.Bgistatus = 3) Then
                If (T2v = 0 Or P2v = 0 Or gg2v = 0) Then
                    footererrorlabel.Content = "Data Error 2311: Data input error." & vbCrLf & "Hint : Click the 'Calculate value' Button."
                    footererrorlabel.Visibility = Windows.Visibility.Visible
                    blinkstory2 = DirectCast(FindResource("blinkanim2"), Storyboard)
                    blinkstory2.Begin()
                    My.Settings.Charterror = 1
                End If
            End If
            If (My.Settings.Bgastatus = 2) Then
                If (Tb2v = 0 Or Pb2v = 0 Or zb2v = 0) Then
                    footererrorlabel.Content = "Data Error 2311: Data input error." & vbCrLf & "Hint : Click the 'Calculate value' Button."
                    footererrorlabel.Visibility = Windows.Visibility.Visible
                    blinkstory2 = DirectCast(FindResource("blinkanim2"), Storyboard)
                    blinkstory2.Begin()
                    My.Settings.Charterror = 1
                End If
            ElseIf (My.Settings.Bgastatus = 3) Then
                If (Tb2v = 0 Or Pb2v = 0 Or ggb2v = 0) Then
                    footererrorlabel.Content = "Data Error 2311: Data input error." & vbCrLf & "Hint : Click the 'Calculate value' Button."
                    footererrorlabel.Visibility = Windows.Visibility.Visible
                    blinkstory2 = DirectCast(FindResource("blinkanim2"), Storyboard)
                    blinkstory2.Begin()
                    My.Settings.Charterror = 1
                End If
            End If
        End If

        If (Gp1.Text = "" Or Gp1.Text = "0") Then
            footererrorlabel.Content = "Data Error 2311: Data input error." & vbCrLf & "Hint : Check the Gas produced, Gp, input box."
            footererrorlabel.Visibility = Windows.Visibility.Visible
            blinkstory2 = DirectCast(FindResource("blinkanim2"), Storyboard)
            blinkstory2.Begin()
            My.Settings.Charterror = 1
        End If

        If (My.Settings.Charterror = 0) Then
            footererrorlabel.Visibility = Windows.Visibility.Hidden
            footererrorlabel.Content = "Error:"
            wowgridwrap.Visibility = Windows.Visibility.Hidden
            wowgridcharts.Visibility = Windows.Visibility.Visible

            myseries4.Clear()
            Try
                Dim Gpv As Double = Gp1.Text

                Dim Bgiinv As Double = 0
                Dim Bgainv As Double = 0

                Dim Gv As Double
                Dim Gpvv As Double
                Dim Rfv As Double
                Dim zo As Double
                Dim zvv As Double
                Dim poverz As Double
                Dim Bgiinf As Double
                Dim Bgainf As Double
                Dim poverz0 As Double
                Dim poverz1 As Double
                Dim Gp0 As Double
                Dim Gp11 As Double
                zo = zb2v

                wowtable.Items.Clear()
                If (My.Settings.Bgistatus = 2 And My.Settings.Bgastatus = 2) Then
                    Dim Zcounter = ((z2v - zb2v) / (Pb2v - P2v)) * 100
                    Gv = callwowG(Gpv, Bgiinv, Bgainv, gg2v, ggb2v, T2v, P2v, Tb2v, Pb2v, z2v, zb2v)
                    For vP As Double = Pb2v To (Pb2v - 900) Step -100
                        Bgiinv = (0.02827 * zb2v * (T2v + 460)) / vP
                        Bgainv = (0.02827 * zo * (Tb2v + 460)) / Pb2v
                        Gpvv = Math.Round(((Gv * (Bgiinv - Bgainv)) / Bgiinv), 2)
                        poverz = Math.Round((vP / z2v), 1)
                        Rfv = Math.Round(((Gpvv / Gv) * 100), 1)

                        wowtable.Items.Add(New Cratedata2(vP, Math.Round(zb2v, 5), poverz, Gpvv, Rfv))
                        colpressure2.Binding = New Binding("pressure")
                        colcompress2.Binding = New Binding("compress")
                        colpoverz2.Binding = New Binding("poverz")
                        colgprod2.Binding = New Binding("gprod")
                        colrecovery2.Binding = New Binding("recovery")

                        myseries4.Add(New DataPoint(vP, Gpvv))
                        zb2v = zb2v + Zcounter
                        If (vP = Pb2v - 800) Then
                            poverz0 = poverz
                            Gp0 = Gpvv
                        End If
                        If (vP = Pb2v - 900) Then
                            poverz1 = poverz
                            Gp11 = Gpvv
                        End If
                    Next
                    myseries4.Add(New DataPoint(0, (Gp11 + ((Gp11 - Gp0) / (poverz0 - poverz1)) * poverz1)))
                    statuslabel.Visibility = Windows.Visibility.Visible
                    statuslabel.Content = "Extrapolating the plot of P/z against Gp to 0 shows G to be " + Math.Round((Gp11 + ((Gp11 - Gp0) / (poverz0 - poverz1)) * poverz1), 2).ToString + " SCF, as against " + Gv.ToString + " SCF gotten from using the formula."
                    blinkstory3 = DirectCast(FindResource("blinkanim3"), Storyboard)
                    blinkstory3.Begin()
                Else
                    Gv = callwowG(Gpv, Bgiinv, Bgainv, gg2v, ggb2v, T2v, P2v, Tb2v, Pb2v, zo, zb2v)
                    For vP As Double = Pb2v To (Pb2v - 900) Step -100
                        If (My.Settings.Bgistatus = 2) Then
                            Bgiinf = (0.02827 * z2v * (T2v + 460)) / vP
                            zvv = z2v
                        ElseIf (My.Settings.Bgistatus = 3) Then
                            Bgiinf = (0.02827 * (callz(gg2v, T2v, vP)) * (T2v + 460)) / vP
                            zvv = callz(gg2v, T2v, vP)
                        End If
                        If (My.Settings.Bgastatus = 2) Then
                            Bgainf = (0.02827 * zb2v * (Tb2v + 460)) / Pb2v
                        ElseIf (My.Settings.Bgastatus = 3) Then
                            Bgainf = (0.02827 * (callz(ggb2v, Tb2v, Pb2v)) * (Tb2v + 460)) / Pb2v
                        End If

                        Gpvv = Math.Round(((Gv * (Bgiinf - Bgainf)) / Bgiinf), 2)
                        poverz = Math.Round((vP / zvv), 1)
                        Rfv = Math.Round(((Gpvv / Gv) * 100), 1)

                        wowtable.Items.Add(New Cratedata2(vP, Math.Round(zvv, 5), poverz, Gpvv, Rfv))
                        colpressure2.Binding = New Binding("pressure")
                        colcompress2.Binding = New Binding("compress")
                        colpoverz2.Binding = New Binding("poverz")
                        colgprod2.Binding = New Binding("gprod")
                        colrecovery2.Binding = New Binding("recovery")

                        myseries4.Add(New DataPoint(vP, Gpvv))
                        If (vP = Pb2v - 800) Then
                            poverz0 = poverz
                            Gp0 = Gpvv
                        End If
                        If (vP = Pb2v - 900) Then
                            poverz1 = poverz
                            Gp11 = Gpvv
                        End If
                    Next
                    myseries4.Add(New DataPoint(0, (Gp11 + ((Gp11 - Gp0) / (poverz0 - poverz1)) * poverz1)))
                    statuslabel.Visibility = Windows.Visibility.Visible
                    statuslabel.Content = "Extrapolating the plot of P/z against Gp to 0 shows G to be " + Math.Round((Gp11 + ((Gp11 - Gp0) / (poverz0 - poverz1)) * poverz1), 2).ToString + " SCF, as against " + Gv.ToString + " SCF gotten from using the formula."
                    blinkstory3 = DirectCast(FindResource("blinkanim3"), Storyboard)
                    blinkstory3.Begin()
                End If

            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub bgiinputbtn1_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles bgiinputbtn1.MouseDown
        My.Settings.Bgistatus = 1
        voldataimg_Copy29.Visibility = Windows.Visibility.Visible
        Bgiin1.Visibility = Windows.Visibility.Visible
        voldataimg_Copy12.Visibility = Windows.Visibility.Hidden
        gg1.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy14.Visibility = Windows.Visibility.Hidden
        T1.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy16.Visibility = Windows.Visibility.Hidden
        P1.Visibility = Windows.Visibility.Hidden
        z1.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy34.Visibility = Windows.Visibility.Hidden

        zbgicalcbtn1.Visibility = Windows.Visibility.Hidden
        ubgicalcbtn1.Visibility = Windows.Visibility.Hidden

    End Sub

    Private Sub bgicalcbtn1_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles bgicalcbtn1.MouseDown
        Bgiin1.Text = "0"
        voldataimg_Copy29.Visibility = Windows.Visibility.Hidden
        Bgiin1.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy12.Visibility = Windows.Visibility.Hidden
        gg1.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy14.Visibility = Windows.Visibility.Hidden
        T1.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy16.Visibility = Windows.Visibility.Hidden
        P1.Visibility = Windows.Visibility.Hidden
        z1.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy33.Visibility = Windows.Visibility.Hidden

        zbgicalcbtn1.Visibility = Windows.Visibility.Visible
        ubgicalcbtn1.Visibility = Windows.Visibility.Visible
    End Sub

    Private Sub bgainputbtn1_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles bgainputbtn1.MouseDown
        My.Settings.Bgastatus = 1
        voldataimg_Copy30.Visibility = Windows.Visibility.Visible
        Bgain1.Visibility = Windows.Visibility.Visible
        voldataimg_Copy13.Visibility = Windows.Visibility.Hidden
        ggb1.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy15.Visibility = Windows.Visibility.Hidden
        Tb1.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy17.Visibility = Windows.Visibility.Hidden
        Pb1.Visibility = Windows.Visibility.Hidden
        zb1.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy34.Visibility = Windows.Visibility.Hidden

        zbgacalcbtn1.Visibility = Windows.Visibility.Hidden
        ubgacalcbtn1.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub bgacalcbtn1_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles bgacalcbtn1.MouseDown
        Bgain1.Text = "0"
        voldataimg_Copy30.Visibility = Windows.Visibility.Hidden
        Bgain1.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy13.Visibility = Windows.Visibility.Hidden
        ggb1.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy15.Visibility = Windows.Visibility.Hidden
        Tb1.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy17.Visibility = Windows.Visibility.Hidden
        Pb1.Visibility = Windows.Visibility.Hidden
        zb1.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy34.Visibility = Windows.Visibility.Hidden

        zbgacalcbtn1.Visibility = Windows.Visibility.Visible
        ubgacalcbtn1.Visibility = Windows.Visibility.Visible
    End Sub

    Private Sub zbgicalcbtn1_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles zbgicalcbtn1.MouseDown
        My.Settings.Bgistatus = 2
        voldataimg_Copy29.Visibility = Windows.Visibility.Hidden
        Bgiin1.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy12.Visibility = Windows.Visibility.Hidden
        gg1.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy14.Visibility = Windows.Visibility.Visible
        T1.Visibility = Windows.Visibility.Visible
        voldataimg_Copy16.Visibility = Windows.Visibility.Visible
        P1.Visibility = Windows.Visibility.Visible
        z1.Visibility = Windows.Visibility.Visible
        voldataimg_Copy33.Visibility = Windows.Visibility.Visible

        zbgicalcbtn1.Visibility = Windows.Visibility.Hidden
        ubgicalcbtn1.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub ubgicalcbtn1_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles ubgicalcbtn1.MouseDown
        My.Settings.Bgistatus = 3
        voldataimg_Copy29.Visibility = Windows.Visibility.Hidden
        Bgiin1.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy12.Visibility = Windows.Visibility.Visible
        gg1.Visibility = Windows.Visibility.Visible
        voldataimg_Copy14.Visibility = Windows.Visibility.Visible
        T1.Visibility = Windows.Visibility.Visible
        voldataimg_Copy16.Visibility = Windows.Visibility.Visible
        P1.Visibility = Windows.Visibility.Visible
        z1.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy33.Visibility = Windows.Visibility.Hidden

        zbgicalcbtn1.Visibility = Windows.Visibility.Hidden
        ubgicalcbtn1.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub zbgacalcbtn1_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles zbgacalcbtn1.MouseDown
        My.Settings.Bgastatus = 2
        Bgain1.Text = "0"
        voldataimg_Copy30.Visibility = Windows.Visibility.Hidden
        Bgain1.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy13.Visibility = Windows.Visibility.Hidden
        ggb1.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy15.Visibility = Windows.Visibility.Visible
        Tb1.Visibility = Windows.Visibility.Visible
        voldataimg_Copy17.Visibility = Windows.Visibility.Visible
        Pb1.Visibility = Windows.Visibility.Visible
        zb1.Visibility = Windows.Visibility.Visible
        voldataimg_Copy34.Visibility = Windows.Visibility.Visible

        zbgacalcbtn1.Visibility = Windows.Visibility.Hidden
        ubgacalcbtn1.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub ubgacalcbtn1_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles ubgacalcbtn1.MouseDown
        My.Settings.Bgastatus = 3
        Bgain1.Text = "0"
        voldataimg_Copy30.Visibility = Windows.Visibility.Hidden
        Bgain1.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy13.Visibility = Windows.Visibility.Visible
        ggb1.Visibility = Windows.Visibility.Visible
        voldataimg_Copy15.Visibility = Windows.Visibility.Visible
        Tb1.Visibility = Windows.Visibility.Visible
        voldataimg_Copy17.Visibility = Windows.Visibility.Visible
        Pb1.Visibility = Windows.Visibility.Visible
        zb1.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy34.Visibility = Windows.Visibility.Hidden

        zbgacalcbtn1.Visibility = Windows.Visibility.Hidden
        ubgacalcbtn1.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub bgiinputbtn2_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles bgiinputbtn2.MouseDown
        My.Settings.Bgistatus = 1
        voldataimg_Copy18.Visibility = Windows.Visibility.Visible
        bgiin2.Visibility = Windows.Visibility.Visible
        voldataimg_Copy21.Visibility = Windows.Visibility.Hidden
        gg2.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy23.Visibility = Windows.Visibility.Hidden
        T2.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy25.Visibility = Windows.Visibility.Hidden
        P2.Visibility = Windows.Visibility.Hidden
        z2.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy31.Visibility = Windows.Visibility.Hidden

        zbgicalcbtn2.Visibility = Windows.Visibility.Hidden
        ubgicalcbtn2.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub bgainputbtn2_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles bgainputbtn2.MouseDown
        My.Settings.Bgastatus = 1
        voldataimg_Copy20.Visibility = Windows.Visibility.Visible
        Bgain2.Visibility = Windows.Visibility.Visible
        voldataimg_Copy22.Visibility = Windows.Visibility.Hidden
        ggb2.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy24.Visibility = Windows.Visibility.Hidden
        Tb2.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy26.Visibility = Windows.Visibility.Hidden
        Pb2.Visibility = Windows.Visibility.Hidden
        zb2.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy32.Visibility = Windows.Visibility.Hidden

        zbgacalcbtn2.Visibility = Windows.Visibility.Hidden
        ubgacalcbtn2.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub bgicalcbtn2_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles bgicalcbtn2.MouseDown
        bgiin2.Text = "0"
        voldataimg_Copy18.Visibility = Windows.Visibility.Hidden
        bgiin2.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy21.Visibility = Windows.Visibility.Hidden
        gg2.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy23.Visibility = Windows.Visibility.Hidden
        T2.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy25.Visibility = Windows.Visibility.Hidden
        P2.Visibility = Windows.Visibility.Hidden
        z2.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy31.Visibility = Windows.Visibility.Hidden

        zbgicalcbtn2.Visibility = Windows.Visibility.Visible
        ubgicalcbtn2.Visibility = Windows.Visibility.Visible
    End Sub

    Private Sub bgacalcbtn2_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles bgacalcbtn2.MouseDown
        Bgain2.Text = "0"
        voldataimg_Copy20.Visibility = Windows.Visibility.Hidden
        Bgain2.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy22.Visibility = Windows.Visibility.Hidden
        ggb2.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy24.Visibility = Windows.Visibility.Hidden
        Tb2.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy26.Visibility = Windows.Visibility.Hidden
        Pb2.Visibility = Windows.Visibility.Hidden
        zb2.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy32.Visibility = Windows.Visibility.Hidden

        zbgacalcbtn2.Visibility = Windows.Visibility.Visible
        ubgacalcbtn2.Visibility = Windows.Visibility.Visible
    End Sub

    Private Sub zbgicalcbtn2_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles zbgicalcbtn2.MouseDown
        My.Settings.Bgistatus = 2
        voldataimg_Copy18.Visibility = Windows.Visibility.Hidden
        bgiin2.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy21.Visibility = Windows.Visibility.Hidden
        gg2.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy23.Visibility = Windows.Visibility.Visible
        T2.Visibility = Windows.Visibility.Visible
        voldataimg_Copy25.Visibility = Windows.Visibility.Visible
        P2.Visibility = Windows.Visibility.Visible
        z2.Visibility = Windows.Visibility.Visible
        voldataimg_Copy31.Visibility = Windows.Visibility.Visible

        zbgicalcbtn2.Visibility = Windows.Visibility.Hidden
        ubgicalcbtn2.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub ubgicalcbtn2_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles ubgicalcbtn2.MouseDown
        My.Settings.Bgistatus = 3
        voldataimg_Copy18.Visibility = Windows.Visibility.Hidden
        bgiin2.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy21.Visibility = Windows.Visibility.Visible
        gg2.Visibility = Windows.Visibility.Visible
        voldataimg_Copy23.Visibility = Windows.Visibility.Visible
        T2.Visibility = Windows.Visibility.Visible
        voldataimg_Copy25.Visibility = Windows.Visibility.Visible
        P2.Visibility = Windows.Visibility.Visible
        z2.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy31.Visibility = Windows.Visibility.Hidden

        zbgicalcbtn2.Visibility = Windows.Visibility.Hidden
        ubgicalcbtn2.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub zbgacalcbtn2_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles zbgacalcbtn2.MouseDown
        My.Settings.Bgastatus = 2
        voldataimg_Copy20.Visibility = Windows.Visibility.Hidden
        Bgain2.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy22.Visibility = Windows.Visibility.Hidden
        ggb2.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy24.Visibility = Windows.Visibility.Visible
        Tb2.Visibility = Windows.Visibility.Visible
        voldataimg_Copy26.Visibility = Windows.Visibility.Visible
        Pb2.Visibility = Windows.Visibility.Visible
        zb2.Visibility = Windows.Visibility.Visible
        voldataimg_Copy32.Visibility = Windows.Visibility.Visible

        zbgacalcbtn2.Visibility = Windows.Visibility.Hidden
        ubgacalcbtn2.Visibility = Windows.Visibility.Hidden
    End Sub

    Private Sub ubgacalcbtn2_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles ubgacalcbtn2.MouseDown
        My.Settings.Bgastatus = 3
        voldataimg_Copy20.Visibility = Windows.Visibility.Hidden
        Bgain2.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy22.Visibility = Windows.Visibility.Visible
        ggb2.Visibility = Windows.Visibility.Visible
        voldataimg_Copy24.Visibility = Windows.Visibility.Visible
        Tb2.Visibility = Windows.Visibility.Visible
        voldataimg_Copy26.Visibility = Windows.Visibility.Visible
        Pb2.Visibility = Windows.Visibility.Visible
        zb2.Visibility = Windows.Visibility.Hidden
        voldataimg_Copy32.Visibility = Windows.Visibility.Hidden

        zbgacalcbtn2.Visibility = Windows.Visibility.Hidden
        ubgacalcbtn2.Visibility = Windows.Visibility.Hidden
    End Sub
End Class
