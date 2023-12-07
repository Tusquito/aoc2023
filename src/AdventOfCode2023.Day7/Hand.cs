namespace AdventOfCode2023.Day7;

public record Hand(string Cards, HandType HandType, int Bid) : IComparable<Hand>
{
    public int CompareTo(Hand? other)
    {
        ArgumentNullException.ThrowIfNull(other);

        if (HandType < other.HandType)
            return 1;
        
        if(HandType > other.HandType)
            return -1;
        
        for (int i = 0; i < Constants.HandLength; i++)
        {
            if (Cards[i] == other.Cards[i])
            {
                continue;
            }
                    
            return Constants.DeckCards.IndexOf(Cards[i]) < Constants.DeckCards.IndexOf(other.Cards[i]) ? 1 :-1;
        }
        
        return 0;
    }
}