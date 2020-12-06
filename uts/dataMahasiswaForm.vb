Imports MySql.Data.MySqlClient

Public Class dataMahasiswaForm

    Private Sub dataMahasiswaForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tampil()
        Call aturdgvmahasiswa()
    End Sub

    Sub tampil()
        Try
            objdataAdo = New MySqlDataAdapter("SELECT * from tabelmahasiswa", objkoneksi)
            objDataSet = New DataSet
            objdataAdo.Fill(objDataSet, "mahasiswa")
            dgvMhs.DataSource = (objDataSet.Tables("mahasiswa"))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub aturdgvmahasiswa()
        Try
            dgvMhs.Columns(0).HeaderText = "NIM"
            dgvMhs.Columns(0).Width = 100

            dgvMhs.Columns(1).HeaderText = "NAMA"
            dgvMhs.Columns(1).Width = 300

            dgvMhs.Columns(2).HeaderText = "TEMPAT TANGGAL LAHIR"
            dgvMhs.Columns(2).Width = 100

            dgvMhs.Columns(3).HeaderText = "ALAMAT"
            dgvMhs.Columns(3).Width = 100

            dgvMhs.Columns(4).HeaderText = "NO HP"
            dgvMhs.Columns(4).Width = 100
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub bersihtextbox()
        txtNim.Text = ""
        txtNama.Text = ""
        txtTtl.Text = ""
        txtAlamat.Text = ""
        txtNohp.Text = ""
    End Sub

    Sub insertDataMhs()
        Try
            If txtNim.Text = "" Or txtNama.Text = "" Or txtTtl.Text = "" Or txtAlamat.Text = "" Or txtNohp.Text = "" Then
                MsgBox("Data belum lengkap!", MsgBoxStyle.Exclamation)
            Else
                Dim Query As String = "INSERT into tabelmahasiswa values ('" & txtNim.Text & "','" & txtNama.Text & "','" & txtTtl.Text & "','" & txtAlamat.Text & "','" & txtNohp.Text & "')"
                objcommand = New MySqlCommand(Query, objkoneksi)
                objcommand.ExecuteNonQuery()
                Call tampil()
                MsgBox("Data berhasil disimpan")
                Call bersihtextbox()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub deleteDataMhs()
        Dim nim As Integer
        nim = dgvMhs.Item(0, dgvMhs.CurrentRow.Index).Value
        Dim Query As String = "DELETE from tabelmahasiswa where nim = '" & nim & "'"
        objcommand = New MySqlCommand(Query, objkoneksi)
        objcommand.ExecuteNonQuery()
        MsgBox("Data berhasil dihapus")
        Call tampil()
    End Sub

    Sub muatDataMhs()
        With dgvMhs
            txtNim.Text = .Item(0, .CurrentRow.Index).Value
            txtNama.Text = .Item(1, .CurrentRow.Index).Value
            txtTtl.Text = .Item(2, .CurrentRow.Index).Value
            txtAlamat.Text = .Item(3, .CurrentRow.Index).Value
            txtNohp.Text = .Item(4, .CurrentRow.Index).Value
        End With
    End Sub

    Sub cari()
        Using objcommand = New MySqlCommand("SELECT * from tabelmahasiswa WHERE nama LIKE'%" & tstbCari.Text & "%'", objkoneksi)
            'tstbCari.Text = Nama Textbox yg digunakan
            Using objdataRd As MySqlDataReader = objcommand.ExecuteReader
                Using Tabel As New DataTable

                    Tabel.Load(objdataRd)
                    If Tabel.Rows.Count = 0 Then
                        dgvMhs.DataSource = Nothing
                    Else
                        dgvMhs.DataSource = Tabel
                        Call aturdgvmahasiswa()
                    End If

                End Using
            End Using
        End Using
    End Sub

    Sub updateDataMhs()
        Try
            If txtNim.Text = "" Or txtNama.Text = "" Or txtTtl.Text = "" Or txtAlamat.Text = "" Or txtNohp.Text = "" Then
                MsgBox("Data belum lengkap!", MsgBoxStyle.Exclamation)
            Else
                Dim Query As String = "UPDATE tabelmahasiswa SET nama = '" & txtNama.Text & "', ttl = '" & txtTtl.Text & "', alamat = '" & txtAlamat.Text & "', no_hp = '" & txtNohp.Text & "' WHERE nim = '" & txtNim.Text & "'"
                objcommand = New MySqlCommand(Query, objkoneksi)
                objcommand.ExecuteNonQuery()
                Call tampil()
                Call bersihtextbox()
                MsgBox("Data berhasil di update")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Call insertDataMhs()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Call updateDataMhs()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Call muatDataMhs()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Dim result As DialogResult = MessageBox.Show("Apakah anda yakin ?", "Informasi", MessageBoxButtons.YesNo)
        If (result = DialogResult.Yes) Then
            Call deleteDataMhs()
        End If
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Call bersihtextbox()
    End Sub


End Class