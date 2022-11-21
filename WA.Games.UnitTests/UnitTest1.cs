using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using NUnit.Framework;

namespace WA.Games.UnitTests;

public class BlackJackTests
{

    [Test]
    public void Display_三張牌相同()
    {
        string actual = BlackJack.Display(1, 1, 1);
        
        Assert.AreEqual("BUST", actual);
    }
    
    [TestCase(6,7,8,"21")]
    [TestCase(1,1,2,"4")]
    public void Display_不大於21點_顯示總點數(int card1, int card2, int card3, string expected)
    {
        string actual = BlackJack.Display(card1, card2, card3);
        
        Assert.AreEqual(expected, actual);
    }
    
    [TestCase(7,7,8,"12")]
    public void Display_大於21點_顯示總點數減10(int card1, int card2, int card3, string expected)
    {
        string actual = BlackJack.Display(card1, card2, card3);
        
        Assert.AreEqual(expected, actual);
    }
}



/// <summary>
/// 21 點遊戲
/// </summary>
public class BlackJack
{
    /// <summary>
    /// 顯示結果，三張牌點數相同顯示'BUST', 若總和小於等於21點，顯示總點數，超過21 點則顯示總點數-10
    /// </summary>
    /// <param name="card1"></param>
    /// <param name="card2"></param>
    /// <param name="card3"></param>
    /// <returns></returns>
    public static string Display(int card1, int card2, int card3)
    {
        if (card1 == card2 && card2 == card3) return "BUST";
        int total = card1 + card2 + card3;
        return (total <= 21) ? total.ToString() : (total - 10).ToString();
    }
}


public class SypGameTests
{
    [TestCase("1,2,4,0,0,7,5")]
    [TestCase("1,0,2,4,0,5,7")]
    public void Exists007_has007_ReturnsTrue(string value)
    {
        var numbers = value.Split(',').Select(x => Convert.ToInt32(x));
        bool actual = SpyGame.Exists007(numbers);
        
        Assert.IsTrue(actual);
    }
    
    [TestCase("1,7,2,0,4,5,0")]
    public void Exists007_007notfound_ReturnsFalse(string value)
    {
        var numbers = value.Split(',').Select(x => Convert.ToInt32(x));
        bool actual = SpyGame.Exists007(numbers);
        
        Assert.IsFalse(actual);
    }
}
public class SpyGame
{
    public static bool Exists007(IEnumerable<int> numbers)
    {
        return numbers.Count(x => x == 0) >= 2 && numbers.Any(x => x == 7);
    }
}