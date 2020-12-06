Imports MySql.Data.MySqlClient

Public Class frmLogin
    Sub login()
        KoneksiDb.koneksi()
        objcommand = New MySqlCommand("SELECT * from tabellogin WHERE username = '" & txtUsername.Text & "' AND password = '" & txtPassword.Text & "'", objkoneksi)
        objdataRd = objcommand.ExecuteReader
        objdataRd.Read()

        If objdataRd.HasRows = True Then
            'MsgBox("Telah berhasil login!")
            MessageBox.Show("Login berhasil!", "Informasi")
            dataMasterForm.ShowDialog()
            txtUsername.Text = ""
            txtPassword.Text = ""
        Else
            MsgBox("Username atau Password salah!")
            txtUsername.Text = ""
            txtPassword.Text = ""
        End If
        Me.Close()
    End Sub

    Sub tampilPassword()
        If btnTampil.Text = "Tampil" Then
            txtPassword.UseSystemPasswordChar = False
            btnTampil.Text = "Sembunyikan"
        ElseIf btnTampil.Text = "Sembunyikan" Then
            txtPassword.UseSystemPasswordChar = True
            btnTampil.Text = "Tampil"
        End If
    End Sub


    Private Sub formLogin_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        txtPassword.UseSystemPasswordChar = True
        Me.BackColor = Color.FromArgb(240, 240, 240)
        Panel1.BackColor = Color.FromArgb(55, 152, 223)
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Call login()
    End Sub

    Private Sub btnTampil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTampil.Click
        Call tampilPassword()
    End Sub
End Class
