namespace AdventOfCode2023.Day7;

public static class Part1
{
    public static void Run(string[] lines)
    {
       List<Hand> hands = lines.Select(GetHandFromInput).ToList();
       
       hands.Sort();
       
       int result = hands.Select((t, i) => (i + 1) * t.Bid).Sum();
       
       Console.WriteLine("Part 1: " + result);
    }
    
    
    //each hand has 5 cards (5 chars)
    public static Hand GetHandFromInput(string input)
    {
         var split = input.Split(' ');
         string cards = split[0];
         int bid = int.Parse(split[1]);
         
        //FiveOfAKind
        if(cards.All(x => x == cards[0]))
            return new Hand(cards, HandType.FiveOfAKind, bid);
        //FourOfAKind
        if(cards.GroupBy(x => x).Any(x => x.Count() == 4))
            return new Hand(cards, HandType.FourOfAKind, bid);
        //FullHouse
        if(cards.GroupBy(x => x).Any(x => x.Count() == 3) && cards.GroupBy(x => x).Any(x => x.Count() == 2))
            return new Hand(cards, HandType.FullHouse, bid);
        
        //ThreeOfAKind
        if (cards.GroupBy(x => x).Any(x => x.Count() == 3))
            return new Hand(cards, HandType.ThreeOfAKind, bid);
        
        //TwoPair
        if(cards.GroupBy(x => x).Count(x => x.Count() == 2) == 2)
            return new Hand(cards, HandType.TwoPair, bid);
        
        //OnePair
        if(cards.GroupBy(x => x).Any(x => x.Count() == 2))
            return new Hand(cards, HandType.OnePair, bid);
        
        //HighCard
        return new Hand(cards, HandType.HighCard, bid);
    }
}