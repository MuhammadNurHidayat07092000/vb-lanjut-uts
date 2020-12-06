Public Class dataMasterForm
    Private Sub dataMasterForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        KoneksiDatabase.koneksi()
    End Sub

    Private Sub BarangToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BarangToolStripMenuItem.Click
        dataBarangForm.Show()
    End Sub
End Class