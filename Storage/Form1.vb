Imports Inventor
Imports System.Runtime.InteropServices

Public Class Storage

    Dim inventorApp As Inventor.Application
    Dim assemblies As AssemblyDocument
    Dim oCompOccurrences As ComponentOccurrences
    Dim oCompOccurrence As ComponentOccurrence
    Dim partComDef As PartComponentDefinition


    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.


        Try
            inventorApp = Marshal.GetActiveObject("Inventor.Application")

        Catch ex As Exception
            MessageBox.Show("cannot connect to Inventor")
        End Try

        assemblies = inventorApp.ActiveDocument
        oCompOccurrences = assemblies.ComponentDefinition.Occurrences


        oCompOccurrence = oCompOccurrences.ItemByName("Polka:1")

        partComDef = oCompOccurrence.Definition

        TextBox1.Text = partComDef.Parameters.Item("d0").Value * 10
        TextBox2.Text = partComDef.Parameters.Item("d1").Value * 10
        TextBox3.Text = assemblies.ComponentDefinition.Parameters.Item("d13").Value * 10
        TextBox4.Text = assemblies.ComponentDefinition.Parameters.Item("d15").Value
        TextBox5.Text = assemblies.ComponentDefinition.Parameters.Item("d23").Value

        assemblies.ComponentDefinition.Parameters.Item("d21").Value = partComDef.Parameters.Item("d0").Value


        oCompOccurrence = oCompOccurrences.ItemByName("Katownik:1")
        partComDef = oCompOccurrence.Definition
        partComDef.Parameters.Item("d1").Value = assemblies.ComponentDefinition.Parameters.Item("d15").Value * assemblies.ComponentDefinition.Parameters.Item("d13").Value
        partComDef.Parameters.Item("d40").Value = assemblies.ComponentDefinition.Parameters.Item("d15").Value
        partComDef.Parameters.Item("d42").Value = (assemblies.ComponentDefinition.Parameters.Item("d13").Value)


        assemblies.Update()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        oCompOccurrence = oCompOccurrences.ItemByName("Polka:1")

        partComDef = oCompOccurrence.Definition

        partComDef.Parameters.Item("d0").Value = (Convert.ToInt32(TextBox1.Text)) / 10
        partComDef.Parameters.Item("d1").Value = ((Convert.ToInt32(TextBox2.Text)) / 10 + 10)

        assemblies.ComponentDefinition.Parameters().Item("d15").Value = Convert.ToInt32(TextBox4.Text)

        assemblies.ComponentDefinition.Parameters.Item("d23").Value = Convert.ToInt32(TextBox5.Text)
        assemblies.ComponentDefinition.Parameters.Item("d21").Value = partComDef.Parameters.Item("d0").Value

        assemblies.ComponentDefinition.Parameters.Item("d13").Value = (Convert.ToInt32(TextBox3.Text)) / 10



        oCompOccurrence = oCompOccurrences.ItemByName("Katownik:1")
        partComDef = oCompOccurrence.Definition
        partComDef.Parameters.Item("d1").Value = assemblies.ComponentDefinition.Parameters.Item("d13").Value * assemblies.ComponentDefinition.Parameters.Item("d15").Value
        partComDef.Parameters.Item("d40").Value = assemblies.ComponentDefinition.Parameters.Item("d15").Value
        partComDef.Parameters.Item("d42").Value = (assemblies.ComponentDefinition.Parameters.Item("d13").Value)



        assemblies.Update()


    End Sub



End Class
