using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void Hero_Creation_Working()
    {
        Hero hero = new Hero("Ganio", 5);

        Assert.AreEqual("Ganio", hero.Name);
        Assert.AreEqual(5, hero.Level);
    }

    [Test]
    public void HeroRepository_Creation_Working()
    {
        //Hero hero = new Hero("Ganio", 5);
        HeroRepository heroRepository = new HeroRepository();

        Assert.AreEqual(0, heroRepository.Heroes.Count);
       
    }

    [Test]
    public void HeroRepository_Create_Method_With_Valid_Hero_Working()
    {
        Hero hero = new Hero("Ganio", 5);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero);

        Assert.AreEqual(1, heroRepository.Heroes.Count);

        Hero hero2 = new Hero("Ganio2", 5);
        string result = $"Successfully added hero {hero2.Name} with level {hero2.Level}";

        Assert.AreEqual(result, heroRepository.Create(hero2));

    }

    [Test]
    public void HeroRepository_Create_Method_With_Null_Hero_Throws()
    {
        Hero hero = null;
        HeroRepository heroRepository = new HeroRepository();
        

        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Create(hero);
        });

        //Assert.AreEqual(1, heroRepository.Heroes.Count);

        //Hero hero2 = new Hero("Ganio2", 5);
        //string result = $"Successfully added hero {hero2.Name} with level {hero2.Level}";

        //Assert.AreEqual(result, heroRepository.Create(hero2));

    }

    [Test]
    public void HeroRepository_Create_Method_With_Exising_Hero_Name_Throws()
    {
        Hero hero = new Hero("Ganio2", 5);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero);


        Assert.Throws<InvalidOperationException>(() =>
        {
            heroRepository.Create(hero);
        });

    }

    [Test]
    public void HeroRepository_Remove_Method_With_Empty_Hero_Name_Throws()
    {
        Hero hero = new Hero("", 5);
        HeroRepository heroRepository = new HeroRepository();
        
        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Remove(hero.Name);
        });

    }

    [Test]
    public void HeroRepository_Remove_Method_With_Valid_But_Not_Added_Hero_Name()
    {
        Hero hero = new Hero("Ganio", 5);
        HeroRepository heroRepository = new HeroRepository();

        bool isRemoved = false;

        Assert.AreEqual(isRemoved, heroRepository.Remove(hero.Name));

    }

    [Test]
    public void HeroRepository_Remove_Method_With_Valid_Added_Hero_Name()
    {
        Hero hero = new Hero("Ganio", 5);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero);

        bool isRemoved = true;

        Assert.AreEqual(isRemoved, heroRepository.Remove(hero.Name));

    }

    [Test]
    public void HeroRepository_GetHero_Method_With_Valid_Added_Hero()
    {
        Hero hero = new Hero("Ganio", 5);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero);

        Assert.AreEqual(hero,heroRepository.GetHero(hero.Name));

    }

    [Test]
    public void HeroRepository_GetHero_Method_With_Inexisitng_Hero()
    {
        Hero hero = new Hero("Ganio", 5);
        HeroRepository heroRepository = new HeroRepository();
        

        Assert.AreEqual(null, heroRepository.GetHero(hero.Name));

    }

    [Test]
    public void HeroRepository_GetHeroWithHighestLevel_Method()
    {
        Hero hero = new Hero("Ganio", 5);
        Hero hero2 = new Hero("Ganio2", 6);
        Hero hero3 = new Hero("Ganio3", 7);
        
        HeroRepository heroRepository = new HeroRepository();

        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        heroRepository.Create(hero3);


        Assert.AreEqual(hero3, heroRepository.GetHeroWithHighestLevel());

    }
}