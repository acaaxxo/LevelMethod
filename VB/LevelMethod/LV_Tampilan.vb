Module LV_Tampilan
    Sub Main()
        Dim p As rest = New rest("http://localhost/LevelMethod/")
        p.List("application/json")

    End Sub

End Module