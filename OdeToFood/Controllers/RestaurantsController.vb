﻿Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports OdeToFood

Namespace Controllers
    Public Class RestaurantsController
        Inherits System.Web.Mvc.Controller

        Private db As New OdeToFoodDb

        ' GET: Restaurants
        Function Index() As ActionResult
            Return View(db.Restaurants.ToList())
        End Function



        ' GET: Restaurants/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Restaurants/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Name,City,Country")> ByVal restaurant As Restaurant) As ActionResult
            If ModelState.IsValid Then
                db.Restaurants.Add(restaurant)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(restaurant)
        End Function

        ' GET: Restaurants/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim restaurant As Restaurant = db.Restaurants.Find(id)
            If IsNothing(restaurant) Then
                Return HttpNotFound()
            End If
            Return View(restaurant)
        End Function

        ' POST: Restaurants/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Name,City,Country")> ByVal restaurant As Restaurant) As ActionResult
            If ModelState.IsValid Then
                db.Entry(restaurant).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(restaurant)
        End Function

        ' GET: Restaurants/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim restaurant As Restaurant = db.Restaurants.Find(id)
            If IsNothing(restaurant) Then
                Return HttpNotFound()
            End If
            Return View(restaurant)
        End Function

        ' POST: Restaurants/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim restaurant As Restaurant = db.Restaurants.Find(id)
            db.Restaurants.Remove(restaurant)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
