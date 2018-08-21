module Navbar.View

open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Global
open Types

let navButton classy href faClass =
  a [
      Href href ]
    [ span
        [ ClassName "icon" ]
        [ i
            [ ClassName (sprintf "navbar-social-icon fa %s" faClass) ]
            [ ] ]
    ]

let navButtons =
  [
    div [ClassName "navbar-item navbar-social"]
          [ navButton "twitter" "https://twitter.com/FableCompiler" "fa-twitter" ]
    div [ClassName "navbar-item navbar-social"] [
            navButton "github" "https://gitter.im/fable-compiler/Fable" "fa-commenting"  ]
  ]

let menuItem label page currentPage dispatch=
    a [
      classList ["navbar-item", true; "is-active", page = currentPage]
      Href (toHash page)
      OnClick (fun _ -> dispatch ToggleBurger)
    ] [str label]

let root currentPage (model: Model) dispatch =
  nav [ClassName "navbar"] [
    div [ClassName "navbar-brand"] [
      div [
        ClassName "navbar-burger"
        OnClick (fun _ -> dispatch ToggleBurger)
      ] [
        span [] []
        span [] []
        span [] []
      ]
    ]
    div [classList ["navbar-menu", true; "is-active", model.isBurgerOpen]] [
      div [ClassName "navbar-start"] [
        div [ClassName "navbar-item navbar-logo"] [
            img [ Src "img/logo_menu.png" ]
        ]
        menuItem "Home." Home currentPage dispatch
        // menuItem "Speakers." (Speakers None) currentPage
        // menuItem "Planning." Planning currentPage dispatch
        // menuItem "Food" Food currentPage
        menuItem "Location." Page.Location currentPage dispatch
      ]
      div [ClassName "navbar-end"] navButtons
    ]
  ]
