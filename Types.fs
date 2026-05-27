namespace Types

type Piece = 
    | Red
    | Blue
    | Black

type Bag =
    {   Red: int 
        Blue: int 
        Black: int }

module Bag =
    let Total bag = 
        bag.Red + bag.Blue + bag.Black

    let AddPiece bag piece =
        match piece with 
        | Red -> { bag with Red = bag.Red + 1 }
        | Blue -> { bag with Blue = bag.Blue + 1 }
        | Black -> { bag with Red = bag.Black + 1 }

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

Region.Total Stuff.test