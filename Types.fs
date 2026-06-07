namespace Types
open System

type Color = 
    | Red
    | Blue
    | Black

type Piece =
    {   Id: Guid
        Color: Color }

module Piece =
    let Create color = { Id = System.Guid.NewGuid(); Color = color }

type Bag =
    {   Red: int 
        Blue: int 
        Black: int
        Pieces: Piece array }

module Bag =
    let Create colors =
        let state =
            colors
            |> Array.fold
                (fun (state: {| Black: int; Blue: int; Pieces: Piece list; Red: int |}) color ->
                    let piece =
                        { Id = Guid.NewGuid()
                          Color = color }

                    match color with
                    | Red ->
                        {| state with
                            Pieces = piece :: state.Pieces
                            Red = state.Red + 1 |}

                    | Blue ->
                        {| state with
                            Pieces = piece :: state.Pieces
                            Blue = state.Blue + 1 |}

                    | Black ->
                        {| state with
                            Pieces = piece :: state.Pieces
                            Black = state.Black + 1 |})
                {| Pieces = []
                   Red = 0
                   Blue = 0
                   Black = 0 |}

        {
            Pieces = state.Pieces |> List.toArray |> Array.randomShuffle 
            Red = state.Red
            Blue = state.Blue
            Black = state.Black
        }
    let Total bag = 
        bag.Red + bag.Blue + bag.Black

    let AddPiece bag piece =
        match piece with 
        | Red -> { bag with Red = bag.Red + 1 }
        | Blue -> { bag with Blue = bag.Blue + 1 }
        | Black -> { bag with Black = bag.Black + 1 }

    let TakePiece bag =
        failwith "Need to look into how best to handle this"

type RegionWinner = 
    | Piece of Piece 
    | Tie

type Region =
    {   Id: int // This is unique to regions not move/attack?
        Red: int 
        Blue: int 
        Black: int
        Winner: RegionWinner }

module Region =
    let Total region = 
        region.Red + region.Blue + region.Black


module Stuff =
    let test : Region =
        {
            Id = 1
            Red = 1
            Blue = 2
            Black = 3
            Winner = Tie
        }   
