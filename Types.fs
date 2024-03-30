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

type RegionTemplate =
    {   Id: int // This is unique to regions not move/attack?
        Red: int 
        Blue: int 
        Black: int
        Winner: RegionWinner }

type Region = RegionTemplate
module RegionTemplate =
    let Total template = 
        template.Red + template.Blue + template.Black

module Region =
    let Total region = RegionTemplate.Total region

type Attackers = RegionTemplate

module Attackers =
    let Total attackers = RegionTemplate.Total attackers

type Movers = RegionTemplate

module Movers =
    let Total movers = RegionTemplate.Total movers

module Stuff =
    let test : Movers =
        {
            Red = 1
            Blue = 2
            Black = 3
        }   