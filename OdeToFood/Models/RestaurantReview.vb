Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

Public Class MaxWordsAttribute
    Inherits ValidationAttribute
    Private ReadOnly _maxWords As Integer
    Public Sub New(maxWords As Integer)

        MyBase.New("{0} has too many words")
        _maxWords = maxWords
    End Sub

    Protected Overrides Function IsValid(value As Object, validationContext As ValidationContext) As ValidationResult
        If Not (IsNothing(value)) Then
            Dim valueAsString = value.ToString()
            If valueAsString.Split(" ").Length() > _maxWords Then
                Dim errorMessage = FormatErrorMessage(validationContext.DisplayName)
                Return New ValidationResult(errorMessage)
            End If
        End If
        Return ValidationResult.Success
    End Function
End Class

Public Class RestaurantReview
    Implements IValidatableObject

    Public Property Id As Integer

    <Range(1, 10)>
    <Required>
    Public Property Rating As Integer
    <Required>
    <StringLength(1024)>
    Public Property Body As String
    <DisplayName("User Name")>
    <DisplayFormat(NullDisplayText:="anonymous")>
    <MaxWords(1)>
    Public Property Reviewer As String
    Public Property RestaurantId As Integer

    Public Iterator Function Validate(validationContext As ValidationContext) As IEnumerable(Of ValidationResult) Implements IValidatableObject.Validate
        If Rating < 2 And Reviewer.ToLower().StartsWith("scott") Then
            Yield New ValidationResult("Sorry Scott, you can't do this ")
        End If

    End Function
End Class
